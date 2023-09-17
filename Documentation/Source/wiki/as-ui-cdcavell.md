
<a name='as_ui_cdcavell.Controllers.AccountController'></a>

## as_ui_cdcavell.Controllers.AccountController
Account Controller

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 02/04/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Utilize Redis Cache - Not implemented |
| Christopher D. Cavell | 1.0.3.1 | 02/08/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.0.3.3 | 03/07/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/12/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.2.0 | 07/08/2021 | SignalR streaming |
| Christopher D. Cavell | 1.1.2.0 | 07/21/2021 | Migrate to AWS Lightsail |


### Methods:
#### AccountController( ILogger<AccountController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings, CustomUserManager userManager, CustomRoleManager roleManager ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<AccountController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|userManager|CustomUserManager|
|appSettings|AppSettings|
|roleManager|CustomRoleManager|
## 
#### Login()

Login method

#### Returns:
IActionResult 
## 
#### ValidateCaptchaToken(string captchaToken)

Validate returned captcha token

|Parameters| |
| - | - |
|captchaToken|string|

#### Returns:
Task<IActionResult> 
## 
#### Logout()

Logout method

#### Returns:
Task<IActionResult> 
## 
#### FrontChannelLogout(string sid)

Front Channel SLO Logout method <br /><br /> https://andersonnjen.com/2019/03/22/identityserver4-global-logout/

#### Returns:
Task<IActionResult> 
## 

( [Home](Home) )


<a name='as_ui_cdcavell.Controllers.ApplicationBaseController'></a>

## as_ui_cdcavell.Controllers.ApplicationBaseController
Base controller class for application

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 02/01/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Utilize Redis Cache |
| Christopher D. Cavell | 1.0.3.3 | 03/07/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/12/2021 | Permission-Based Authorization |


|Fields| |
| - | - |
|_userManager|CustomUserManager|
|_roleManager|CustomRoleManager|
|_appSettings|AppSettings|

### Methods:
#### ApplicationBaseController( ILogger<T> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings, CustomUserManager userManager CutomRoleManager RoleManager ) : base(logger, webHostEnvironment, httpContextAccessor)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|appSettings|AppSettings|
|userManager|CustomUserManager|
|roleManager|CustomRoleManager|
## 

( [Home](Home) )


<a name='as_ui_cdcavell.Controllers.HomeController'></a>

## as_ui_cdcavell.Controllers.HomeController
Home Controller

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/12/2021 | Permission-Based Authorization |


### Methods:
#### HomeController( ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings, CustomUserManager userManager, CustomRoleManager roleManager ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<HomeController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|userManager|CustomUserManager|
|appSettings|AppSettings|
|roleManager|CustomRoleManager|
## 

( [Home](Home) )


<a name='as_ui_cdcavell.Controllers.RegistrationController'></a>

## as_ui_cdcavell.Controllers.RegistrationController
Registration Controller

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.1 | 06/07/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/19/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |


### Methods:
#### RegistrationController( ILogger<RegistrationController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings, CustomUserManager userManager, CustomRoleManager roleManager ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<RegistrationController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|userManager|CustomUserManager|
|roleManager|CustomRoleManager|
|appSettings|AppSettings|
## 
#### Status()

Registration Status HttpGet method

#### Returns:
Task<IActionResult> 
## 
#### Update()

Update Registration HttpGet method

#### Returns:
Task<IActionResult> 
## 
#### Update(RegistrationIndexModel model)

Update Registration HttpPost method

#### Returns:
Task<IActionResult> 
## 
#### Administration()

Registration Administration HttpGet method

#### Returns:
Task<IActionResult> 
## 
#### Administration(AdministrationModel model)

Administration HttpPost method

|Parameters| |
| - | - |
|model|AdministrationModel|

#### Returns:
Task<IActionResult> 
## 
#### RoleClaim(AdministrationModel model)

RoleClaim HttpPost method

|Parameters| |
| - | - |
|model|AdministrationModel|

#### Returns:
Task<IActionResult> 
## 

( [Home](Home) )


