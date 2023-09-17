
<a name='dis5_cdcavell.Config'></a>

## dis5_cdcavell.Config
IdentityServer4 In Memory Configuration <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2020 | Initial build |
| Christopher D. Cavell | 1.0.2.2 | 01/18/2020 | Convert GrantType from Implicit to Pkce |
| Christopher D. Cavell | 1.0.2.2 | 01/18/2020 | Removed unused clients and scopes |
| Christopher D. Cavell | 1.0.3.0 | 02/06/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.4.2 | 03/16/2021 | Email verification |
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.2.0 | 07/06/2021 | SignalR streaming |


|Properties| |
| - | - |
|ApiAccessToken|string|
|IdentityResources|IEnumerable<IdentityResource>|
|ApiScopes|IEnumerable<ApiScope>|
|Clients|IEnumerable<Client>|


( [Home](Home) )


<a name='dis5_cdcavell.Controllers.AccountController'></a>

## dis5_cdcavell.Controllers.AccountController
Account Controller <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |
| Christopher D. Cavell | 1.0.3.0 | 02/02/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.4.3 | 03/21/2021 | 2FA using TOTP |
| Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |


### Methods:
#### AccountController( ILogger<AccountController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IIdentityServerInteractionService interaction, IClientStore clientStore, IAuthenticationSchemeProvider schemeProvider, IEventService events, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, AppSettings appSettings ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<AccountController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|interaction|IIdentityServerInteractionService|
|clientStore|IClientStore|
|schemeProvider|IAuthenticationSchemeProvider|
|events|IEventService|
|signInManager|SignInManager<ApplicationUser>|
|userManager|UserManager<ApplicationUser>|
|appSettings|AppSettings|
## 
#### Login(string returnUrl)

Entry point into the login workflow

#### Returns:
Task<IActionResult> 
## 
#### Login(LoginInputModel model, string button)

Handle postback from username/password login

#### Returns:
Task<IActionResult> 
## 
#### Logout(string logoutId)

Show logout page

#### Returns:
Task<IActionResult> 
## 
#### Logout(LogoutInputModel model)

Handle logout page postback

#### Returns:
Task<IActionResult> 
## 
#### AccessDenied

Access Denied

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

( [Home](Home) )


<a name='dis5_cdcavell.Controllers.ApplicationBaseController'></a>

## dis5_cdcavell.Controllers.ApplicationBaseController
Base controller class for application

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2020 | Initial build |
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |


### Methods:
#### ApplicationBaseController( ILogger<T> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings ) : base(logger, webHostEnvironment, httpContextAccessor)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|appSettings|AppSettings|
## 

( [Home](Home) )


<a name='dis5_cdcavell.Controllers.ConsentController'></a>

## dis5_cdcavell.Controllers.ConsentController
Consent Controller <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |


### Methods:
#### ConsentController( ILogger<ConsentController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IIdentityServerInteractionService interaction, IEventService events, AppSettings appSettings ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<AccountController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|interaction|IIdentityServerInteractionService|
|events|IEventService|
|appSettings|AppSettings|
## 
#### Index(string returnUrl)

Shows the consent screen

|Parameters| |
| - | - |
|returnUrl|string|

#### Returns:
Task<IActionResult> 
## 
#### Index(ConsentInputModel model)

Handles the consent screen postback

#### Returns:
Task<IActionResult> 
## 
#### CreateScopeViewModel(ParsedScopeValue parsedScopeValue, ApiScope apiScope, bool check)

Create scope view model

#### Returns:
ScopeViewModel 
## 

( [Home](Home) )


<a name='dis5_cdcavell.Controllers.DeviceController'></a>

## dis5_cdcavell.Controllers.DeviceController
Device Controller <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |


### Methods:
#### DeviceController( ILogger<DeviceController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IDeviceFlowInteractionService interaction, IEventService eventService, IOptions<IdentityServerOptions> options, AppSettings appSettings ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<AccountController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|interaction|IIdentityServerInteractionService|
|eventService|IEventService|
|options|IOptions>IdentityServerOptions<|
|appSettings|AppSettings|
## 
#### Index()

Index Method

#### Returns:
Task<IActionResult> 
## 
#### UserCodeCapture(string userCode)

UserCodeCapture Method

#### Returns:
Task<IActionResult> 
## 
#### Callback(DeviceAuthorizationInputModel model)

Callback Method

#### Returns:
Task<IActionResult> 
## 
#### CreateScopeViewModel(ParsedScopeValue parsedScopeValue, ApiScope apiScope, bool check)

CreateScopeViewModel Method

