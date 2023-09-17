
<a name='cdcavell.Classes.Sitemap'></a>

## cdcavell.Classes.Sitemap
Sitemap builder class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/28/2020 | Initial build |
| Christopher D. Cavell | 1.0.0.6 | 10/31/2020 | Convert Sitemap class to build sitemap.xml dynamic based on existing controllers in project [#145](https://github.com/cdcavell/cdcavell.name/issues/145) |
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |
| Christopher D. Cavell | 1.0.0.9 | 11/03/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |
| Christopher D. Cavell | 1.0.0.9 | 11/21/2020 | Ping Google with the location of sitemap |
| Christopher D. Cavell | 1.0.3.1 | 02/08/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.0.3.3 | 03/07/2021 | User Authorization Web Service |


### Methods:
#### Sitemap( Logger logger, IWebHostEnvironment webHostEnvironment, AppSettings appSettings )

Constructor method

|Parameters| |
| - | - |
|logger|Logger|
|webHostEnvironment|IWebHostEnvironment|
|appSettings|AppSettings|
## 
#### public void Create()

Create sitemap.xml in ASP.NET Core <br /><br /> https://www.c-sharpcorner.com/article/create-and-configure-sitemap-xml-in-asp-net-core/
## 

( [Home](Home) )


<a name='cdcavell.Controllers.AccountController'></a>

## cdcavell.Controllers.AccountController
Account Controller

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/19/2020 | Initial build |
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |
| Christopher D. Cavell | 1.0.0.9 | 11/12/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |
| Christopher D. Cavell | 1.0.3.0 | 02/04/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Utilize Redis Cache |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.0.3.3 | 03/07/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/04/2021 | Permission-Based Authorization |
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
#### Index()

Index method

#### Returns:
IActionResult 
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


<a name='cdcavell.Controllers.ApplicationBaseController'></a>

## cdcavell.Controllers.ApplicationBaseController
Base controller class for application

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/18/2020 | Initial build |
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |
| Christopher D. Cavell | 1.0.0.9 | 11/04/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |
| Christopher D. Cavell | 1.0.3.0 | 02/01/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Utilize Redis Cache - Not Implemented |
| Christopher D. Cavell | 1.0.3.1 | 02/08/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.0.3.3 | 03/07/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/03/2021 | Permission-Based Authorization |


|Fields| |
| - | - |
|_appSettings|AppSettings|

### Methods:
#### ApplicationBaseController( ILogger<T> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings )

Constructor method

|Parameters| |
| - | - |
|logger|ILogger|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
|appSettings|AppSettings|
## 

( [Home](Home) )


<a name='cdcavell.Controllers.HomeController'></a>

## cdcavell.Controllers.HomeController
Home controller class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/28/2020 | Initial build |
| Christopher D. Cavell | 1.0.0.1 | 10/28/2020 | Update namespace |
| Christopher D. Cavell | 1.0.0.1 | 10/29/2020 | Remove YouTubeVideo from Index |
| Christopher D. Cavell | 1.0.0.5 | 10/30/2020 | EU General Data Protection Regulation (GDPR) support in ASP.NET Core [#161](https://github.com/cdcavell/cdcavell.name/issues/161) |
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |
| Christopher D. Cavell | 1.0.0.8 | 11/01/2020 | Bing Search APIs will transition from Azure Cognitive Services to Azure Marketplace on 31 October 2023 [#152](https://github.com/cdcavell/cdcavell.name/issues/152) |
| Christopher D. Cavell | 1.0.0.9 | 11/04/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.0.3.3 | 03/07/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/03/2021 | Permission-Based Authorization |


### Methods:
#### public HomeController( ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, AppSettings appSettings ) : base(logger, webHostEnvironment, httpContextAccessor, appSettings)

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
#### PrivacyPolicy()

Privacy policy

#### Returns:
IActionResult 
## 
#### Revoke()

Revoke external access permissions

#### Returns:
IActionResult 
## 
#### TermsOfService()

Terms of service

#### Returns:
IActionResult 
## 
#### WithdrawConsent()

Withdraw cookie consent

#### Returns:
IActionResult 
## 
#### Search()

Search get method

#### Returns:
IActionResult 
## 
#### Search()

Handle postback from Search request method

#### Returns:
Task<IActionResult> 
## 

( [Home](Home) )


<a name='cdcavell.Data.AuditEntry'></a>

## cdcavell.Data.AuditEntry
CDCavell AuditEntry record

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.9 | 11/03/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |


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


<a name='cdcavell.Data.AuditHistory'></a>

## cdcavell.Data.AuditHistory
CDCavell AuditHistory Entity

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.9 | 11/03/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |


|Properties| |
| - | - |
|Id|int|
|ModifiedBy|string|
|ModifiedOn|DateTime?|
|Application|string|
|Entity|string|
|State|string|
|KeyValues|string|
|OriginalValues|string|
|CurrentValues|string|


( [Home](Home) )


<a name='cdcavell.Data.CDCavellDbContext'></a>

## cdcavell.Data.CDCavellDbContext
CDCavell Database Context

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |
| Christopher D. Cavell | 1.0.0.9 | 11/09/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |
| Christopher D. Cavell | 1.0.3.0 | 10/24/2020 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.3 | 03/07/2021 | User Authorization Service |


|Properties| |
| - | - |
|AuditHistory|DbSet<AuditHistory>|
|SiteMap|DbSet<SiteMap>|

### Methods:
#### CDCavellDdContext(ILogger<CDCavellDbContext> logger, IHttpContextAccessor httpContextAccessor, DbContextOptions<CDCavellDbContext> options) : base(options)

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


<a name='cdcavell.Data.DataModel`1'></a>

## cdcavell.Data.DataModel`1
CDCavell DataModel base class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.9 | 11/12/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |
| Christopher D. Cavell | 1.0.3.0 | 10/23/2020 | Initial build Authorization Service |


|Properties| |
| - | - |
|Id|int|
|IsNew|bool|

### Methods:
#### AddUpdate(CDCavellDbContext dbContext)

Add/Update record
## 
#### Delete(cdcavell.Data.CDCavellDbContext)

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


<a name='cdcavell.Data.DbInitializer'></a>

## cdcavell.Data.DbInitializer
CDCavell Database Initializer

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |
| Christopher D. Cavell | 1.0.0.9 | 11/11/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |
| Christopher D. Cavell | 1.0.3.0 | 01/23/2021 | Initial build Authorization Service |


### Methods:
#### Initialize(MigrateDdContext context)

Initialize method <br /> To Initialize: dotnet ef migrations add InitialCreate --context CDCavellDbContext <br /> To Update: dotnet ef migrations add UpdateDatabase_<<YYYY-MM-DD>> --context CDCavellDbContext <br /> To Revert: dotnet ef database update <previous migration name> (Then - dotnet ef migrations remove)

|Parameters| |
| - | - |
|context|CDCavellDdContext|
## 

( [Home](Home) )


<a name='cdcavell.Data.IDataModel`1'></a>

## cdcavell.Data.IDataModel`1
CDCavell DataModel Interface

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.9 | 11/03/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |


|Properties| |
| - | - |
|Id|int|
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


<a name='cdcavell.Data.SiteMap'></a>

## cdcavell.Data.SiteMap
CDCavell SiteMap Entity

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |
| Christopher D. Cavell | 1.0.0.9 | 11/03/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |


|Properties| |
| - | - |
|Controller|string|
|Action|string|
|LastSubmitDate|DateTime?|

### Methods:
#### GetCount(string controller, string action, CDCavellDbContext dbContext)

Get count of controller and action in StieMap entity

|Parameters| |
| - | - |
|controller||
|action||
|dbContext||

#### Returns:
int 
## 
#### GetAllSiteMap(CDCavellDbContext dbContext)

Get all StieMap entity records

|Parameters| |
| - | - |
|dbContext||

#### Returns:
int 
## 
#### GetNotSubmittedSiteMap(CDCavellDbContext dbContext)

Get StieMap entity records that have not been submitted

|Parameters| |
| - | - |
|dbContext||

#### Returns:
int 
## 
#### GetSiteMap(string controller, string action, CDCavellDbContext dbContext)

Get StieMap entity records

|Parameters| |
| - | - |
|controller||
|action||
|dbContext||

#### Returns:
int 
## 

( [Home](Home) )


<a name='cdcavell.Filters.SecurityHeadersAttribute'></a>

## cdcavell.Filters.SecurityHeadersAttribute
Security Headers Attribute Filter from Brock Allen & Dominick Baier. <br /><br /> Copyright (c) Brock Allen & Dominick Baier. All rights reserved. Licensed under the Apache License, Version 2.0.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/25/2020 | Initial build |
| Christopher D. Cavell | 1.0.0.1 | 10/28/2020 | Add YouTubeVideos |
| Christopher D. Cavell | 1.0.0.1 | 10/29/2020 | Remove YouTubeVideos (Not Implemented) |
| Christopher D. Cavell | 1.0.0.3 | 10/30/2020 | Issue #150 Content-Security-Policy HTTP header: Bad content security policy |
| Christopher D. Cavell | 1.0.0.9 | 11/12/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |
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


<a name='cdcavell.Models.Account.CaptchaResponse'></a>

## cdcavell.Models.Account.CaptchaResponse
Captcha response model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.9 | 11/08/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |


|Properties| |
| - | - |
|success|bool|
|challenge_ts|DateTime|
|hostname|string|
|score|double|
|action|string|
|ErrorCodes|object[]|


( [Home](Home) )


<a name='cdcavell.Models.AppSettings.Application'></a>

## cdcavell.Models.AppSettings.Application
Application model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Web Service |


|Properties| |
| - | - |
|ConnectionStrings|ConnectionStrings|
|BingWebSearch|BingWebSearchModel|
|BingWebmaster|BingWebmasterModel|


( [Home](Home) )


<a name='cdcavell.Models.AppSettings'></a>

## cdcavell.Models.AppSettings
AppSettings model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/20/2020 | Initial build |
| Christopher D. Cavell | 1.0.0.1 | 10/28/2020 | Add YouTubeVideos |
| Christopher D. Cavell | 1.0.0.1 | 10/29/2020 | Remove YouTubeVideos (Not Implemented) |
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |
| Christopher D. Cavell | 1.0.0.9 | 11/12/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Web Service |


|Properties| |
| - | - |
|Application|Application|


( [Home](Home) )


<a name='cdcavell.Models.AppSettings.BingWebmasterModel'></a>

## cdcavell.Models.AppSettings.BingWebmasterModel
Bing Webmaster model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |


|Properties| |
| - | - |
|ApiKey|string|


( [Home](Home) )


<a name='cdcavell.Models.AppSettings.BingWebSearchModel'></a>

## cdcavell.Models.AppSettings.BingWebSearchModel
Bing Web Search Authentication model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.8 | 11/01/2020 | Bing Search APIs will transition from Azure Cognitive Services to Azure Marketplace on 31 October 2023 [#152](https://github.com/cdcavell/cdcavell.name/issues/152) |


|Properties| |
| - | - |
|SubscriptionKey|string|
|CustomConfigId|string|


( [Home](Home) )


<a name='cdcavell.Models.AppSettings.ConnectionStrings'></a>

## cdcavell.Models.AppSettings.ConnectionStrings
ConnectionStrings model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |
| Christopher D. Cavell | 1.0.3.0 | 02/05/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Add ApplicationInsights |
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Web Service |


|Properties| |
| - | - |
|CDCavellConnection|string|


( [Home](Home) )


<a name='cdcavell.Models.Home.IndexModel'></a>

## cdcavell.Models.Home.IndexModel
Index model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/28/2020 | Initial build |
| Christopher D. Cavell | 1.0.0.1 | 10/28/2020 | Add YouTubeVideos |
| Christopher D. Cavell | 1.0.0.1 | 10/29/2020 | Remove YouTubeVideos (Not Implemented) |



( [Home](Home) )


<a name='cdcavell.Models.Home.Search.SearchModel'></a>

## cdcavell.Models.Home.Search.SearchModel
Search Model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/25/2020 | Initial build |
| Christopher D. Cavell | 1.0.0.1 | 10/28/2020 | Update namespace |
| Christopher D. Cavell | 1.0.0.8 | 11/01/2020 | Bing Search APIs will transition from Azure Cognitive Services to Azure Marketplace on 31 October 2023 [#152](https://github.com/cdcavell/cdcavell.name/issues/152) |


|Properties| |
| - | - |
|StatusCode|HttpStatusCode|
|WebActive|string|
|WebDisabled|string|
|WebResult|ResultModel|
|ImageActive|string|
|ImageDisabled|string|
|ImageResult|ResultModel|
|VideoActive|string|
|VideoDisabled|string|
|VideoResult|ResultModel|
|SearchRequest|string|


( [Home](Home) )


<a name='cdcavell.Program'></a>

## cdcavell.Program
Entry point class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/28/2020 | Initial build |
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |
| Christopher D. Cavell | 1.0.0.9 | 11/03/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |
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


<a name='cdcavell.Startup'></a>

## cdcavell.Startup
The Startup class configures services and the application's request pipeline<br /><br /> _Services_ are components that are used by the app. For example, a logging component is a service. Code to configure (_or register_) services is added to the ```Startup.ConfigureServices``` method.<br /><br /> The request handling pipeline is composed as a series of _middleware_ components. For example, a middleware might handle requests for static files or redirect HTTP requests to HTTPS. Each middleware performs asynchronous operations on an ```HttpContext``` and then either invokes the next middleware in the pipeline or terminates the request. Code to configure the request handling pipeline is added to the ```Startup.Configure``` method.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/28/2020 | Initial build |
| Christopher D. Cavell | 1.0.0.4 | 10/30/2020 | Enforce HTTPS in ASP.NET Core [#158](https://github.com/cdcavell/cdcavell.name/issues/158) |
| Christopher D. Cavell | 1.0.0.5 | 10/31/2020 | EU General Data Protection Regulation (GDPR) support in ASP.NET Core [#161](https://github.com/cdcavell/cdcavell.name/issues/161) |
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Serve static assets with an efficient cache policy [#172](https://github.com/cdcavell/cdcavell.name/issues/172) |
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |
| Christopher D. Cavell | 1.0.0.9 | 11/11/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |
| Christopher D. Cavell | 1.0.2.2 | 01/18/2021 | Convert GrantType from Implicit to Pkce |
| Christopher D. Cavell | 1.0.3.0 | 02/06/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Utilize Redis Cache - Not implemented |
| Christopher D. Cavell | 1.0.3.1 | 02/09/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.0.3.3 | 03/09/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.0.4.2 | 03/16/2021 | Email verification |
| Christopher D. Cavell | 1.1.0.0 | 03/28/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.0 | 04/05/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.2.0 | 07/08/2021 | SignalR streaming |
| Christopher D. Cavell | 1.1.2.0 | 07/14/2021 | App Services Action Build And Deployment Pipeline |
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
#### Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger, IHostApplicationLifetime lifetime, CDCavellDbContext dbContext)

This required method gets called by the runtime. Use this method to configure the HTTP request pipeline.

|Parameters| |
| - | - |
|app|IApplicationBuilder|
|env|IWebHostEnvironment|
|logger|ILogger<Startup>|
|lifetime|IHostApplicationLifetime|
|dbContext|CDCavellDbContext|
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

