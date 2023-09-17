
<a name='CDCavell.ClassLibrary.Web.Identity.Authorization.CustomAuthorizeAttribute'></a>

## CDCavell.ClassLibrary.Web.Identity.Authorization.CustomAuthorizeAttribute
CustomAuthorizeAttribute Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/02/2021 | Permission-Based Authorization |


### Methods:
#### CustomAuthorizeAttribute(string Permissions) : base(typeof(CustomAuthorizeFilter))

CustomAuthorizeAttribute method

|Parameters| |
| - | - |
|Permissions|string|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Authorization.CustomAuthorizeFilter'></a>

## CDCavell.ClassLibrary.Web.Identity.Authorization.CustomAuthorizeFilter
CustomAuthorizeFilter Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/10/2021 | Permission-Based Authorization |


### Methods:
#### CustomAuthorizeFilter( ILogger<CustomAuthorizeFilter> logger, IAppSettingsService appSettings, UserManager<ApplicationUser> userManager, List<string> permissions )

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<CustomAuthorizeFilter>|
|appSettings|IAppSettingsService|
|userManager|UserManager<ApplicationUser>|
|permissions|List<string>|
## 
#### OnAuthorization(AuthorizationFilterContext context)

OnAuthorization method

|Parameters| |
| - | - |
|context|AuthorizationFilterContext|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Extensions.CustomIdentityServerBuilder'></a>

## CDCavell.ClassLibrary.Web.Identity.Extensions.CustomIdentityServerBuilder
CustomIdentityServerBuilder Options Extension

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/25/2021 | Integrate ASP.NET Core Identity |


### Methods:
#### AddCustomUserStore(this IServiceCollection serviceCollection, Action<CustomUserStoreOptions> options)

Add CustomUserStore Options Extention

|Parameters| |
| - | - |
|serviceCollection|IServiceCollection|
|options|Action<CustomUserStoreOptions>|
## 
#### AddCustomRoleStore(this IServiceCollection serviceCollection, Action<CustomRoleStoreOptions> options)

Add CustomRoleStore Options Extention

|Parameters| |
| - | - |
|serviceCollection|IServiceCollection|
|options|Action<CustomRoleStoreOptions>|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Models.ApplicationRole'></a>

## CDCavell.ClassLibrary.Web.Identity.Models.ApplicationRole
Instance of Microsoft IdentityRole Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
|Id|string|
|RoleClaims|ICollection<ApplicationRoleClaim>|
||Role|
||string|
||string|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Models.ApplicationRoleClaim'></a>

## CDCavell.ClassLibrary.Web.Identity.Models.ApplicationRoleClaim
Instance of Microsoft IdentityRoleClaim Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/05/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
|Role|Role|
|NormalizedClaimType|string|
|NormalizedClaimValue|string|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Models.ApplicationUser'></a>

## CDCavell.ClassLibrary.Web.Identity.Models.ApplicationUser
Instance of Microsoft IdentityUser Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/25/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/10/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/19/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
|Id|string|
|FirstName|string|
|LastName|string|
|RequestDate|DateTime?|
|ApprovedDate|DateTime?|
|ApprovedById|string|
|ApprovedBy|ApplicationUser|
|RevokedDate|DateTime?|
|RevokedById|string|
|RevokedBy|ApplicationUser|
|Claims|ICollection<IdentityUserClaim<string>>|
|Logins|ICollection<IdentityUserLogin<string>>|
|Tokens|ICollection<IdentityUserToken<string>>|
|RoleClaims|ICollection<IdentityUserRole<string>>|
|FullName|string|
|IsSysAdmin|bool|
|IsActive|bool|
|IsPending|bool|
|IsRevoked|bool|
|Status|string|
||ApplicationRole|

### Methods:
#### HasRoleClaim(System.String)

Validate if user has RoleClaim

|Parameters| |
| - | - |
|roleClaims|string|

#### Returns:
bool 
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Models.ApplicationUserRole'></a>