#### Returns:
ScopeViewModel 
## 

( [Home](Home) )


<a name='dis5_cdcavell.Controllers.ExternalController'></a>

## dis5_cdcavell.Controllers.ExternalController
External Controller <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |
| Christopher D. Cavell | 1.0.4.3 | 03/21/2021 | 2FA using TOTP |
| Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/06/2021 | Permission-Based Authorization |


### Methods:
#### AccountController( ILogger<ExternalController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor IIdentityServerInteractionService interaction, IClientStore clientStore, IEventService events, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, AppSettings appSettings ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<ExternalController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|interaction|IIdentityServerInteractionService|
|clientStore|IClientStore|
|events|IEventService|
|signInManager|SignInManager<ApplicationUser>|
|userManager|UserManager<ApplicationUser>|
|appSettings|AppSettings|
## 
#### Challenge(string scheme, string returnUrl)

initiate roundtrip to external authentication provider

#### Returns:
IActionResult 

#### Exceptions:
System.Exception ( invalid return URL )
## 
#### Callback()

Post processing of external authentication

#### Returns:
Task<IActionResult> 

#### Exceptions:
System.Exception ( External authentication error )
## 

( [Home](Home) )


<a name='dis5_cdcavell.Controllers.HomeController'></a>

## dis5_cdcavell.Controllers.HomeController
Home controller class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |
| Christopher D. Cavell | 1.0.3.0 | 02/02/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.2.0 | 07/21/2021 | Migrate to AWS Lightsail |


### Methods:
#### HomeController( ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|appSettings|AppSettings|
## 
#### Index()

Index method

#### Returns:
IActionResult 
## 

( [Home](Home) )


<a name='dis5_cdcavell.Controllers.RegistrationController'></a>

## dis5_cdcavell.Controllers.RegistrationController
Registration Controller

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/27/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/04/2021 | Permission-Based Authorization |


### Methods:
#### RegistrationController( ILogger<RegistrationController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor AppSettings appSettings, UserManager<ApplicationUser> userManager, IEmailService emailService ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<RegistrationController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|appSettings|AppSettings|
|userManager|UserManager<ApplicationUser>|
|emailService|EmailService|
## 
#### TwoFactorConfiguration()

TwoFactor Authentication Configuration

#### Returns:
Task<IActionResult> 
## 
#### Index(RegistrationIndexModel model)

New Registration HttpPost method

#### Returns:
Task<IActionResult> 
## 
#### EmailValidation()

Email validation notice

#### Returns:
Task<IActionResult> 
## 
#### ConfirmEmail(string token, string email)

Email verification of external authentication

|Parameters| |
| - | - |
|token|string|
|email|string|

#### Returns:
Task<IActionResult> 
## 

( [Home](Home) )


<a name='dis5_cdcavell.Controllers.TwoFactorController'></a>

## dis5_cdcavell.Controllers.TwoFactorController
Two-Factor Controller

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/04/2021 | Permission-Based Authorization |


### Methods:
#### TwoFactorController( ILogger<TwoFactorController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor AppSettings appSettings, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IIdentityServerInteractionService interaction, IEventService events, IEmailService emailService ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<TwoFactorController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|appSettings|AppSettings|
|userManager|UserManager<ApplicationUser>|
|signInManager|SignInManager<ApplicationUser>|
|interaction|IIdentityServerInteractionService|
|events|IEventService|
|emailService|EmailService|
## 
#### Configuration()

TwoFactor Authentication Configuration

#### Returns:
Task<IActionResult> 
## 
#### Validate()

TwoFactor Authentication Validate

#### Returns:
Task<IActionResult> 
## 
#### Validate(TwoFactorValidateModel model)

TwoFactor Authentication Validate

#### Returns:
Task<IActionResult> 
## 
#### Disable()

TwoFactor Authentication Disable

#### Returns:
Task<IActionResult> 
## 
#### Retrive()

TwoFactor Authentication Retrive

#### Returns:
Task<IActionResult> 
## 
#### RetriveConfirm(string token, string email)

TwoFactor Authentication Retrive Confirm

|Parameters| |
| - | - |
|token|string|
|email|string|

#### Returns:
Task<IActionResult> 
## 

( [Home](Home) )


<a name='dis5_cdcavell.Extensions'></a>

## dis5_cdcavell.Extensions
Extensions <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


### Methods:
#### IsNativeClient(this AuthorizationRequest context)

Checks if the redirect URI is for a native client.

#### Returns:
bool 
## 
#### LoadingPage(this Controller controller, string viewName, string redirectUri)

Loading page.