<a name='as_ui_cdcavell.Controllers.RoleClaimsController'></a>

## as_ui_cdcavell.Controllers.RoleClaimsController
RoleClaims Controller

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/12/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.3 | 06/30/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |


### Methods:
#### RoleClaimsController( ILogger<RoleClaimsController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings, CustomUserManager userManager, CustomRoleManager roleManager ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<RoleClaimsController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|userManager|CustomUserManager|
|roleManager|CustomRoleManager|
|appSettings|AppSettings|
## 
#### Index()

RoleClaims HttpGet View method

#### Returns:
IActionResult 
## 
#### Disable()

RoleClaims HttpGet Disable View method

|Parameters| |
| - | - |
|role|string|
|claim|int|

#### Returns:
Task<IActionResult> 
## 
#### Enable()

RoleClaims HttpGet Enable View method

|Parameters| |
| - | - |
|role|string|
|claim|int|

#### Returns:
Task<IActionResult> 
## 
#### Users()

RoleClaims HttpGet Users View method

|Parameters| |
| - | - |
|role|string|
|claim|int|

#### Returns:
Task<IActionResult> 
## 
#### RevokeClaim(ViewModel model)

RoleClaims HttpPost RevokeClaim method

|Parameters| |
| - | - |
|model|ViewModel|

#### Returns:
Task<IActionResult> 
## 

( [Home](Home) )


<a name='as_ui_cdcavell.Controllers.TwoFactorController'></a>

## as_ui_cdcavell.Controllers.TwoFactorController
Two-Factor Controller

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/12/2021 | Permission-Based Authorization |


### Methods:
#### TwoFactorController( ILogger<TwoFactorController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings, CustomUserManager userManager, CustomRoleManager roleManager ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings, userManager, roleManager)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<TwoFactorController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|userManager|CustomUserManager|
|roleManager|CustomRoleManager|
|appSettings|AppSettings|
## 
#### Disable()

TwoFactor Authentication Disable

#### Returns:
Task<IActionResult> 
## 
#### Enable()

TwoFactor Authentication Enable

#### Returns:
Task<IActionResult> 
## 

( [Home](Home) )


<a name='as_ui_cdcavell.Filters.SecurityHeadersAttribute'></a>

## as_ui_cdcavell.Filters.SecurityHeadersAttribute
Security Headers Attribute Filter from Brock Allen & Dominick Baier. <br /><br /> Copyright (c) Brock Allen & Dominick Baier. All rights reserved. Licensed under the Apache License, Version 2.0.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 02/04/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.3 | 03/09/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.1.1.2 | 06/15/2021 | New IHtmlHelper Extension Gravatar |
| Christopher D. Cavell | 1.1.1.2 | 06/19/2021 | Update CSP Image Source |
| Christopher D. Cavell | 1.1.1.5 | 07/04/2021 | Microsoft Clarity |
| Christopher D. Cavell | 1.1.2.0 | 07/23/2021 | Migrate to AWS Lightsail |


### Methods:
#### SecurityHeadersAttribute(AppSettings appSettings)

Constructor method

|Parameters| |
| - | - |
|appSettings|AppSettings|
## 
#### OnResultExecuting(ResultExecutingContext context)

Executes before result execution <br /><br /> CSP Evaluator: https://csp-evaluator.appspot.com/

|Parameters| |
| - | - |
|context|ResultExecutingContext|
## 
#### OnActionExecuted(ActionExecutedContext context)

Executes after action method execution to set script nonce

|Parameters| |
| - | - |
|context|ActionExecutedContext|
## 

( [Home](Home) )


<a name='as_ui_cdcavell.Models.Account.CaptchaResponse'></a>

## as_ui_cdcavell.Models.Account.CaptchaResponse
Captcha response model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/30/2021 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |


|Properties| |
| - | - |
|success|bool|
|challenge_ts|DateTime|
|hostname|string|
|score|double|
|action|string|
|ErrorCodes|object[]|


( [Home](Home) )


<a name='as_ui_cdcavell.Models.AppSettings'></a>

