﻿using dis5_cdcavell.Models.AppSettings;
using dis5_cdcavell.Models.Consent;
using dis5_cdcavell.Options;
using Duende.IdentityServer;
using Duende.IdentityServer.Events;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Validation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dis5_cdcavell.Controllers
{
    /// <summary>
    /// Consent Controller
    /// &lt;br /&gt;&lt;br /&gt;
    /// Copyright (c) Duende Software. All rights reserved.
    /// See https://duendesoftware.com/license/identityserver.pdf for license information. 
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |~ 
    /// | Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |~ 
    /// </revision>
    public class ConsentController : ApplicationBaseController<ConsentController>
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IEventService _events;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;AccountController&gt;</param>
        /// <param name="webHostEnvironment">IWebHostEnvironment</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        /// <param name="interaction">IIdentityServerInteractionService</param>
        /// <param name="events">IEventService</param>
        /// <param name="appSettings">AppSettings</param>
        /// <method>
        /// ConsentController(
        ///     ILogger&lt;ConsentController&gt; logger, 
        ///     IWebHostEnvironment webHostEnvironment, 
        ///     IHttpContextAccessor httpContextAccessor, 
        ///     IIdentityServerInteractionService interaction,
        ///     IEventService events,
        ///     AppSettings appSettings
        /// ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)
        /// </method>
        public ConsentController(
            ILogger<ConsentController> logger,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            IIdentityServerInteractionService interaction,
            IEventService events,
            AppSettings appSettings
        ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)
        {
            _interaction = interaction;
            _events = events;
        }

        /// <summary>
        /// Shows the consent screen
        /// </summary>
        /// <param name="returnUrl">string</param>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Index(string returnUrl)</method>
        [HttpGet]
        public async Task<IActionResult> Index(string returnUrl)
        {
            var vm = await BuildViewModelAsync(returnUrl);
            if (vm != null)
            {
                return View("Index", vm);
            }

            return View("Error");
        }

        /// <summary>
        /// Handles the consent screen postback
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;</returns>
        /// <method>Index(ConsentInputModel model)</method>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ConsentInputModel model)
        {
            var result = await ProcessConsent(model);

            if (result.IsRedirect)
            {
                var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
                if (context?.IsNativeClient() == true)
                {
                    // The client is native, so this change in how to
                    // return the response is for better UX for the end user.
                    return this.LoadingPage("Redirect", result.RedirectUri);
                }

                return Redirect(result.RedirectUri);
            }

            if (result.HasValidationError)
            {
                ModelState.AddModelError(string.Empty, result.ValidationError);
            }

            if (result.ShowView)
            {
                return View("Index", result.ViewModel);
            }

            return View("Error");
        }

        /*****************************************/
        /* helper APIs for the ConsentController */
        /*****************************************/
        private async Task<ProcessConsentResult> ProcessConsent(ConsentInputModel model)
        {
            var result = new ProcessConsentResult();

            // validate return url is still valid
            var request = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
            if (request == null) return result;

            ConsentResponse grantedConsent = null;

            // user clicked 'no' - send back the standard 'access_denied' response
            if (model?.Button == "no")
            {
                grantedConsent = new ConsentResponse { Error = AuthorizationError.AccessDenied };

                // emit event
                await _events.RaiseAsync(new ConsentDeniedEvent(User.GetSubjectId(), request.Client.ClientId, request.ValidatedResources.RawScopeValues));
            }
            // user clicked 'yes' - validate the data
            else if (model?.Button == "yes")
            {
                // if the user consented to some scope, build the response model
                if (model.ScopesConsented != null && model.ScopesConsented.Any())
                {
                    var scopes = model.ScopesConsented;
                    if (ConsentOptions.EnableOfflineAccess == false)
                    {
                        scopes = scopes.Where(x => x != IdentityServerConstants.StandardScopes.OfflineAccess);
                    }

                    grantedConsent = new ConsentResponse
                    {
                        RememberConsent = model.RememberConsent,
                        ScopesValuesConsented = scopes.ToArray(),
                        Description = model.Description
                    };

                    // emit event
                    await _events.RaiseAsync(new ConsentGrantedEvent(User.GetSubjectId(), request.Client.ClientId, request.ValidatedResources.RawScopeValues, grantedConsent.ScopesValuesConsented, grantedConsent.RememberConsent));
                }
                else
                {
                    result.ValidationError = ConsentOptions.MustChooseOneErrorMessage;
                }
            }
            else
            {
                result.ValidationError = ConsentOptions.InvalidSelectionErrorMessage;
            }

            if (grantedConsent != null)
            {
                // communicate outcome of consent back to identityserver
                await _interaction.GrantConsentAsync(request, grantedConsent);

                // indicate that's it ok to redirect back to authorization endpoint
                result.RedirectUri = model.ReturnUrl;
                result.Client = request.Client;
            }
            else
            {
                // we need to redisplay the consent UI
                result.ViewModel = await BuildViewModelAsync(model.ReturnUrl, model);
            }

            return result;
        }

        private async Task<ConsentViewModel> BuildViewModelAsync(string returnUrl, ConsentInputModel model = null)
        {
            var request = await _interaction.GetAuthorizationContextAsync(returnUrl);
            if (request != null)
            {
                return CreateConsentViewModel(model, returnUrl, request);
            }
            else
            {
                _logger.Warning($"No consent request matching request: {returnUrl}");
            }

            return null;
        }

        private ConsentViewModel CreateConsentViewModel(
            ConsentInputModel model, string returnUrl,
            AuthorizationRequest request)
        {
            var vm = new ConsentViewModel
            {
                RememberConsent = model?.RememberConsent ?? true,
                ScopesConsented = model?.ScopesConsented ?? Enumerable.Empty<string>(),
                Description = model?.Description,

                ReturnUrl = returnUrl,

                ClientName = request.Client.ClientName ?? request.Client.ClientId,
                ClientUrl = request.Client.ClientUri,
                ClientLogoUrl = request.Client.LogoUri,
                AllowRememberConsent = request.Client.AllowRememberConsent
            };

            vm.IdentityScopes = request.ValidatedResources.Resources.IdentityResources.Select(x => CreateScopeViewModel(x, vm.ScopesConsented.Contains(x.Name) || model == null)).ToArray();

            var apiScopes = new List<ScopeViewModel>();
            foreach (var parsedScope in request.ValidatedResources.ParsedScopes)
            {
                var apiScope = request.ValidatedResources.Resources.FindApiScope(parsedScope.ParsedName);
                if (apiScope != null)
                {
                    var scopeVm = CreateScopeViewModel(parsedScope, apiScope, vm.ScopesConsented.Contains(parsedScope.RawValue) || model == null);
                    apiScopes.Add(scopeVm);
                }
            }
            if (ConsentOptions.EnableOfflineAccess && request.ValidatedResources.Resources.OfflineAccess)
            {
                apiScopes.Add(GetOfflineAccessScope(vm.ScopesConsented.Contains(IdentityServerConstants.StandardScopes.OfflineAccess) || model == null));
            }
            vm.ApiScopes = apiScopes;

            return vm;
        }

        private ScopeViewModel CreateScopeViewModel(IdentityResource identity, bool check)
        {
            return new ScopeViewModel
            {
                Value = identity.Name,
                DisplayName = identity.DisplayName ?? identity.Name,
                Description = identity.Description,
                Emphasize = identity.Emphasize,
                Required = identity.Required,
                Checked = check || identity.Required
            };
        }

        /// <summary>
        /// Create scope view model
        /// </summary>
        /// <returns>ScopeViewModel</returns>
        /// <method>CreateScopeViewModel(ParsedScopeValue parsedScopeValue, ApiScope apiScope, bool check)</method>
        public ScopeViewModel CreateScopeViewModel(ParsedScopeValue parsedScopeValue, ApiScope apiScope, bool check)
        {
            var displayName = apiScope.DisplayName ?? apiScope.Name;
            if (!String.IsNullOrWhiteSpace(parsedScopeValue.ParsedParameter))
            {
                displayName += ":" + parsedScopeValue.ParsedParameter;
            }

            return new ScopeViewModel
            {
                Value = parsedScopeValue.RawValue,
                DisplayName = displayName,
                Description = apiScope.Description,
                Emphasize = apiScope.Emphasize,
                Required = apiScope.Required,
                Checked = check || apiScope.Required
            };
        }

        private ScopeViewModel GetOfflineAccessScope(bool check)
        {
            return new ScopeViewModel
            {
                Value = IdentityServerConstants.StandardScopes.OfflineAccess,
                DisplayName = ConsentOptions.OfflineAccessDisplayName,
                Description = ConsentOptions.OfflineAccessDescription,
                Emphasize = true,
                Checked = check
            };
        }
    }
}
