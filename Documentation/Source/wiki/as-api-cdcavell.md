
<a name='as_api_cdcavell.Authorization.ReadHandler'></a>

## as_api_cdcavell.Authorization.ReadHandler
Read Handler

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/31/2020 | Initial build Authorization Service |
| Christopher D. Cavell | 1.1.0.0 | 03/24/2021 | Integrate ASP.NET Core Identity |


### Methods:
#### ReadHandler()

Constructor method
## 
#### HandleRequirementAsync(AuthorizationHandlerContext context, ReadRequirement requirement)

Handle Requirement method

|Parameters| |
| - | - |
|context|AuthorizationHandlerContext|
|requirement|AuthenticatedRequirement|

#### Returns:
Task 
## 

( [Home](Home) )


<a name='as_api_cdcavell.Authorization.ReadRequirement'></a>

## as_api_cdcavell.Authorization.ReadRequirement
Read Access Requirement

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/30/2021 | Initial build Authorization Service |


|Properties| |
| - | - |
|Authorized|bool|

### Methods:
#### ReadRequirement(bool isAuthorized)

Constructor method

|Parameters| |
| - | - |
|isAuthorized|bool|
## 

( [Home](Home) )


<a name='as_api_cdcavell.Authorization.WriteHandler'></a>

## as_api_cdcavell.Authorization.WriteHandler
Write Handler

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/31/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.1.0.0 | 03/24/2021 | Integrate ASP.NET Core Identity |


### Methods:
#### WriteHandler()

Constructor method
## 
#### HandleRequirementAsync(AuthorizationHandlerContext context, WriteRequirement requirement)

Handle Requirement method

|Parameters| |
| - | - |
|context|AuthorizationHandlerContext|
|requirement|AuthenticatedRequirement|

#### Returns:
Task 
## 

( [Home](Home) )


<a name='as_api_cdcavell.Authorization.WriteRequirement'></a>

## as_api_cdcavell.Authorization.WriteRequirement
Write Access Requirement

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/30/2021 | Initial build Authorization Service |


|Properties| |
| - | - |
|Authorized|bool|

### Methods:
#### WriteRequirement(bool isAuthorized)

Constructor method

|Parameters| |
| - | - |
|isAuthorized|bool|
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.ApplicationBaseController'></a>

## as_api_cdcavell.Controllers.ApplicationBaseController
Base controller class for application

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/18/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |


|Fields| |
| - | - |
|_appSettings|AppSettings|
|_dbContext|AuthorizationServiceDbContext|
|_authorizationService|IAuthorizationService|

### Methods:
#### ApplicationBaseController( ILogger<T> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext )

Constructor method

|Parameters| |
| - | - |
|logger|ILogger|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.DateTimeController'></a>

## as_api_cdcavell.Controllers.DateTimeController
Current date time controller class for application

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/19/2021 | Initial build Authorization Service |


### Methods:
#### public DateTimeController( ILogger<DateTimeController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Get

Get action method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.Role.CreateController'></a>

## as_api_cdcavell.Controllers.Role.CreateController
Identity Role CreateAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |


### Methods:
#### public CreateController( ILogger<CreateController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<CreateController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

Create Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.Role.FindByIdController'></a>

## as_api_cdcavell.Controllers.Role.FindByIdController
Identity Role FindByIdAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |


### Methods:
#### public FindByIdController( ILogger<FindByIdController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<FindByIdController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

FindById Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.Role.FindByNormalizedNameController'></a>

## as_api_cdcavell.Controllers.Role.FindByNormalizedNameController
Identity Role FindByNormalizedNameAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |


### Methods:
#### public FindByNormalizedNameController( ILogger<FindByNormalizedNameController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<FindByNormalizedNameController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

FindByNormalizedName Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.Role.GetApprovedUsersController'></a>

## as_api_cdcavell.Controllers.Role.GetApprovedUsersController
Custom GetApprovedUsersAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |


### Methods:
#### public GetApprovedUsersController( ILogger<GetApprovedUsersController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<GetApprovedUsersController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

GetActiveUsers Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.Role.GetRolesController'></a>

## as_api_cdcavell.Controllers.Role.GetRolesController
Identity Role Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |


### Methods:
#### public GetRolesController( ILogger<GetRolesController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<GetRolesController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post

GetRoles Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.Role.GetUsersController'></a>

## as_api_cdcavell.Controllers.Role.GetUsersController
Identity Role GetUsersAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |


### Methods:
#### public GetUsersController( ILogger<GetUsersController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<GetUsersController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

GetUsers Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.Role.UpdateController'></a>

## as_api_cdcavell.Controllers.Role.UpdateController
Identity Role UpdateAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/27/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/06/2021 | Permission-Based Authorization |


### Methods:
#### public UpdateController( ILogger<UpdateController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<UpdateController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

Update Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.User.CreateController'></a>

## as_api_cdcavell.Controllers.User.CreateController
Identity User CreateAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/24/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/06/2021 | Permission-Based Authorization |


### Methods:
#### public CreateController( ILogger<CreateController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<CreateController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

Create Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.User.FindByClaimController'></a>

## as_api_cdcavell.Controllers.User.FindByClaimController
Identity User FindByClaimAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/26/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/10/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.1 | 06/06/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.3 | 06/27/2021 | ASP.NET Core 6.0 Preview |


### Methods:
#### public FindByClaimController( ILogger<FindByClaimController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<FindByClaimController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

FindByClaim Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.User.FindByIdController'></a>

## as_api_cdcavell.Controllers.User.FindByIdController
Identity User FindByIdAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/25/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/10/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.1 | 06/06/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.3 | 06/27/2021 | ASP.NET Core 6.0 Preview |


### Methods:
#### public FindByIdController( ILogger<FindByIdController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<FindByIdController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

FindById Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.User.FindByLoginController'></a>

## as_api_cdcavell.Controllers.User.FindByLoginController
Identity User FindByLoginAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/25/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/10/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.1 | 06/06/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.3 | 06/27/2021 | ASP.NET Core 6.0 Preview |


### Methods:
#### public FindByLoginController( ILogger<FindByLoginController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<FindByLoginController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

FindByLogin Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.User.FindByNameController'></a>

## as_api_cdcavell.Controllers.User.FindByNameController
Identity User FindByNameAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/25/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/10/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.1 | 06/06/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.3 | 06/27/2021 | ASP.NET Core 6.0 Preview |


### Methods:
#### public FindByNameController( ILogger<FindByNameController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<FindByNameController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

FindByName Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.User.FindByNormalizedEmailController'></a>

## as_api_cdcavell.Controllers.User.FindByNormalizedEmailController
Identity User FindByNormalizedEmailAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/26/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/10/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.1 | 06/06/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.3 | 06/27/2021 | ASP.NET Core 6.0 Preview |


### Methods:
#### public FindByNormalizedEmailController( ILogger<FindByNormalizedEmailController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<FindByNormalizedEmailController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

FindByNormalizedEmail Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.User.FindByNormalizedNameController'></a>

## as_api_cdcavell.Controllers.User.FindByNormalizedNameController
Identity User FindByNormalizedNameAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/26/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/10/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.1 | 06/06/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.3 | 06/27/2021 | ASP.NET Core 6.0 Preview |


### Methods:
#### public FindByNormalizedNameController( ILogger<FindByNormalizedNameController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<FindByNormalizedNameController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

FindByNormalizedName Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.User.PendingRegistrationsController'></a>

## as_api_cdcavell.Controllers.User.PendingRegistrationsController
Custom PendingRegistrations Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.1 | 06/06/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.3 | 06/27/2021 | ASP.NET Core 6.0 Preview |


### Methods:
#### public PendingRegistrationsController( ILogger<PendingRegistrationController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<PendingRegistrationController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post

PendingRegistrations Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.User.RoleClaimHistoryController'></a>

## as_api_cdcavell.Controllers.User.RoleClaimHistoryController
Custom RoleClaimHistory Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.1 | 06/06/2021 | Permission-Based Authorization |


### Methods:
#### public RoleClaimHistoryController( ILogger<RoleClaimHistoryController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<RoleClaimHistoryController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

RoleClaimHistory Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Controllers.User.UpdateController'></a>

## as_api_cdcavell.Controllers.User.UpdateController
Identity User UpdateAsync Controller Class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/27/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/06/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/13/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.3 | 06/27/2021 | ASP.NET Core 6.0 Preview |
| Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |


### Methods:
#### public UpdateController( ILogger<UpdateController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, AppSettings appSettings, AuthorizationServiceDbContext dbContext ) : base(logger, webHostEnvironment, httpContextAccessor, authorizationService, appSettings, dbContext)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<UpdateController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|authorizationService|IAuthorizationService|
|appSettings|AppSettings|
|dbContext|AuthorizationServiceDbContext|
## 
#### Post(System.Object)