## as_ui_cdcavell.Models.AppSettings
AppSettings model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/30/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Web Service |


|Properties| |
| - | - |
|Application|Application|


( [Home](Home) )


<a name='as_ui_cdcavell.Models.Registration.AdministrationModel'></a>

## as_ui_cdcavell.Models.Registration.AdministrationModel
Administration Model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.1 | 06/07/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.2 | 06/19/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
|Action|string|
|Id|string|
|PendingRegistrations|List<ApplicationUser>|
|SearchModel|SearchModel|
|Roles|List<ApplicationRole>|
|RoleId|string|
|ClaimId|int|


( [Home](Home) )


<a name='as_ui_cdcavell.Models.Registration.SearchModel'></a>

## as_ui_cdcavell.Models.Registration.SearchModel
Administration Model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.2 | 06/19/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
|SearchRequest|string|
|SearchResult|SearchResultModel|


( [Home](Home) )


<a name='as_ui_cdcavell.Models.Registration.SearchResultModel'></a>

## as_ui_cdcavell.Models.Registration.SearchResultModel
Search Result Model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.2 | 06/19/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.4 | 07/03/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
|UserId|string|
|Email|string|
|FirstName|string|
|LastName|string|
|RequestDate|DateTime?|
|FullName|string|
|Status|string|
|IsSelf|bool|
|IsSysAdmin|bool|
|IsActive|bool|
|IsPending|bool|
|IsRevoked|bool|
|TwoFactorEnabled|bool|
|RoleClaims|List<AspNetUserRoleClaim>|


( [Home](Home) )


<a name='as_ui_cdcavell.Models.Registration.StatusModel'></a>

## as_ui_cdcavell.Models.Registration.StatusModel
Status Model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/04/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.1 | 06/05/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
|Email|string|
|FirstName|string|
|LastName|string|
|RequestDate|DateTime?|
|Status|string|
|TwoFactorEnabled|bool|
|RoleClaims|List<AspNetUserRoleClaim>|


( [Home](Home) )


<a name='as_ui_cdcavell.Models.RoleClaims.ViewModel'></a>

## as_ui_cdcavell.Models.RoleClaims.ViewModel
View Model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.1.3 | 06/30/2021 | Permission-Based Authorization |


|Properties| |
| - | - |
|Roles|List<ApplicationRole>|
|Users|List<ApplicationUser>|
|RoleDescription|string|
|RoleId|string|
|ClaimDescription|string|
|ClaimId|string|
|RevokeId|string|


( [Home](Home) )


<a name='as_ui_cdcavell.Program'></a>

## as_ui_cdcavell.Program
Entry point class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/30/2021 | Initial build Initial build Authorization Service |
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


<a name='as_ui_cdcavell.Startup'></a>

## as_ui_cdcavell.Startup
The Startup class configures services and the application's request pipeline<br /><br /> _Services_ are components that are used by the app. For example, a logging component is a service. Code to configure (_or register_) services is added to the ```Startup.ConfigureServices``` method.<br /><br /> The request handling pipeline is composed as a series of _middleware_ components. For example, a middleware might handle requests for static files or redirect HTTP requests to HTTPS. Each middleware performs asynchronous operations on an ```HttpContext``` and then either invokes the next middleware in the pipeline or terminates the request. Code to configure the request handling pipeline is added to the ```Startup.Configure``` method.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 02/06/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Utilize Redis Cache - Not implemented |
| Christopher D. Cavell | 1.0.3.3 | 03/09/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.0.4.2 | 03/16/2021 | Email verification |
| Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/09/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.2.0 | 07/08/2021 | SignalR streaming |
| Christopher D. Cavell | 1.1.2.0 | 07/21/2021 | Migrate to AWS Lightsail |


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
#### Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger, IHostApplicationLifetime lifetime)

This required method gets called by the runtime. Use this method to configure the HTTP request pipeline.

|Parameters| |
| - | - |
|app|IApplicationBuilder|
|env|IWebHostEnvironment|
|logger|ILogger<Startup>|
|lifetime|IHostApplicationLifetime|
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