## CDCavell.ClassLibrary.Web.Identity.Models.ApplicationUserRole
Instance of Microsoft IdentityUserRole Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/06/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
|Role|ApplicationRole|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Models.AspNetUserRoleClaim'></a>

## CDCavell.ClassLibrary.Web.Identity.Models.AspNetUserRoleClaim
Instance of Microsoft IdentityUserRoleClaim Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |


|Fields| |
| - | - |
|RoleClaimStatus.Requested|0|
|RoleClaimStatus.Approved|1|
|RoleClaimStatus.Retired|2|
|RoleClaimStatus.Rejected|3|

|Properties| |
| - | - |
|Id|string|
|UserId|string|
|User|ApplicationUser|
|RoleId|string|
|Role|ApplicationRole|
|RoleClaimId|int|
|RoleClaim|ApplicationRoleClaim|
|Status|RoleClaimStatus|
|History|AspNetUserRoleClaimHistory|
||string|
||string|
||UserRoleClaim|
||DateTime|
||string|
||ApplicationUser|
||RoleClaimStatus|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Models.AspNetUserRoleClaim.RoleClaimStatus'></a>

## CDCavell.ClassLibrary.Web.Identity.Models.AspNetUserRoleClaim.RoleClaimStatus




|Fields| |
| - | - |
|Requested|0|
|Approved|1|
|Retired|2|
|Rejected|3|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Models.AspNetUserRoleClaimHistory'></a>

## CDCavell.ClassLibrary.Web.Identity.Models.AspNetUserRoleClaimHistory
Custom UserRoleClaimHistory Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
|Id|string|
|UserRoleClaimId|string|
|UserRoleClaim|UserRoleClaim|
|ActionOn|DateTime|
|ActionById|string|
|ActionBy|ApplicationUser|
|Status|RoleClaimStatus|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Services.CustomRoleManager'></a>

## CDCavell.ClassLibrary.Web.Identity.Services.CustomRoleManager
Custom UserManager Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |


### Methods:
#### CustomUserManager( IRoleStore<ApplicationRole> store, IEnumerable<IRoleValidator<ApplicationRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<CustomRoleManager> logger ) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)

Constructor method

|Parameters| |
| - | - |
|store|IRoleStore<ApplicationRole>|
|roleValidators|IEnumerable<IRoleValidator<ApplicationRole>>|
|keyNormalizer|ILookupNormalizer|
|errors|IdentityErrorDescriber|
|logger|ILogger<CustomRoleManager>|
## 
#### GetUsersAsync(string roleId, int roleClaimId)

Custom GetUsersAsync Method

|Parameters| |
| - | - |
|roleId|string|
|roleClaimId|int|

#### Returns:
Task<List<ApplicationUser>> 
## 
#### GetApprovedUsersAsync(string roleId, int roleClaimId)

Custom GetApprovedUsersAsync Method

|Parameters| |
| - | - |
|roleId|string|
|roleClaimId|int|

#### Returns:
Task<List<ApplicationUser>> 
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Services.CustomRoleStore'></a>

## CDCavell.ClassLibrary.Web.Identity.Services.CustomRoleStore
Custom RoleStore Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
|Roles|IQueryable<ApplicationRole>|
||string|
||string|
||string|

### Methods:
#### CustomRoleStore( ILogger<CustomRoleStore> logger, IOptions<CustomRoleStoreOptions> options, IHttpContextAccessor httpContextAccessor )

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<CustomRoleStore>|
|options|IOptions<CustomRoleStoreOptions>|
|httpContextAccessor|HttpContextAccessor|
## 
#### CreateAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))

Implemented IRoleStore CreateAsync Method

|Parameters| |
| - | - |
|role|ApplicationRole|
|cancellationToken|CancellationToken|

#### Returns:
Task<IdentityResult> 
## 
#### DeleteAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))

Implemented IRoleStore DeleteAsync Method

|Parameters| |
| - | - |
|role|ApplicationRole|
|cancellationToken|CancellationToken|

#### Returns:
Task<IdentityResult> 
## 
#### FindByIdAsync(string roleId, CancellationToken cancellationToken = default(CancellationToken))