#### Returns:
IActionResult 
## 

( [Home](Home) )


<a name='dis5_cdcavell.Filters.SecurityHeadersAttribute'></a>

## dis5_cdcavell.Filters.SecurityHeadersAttribute
Security Headers Attribute Filter <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |
| Christopher D. Cavell | 1.0.3.0 | 02/05/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.2 | 06/15/2021 | New IHtmlHelper Extension Gravatar |
| Christopher D. Cavell | 1.1.1.2 | 06/19/2021 | Update CSP Image Source |
| Christopher D. Cavell | 1.1.2.0 | 07/23/2021 | Migrate to AWS Lightsail |


### Methods:
#### SecurityHeadersAttribute(AppSettings appSettings)

Constructor method

|Parameters| |
| - | - |
|appSettings|AppSettings|
## 
#### OnResultExecuting(ResultExecutingContext context)

Executes before result execution

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


<a name='dis5_cdcavell.Models.Account.OldApplicationUser'></a>

## dis5_cdcavell.Models.Account.OldApplicationUser
Duende IdentityServer5 Application User

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.5.0 | 01/16/2021 | Initial build |
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |


|Properties| |
| - | - |
|FirstName|string|
|LastName|string|
|ApprovedDate|DateTime?|
|ApprovedById|string|
|ApprovedBy|ApplicationUser|
|RevokedDate|DateTime?|
|RevokedById|string|
|RevokedBy|ApplicationUser|
|IsPending|bool|
|IsRevoked|bool|
|Status|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Account.CaptchaResponse'></a>

## dis5_cdcavell.Models.Account.CaptchaResponse
Captcha response model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/27/2021 | Integrate ASP.NET Core Identity |


|Properties| |
| - | - |
|success|bool|
|challenge_ts|DateTime|
|hostname|string|
|score|double|
|action|string|
|ErrorCodes|object[]|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Account.ExternalProvider'></a>

## dis5_cdcavell.Models.Account.ExternalProvider
External Provider Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|DisplayName|string|
|AuthenticationScheme|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Account.LoggedOutViewModel'></a>

## dis5_cdcavell.Models.Account.LoggedOutViewModel
Logged Out View Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|PostLogoutRedirectUri|string|
|ClientName|string|
|SignOutIframeUrl|string|
|AutomaticRedirectAfterSignOut|bool|
|LogoutId|string|
|TriggerExternalSignout|bool|
|ExternalAuthenticationScheme|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Account.LoginInputModel'></a>

## dis5_cdcavell.Models.Account.LoginInputModel
Login Input Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|Username|string|
|Password|string|
|RememberLogin|bool|
|ReturnUrl|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Account.LoginViewModel'></a>

## dis5_cdcavell.Models.Account.LoginViewModel
Login View Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|AllowRememberLogin|bool|
|EnableLocalLogin|bool|
|ExternalProviders|IEnumerable<ExternalProvider>|
|VisibleExternalProviders|IEnumerable<ExternalProvider>|
|IsExternalLoginOnly|bool|
|ExternalLoginScheme|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Account.LogoutInputModel'></a>

## dis5_cdcavell.Models.Account.LogoutInputModel
Logout Input Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|LogoutId|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Account.LogoutViewModel'></a>

## dis5_cdcavell.Models.Account.LogoutViewModel
Logout View Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|ShowLogoutPrompt|bool|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Account.RedirectViewModel'></a>

## dis5_cdcavell.Models.Account.RedirectViewModel
Redirect View Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|RedirectUrl|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.AppSettings.Application'></a>

## dis5_cdcavell.Models.AppSettings.Application
Application model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |
| Christopher D. Cavell | 1.0.3.0 | 02/02/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.4.3 | 03/21/2021 | 2FA using TOTP |
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |


|Properties| |
| - | - |
|MainSiteUrl|string|
|MainSiteUrlTrim|string|
|ApiUrl|string|
|ApiUrlTrim|string|
|UiUrl|string|
|UiUrlTrim|string|
|ISDUrl|string|
|ISDUrlTrim|string|
|RTCUrl|string|
|RTCUrlTrim|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.AppSettings'></a>

## dis5_cdcavell.Models.AppSettings
AppSettings model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.1.0.0 | 03/26/2021 | Integrate ASP.NET Core Identity |


|Properties| |
| - | - |
|AssemblyName|string|
|AssemblyVersion|string|
|LastModifiedDate|DateTime|
|SecretKey|string|
|ConnectionStrings|ConnectionStrings|
|Authentication|Authentication|
|Application|Application|
|EmailService|EmailService|


( [Home](Home) )