Update Post Method
## 

( [Home](Home) )


<a name='as_api_cdcavell.Data.AuditEntry'></a>

## as_api_cdcavell.Data.AuditEntry
CDCavell AuditEntry record

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/18/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.1.1.0 | 04/05/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
|Entry|EntityEntry|
|TableName|string|
|State|string|
|Application|string|
|ModifiedBy|string|
|ModifiedOn|DateTime|
|KeyValues|Dictionary<string, object>|
|OriginalValues|Dictionary<string, object>|
|CurrentValues|Dictionary<string, object>|
|TemporaryProperties|List<PropertyEntry>|
|HasTemporaryProperties|bool|

### Methods:
#### AuditEntry(EntityEntry entry)

Constructor method

|Parameters| |
| - | - |
|entry|EntityEntry|
## 
#### ToAuditHistory()

Audit History record to write
## 

( [Home](Home) )


<a name='as_api_cdcavell.Data.AuditHistory'></a>

## as_api_cdcavell.Data.AuditHistory
Authorization Service AuditHistory Entity

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/18/2021 | Initial build Authorization Service |


|Properties| |
| - | - |
|Id|long|
|ModifiedBy|string|
|ModifiedOn|DateTime?|
|Application|string|
|Entity|string|
|State|string|
|KeyValues|string|
|OriginalValues|string|
|CurrentValues|string|


( [Home](Home) )


<a name='as_api_cdcavell.Data.AuthorizationServiceDbContext'></a>

## as_api_cdcavell.Data.AuthorizationServiceDbContext
Authorization Service Database Context

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/20/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.1 | 06/06/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
|AuditHistory|DbSet<AuditHistory>|
|UserRoleClaims|DbSet<AspNetUserRoleClaims>|
|UserRoleClaimHistory|DbSet<AspNetUserRoleClaimHistory>|

### Methods:
#### CDCavellDdContext(ILogger<CDCavellDbContext> logger, IHttpContextAccessor httpContextAccessor, DbContextOptions<AuthorizationServiceDbContext> options) : base(options)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<CDCavellDbContext>|
|httpContextAccessor|IHttpContextAccessor|
|options|DbContextOptions|
## 
#### OnModelCreating(ModelBuilder builder)

OnModelCreating method

|Parameters| |
| - | - |
|builder|ModelBuilder|
## 
#### HasUnsavedChanges()

Checks for any unsaved INSERT, UPDATE, DELETE history.

#### Returns:
bool 
## 
#### SaveChanges(bool acceptAllChangesOnSuccess = true)

Override to record all the data change history in a table named ```Audit```, this table contains INSERT, UPDATE, DELETE history.

#### Returns:
int 
## 
#### SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))

Override to record all the data change history in a table named ```Audit```, this table contains INSERT, UPDATE, DELETE history.

|Parameters| |
| - | - |
|cancellationToken|CancellationToken|

#### Returns:
Task<int> 
## 
#### OnBeforeSaveChanges(string userId)

Save audit entities that have all the modifications and return list of entries where the value of some properties are unknown at this step. <br/><br/> https://www.meziantou.net/entity-framework-core-history-audit-table.htm

#### Returns:
List<AuditEntry> 
## 
#### OnAfterSaveChanges(List<AuditEntry> auditEntries)

Save audit entities where the value of some properties were unknown at previous step. <br/><br/> https://www.meziantou.net/entity-framework-core-history-audit-table.htm
## 
#### OnAfterSaveChangesAsync(List<AuditEntry> auditEntries)

Save audit entities where the value of some properties were unknown at previous step. <br/><br/> https://www.meziantou.net/entity-framework-core-history-audit-table.htm
## 
#### RemoveAuditRecords()

Remove audit records greater than 7 days old
## 

( [Home](Home) )


<a name='.DataModel<T>'></a>

## .DataModel<T>
Authorization Service DataModel base class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/20/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.3 | 02/27/2021 | User Authorization Service |


|Properties| |
| - | - |
|Id|long|
|IsNew|bool|

### Methods:
#### AddUpdate(CDCavellDbContext dbContext)

Add/Update record
## 
#### Delete(AuthorizationServiceDbContext dbContext)

Delete record

|Parameters| |
| - | - |
|dbContext||
## 
#### Equals(DataModel<T> obj)

Equate method

|Parameters| |
| - | - |
|obj|T|