Implemented IRoleStore Method

|Parameters| |
| - | - |
|roleId|string|
|cancellationToken|CancellationToken|

#### Returns:
Task<ApplicationRole> 
## 
#### FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken = default(CancellationToken))

Implemented IRoleStore FindByNameAsync Method

|Parameters| |
| - | - |
|normalizedRoleName|string|
|cancellationToken|CancellationToken|

#### Returns:
Task<ApplicationRole> 
## 
#### GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))

Implemented IRoleStore GetNormalizedRoleNameAsync Method

|Parameters| |
| - | - |
|role|ApplicationRole|
|cancellationToken|CancellationToken|

#### Returns:
Task<string> 
## 
#### GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))

Implemented IRoleStore GetRoleIdAsync Method

|Parameters| |
| - | - |
|role|ApplicationRole|
|cancellationToken|CancellationToken|

#### Returns:
Task<string> 
## 
#### GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))

Implemented IRoleStore GetRoleNameAsync Method

|Parameters| |
| - | - |
|role|ApplicationRole|
|cancellationToken|CancellationToken|

#### Returns:
Task<string> 
## 
#### SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken = default(CancellationToken))

Implemented IRoleStore SetNormalizedRoleNameAsync Method

|Parameters| |
| - | - |
|role|ApplicationRole|
|normalizedName|string|
|cancellationToken|CancellationToken|

#### Returns:
Task 
## 
#### SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken = default(CancellationToken))

Implemented IRoleStore SetRoleNameAsync Method

|Parameters| |
| - | - |
|role|ApplicationRole|
|roleName|string|
|cancellationToken|CancellationToken|

#### Returns:
Task 
## 
#### UpdateAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))

Implemented IRoleStore UpdateAsync Method

|Parameters| |
| - | - |
|role|ApplicationRole|
|cancellationToken|CancellationToken|

#### Returns:
Task<IdentityResult> 
## 
#### GetUsersAsync(string roleId, int roleClaimId, CancellationToken cancellationToken = default(CancellationToken))

Custom GetUsersAsync Method

|Parameters| |
| - | - |
|roleId|string|
|roleClaimId|int|
|cancellationToken|CancellationToken|

#### Returns:
Task<List<ApplicationUser>> 
## 
#### GetApprovedUsersAsync(string roleId, int roleClaimId, CancellationToken cancellationToken = default(CancellationToken))

Custom GetApprovedUsersAsync Method

|Parameters| |
| - | - |
|roleId|string|
|roleClaimId|int|
|cancellationToken|CancellationToken|

#### Returns:
Task<List<ApplicationUser>> 
## 
#### Dispose(bool disposing)

Implemented IRoleStore Dispose Method

|Parameters| |
| - | - |
|disposing|bool|
## 
#### Dispose()

Implemented IRoleStore Dispose Method
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Services.CustomRoleStoreOptions'></a>

## CDCavell.ClassLibrary.Web.Identity.Services.CustomRoleStoreOptions
CustomRoleStore Service Options

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |


|Properties| |
| - | - |
|ISDBaseUrl|string|
|ApiBaseUrl|string|
|ApiAccessToken|string|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Services.CustomUserManager'></a>

## CDCavell.ClassLibrary.Web.Identity.Services.CustomUserManager
Custom UserManager Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/25/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 03/30/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/12/2021 | Permission-Based Authorization |


### Methods:
#### CustomUserManager( IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<CustomUserManager> logger ) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)

Constructor method

|Parameters| |
| - | - |
|store|IUserStore<ApplicationUser>|
|optionsAccessor|IOptions<ApplicationUser>|
|passwordHasher|IPasswordHasher<ApplicationUser>|
|userValidators|IEnumerable<IUserValidator<ApplicationUser>>|
|passwordValidators|IEnumerable<IPasswordValidator<ApplicationUser>>|
|keyNormalizer|ILookupNormalizer|
|errors|IdentityErrorDescriber|
|services|IServiceProvider|
|logger|ILogger<CustomUserManager>|
## 
#### GetPendingRegistrations())