<a name='dis5_cdcavell.Models.AppSettings.Authentication'></a>

## dis5_cdcavell.Models.AppSettings.Authentication
Authentication model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 11.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|Twitter|Twitter|
|Facebook|Facebook|
|Microsoft|Microsoft|
|Google|Google|
|GitHub|GitHub|
|LinkedIn|LinkedIn|
|reCAPTCHA|reCAPTCHA|


( [Home](Home) )


<a name='dis5_cdcavell.Models.AppSettings.Facebook'></a>

## dis5_cdcavell.Models.AppSettings.Facebook
Facebook Authentication model <br/><br/> https://developers.facebook.com/apps/

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|AppId|string|
|AppSecret|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.AppSettings.GitHub'></a>

## dis5_cdcavell.Models.AppSettings.GitHub
GitHub Authentication model <br/><br/> https://github.com/settings/applications/new

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|ClientId|string|
|ClientSecret|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.AppSettings.Google'></a>

## dis5_cdcavell.Models.AppSettings.Google
Google Authentication model <br/><br/> https://developers.google.com/identity/sign-in/web/sign-in

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|ClientId|string|
|ClientSecret|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.AppSettings.LinkedIn'></a>

## dis5_cdcavell.Models.AppSettings.LinkedIn
LinkedIn Authentication model <br/><br/> https://www.linkedin.com/developers/apps

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|ClientId|string|
|ClientSecret|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.AppSettings.Microsoft'></a>

## dis5_cdcavell.Models.AppSettings.Microsoft
Microsoft Authentication model <br/><br/> https://go.microsoft.com/fwlink/?linkid=2083908

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|ClientId|string|
|ClientSecret|string|
|TokenEndpoint|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.AppSettings.reCAPTCHA'></a>

## dis5_cdcavell.Models.AppSettings.reCAPTCHA
reCAPTCHA Authentication model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/27/2021 | Integrate ASP.NET Core Identity |


|Properties| |
| - | - |
|SiteKey|string|
|SecretKey|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.AppSettings.Twitter'></a>

## dis5_cdcavell.Models.AppSettings.Twitter
Twitter Authentication model <br/><br/> https://developer.twitter.com/en/portal/dashboard

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|ConsumerAPIKey|string|
|ConsumerSecret|string|
|BearerToken|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.AppSettings.ConnectionStrings'></a>

## dis5_cdcavell.Models.AppSettings.ConnectionStrings
Connection Strings model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |
| Christopher D. Cavell | 1.0.3.0 | 02/05/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Add ApplicationInsights |


|Properties| |
| - | - |
|AspIdUsersConnection|string|
|ApplicationInsightsConnection|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.AppSettings.EmailService'></a>

## dis5_cdcavell.Models.AppSettings.EmailService
Site Administrator model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/26/2021 | Integrate ASP.NET Core Identity |


|Properties| |
| - | - |
|Host|string|
|Port|int|
|EnableSsl|bool|
|UserId|string|
|Password|string|
|Email|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Consent.ConsentInputModel'></a>

## dis5_cdcavell.Models.Consent.ConsentInputModel
Consent Input Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|Button|string|
|ScopesConsented|IEnumerable<string>|
|RememberConsent|bool|
|ReturnUrl|string|
|Description|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Consent.ConsentViewModel'></a>

## dis5_cdcavell.Models.Consent.ConsentViewModel
Consent View Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|ClientName|string|
|ClientUrl|string|
|ClientLogoUrl|string|
|AllowRememberConsent|bool|
|IdentityScopes|IEnumerable<ScopeViewModel>|
|ApiScopes|IEnumerable<ScopeViewModel>|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Consent.ProcessConsentResult'></a>

## dis5_cdcavell.Models.Consent.ProcessConsentResult
Process Consent Result Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|IsRedirect|bool|
|RedirectUri|string|
|Client|Client|
|ShowView|bool|
|ViewModel|ConsentViewModel|
|HasValidationError|bool|
|ValidationError|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Consent.ScopeViewModel'></a>

## dis5_cdcavell.Models.Consent.ScopeViewModel
Scope View Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|Value|string|
|DisplayName|string|
|Description|string|
|Emphasize|bool|
|Required|bool|
|Checked|bool|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Device.DeviceAuthorizationInputModel'></a>

## dis5_cdcavell.Models.Device.DeviceAuthorizationInputModel
Device Authorization Input Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|UserCode|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Device.DeviceAuthorizationViewModel'></a>

## dis5_cdcavell.Models.Device.DeviceAuthorizationViewModel
Device Authorization View Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|UserCode|string|
|ConfirmUserCode|bool|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Diagnostics.DiagnosticsViewModel'></a>