#### Returns:
bool 
## 

( [Home](Home) )


<a name='as_api_cdcavell.Data.DbInitializer'></a>

## as_api_cdcavell.Data.DbInitializer
Authorization Service Database Initializer

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/21/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.3 | 03/09/2021 | User Authorization Service |
| Christopher D. Cavell | 1.0.4.2 | 03/16/2021 | Email verification |
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |


### Methods:
#### Initialize(MigrateDdContext context)

Initialize method <br /> To Initialize: dotnet ef migrations add InitialCreate <br /> To Update: dotnet ef migrations add UpdateDatabase_<<YYYY-MM-DD>> <br /><br /> EF Core tools reference: https://docs.microsoft.com/en-us/ef/core/cli/dotnet <br /> Install EF Core Tools: dotnet tool install --global dotnet-ef <br /> Upgrade EF Core Tools: dotnet tool update --global dotnet-ef <br /><br /> _Before you can use the tools on a specific project, you'll need to add the `Microsoft.EntityFrameworkCore.Design` package to it._

|Parameters| |
| - | - |
|context|AuthorizationServiceDbContext|
|siteAdministrator|SiteAdministrator|
## 

( [Home](Home) )


<a name='.IDataModel<T>'></a>

## .IDataModel<T>
DataModel Interface

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/20/2021 | Initial build Authorization Service |


|Properties| |
| - | - |
|Id|long|
|IsNew|bool|

### Methods:
#### AddUpdate(CDCavellDbContext dbContext)

Add/Update method

|Parameters| |
| - | - |
|dbContext|CDCavellDbContext|
## 
#### Equals(T obj)

Equate method

|Parameters| |
| - | - |
|obj|T|

#### Returns:
bool 
## 

( [Home](Home) )


<a name='as_api_cdcavell.Models.AppSettings'></a>

## as_api_cdcavell.Models.AppSettings
AppSettings model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/18/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Service |



( [Home](Home) )


<a name='as_api_cdcavell.Program'></a>

## as_api_cdcavell.Program
Entry point class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/18/2021 | Initial build Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Add ApplicationInsights |


### Methods:
#### Main(string[] args)

Entry point method

|Parameters| |
| - | - |
|args|string[]|
## 
#### CreateHostBuilder(string[] args)

Host Builder configuration

|Parameters| |
| - | - |
|args|string[]|

#### Returns:
IHostBuilder 
## 

( [Home](Home) )


<a name='as_api_cdcavell.Startup'></a>

## as_api_cdcavell.Startup
The Startup class configures services and the application's request pipeline<br /><br /> _Services_ are components that are used by the app. For example, a logging component is a service. Code to configure (_or register_) services is added to the ```Startup.ConfigureServices``` method.<br /><br /> The request handling pipeline is composed as a series of _middleware_ components. For example, a middleware might handle requests for static files or redirect HTTP requests to HTTPS. Each middleware performs asynchronous operations on an ```HttpContext``` and then either invokes the next middleware in the pipeline or terminates the request. Code to configure the request handling pipeline is added to the ```Startup.Configure``` method.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 02/06/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Utilize Redis Cache - Not implemented |
| Christopher D. Cavell | 1.0.3.3 | 03/09/2021 | User Authorization Service |
| Christopher D. Cavell | 1.1.0.0 | 03/24/2021 | Integrate ASP.NET Core Identity |


### Methods:
#### Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)

Class Constructor

|Parameters| |
| - | - |
|configuration|IConfiguration|
|webHostEnvironment|IWebHostEnvironment|
## 
#### ConfigureServices(IServiceCollection services)

This optional method gets called by the runtime. Use this method to add services to the container.

|Parameters| |
| - | - |
|services|IServiceCollection|
## 
#### Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger, IHostApplicationLifetime lifetime, AuthorizationServiceDbContext dbContext)

This required method gets called by the runtime. Use this method to configure the HTTP request pipeline.

|Parameters| |
| - | - |
|app|IApplicationBuilder|
|env|IWebHostEnvironment|
|logger|ILogger<Startup>|
|lifetime|IHostApplicationLifetime|
|dbContext|AuthorizationServiceDbContext|
## 
#### OnAppStarted()

Exposed IApplicationLifetime interface method.
## 
#### OnAppStopping()

Exposed IApplicationLifetime interface method.
## 
#### OnAppStopped()

Exposed IApplicationLifetime interface method.
## 

( [Home](Home) )