CustomUserStore GetPendingRegistrations Method

#### Returns:
Task<List<ApplicationUser>> 
## 
#### GetRoleClaimHistory(string userRoleClaimId))

CustomUserStore GetRoleClaimHistory Method

#### Returns:
Task<List<AspNetUserRoleClaimHistory>> 
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Services.CustomUserStore'></a>

## CDCavell.ClassLibrary.Web.Identity.Services.CustomUserStore
Custom UserStore Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/26/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.1 | 06/06/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
||string|
||string|
||string|

### Methods:
#### CustomUserStore( ILogger<CustomUserStore> logger, IOptions<CustomUserStoreOptions> options, IHttpContextAccessor httpContextAccessor ) : base()

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<CustomUserStore>|
|options|IOptions<CustomUserStoreOptions>|
|httpContextAccessor|HttpContextAccessor|
## 
#### GetRoleClaimHistory(CancellationToken cancellationToken)

Custom GetRoleClaimHistory Method

|Parameters| |
| - | - |
|userRoleClaimId|string|
|cancellationToken|CancellationToken|

#### Returns:
Task<List<AspNetUserRoleClaimHistory>> 
## 
#### CreateAsync(CancellationToken cancellationToken)

Custom GetPendingRegistrations Method

|Parameters| |
| - | - |
|cancellationToken|CancellationToken|

#### Returns:
Task<List<ApplicationUser>> 
## 
#### CreateAsync(ApplicationUser user, CancellationToken cancellationToken)

Implemented IUserStore CreateAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|cancellationToken|CancellationToken|

#### Returns:
Task<IdentityResult> 
## 
#### DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)

Implemented IUserStore DeleteAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|cancellationToken|CancellationToken|

#### Returns:
Task<IdentityResult> 
## 
#### FindByIdAsync(string userId, CancellationToken cancellationToken)

Implemented IUserStore FindByIdAsync Method

|Parameters| |
| - | - |
|userId|string|
|cancellationToken|CancellationToken|

#### Returns:
Task<ApplicationUser> 
## 
#### FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)

Implemented IUserStore FindByNameAsync Method

|Parameters| |
| - | - |
|normalizedUserName|string|
|cancellationToken|CancellationToken|

#### Returns:
Task<ApplicationUser> 
## 
#### GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)

Implemented IUserStore GetNormalizedUserNameAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|cancellationToken|CancellationToken|

#### Returns:
Task<string> 
## 
#### GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)

Implemented IUserStore GetUserIdAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|cancellationToken|CancellationToken|

#### Returns:
Task<string> 
## 
#### GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)

Implemented IUserStore GetUserNameAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|cancellationToken|CancellationToken|

#### Returns:
Task<string> 
## 
#### SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)

Implemented IUserStore SetNormalizedUserNameAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|normalizedName|string|
|cancellationToken|CancellationToken|

#### Returns:
Task 
## 
#### SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)

Implemented IUserStore SetUserNameAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|userName|string|
|cancellationToken|CancellationToken|

#### Returns:
Task 
## 
#### UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)

Implemented IUserStore UpdateAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|cancellationToken|CancellationToken|

#### Returns:
Task<IdentityResult> 
## 
#### AddLoginAsync(ApplicationUser user, UserLoginInfo login, CancellationToken cancellationToken)

Implemented IUserLoginStore AddLoginAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|login|UserLoginInfo|
|cancellationToken|CancellationToken|

#### Returns:
Task 
## 
#### FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)

Implemented IUserLoginStore FindByLoginAsync Method

|Parameters| |
| - | - |
|loginProvider|string|
|providerKey|string|
|cancellationToken|CancellationToken|

#### Returns:
Task<ApplicationUser> 
## 
#### RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)

Implemented IUserLoginStore RemoveLoginAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|loginProvider|string|
|providerKey|string|
|cancellationToken|CancellationToken|

#### Returns:
Task 
## 
#### GetLoginsAsync(ApplicationUser user, CancellationToken cancellationToken)