## dis5_cdcavell.Models.Diagnostics.DiagnosticsViewModel
Diagnostics View Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|AuthenticateResult|AuthenticateResult|
|Clients|Clients|

### Methods:
#### #ctor(Microsoft.AspNetCore.Authentication.AuthenticateResult)

Constructor method

|Parameters| |
| - | - |
|result|AuthenticateResult|
## 

( [Home](Home) )


<a name='dis5_cdcavell.Models.Grants.GrantsViewModel'></a>

## dis5_cdcavell.Models.Grants.GrantsViewModel
Grants View Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|Grants|IEnumerable<GrantViewModel>|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Grants.GrantViewModel'></a>

## dis5_cdcavell.Models.Grants.GrantViewModel
Grant View Model <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Properties| |
| - | - |
|ClientId|string|
|ClientName|string|
|ClientUrl|string|
|ClientLogoUrl|string|
|Description|string|
|Created|DateTime|
|Expires|DateTime?|
|IdentityGrantNames|IEnumerable<string>|
|ApiGrantNames|IEnumerable<string>|


( [Home](Home) )


<a name='dis5_cdcavell.Models.Registration.RegistrationIndexModel'></a>

## dis5_cdcavell.Models.Registration.RegistrationIndexModel
Index model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/27/2021 | Integrate ASP.NET Core Identity |


|Properties| |
| - | - |
|Email|string|
|FirstName|string|
|LastName|string|
|RequestDate|DateTime?|
|Status|string|


( [Home](Home) )


<a name='dis5_cdcavell.Models.TwoFactor.TwoFactorValidateModel'></a>

## dis5_cdcavell.Models.TwoFactor.TwoFactorValidateModel
Two-Factor Validate model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |


|Properties| |
| - | - |
|Email|string|
|Provider|string|
|ProviderUserId|string|
|SessionId|string|
|AuthenticationToken|string|
|ReturnUrl|string|


( [Home](Home) )


<a name='dis5_cdcavell.Options.AccountOptions'></a>

## dis5_cdcavell.Options.AccountOptions
Account Options <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |
| Christopher D. Cavell | 1.0.3.0 | 02/06/2021 | Initial build Authorization Service |


|Fields| |
| - | - |
|AllowLocalLogin|bool|
|AllowRememberLogin|bool|
|RememberMeLoginDuration|TimeSpan|
|ShowLogoutPrompt|bool|
|AutomaticRedirectAfterSignOut|bool|
|InvalidCredentialsErrorMessage|string|


( [Home](Home) )


<a name='dis5_cdcavell.Options.ConsentOptions'></a>

## dis5_cdcavell.Options.ConsentOptions
Consent Options <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |


|Fields| |
| - | - |
|EnableOfflineAccess|bool|
|OfflineAccessDisplayName|string|
|OfflineAccessDescription|string|
|MustChooseOneErrorMessage|string|
|InvalidSelectionErrorMessage|string|


( [Home](Home) )


<a name='dis5_cdcavell.Program'></a>

## dis5_cdcavell.Program
Entry point class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |
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


<a name='dis5_cdcavell.Startup'></a>

## dis5_cdcavell.Startup
The Startup class configures services and the application's request pipeline<br /><br /> _Services_ are components that are used by the app. For example, a logging component is a service. Code to configure (_or register_) services is added to the ```Startup.ConfigureServices``` method.<br /><br /> The request handling pipeline is composed as a series of _middleware_ components. For example, a middleware might handle requests for static files or redirect HTTP requests to HTTPS. Each middleware performs asynchronous operations on an ```HttpContext``` and then either invokes the next middleware in the pipeline or terminates the request. Code to configure the request handling pipeline is added to the ```Startup.Configure``` method.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |
| Christopher D. Cavell | 1.0.3.0 | 02/06/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Utilize Redis Cache - Not implemented |
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.1.0.0 | 03/26/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/06/2021 | Permission-Based Authorization |
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


<a name='is4_cdcavell.Controllers.DiagnosticsController'></a>

## is4_cdcavell.Controllers.DiagnosticsController
Diagnostics Controller <br /><br /> Copyright (c) Duende Software. All rights reserved. See https://duendesoftware.com/license/identityserver.pdf for license information.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.2.0 | 01/16/2021 | Initial build |
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |


### Methods:
#### DiagnosticsController( ILogger<DiagnosticsController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|appSettings|AppSettings|
## 
#### Index()

Index method

#### Returns:
Task<IActionResult> 
## 

( [Home](Home) )

