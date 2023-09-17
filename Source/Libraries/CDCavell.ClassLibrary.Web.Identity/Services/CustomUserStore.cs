using CDCavell.ClassLibrary.Commons.Logging;
using CDCavell.ClassLibrary.Web.Http;
using CDCavell.ClassLibrary.Web.Identity.Models;
using CDCavell.ClassLibrary.Web.Security;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace CDCavell.ClassLibrary.Web.Identity.Services
{
    /// <summary>
    /// Custom UserStore Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/26/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.1 | 06/06/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class CustomUserStore : IUserStore<ApplicationUser>, 
        IUserLoginStore<ApplicationUser>,
        IUserClaimStore<ApplicationUser>,
        IUserEmailStore<ApplicationUser>,
        IUserTwoFactorStore<ApplicationUser>,
        IDisposable
    {
        private readonly string _isdBaseUrl;
        private readonly string _apiBaseUrl;
        private readonly string _apiAccessToken;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private Logger _logger;
        private bool _disposedValue;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;CustomUserStore&gt;</param>
        /// <param name="options">IOptions&lt;CustomUserStoreOptions&gt;</param>
        /// <param name="httpContextAccessor">HttpContextAccessor</param>
        /// <method>CustomUserStore(
        ///     ILogger&lt;CustomUserStore&gt; logger,
        ///     IOptions&lt;CustomUserStoreOptions&gt; options,
        ///     IHttpContextAccessor httpContextAccessor
        /// ) : base()
        /// </method>
        public CustomUserStore(
            ILogger<CustomUserStore> logger, 
            IOptions<CustomUserStoreOptions> options,
            IHttpContextAccessor httpContextAccessor
        ) : base()
        {
            _logger = new Logger(logger);
            _isdBaseUrl = options.Value.ISDBaseUrl;
            _apiBaseUrl = options.Value.ApiBaseUrl;
            _apiAccessToken = options.Value.ApiAccessToken;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Custom GetRoleClaimHistory Method
        /// </summary>
        /// <param name="userRoleClaimId">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;List&lt;AspNetUserRoleClaimHistory&gt;&gt;</returns>
        /// <method>GetRoleClaimHistory(CancellationToken cancellationToken)</method>
        public async Task<List<AspNetUserRoleClaimHistory>> GetRoleClaimHistory(string userRoleClaimId, CancellationToken cancellationToken)
        {
            try
            {
                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(userRoleClaimId.Clean());
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "User/RoleClaimHistory", encryptString);
                if (!jsonClient.IsResponseSuccess)
                {
                    _logger.Exception(new Exception(jsonClient.GetResponseString()));
                    throw new Exception(jsonClient.GetResponseString());
                }

                jsonString = AESGCM.Decrypt(jsonClient.GetResponseObject<string>(), accessToken);
                List<AspNetUserRoleClaimHistory> history = JsonConvert.DeserializeObject<List<AspNetUserRoleClaimHistory>>(jsonString);

                return history;
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                throw;
            }
        }

        /// <summary>
        /// Custom GetPendingRegistrations Method
        /// </summary>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;List&lt;ApplicationUser&gt;&gt;</returns>
        /// <method>CreateAsync(CancellationToken cancellationToken)</method>
        public async Task<List<ApplicationUser>> GetPendingRegistrations(CancellationToken cancellationToken)
        {
            try
            {
                string accessToken = await GetAccessToken();

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "User/PendingRegistrations");
                if (!jsonClient.IsResponseSuccess)
                {
                    _logger.Exception(new Exception(jsonClient.GetResponseString()));
                    throw new Exception(jsonClient.GetResponseString());
                }

                string jsonString = AESGCM.Decrypt(jsonClient.GetResponseObject<string>(), accessToken);
                List<ApplicationUser> users = JsonConvert.DeserializeObject<List<ApplicationUser>>(jsonString);

                return users;
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                throw;
            }
        }

        /// <summary>
        /// Implemented IUserStore CreateAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;IdentityResult&gt;</returns>
        /// <method>CreateAsync(ApplicationUser user, CancellationToken cancellationToken)</method>
        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            try
            {
                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(user, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "User/Create", encryptString);
                if (!jsonClient.IsResponseSuccess)
                {
                    _logger.Warning(jsonClient.GetResponseString());
                    return IdentityResult.Failed(
                        new IdentityError()
                        {
                            Code = jsonClient.StatusCode.ToString(),
                            Description = jsonClient.GetResponseString()
                        }
                    );
                }
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                return IdentityResult.Failed(
                    new IdentityError
                    {
                        Code = exception.Source,
                        Description = exception.Message
                    }
                );
            }

            return IdentityResult.Success;
        }

        /// <summary>
        /// Implemented IUserStore DeleteAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;IdentityResult&gt;</returns>
        /// <method>DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)</method>
        public async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            try
            {
                if (user.RevokedDate == (DateTime?)DateTime.MinValue)
                    throw new Exception("Missing required revoked date");

                if (string.IsNullOrEmpty(user.RevokedById))
                    throw new Exception("Missing required revoked by");

                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(user);
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "User/Update", encryptString);
                if (!jsonClient.IsResponseSuccess)
                {
                    _logger.Warning(jsonClient.GetResponseString());
                    return IdentityResult.Failed(
                        new IdentityError()
                        {
                            Code = jsonClient.StatusCode.ToString(),
                            Description = jsonClient.GetResponseString()
                        }
                    );
                }
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                return IdentityResult.Failed(
                    new IdentityError
                    {
                        Code = exception.Source,
                        Description = exception.Message
                    }
                );
            }

            return IdentityResult.Success;
        }

        /// <summary>
        /// Implemented IUserStore FindByIdAsync Method
        /// </summary>
        /// <param name="userId">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;ApplicationUser&gt;</returns>
        /// <method>FindByIdAsync(string userId, CancellationToken cancellationToken)</method>
        public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            try
            {
                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(userId.Clean());
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "User/FindById", encryptString);
                if (!jsonClient.IsResponseSuccess)
                {
                    _logger.Exception(new Exception(jsonClient.GetResponseString()));
                    throw new Exception(jsonClient.GetResponseString());
                }

                jsonString = AESGCM.Decrypt(jsonClient.GetResponseObject<string>(), accessToken);
                ApplicationUser user = JsonConvert.DeserializeObject<ApplicationUser>(jsonString);

                return user;
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                throw;
            }
        }

        /// <summary>
        /// Implemented IUserStore FindByNameAsync Method
        /// </summary>
        /// <param name="normalizedUserName">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;ApplicationUser&gt;</returns>
        /// <method>FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)</method>
        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            try
            {
                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(normalizedUserName.Clean().ToUpper());
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "User/FindByNormalizedName", encryptString);
                if (!jsonClient.IsResponseSuccess)
                {
                    _logger.Exception(new Exception(jsonClient.GetResponseString()));
                    throw new Exception(jsonClient.GetResponseString());
                }

                jsonString = AESGCM.Decrypt(jsonClient.GetResponseObject<string>(), accessToken);
                ApplicationUser user = JsonConvert.DeserializeObject<ApplicationUser>(jsonString);

                return user;
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                throw;
            }
        }

        /// <summary>
        /// Implemented IUserStore GetNormalizedUserNameAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;string&gt;</returns>
        /// <method>GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)</method>
        public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName ?? user.UserName.ToUpper());
        }

        /// <summary>
        /// Implemented IUserStore GetUserIdAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;string&gt;</returns>
        /// <method>GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)</method>
        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        /// <summary>
        /// Implemented IUserStore GetUserNameAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;string&gt;</returns>
        /// <method>GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)</method>
        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName ?? string.Empty);
        }

        /// <summary>
        /// Implemented IUserStore SetNormalizedUserNameAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="normalizedName">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        /// <method>SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)</method>
        public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName.Clean().Trim().ToUpper();
            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented IUserStore SetUserNameAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="userName">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        /// <method>SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)</method>
        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName.Clean();
            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented IUserStore UpdateAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;IdentityResult&gt;</returns>
        /// <method>UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)</method>
        public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            try
            {
                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(user, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "User/Update", encryptString);
                if (!jsonClient.IsResponseSuccess)
                {
                    _logger.Warning(jsonClient.GetResponseString());
                    return IdentityResult.Failed(
                        new IdentityError()
                        {
                            Code = jsonClient.StatusCode.ToString(),
                            Description = jsonClient.GetResponseString()
                        }
                    );
                }
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                return IdentityResult.Failed(
                    new IdentityError
                    {
                        Code = exception.Source,
                        Description = exception.Message
                    }
                );
            }

            return IdentityResult.Success;
        }

        /// <summary>
        /// Implemented IUserLoginStore AddLoginAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="login">UserLoginInfo</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        /// <method>AddLoginAsync(ApplicationUser user, UserLoginInfo login, CancellationToken cancellationToken)</method>
        public Task AddLoginAsync(ApplicationUser user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            IdentityUserLogin<string> input = new IdentityUserLogin<string>();
            input.ProviderKey = login.ProviderKey.Clean();
            input.LoginProvider = login.LoginProvider.Clean();
            input.ProviderDisplayName = login.ProviderDisplayName.Clean();
            input.UserId = user.Id;

            user.Logins.Add(input);
            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented IUserLoginStore FindByLoginAsync Method
        /// </summary>
        /// <param name="loginProvider">string</param>
        /// <param name="providerKey">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;ApplicationUser&gt;</returns>
        /// <method>FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)</method>
        public async Task<ApplicationUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            try
            {
                IdentityUserLogin<string> input = new IdentityUserLogin<string>();
                input.LoginProvider = loginProvider.Clean();
                input.ProviderKey = providerKey.Clean();

                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(input);
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "User/FindByLogin", encryptString);
                if (!jsonClient.IsResponseSuccess)
                {
                    _logger.Exception(new Exception(jsonClient.GetResponseString()));
                    throw new Exception(jsonClient.GetResponseString());
                }

                jsonString = AESGCM.Decrypt(jsonClient.GetResponseObject<string>(), accessToken);
                ApplicationUser user = JsonConvert.DeserializeObject<ApplicationUser>(jsonString);

                return user;
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                throw;
            }
        }

        /// <summary>
        /// Implemented IUserLoginStore RemoveLoginAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="loginProvider">string</param>
        /// <param name="providerKey">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        /// <method>RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)</method>
        public Task RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            var logins = user.Logins.Where(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey).ToList();
            foreach (IdentityUserLogin<string> login in logins)
                user.Logins.Remove(login);

            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented IUserLoginStore GetLoginsAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;IList&lt;UserLoginInfo&gt;&gt;</returns>
        /// <method>GetLoginsAsync(ApplicationUser user, CancellationToken cancellationToken)</method>
        public Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            List<UserLoginInfo> userLogins = new List<UserLoginInfo>();
            foreach (IdentityUserLogin<string> login in user.Logins)
                userLogins.Add(new UserLoginInfo(
                    login.LoginProvider, 
                    login.ProviderKey, 
                    login.ProviderDisplayName
                ));

            return Task.FromResult<IList<UserLoginInfo>>(userLogins);
        }


        /// <summary>
        /// Implemented IUserClaimStore GetClaimsAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;IList&lt;Claim&gt;&gt;</returns>
        /// <method>GetClaimsAsync(ApplicationUser user, CancellationToken cancellationToken)</method>
        public Task<IList<Claim>> GetClaimsAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            List<Claim> claims = new List<Claim>();
            foreach (IdentityUserClaim<string> userClaim in user.Claims)
                claims.Add(userClaim.ToClaim());

            return Task.FromResult<IList<Claim>>(claims);
        }

        /// <summary>
        /// Implemented IUserClaimStore AddClaimsAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="claims">IEnumerable&lt;Claim&gt;</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        /// <method>AddClaimsAsync(ApplicationUser user, IEnumerable&lt;Claim&gt; claims, CancellationToken cancellationToken)</method>
        public Task AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            foreach (Claim claim in claims)
            {
                IdentityUserClaim<string> identityUserClaim = new IdentityUserClaim<string>();
                identityUserClaim.UserId = user.Id;
                identityUserClaim.ClaimType = claim.Type;
                identityUserClaim.ClaimValue = claim.Value;

                user.Claims.Add(identityUserClaim);
            }

            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented Custom AddAdditionalClaimsAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="claims">IEnumerable&lt;Claim&gt;</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        /// <method>AddAdditionalClaimsAsync(ApplicationUser user, IEnumerable&lt;Claim&gt; claims, CancellationToken cancellationToken)</method>
        public Task AddAdditionalClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            foreach (Claim claim in claims)
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

            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented IUserClaimStore ReplaceClaimAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="claim">Claim</param>
        /// <param name="newClaim">Claim</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        /// <method>ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)</method>
        public Task ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            var removeClaim = user.Claims.Where(x => x.ClaimType == claim.Type && x.ClaimType == claim.Value).FirstOrDefault();
            if (removeClaim != null)
                user.Claims.Remove(removeClaim);

            IdentityUserClaim<string> identityUserClaim = new IdentityUserClaim<string>();
            identityUserClaim.UserId = user.Id;
            identityUserClaim.ClaimType = newClaim.Type;
            identityUserClaim.ClaimValue = newClaim.Value;

            user.Claims.Add(identityUserClaim);
            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented IUserClaimStore RemoveClaimsAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="claims">IEnumerable&lt;Claim&gt;</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        /// <method>RemoveClaimsAsync(ApplicationUser user, IEnumerable&lt;Claim&gt; claims, CancellationToken cancellationToken)</method>
        public Task RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            foreach (Claim claim in claims)
            {
                var removeClaims = user.Claims.Where(x => x.ClaimType == claim.Type && x.ClaimType == claim.Value);
                foreach (IdentityUserClaim<string> removeClaim in removeClaims)
                    user.Claims.Remove(removeClaim);
            }

            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented IUserClaimStore GetUsersForClaimAsync Method
        /// </summary>
        /// <param name="claim">Claim</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        /// <method>GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)</method>
        public async Task<IList<ApplicationUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            try
            {
                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(claim, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "User/FindByClaim", encryptString);
                if (!jsonClient.IsResponseSuccess)
                {
                    _logger.Exception(new Exception(jsonClient.GetResponseString()));
                    throw new Exception(jsonClient.GetResponseString());
                }

                jsonString = AESGCM.Decrypt(jsonClient.GetResponseObject<string>(), accessToken);
                List<ApplicationUser> users = JsonConvert.DeserializeObject<List<ApplicationUser>>(jsonString);

                return users;
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                throw;
            }
        }

        /// <summary>
        /// Implemented IUserEmailStore SetEmailAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="email">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;string&gt;</returns>
        /// <method>SetEmailAsync(ApplicationUser user, string email, CancellationToken cancellationToken)</method>
        public Task SetEmailAsync(ApplicationUser user, string email, CancellationToken cancellationToken)
        {
            user.Email = email.Clean();
            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented IUserEmailStore GetEmailAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;string&gt;</returns>
        /// <method>GetEmailAsync(ApplicationUser user, CancellationToken cancellationToken)</method>
        public Task<string> GetEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        /// <summary>
        /// Implemented IUserEmailStore GetEmailConfirmedAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;bool&gt;</returns>
        /// <method>GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken)</method>
        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        /// <summary>
        /// Implemented IUserEmailStore SetEmailConfirmedAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="confirmed">bool</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;string&gt;</returns>
        /// <method>SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken)</method>
        public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken)
        {
            user.EmailConfirmed = confirmed;
            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented IUserEmailStore FindByEmailAsync Method
        /// </summary>
        /// <param name="normalizedEmail">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;ApplicationUser&gt;</returns>
        /// <method>FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)</method>
        public async Task<ApplicationUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            try
            {
                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(normalizedEmail.Clean().ToUpper());
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "User/FindByNormalizedEmail", encryptString);
                if (!jsonClient.IsResponseSuccess)
                {
                    _logger.Exception(new Exception(jsonClient.GetResponseString()));
                    throw new Exception(jsonClient.GetResponseString());
                }

                jsonString = AESGCM.Decrypt(jsonClient.GetResponseObject<string>(), accessToken);
                ApplicationUser user = JsonConvert.DeserializeObject<ApplicationUser>(jsonString);

                return user;
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                throw;
            }
        }

        /// <summary>
        /// Implemented IUserEmailStore GetNormalizedEmailAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;string&gt;</returns>
        /// <method>GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken)</method>
        public Task<string> GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedEmail);
        }

        /// <summary>
        /// Implemented IUserEmailStore SetNormalizedEmailAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="normalizedEmail">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;string&gt;</returns>
        /// <method>SetNormalizedEmailAsync(ApplicationUser user, string normalizedEmail, CancellationToken cancellationToken)</method>
        public Task SetNormalizedEmailAsync(ApplicationUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizedEmail = normalizedEmail.Clean().ToUpper();
            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented IUserTwoFactorStore SetTwoFactorEnabledAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="enabled">bool</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        /// <method>SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled, CancellationToken cancellationToken)</method>
        public Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled, CancellationToken cancellationToken)
        {
            user.TwoFactorEnabled = enabled;
            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented IUserTwoFactorStore GetTwoFactorEnabledAsync Method
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;bool&gt;</returns>
        /// <method>GetTwoFactorEnabledAsync(ApplicationUser user, CancellationToken cancellationToken)</method>
        public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }

        private async Task<string> GetAccessToken()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var accessToken = claims.Where(x => x.Type == "access_token").Select(x => x.Value).FirstOrDefault();

            if (!string.IsNullOrEmpty(accessToken))
            {
                return accessToken;
            }
            else
            {
                if (!string.IsNullOrEmpty(_apiAccessToken))
                {
                    // discover endpoints from metadata
                    var client = new HttpClient();
                    var disco = await client.GetDiscoveryDocumentAsync(_isdBaseUrl);
                    if (disco.IsError) throw new Exception(disco.Error);

                    // request from IdentityServer so request token
                    var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                    {
                        Address = disco.TokenEndpoint,
                        ClientId = "ISD5",
                        ClientSecret = _apiAccessToken,

                        Scope = "Authorization.Service.API.Read Authorization.Service.API.Write"
                    });
                    if (tokenResponse.IsError) throw new Exception(tokenResponse.Error);

                    return tokenResponse.AccessToken;
                }
            }

            throw new Exception("Unauthorized");
        }

        /// <summary>
        /// Implemented IUserStore Dispose Method
        /// </summary>
        /// <param name="disposing">bool</param>
        /// <method>Dispose(bool disposing)</method>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CustomRoleStore()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        /// <summary>
        /// Implemented IUserStore Dispose Method
        /// </summary>
        /// <method>Dispose()</method>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }
}
