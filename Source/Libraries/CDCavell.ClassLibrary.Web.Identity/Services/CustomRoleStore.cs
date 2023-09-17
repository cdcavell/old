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
using System.Threading;
using System.Threading.Tasks;

namespace CDCavell.ClassLibrary.Web.Identity.Services
{
    /// <summary>
    /// Custom RoleStore Class
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |~ 
    /// | Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public class CustomRoleStore : IRoleStore<ApplicationRole>, IQueryableRoleStore<ApplicationRole>, IDisposable
    {
        private readonly string _isdBaseUrl;
        private readonly string _apiBaseUrl;
        private readonly string _apiAccessToken;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private Logger _logger;
        private bool _disposedValue;

        /// <value>IQueryable&lt;ApplicationRole&gt;</value>
        public IQueryable<ApplicationRole> Roles
        {
            get 
            {
                try
                {
                    string accessToken = GetAccessToken().Result;

                    JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                    HttpStatusCode statusCode = jsonClient.SendRequest(HttpMethod.Post, "Role/GetRoles", null).Result;
                    if (!jsonClient.IsResponseSuccess)
                    {
                        _logger.Exception(new Exception(jsonClient.GetResponseString()));
                        throw new Exception(jsonClient.GetResponseString());
                    }

                    string jsonString = AESGCM.Decrypt(jsonClient.GetResponseObject<string>(), accessToken);
                    List<ApplicationRole> roles = JsonConvert.DeserializeObject<List<ApplicationRole>>(jsonString);

                    return roles.AsQueryable<ApplicationRole>();
                }
                catch (Exception exception)
                {
                    _logger.Exception(exception);
                    throw;
                }
            }
        }

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="logger">ILogger&lt;CustomRoleStore&gt;</param>
        /// <param name="options">IOptions&lt;CustomRoleStoreOptions&gt;</param>
        /// <param name="httpContextAccessor">HttpContextAccessor</param>
        /// <method>
        /// CustomRoleStore(
        ///    ILogger&lt;CustomRoleStore&gt; logger,
        ///    IOptions&lt;CustomRoleStoreOptions&gt; options,
        ///    IHttpContextAccessor httpContextAccessor
        /// )
        /// </method>
        public CustomRoleStore(
            ILogger<CustomRoleStore> logger, 
            IOptions<CustomRoleStoreOptions> options,
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
        /// Implemented IRoleStore CreateAsync Method
        /// </summary>
        /// <param name="role">ApplicationRole</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;IdentityResult&gt;</returns>
        /// <method>CreateAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))</method>
        public async Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(role, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "Role/Create", encryptString);
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
        /// Implemented IRoleStore DeleteAsync Method
        /// </summary>
        /// <param name="role">ApplicationRole</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;IdentityResult&gt;</returns>
        /// <method>DeleteAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))</method>
        public Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Implemented IRoleStore Method
        /// </summary>
        /// <param name="roleId">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;ApplicationRole&gt;</returns>
        /// <method>FindByIdAsync(string roleId, CancellationToken cancellationToken = default(CancellationToken))</method>
        public async Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(roleId.Clean());
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "Role/FindById", encryptString);
                if (!jsonClient.IsResponseSuccess)
                {
                    _logger.Exception(new Exception(jsonClient.GetResponseString()));
                    throw new Exception(jsonClient.GetResponseString());
                }

                jsonString = AESGCM.Decrypt(jsonClient.GetResponseObject<string>(), accessToken);
                ApplicationRole role = JsonConvert.DeserializeObject<ApplicationRole>(jsonString);

                return role;
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                throw;
            }
        }

        /// <summary>
        /// Implemented IRoleStore FindByNameAsync Method
        /// </summary>
        /// <param name="normalizedRoleName">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;ApplicationRole&gt;</returns>
        /// <method>FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken = default(CancellationToken))</method>
        public async Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(normalizedRoleName.Clean().Trim().ToUpper());
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "Role/FindByNormalizedName", encryptString);
                if (!jsonClient.IsResponseSuccess)
                {
                    _logger.Exception(new Exception(jsonClient.GetResponseString()));
                    throw new Exception(jsonClient.GetResponseString());
                }

                jsonString = AESGCM.Decrypt(jsonClient.GetResponseObject<string>(), accessToken);
                ApplicationRole role = JsonConvert.DeserializeObject<ApplicationRole>(jsonString);

                return role;
            }
            catch (Exception exception)
            {
                _logger.Exception(exception);
                throw;
            }
        }

        /// <summary>
        /// Implemented IRoleStore GetNormalizedRoleNameAsync Method
        /// </summary>
        /// <param name="role">ApplicationRole</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;string&gt;</returns>
        /// <method>GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))</method>
        public Task<string> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(role.NormalizedName ?? role.Name.Trim().ToUpper());
        }

        /// <summary>
        /// Implemented IRoleStore GetRoleIdAsync Method
        /// </summary>
        /// <param name="role">ApplicationRole</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;string&gt;</returns>
        /// <method>GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))</method>
        public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(role.Id);
        }

        /// <summary>
        /// Implemented IRoleStore GetRoleNameAsync Method
        /// </summary>
        /// <param name="role">ApplicationRole</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;string&gt;</returns>
        /// <method>GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))</method>
        public Task<string> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(role.Name ?? string.Empty);
        }

        /// <summary>
        /// Implemented IRoleStore SetNormalizedRoleNameAsync Method
        /// </summary>
        /// <param name="role">ApplicationRole</param>
        /// <param name="normalizedName">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        /// <method>SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken = default(CancellationToken))</method>
        public Task SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken = default(CancellationToken))
        {
            role.NormalizedName = normalizedName.Clean().Trim().ToUpper();
            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented IRoleStore SetRoleNameAsync Method
        /// </summary>
        /// <param name="role">ApplicationRole</param>
        /// <param name="roleName">string</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        /// <method>SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken = default(CancellationToken))</method>
        public Task SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            role.Name = roleName.Clean();
            return Task.FromResult(0);
        }

        /// <summary>
        /// Implemented IRoleStore UpdateAsync Method
        /// </summary>
        /// <param name="role">ApplicationRole</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;IdentityResult&gt;</returns>
        /// <method>UpdateAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))</method>
        public async Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(role, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "Role/Update", encryptString);
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
        /// Custom GetUsersAsync Method
        /// </summary>
        /// <param name="roleId">string</param>
        /// <param name="roleClaimId">int</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;List&lt;ApplicationUser&gt;&gt;</returns>
        /// <method>GetUsersAsync(string roleId, int roleClaimId, CancellationToken cancellationToken = default(CancellationToken))</method>
        public async Task<List<ApplicationUser>> GetUsersAsync(string roleId, int roleClaimId, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(new KeyValuePair<string, int>(roleId.Clean(), roleClaimId));
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "Role/GetUsers", encryptString);
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
        /// Custom GetApprovedUsersAsync Method
        /// </summary>
        /// <param name="roleId">string</param>
        /// <param name="roleClaimId">int</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task&lt;List&lt;ApplicationUser&gt;&gt;</returns>
        /// <method>GetApprovedUsersAsync(string roleId, int roleClaimId, CancellationToken cancellationToken = default(CancellationToken))</method>
        public async Task<List<ApplicationUser>> GetApprovedUsersAsync(string roleId, int roleClaimId, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                string accessToken = await GetAccessToken();
                string jsonString = JsonConvert.SerializeObject(new KeyValuePair<string, int>(roleId.Clean(), roleClaimId));
                string encryptString = AESGCM.Encrypt(jsonString, accessToken);

                JsonClient jsonClient = new JsonClient(_apiBaseUrl, accessToken);
                HttpStatusCode statusCode = await jsonClient.SendRequest(HttpMethod.Post, "Role/GetApprovedUsers", encryptString);
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
        /// Implemented IRoleStore Dispose Method
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
        /// Implemented IRoleStore Dispose Method
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