Implemented IUserLoginStore GetLoginsAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|cancellationToken|CancellationToken|

#### Returns:
Task<IList<UserLoginInfo>> 
## 
#### GetClaimsAsync(ApplicationUser user, CancellationToken cancellationToken)

Implemented IUserClaimStore GetClaimsAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|cancellationToken|CancellationToken|

#### Returns:
Task<IList<Claim>> 
## 
#### AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)

Implemented IUserClaimStore AddClaimsAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|claims|IEnumerable<Claim>|
|cancellationToken|CancellationToken|

#### Returns:
Task 
## 
#### AddAdditionalClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)

Implemented Custom AddAdditionalClaimsAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|claims|IEnumerable<Claim>|
|cancellationToken|CancellationToken|

#### Returns:
Task 
## 
#### ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)

Implemented IUserClaimStore ReplaceClaimAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|claim|Claim|
|newClaim|Claim|
|cancellationToken|CancellationToken|

#### Returns:
Task 
## 
#### RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)

Implemented IUserClaimStore RemoveClaimsAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|claims|IEnumerable<Claim>|
|cancellationToken|CancellationToken|

#### Returns:
Task 
## 
#### GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)

Implemented IUserClaimStore GetUsersForClaimAsync Method

|Parameters| |
| - | - |
|claim|Claim|
|cancellationToken|CancellationToken|

#### Returns:
Task 
## 
#### SetEmailAsync(ApplicationUser user, string email, CancellationToken cancellationToken)

Implemented IUserEmailStore SetEmailAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|email|string|
|cancellationToken|CancellationToken|

#### Returns:
Task<string> 
## 
#### GetEmailAsync(ApplicationUser user, CancellationToken cancellationToken)

Implemented IUserEmailStore GetEmailAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|cancellationToken|CancellationToken|

#### Returns:
Task<string> 
## 
#### GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken)

Implemented IUserEmailStore GetEmailConfirmedAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|cancellationToken|CancellationToken|

#### Returns:
Task<bool> 
## 
#### SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken)

Implemented IUserEmailStore SetEmailConfirmedAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|confirmed|bool|
|cancellationToken|CancellationToken|

#### Returns:
Task<string> 
## 
#### FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)

Implemented IUserEmailStore FindByEmailAsync Method

|Parameters| |
| - | - |
|normalizedEmail|string|
|cancellationToken|CancellationToken|

#### Returns:
Task<ApplicationUser> 
## 
#### GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken)

Implemented IUserEmailStore GetNormalizedEmailAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|cancellationToken|CancellationToken|

#### Returns:
Task<string> 
## 
#### SetNormalizedEmailAsync(ApplicationUser user, string normalizedEmail, CancellationToken cancellationToken)

Implemented IUserEmailStore SetNormalizedEmailAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|normalizedEmail|string|
|cancellationToken|CancellationToken|

#### Returns:
Task<string> 
## 
#### SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled, CancellationToken cancellationToken)

Implemented IUserTwoFactorStore SetTwoFactorEnabledAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|enabled|bool|
|cancellationToken|CancellationToken|

#### Returns:
Task 
## 
#### GetTwoFactorEnabledAsync(ApplicationUser user, CancellationToken cancellationToken)

Implemented IUserTwoFactorStore GetTwoFactorEnabledAsync Method

|Parameters| |
| - | - |
|user|ApplicationUser|
|cancellationToken|CancellationToken|

#### Returns:
Task<bool> 
## 
#### Dispose(bool disposing)

Implemented IUserStore Dispose Method

|Parameters| |
| - | - |
|disposing|bool|
## 
#### Dispose()

Implemented IUserStore Dispose Method
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Identity.Services.CustomUserStoreOptions'></a>

## CDCavell.ClassLibrary.Web.Identity.Services.CustomUserStoreOptions
CustomUserStore Service Options

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/24/2021 | Integrate ASP.NET Core Identity |


|Properties| |
| - | - |
|ISDBaseUrl|string|
|ApiBaseUrl|string|
|ApiAccessToken|string|


( [Home](Home) )

