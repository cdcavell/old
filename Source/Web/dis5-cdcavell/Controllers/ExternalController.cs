using CDCavell.ClassLibrary.Web.Identity.Models;
using dis5_cdcavell.Models.AppSettings;
using dis5_cdcavell.Models.TwoFactor;
using Duende.IdentityServer;
using Duende.IdentityServer.Events;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dis5_cdcavell.Controllers
{
    /// <summary>
    /// External Controller
    /// &lt;br /&gt;&lt;br /&gt;
    /// Copyright (c) Duende Software. All rights reserved.
    /// See https://duendesoftware.com/license/identityserver.pdf for license information. 
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |~ 
    /// | Christopher D. Cavell | 1.0.4.3 | 03/21/2021 | 2FA using TOTP |~ 
    /// | Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/06/2021 | Permission-Based Authorization |~ 
    /// </revision>
    [AllowAnonymous]
    public class ExternalController : ApplicationBaseController<ExternalController>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IEventService _events;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;ExternalController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="interaction">IIdentityServerInteractionService</param>
        /// <param name="clientStore">IClientStore</param>
        /// <param name="events">IEventService</param>
        /// <param name="signInManager">SignInManager&lt;ApplicationUser&gt;</param>
        /// <param name="userManager">UserManager&lt;ApplicationUser&gt;</param>
        /// <param name="appSettings">AppSettings</param>
        /// <method>
        /// AccountController(
        ///     ILogger&lt;ExternalController&gt; logger, 
        ///     IWebHostEnvironment webHostEnvironment, 
        ///     IHttpContextAccessor httpContextAccessor
        ///     IIdentityServerInteractionService interaction,
        ///     IClientStore clientStore,
        ///     IEventService events,
        ///     SignInManager&lt;ApplicationUser&gt; signInManager,
        ///     UserManager&lt;ApplicationUser&gt; userManager,
        ///     AppSettings appSettings
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)
        /// </method>
        public ExternalController(
            ILogger<ExternalController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IEventService events,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            AppSettings appSettings
        ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _clientStore = clientStore;
            _events = events;
        }

        /// <summary>
        /// initiate roundtrip to external authentication provider
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <method>Challenge(string scheme, string returnUrl)</method>
        /// <exception cref="Exception">invalid return URL</exception>
        [HttpGet]
        public IActionResult Challenge(string scheme, string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl)) returnUrl = _appSettings.Application.MainSiteUrlTrim;

            // validate returnUrl - either it is a valid OIDC URL or back to a local page
            if (Url.IsLocalUrl(returnUrl) == false && _interaction.IsValidReturnUrl(returnUrl) == false)
            {
                // user might have clicked on a malicious link - should be logged
                throw new Exception("invalid return URL");
            }

            // start challenge and roundtrip the return URL and scheme 
            var props = new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(Callback)),
                Items =
                {
                    { "returnUrl", returnUrl },
                    { "scheme", scheme },
                }
            };

            return Challenge(props, scheme);
        }

        /// <summary>
        /// Post processing of external authentication
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Callback()</method>
        /// <exception cref="Exception">External authentication error</exception>
        [HttpGet]
        public async Task<IActionResult> Callback()
        {
            // read external identity from the temporary cookie
            var result = await HttpContext.AuthenticateAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);
            if (result?.Succeeded != true)
            {
                _logger.Exception(result.Failure);
                string errMsg = "External authentication error - " + result.Failure.Message;
                errMsg += (result.Failure.InnerException != null) ? (" - " + result.Failure.InnerException.Message) : string.Empty;

                throw new HttpRequestException(
                        CDCavell.ClassLibrary.Web.Html.StatusCodes.ToString(401),
                        new Exception(errMsg),
                        HttpStatusCode.Unauthorized
                    );
            }

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                var externalClaims = result.Principal.Claims.Select(c => $"{c.Type}: {c.Value}");
                _logger.Debug($"External claims: {externalClaims}");
            }

            // lookup our user and external provider info
            var (user, provider, providerUserId, claims) = await FindUserFromExternalProviderAsync(result);
            if (user == null)
            {
                // this might be where you might initiate a custom workflow for user registration
                // in this sample we don't show how that would be done, as our sample implementation
                // simply auto-provisions new external user
                user = await AutoProvisionUserAsync(provider, providerUserId, claims);
            }

            // validate email address
            if (!user.EmailConfirmed)
            {
                // delete temporary cookie used during external authentication
                await HttpContext.SignOutAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);

                TempData["Email"] = user.Email;
                return RedirectToAction("Index", "Registration");
            }

            if (user.TwoFactorEnabled)
            {
                TwoFactorValidateModel model = new TwoFactorValidateModel();
                model.Email = user.Email;
                model.Provider = provider;
                model.ProviderUserId = providerUserId;
                model.ReturnUrl = result.Properties.Items["returnUrl"];

                // if the external system sent a session id claim, copy it over
                // so we can use it for single sign-out
                var sid = result.Principal.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.SessionId);
                if (sid != null)
                {
                    model.SessionId = sid.Value;
                }

                // if the external provider issued an id_token, we'll keep it for signout
                var idToken = result.Properties.GetTokenValue("id_token");
                if (idToken != null)
                {
                    model.AuthenticationToken = idToken;
                }

                TempData["TwoFactorValidateModel"] = JsonConvert.SerializeObject(model);
                return RedirectToAction("Validate", "TwoFactor");
            }

            // this allows us to collect any additional claims or properties
            // for the specific protocols used and store them in the local auth cookie.
            // this is typically used to store data needed for signout from those protocols.
            var additionalLocalClaims = new List<Claim>();
            var localSignInProps = new AuthenticationProperties();
            ProcessLoginCallback(result, additionalLocalClaims, localSignInProps);

            // issue authentication cookie for user
            // we must issue the cookie maually, and can't use the SignInManager because
            // it doesn't expose an API to issue additional claims from the login workflow
            var principal = await _signInManager.CreateUserPrincipalAsync(user);
            additionalLocalClaims.AddRange(principal.Claims);
            var name = user.FullName; //principal.FindFirst(JwtClaimTypes.Name)?.Value ?? user.Id;

            var isuser = new IdentityServerUser(user.Id)
            {
                DisplayName = name,
                IdentityProvider = provider,
                AdditionalClaims = additionalLocalClaims
            };

            await HttpContext.SignInAsync(isuser, localSignInProps);

            // delete temporary cookie used during external authentication
            await HttpContext.SignOutAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);

            // retrieve return URL
            var returnUrl = result.Properties.Items["returnUrl"] ?? "~/";

            // check if external login is in the context of an OIDC request
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            await _events.RaiseAsync(new UserLoginSuccessEvent(provider, providerUserId, user.Id, name, true, context?.Client.ClientId));

            if (context != null)
            {
                if (context.IsNativeClient())
                {
                    // The client is native, so this change in how to
                    // return the response is for better UX for the end user.
                    return this.LoadingPage("Redirect", returnUrl);
                }
            }

            return Redirect(returnUrl);
        }

        private async Task<(ApplicationUser user, string provider, string providerUserId, IEnumerable<Claim> claims)>
            FindUserFromExternalProviderAsync(AuthenticateResult result)
        {
            var externalUser = result.Principal;

            // try to determine the unique id of the external user (issued by the provider)
            // the most common claim type for that are the sub claim and the NameIdentifier
            // depending on the external provider, some other claim type might be used
            var userIdClaim = externalUser.FindFirst(JwtClaimTypes.Subject) ??
                              externalUser.FindFirst(ClaimTypes.NameIdentifier) ??
                              throw new Exception("Unknown userid");

            // remove the user id claim so we don't include it as an extra claim if/when we provision the user
            var claims = externalUser.Claims.ToList();
            claims.Remove(userIdClaim);

            var provider = result.Properties.Items["scheme"];
            var providerUserId = userIdClaim.Value;

            // find external user
            var user = await _userManager.FindByLoginAsync(provider, providerUserId);

            return (user, provider, providerUserId, claims);
        }

        private async Task<ApplicationUser> AutoProvisionUserAsync(string provider, string providerUserId, IEnumerable<Claim> claims)
        {
            // create a list of claims that we want to transfer into our store
            var filtered = new List<Claim>();

            // user's display name
            var name = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Name)?.Value ??
                claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            if (name != null)
            {
                filtered.Add(new Claim(JwtClaimTypes.Name, name));
            }
            else
            {
                var first = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.GivenName)?.Value ??
                    claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value;
                var last = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.FamilyName)?.Value ??
                    claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value;
                if (first != null && last != null)
                {
                    filtered.Add(new Claim(JwtClaimTypes.Name, first + " " + last));
                }
                else if (first != null)
                {
                    filtered.Add(new Claim(JwtClaimTypes.Name, first));
                }
                else if (last != null)
                {
                    filtered.Add(new Claim(JwtClaimTypes.Name, last));
                }
            }

            // email
            var email = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Email)?.Value ??
               claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            if (email != null)
            {
                filtered.Add(new Claim(JwtClaimTypes.Email, email));
            }
            else
            {
                throw new Exception("Missing required email claim");
            }

            // setup results
            var identityResult = new IdentityResult();

            // check to make sure user dose not exist under diffrent external login
            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                // no, so create user
                user = new ApplicationUser
                {
                    Email = email,
                    UserName = email,
                    NormalizedEmail = email.Trim().ToUpper(),
                    NormalizedUserName = email.Trim().ToUpper()
                };

                identityResult = await _userManager.CreateAsync(user);
                if (!identityResult.Succeeded) throw new Exception(identityResult.Errors.First().Description);

                // get created user
                user = await _userManager.FindByEmailAsync(email);
                if (user == null) throw new Exception($"User not found for {email}");

                if (filtered.Any())
                {
                    identityResult = await _userManager.AddClaimsAsync(user, filtered);
                    if (!identityResult.Succeeded) throw new Exception(identityResult.Errors.First().Description);
                }

                identityResult = await _userManager.AddLoginAsync(user, new UserLoginInfo(provider, providerUserId, provider));
                if (!identityResult.Succeeded) throw new Exception(identityResult.Errors.First().Description);
            }
            else 
            {
                // yes, so update existing user claims
                if (filtered.Any())
                {
                    foreach (Claim claim in filtered)
                    {
                        var foundClaim = user.Claims.Where(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value).FirstOrDefault();
                        if (foundClaim == null)
                        {
                            IdentityUserClaim<string> identityUserClaim = new IdentityUserClaim<string>();
                            identityUserClaim.UserId = user.Id;
                            identityUserClaim.ClaimType = claim.Type;
                            identityUserClaim.ClaimValue = claim.Value;

                            user.Claims.Add(identityUserClaim);
                        }
                    }

                    var userLogin = ((List<UserLoginInfo>)await _userManager.GetLoginsAsync(user))
                        .Where(x => x.LoginProvider == provider && x.ProviderKey == providerUserId)
                        .FirstOrDefault();
                    if (userLogin == null)
                    {
                        identityResult = await _userManager.AddLoginAsync(user, new UserLoginInfo(provider, providerUserId, provider));
                        if (!identityResult.Succeeded) throw new Exception(identityResult.Errors.First().Description);
                    }

                    identityResult = await _userManager.UpdateAsync(user);
                    if (!identityResult.Succeeded) throw new Exception(identityResult.Errors.First().Description);
                }
            }

            return user;
        }

        // if the external login is OIDC-based, there are certain things we need to preserve to make logout work
        // this will be different for WS-Fed, SAML2p or other protocols
        private void ProcessLoginCallback(AuthenticateResult externalResult, List<Claim> localClaims, AuthenticationProperties localSignInProps)
        {
            // if the external system sent a session id claim, copy it over
            // so we can use it for single sign-out
            var sid = externalResult.Principal.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.SessionId);
            if (sid != null)
            {
                localClaims.Add(new Claim(JwtClaimTypes.SessionId, sid.Value));
            }

            // if the external provider issued an id_token, we'll keep it for signout
            var idToken = externalResult.Properties.GetTokenValue("id_token");
            if (idToken != null)
            {
                localSignInProps.StoreTokens(new[] { new AuthenticationToken { Name = "id_token", Value = idToken } });
            }
        }
    }
}
