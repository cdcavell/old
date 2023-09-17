
<a name='rtc_cdcavell.Controllers.AccountController'></a>

## rtc_cdcavell.Controllers.AccountController
Account Controller

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.2.0 | 07/08/2021 | SignalR streaming |
| Christopher D. Cavell | 1.1.2.0 | 07/21/2021 | Migrate to AWS Lightsail |


### Methods:
#### AccountController( ILogger<AccountController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<AccountController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|appSettings|AppSettings|
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


<a name='rtc_cdcavell.Controllers.ApplicationBaseController'></a>

## rtc_cdcavell.Controllers.ApplicationBaseController
Base controller class for application

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.2.0 | 07/05/2021 | SignalR streaming |


|Fields| |
| - | - |
|_userManager|CustomUserManager|
|_roleManager|CustomRoleManager|
|_appSettings|AppSettings|

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


<a name='rtc_cdcavell.Controllers.ChatController'></a>

## rtc_cdcavell.Controllers.ChatController
Home Controller

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.2.0 | 07/06/2021 | SignalR streaming |


### Methods:
#### ChatController( ILogger<ChatController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<ChatController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|appSettings|AppSettings|
## 
#### Index()

Index HttpGet method

#### Returns:
Task<IActionResult> 
## 

( [Home](Home) )


<a name='rtc_cdcavell.Controllers.HomeController'></a>

## rtc_cdcavell.Controllers.HomeController
Home Controller

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.2.0 | 07/06/2021 | SignalR streaming |


### Methods:
#### HomeController( ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings, CustomUserManager userManager, CustomRoleManager roleManager ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger<HomeController>|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|appSettings|AppSettings|
## 

( [Home](Home) )


<a name='rtc_cdcavell.Filters.SecurityHeadersAttribute'></a>

## rtc_cdcavell.Filters.SecurityHeadersAttribute
Security Headers Attribute Filter from Brock Allen & Dominick Baier. <br /><br /> Copyright (c) Brock Allen & Dominick Baier. All rights reserved. Licensed under the Apache License, Version 2.0.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.2.0 | 07/05/2021 | SignalR streaming |
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


<a name='rtc_cdcavell.Models.Account.CaptchaResponse'></a>

## rtc_cdcavell.Models.Account.CaptchaResponse
Captcha response model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.2.0 | 07/05/2021 | SignalR streaming |


|Properties| |
| - | - |
|success|bool|
|challenge_ts|DateTime|
|hostname|string|
|score|double|
|action|string|
|ErrorCodes|object[]|


( [Home](Home) )


<a name='rtc_cdcavell.Models.AppSettings.Application'></a>

## rtc_cdcavell.Models.AppSettings.Application
Application model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.2.0 | 07/05/2021 | SignalR streaming |



( [Home](Home) )


<a name='rtc_cdcavell.Models.AppSettings'></a>

## rtc_cdcavell.Models.AppSettings
AppSettings model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.2.0 | 07/05/2021 | SignalR streaming |


|Properties| |
| - | - |
|Application|Application|


( [Home](Home) )


<a name='rtc_cdcavell.Program'></a>

## rtc_cdcavell.Program
Entry point class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.2.0 | 07/05/2021 | SignalR streaming |


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


<a name='rtc_cdcavell.Startup'></a>

## rtc_cdcavell.Startup
The Startup class configures services and the application's request pipeline<br /><br /> _Services_ are components that are used by the app. For example, a logging component is a service. Code to configure (_or register_) services is added to the ```Startup.ConfigureServices``` method.<br /><br /> The request handling pipeline is composed as a series of _middleware_ components. For example, a middleware might handle requests for static files or redirect HTTP requests to HTTPS. Each middleware performs asynchronous operations on an ```HttpContext``` and then either invokes the next middleware in the pipeline or terminates the request. Code to configure the request handling pipeline is added to the ```Startup.Configure``` method.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
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

