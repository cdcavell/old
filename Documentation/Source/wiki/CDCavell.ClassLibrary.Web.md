
<a name='Microsoft.AspNetCore.Http.HttpContextExtensions'></a>

## Microsoft.AspNetCore.Http.HttpContextExtensions
Extension methods for existing HttpContext types.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 09/29/2020 | Initial build |


### Methods:
#### GetAbsoluteUri(this HttpContext httpContext)

Method to return Absolute Uri for HttpContext

|Parameters| |
| - | - |
|httpContext|this HttpContext|

#### Returns:
Uri 
## 
#### GetAbsoluteDomain(this HttpContext httpContext)

Method to return Absolute Domain for HttpContext

|Parameters| |
| - | - |
|httpContext|this HttpContext|

#### Returns:
string 
## 
#### GetAbsoluteUrl(this HttpContext httpContext)

Similar methods for Url/AbsolutePath which internally call GetAbsoluteUri

|Parameters| |
| - | - |
|httpContext|this HttpContext|

#### Returns:
string 
## 
#### GetAbsolutePath(this HttpContext httpContext)

Method to return Absolute Path HttpContext

|Parameters| |
| - | - |
|httpContext|this HttpContext|

#### Returns:
string 
## 
#### IsAjaxRequest(this HttpContext httpContext)

Method to return if HttpContext is an AJax request

|Parameters| |
| - | - |
|httpContext|this HttpContext|

#### Returns:
bool 
## 
#### GetRemoteAddress(this HttpContext httpContext)

Method to return IPAddress of reomote address for HttpContext

|Parameters| |
| - | - |
|httpContext|HttpContext|

#### Returns:
IPAddress 
## 

( [Home](Home) )


<a name='Microsoft.AspNetCore.Http.HttpRequestExtensions'></a>

## Microsoft.AspNetCore.Http.HttpRequestExtensions
Extension methods for existing HttpRequest types.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 09/29/2020 | Initial build |


### Methods:
#### IsLocalUrl(this HttpRequest request, string url)

Method to determine if string is a local url

|Parameters| |
| - | - |
|request|this HttpRequest|
|url|string|

#### Returns:
bool 
## 
#### GetUri(this HttpRequest request)

Method to return Uri of HttpRequest

|Parameters| |
| - | - |
|request|this HttpRequest|

#### Returns:
bool 
## 
#### GetRemoteAddress(this IPAddress ipAddress)

Method to return IPAddress of reomote address for HttpRequest

|Parameters| |
| - | - |
|request|HttpRequest|

#### Returns:
IPAddress 
## 
#### IsAjaxRequest(this HttpRequest httpRequest)

Method to return if HttpRequest is an AJax request

|Parameters| |
| - | - |
|httpRequest|this HttpRequest|

#### Returns:
bool 
## 

( [Home](Home) )


<a name='Microsoft.AspNetCore.Http.ISessionExtensions'></a>

## Microsoft.AspNetCore.Http.ISessionExtensions
Extension methods for existing ISession types.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | Utilize Redis Cache - Not implemented |


### Methods:
#### Decrypt<T>(this ISession session, string key)

Method to return decrypted object from Http Session

|Parameters| |
| - | - |
|session|ISession|
|key|string|

#### Returns:
<T> 
## 
#### Encrypt<T>(this ISession session, string key, T value)

Method to store encrypted object in Http Session

|Parameters| |
| - | - |
|session|ISession|
|key|string|
|value|T|
## 

( [Home](Home) )


<a name='Microsoft.AspNetCore.Html.IHtmlContentExtensions'></a>

## Microsoft.AspNetCore.Html.IHtmlContentExtensions
Extension methods for existing IHtmlContent types.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.2 | 06/15/2021 | New IHtmlHelper Extension Gravatar |


### Methods:
#### GetString(Microsoft.AspNetCore.Html.IHtmlContent)

Returns HTML string for IHtmlContent. <br /><br /> Original Developer: cygnim (https://stackoverflow.com/users/1152681/cygnim) <br /><br /> Original Source: https://stackoverflow.com/a/33679999/8041900

|Parameters| |
| - | - |
|content|IHtmlContent|

#### Returns:
string 
## 

( [Home](Home) )


<a name='Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelperExtensions'></a>

## Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelperExtensions
Extension methods for existing IHtmlHelper types.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.1.1.2 | 06/15/2021 | New IHtmlHelper Extension Gravatar |


### Methods:
#### Gravatar(Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper,System.String,System.Nullable{System.Int32},Microsoft.AspNetCore.Mvc.Rendering.GravatarRating,Microsoft.AspNetCore.Mvc.Rendering.GravatarDefaultImage,System.Object)

Creates HTML for an <c>img</c> element that presents a Gravatar icon (https://en.gravatar.com/). <br /><br /> Original Developer: Ricardo Polo Jaramillo (https://stackoverflow.com/users/909974/ricardo-polo-jaramillo) <br /><br /> Original Source: https://stackoverflow.com/a/3561841/8041900

|Parameters| |
| - | - |
|html|The <see cref="IHtmlHelper"/> upon which this extension method is provided.|
|email|The email address used to identify the icon.|
|size|An optional parameter that specifies the size of the square image in pixels.|
|rating|An optional parameter that specifies the safety level of allowed images.|
|defaultImage|An optional parameter that controls what image is displayed for email addresses that don't have associated Gravatar icons.|
|htmlAttributes|An optional parameter holding additional attributes to be included on the img element.|

#### Returns:
An HTML string of the img element that presents a Gravatar icon. 
## 

( [Home](Home) )


<a name='Microsoft.AspNetCore.Mvc.Rendering.GravatarRating'></a>

## Microsoft.AspNetCore.Mvc.Rendering.GravatarRating
GravatarRating Enumeration



|Fields| |
| - | - |
|Default||
|G||
|Pg||
|R||
|X||


( [Home](Home) )


<a name='Microsoft.AspNetCore.Mvc.Rendering.GravatarDefaultImage'></a>

## Microsoft.AspNetCore.Mvc.Rendering.GravatarDefaultImage
GravatarDefaultImage Enumeration



|Fields| |
| - | - |
|Default||
|Http404||
|MysteryMan||
|Identicon||
|MonsterId||
|Wavatar||


( [Home](Home) )


<a name='System.Net.IPAddressExtensions'></a>

## System.Net.IPAddressExtensions
Extension methods for existing IPAddress types.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 09/29/2020 | Initial build |


### Methods:
#### GetRemoteAddress(this IPAddress ipAddress)

Method to return IPAddress of reomote address of supplied HttpRequest

|Parameters| |
| - | - |
|ipAddress|this IPAddress|
|request|HttpRequest|

#### Returns:
IPAddress 
## 
#### IsInternalRequest(this IPAddress ipAddress)

An extension method to determine if an IP address is internal, as specified in RFC1918

|Parameters| |
| - | - |
|ipAddress|The IP address that will be tested|

#### Returns:
Returns true if the IP is internal, false if it is external 
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Html.StatusCodes'></a>

## CDCavell.ClassLibrary.Web.Html.StatusCodes
Class for returning defintion of given Html status code

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 09/29/2020 | Initial build |


### Methods:
#### GetCodeDefinition(int code)



|Parameters| |
| - | - |
|code|int|

#### Returns:
KeyValuePair\<int, string\> 
## 
#### ToString(int code)



|Parameters| |
| - | - |
|code|int|

#### Returns:
string 
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Html.Tags'></a>

## CDCavell.ClassLibrary.Web.Html.Tags
Class to return string of Html tag.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 09/29/2020 | Initial build |


### Methods:
#### LineBreak()

Method to return one new line

#### Returns:
string 
## 
#### LineBreak(int count)

Method to return multple new lines

|Parameters| |
| - | - |
|count|int|

#### Returns:
string 
## 
#### Space()

Method to return one space

#### Returns:
string 
## 
#### Space(int count)

Method to return multipe spaces

|Parameters| |
| - | - |
|count|int|

#### Returns:
string 
## 
#### Brackets(string item)

Method to wrap given string in brakets

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Bold(string item)

Method to wrap given string in bold tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Italic(string item)

Method to wrap given string in italic tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Important(string item)

Method to wrap given string in strong tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Emphasized(string item)

Method to wrap given string in em tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Marked(string item)

Method to wrap given string in mark tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Small(string item)

Method to wrap given string in small tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Deleted(string item)

Method to wrap given string in del tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Inserted(string item)

Method to wrap given string in ins tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Subscript(string item)

Method to wrap given string in sub tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Superscript(string item)

Method to wrap given string in sup tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Quote(string item)

Method to wrap given string in q tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### BlockQuote(string item, string cite)

Method to wrap given string in blockquote tags with given citing

|Parameters| |
| - | - |
|item|string|
|cite|string|

#### Returns:
string 
## 
#### Abbreviation(string item)

Method to wrap given string in abbr tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Address(string item)

Method to wrap given string in address tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Cite(string item)

Method to wrap given string in cite tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### BidirectionalOverride(string item)

Method to wrap given string in bdo tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 
#### Paragraph(string item)

Method to wrap given string in p tags

|Parameters| |
| - | - |
|item|string|

#### Returns:
string 
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Http.ApplicationCookie'></a>

## CDCavell.ClassLibrary.Web.Http.ApplicationCookie
Cookie class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 09/29/2020 | Initial build |


### Methods:
#### ApplicationCookie(IHttpContextAccessor httpContextAccessor)

Initializes a new instance reading, writing or removing cookie
## 
#### ApplicationCookie(IHttpContextAccessor httpContextAccessor, CookieOptions cookieOptions)

Initializes a new instance reading, writing or removing cookie
## 
#### GetValue(string cookieKey, string key)

Method to return value for given key in dictonary stored in cookie

|Parameters| |
| - | - |
|cookieKey|string|
|key|string|

#### Returns:
string 

#### Exceptions:
 ( Requires HttpRequest )
## 
#### GetAllValues(string sessionkey)

Method to return dictionary of values for given key stored in cookie

|Parameters| |
| - | - |
|cookieKey|string|

#### Returns:
Dictionary<string, string%gt; 

#### Exceptions:
 ( Requires HttpRequest )
## 
#### SetValue(string cookiekey, string key, string value)

Method to save a record in a dictonary of key value records in cookie

|Parameters| |
| - | - |
|cookieKey|string|
|key|string|
|value|string|

#### Exceptions:
 ( Requires HttpRequest and HttpResponse )
## 
#### SetAllValues(string cookiekey, Dictionary<string, string>)

Method to save a dictonary of key value records in cookie

|Parameters| |
| - | - |
|cookieKey|string|
|values|Dictionary<string, string>|

#### Exceptions:
 ( Requires HttpRequest and HttpResponse )
## 
#### Remove(string cookiekey)

Delete the cookie

|Parameters| |
| - | - |
|cookieKey|string|

#### Exceptions:
 ( Requires HttpResponse )
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Http.FormPost'></a>

## CDCavell.ClassLibrary.Web.Http.FormPost
Class to post form data to given Respose object

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/31/2021 | Initial build Authorization Service |


### Methods:
#### FormPost(HttpResponse response)

Constructor method

|Parameters| |
| - | - |
|response|HttpResponse|
## 
#### Add(List<KeyValuePair<string, string>> items)

Add form items

|Parameters| |
| - | - |
|items|List<KeyValuePair<string, string>>|
## 
#### Add(KeyValuePair<string, string> item)

Add form item

|Parameters| |
| - | - |
|item|KeyValuePair<string, string>|
## 
#### Add(string key, string value)

Add form item

|Parameters| |
| - | - |
|key|string|
|value|string|
## 
#### Submit(string url)

Submit form to url

|Parameters| |
| - | - |
|url|string|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Http.JsonClient'></a>

## CDCavell.ClassLibrary.Web.Http.JsonClient
Http client to handle json requests. Each request defaults to one minute timeout and can be overriden with TimeOut property.


#### Example:

```

            JsonClient client = new JsonClient("https://SomeAPI.com");
            client.TimeOut = TimeSpan.FromMinutes(2);
            client.AddRequestHeader("MyHeader", "Some Custome Header String");
            
            HttpStatusCode statusCode = client.SendRequest(HttpMethod.Post, "APIService", "Request Content");
            if (client.IsResponseSuccess)
            {
                string response = client.GetResponseString();
                // or    
                MyObject myObject = client.GetResponseObject<MyObject>();    
            }
            
```
__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/12/2020 | Initial build |
| Christopher D. Cavell | 1.0.0.9 | 11/08/2020 | Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |
| Christopher D. Cavell | 1.0.1.0 | 11/25/2020 | Update: Target Framework netcoreapp3.1 to net5.0 |
| Christopher D. Cavell | 1.0.3.0 | 01/23/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | User Authorization Web Service |


|Properties| |
| - | - |
|StatusCode|HttpStatusCode|
|IsResponseSuccess|bool|
|TimeOut|TimeSpan|
|BearerToken|string|

### Methods:
#### JsonClient(string baseUrl)

Constructor method

|Parameters| |
| - | - |
|baseUrl|string|
## 
#### JsonClient(string baseUrl)

Constructor method

|Parameters| |
| - | - |
|baseUrl|string|
|bearerToken|string|
## 
#### SendRequest(HttpMethod httpMethod, string requestUri)

Send request ignoring self signed certificate errors

|Parameters| |
| - | - |
|httpMethod|HttpMethod|
|requestUri|string|

#### Returns:
Task<HttpStatusCode> 
## 
#### SendRequest(HttpMethod httpMethod, string requestUri, object content)

Send request ignoring self signed certificate errors

|Parameters| |
| - | - |
|httpMethod|HttpMethod|
|requestUri|string|
|content|object|

#### Returns:
Task<HttpStatusCode> 
## 
#### SendRequest(HttpMethod httpMethod, string requestUri, object content, bool ignoreSelfSignedError)

Send request

|Parameters| |
| - | - |
|httpMethod|HttpMethod|
|requestUri|string|
|content|object|
|ignoreSelfSignedError|bool|

#### Returns:
Task<HttpStatusCode> 
## 
#### GetResponseString()

Get response string

#### Returns:
string 
## 
#### GetResponseObject<T>()

Get response object

#### Returns:
T 
## 
#### AddRequestHeader(string name, string value)

Add request header

|Parameters| |
| - | - |
|name|string|
|value|value|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Controllers.ApiBaseController'></a>

## CDCavell.ClassLibrary.Web.Mvc.Controllers.ApiBaseController
Base controller class for api application

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.0 | 01/18/2021 | Initial build Authorization Service |


|Fields| |
| - | - |
|_logger|ILogger|
|_webHostEnvironment|IWebHostEnvironment|
|_httpContextAccessor|IWebHostEnvironment|

### Methods:
#### WebBaseController(ILogger<T> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Controllers.WebBaseController'></a>

## CDCavell.ClassLibrary.Web.Mvc.Controllers.WebBaseController
Base controller class for web application

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/12/2020 | Initial build |
| Christopher D. Cavell | 1.0.2.1 | 01/17/2021 | Handle HttpRequestException as http status instead of application exception |
| Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.2 | 06/12/2021 | Permission-Based Authorization |


|Fields| |
| - | - |
|_logger|ILogger|
|_webHostEnvironment|IWebHostEnvironment|
|_httpContextAccessor|IWebHostEnvironment|

### Methods:
#### WebBaseController(ILogger<T> logger, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)

Constructor method

|Parameters| |
| - | - |
|logger|ILogger|
|webHostEnvironment|IWebHostEnvironment|
|httpContextAccessor|IHttpContextAccessor|
## 
#### ValidateModel<M>(M model)

Global model validation method (View found in HomeSite.ClassLibrary.Razor)

|Parameters| |
| - | - |
|model|Model|

#### Returns:
KeyValuePair<int, string> 
## 
#### Error(System.Int32)

Global error handling

|Parameters| |
| - | - |
|id|int|

#### Returns:
IActionResult 
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Filters.ControllerActionLogFilter'></a>

## CDCavell.ClassLibrary.Web.Mvc.Filters.ControllerActionLogFilter
Action logging filter that runs before and after action method execution

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/12/2020 | Initial build |
| Christopher D. Cavell | 1.0.3.0 | 01/19/2021 | Initial build Authorization Service |


### Methods:
#### ControllerActionLogFilter(ILogger<ControllerActionLogFilter> logger, IHttpContextAccessor httpContextAccessor)

Initializes a new instance
## 
#### OnActionExecuting(ActionExecutingContext context)

Executes before action method execution

|Parameters| |
| - | - |
|context|ActionExecutingContext|
## 
#### OnActionExecuted(ActionExecutedContext context)

Executes after action method execution

|Parameters| |
| - | - |
|context|ActionExecutedContext|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Filters.ControllerActionPageFilter'></a>

## CDCavell.ClassLibrary.Web.Mvc.Filters.ControllerActionPageFilter
Action user filter that runs before and after action method execution

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/12/2020 | Initial build |


### Methods:
#### ControllerActionPageFilter(ILogger<ControllerActionPageFilter> logger, IHttpContextAccessor httpContextAccessor)

Initializes a new instance
## 
#### OnActionExecuting(ActionExecutingContext context)

Executes before action method execution

|Parameters| |
| - | - |
|context|ActionExecutingContext|
## 
#### OnActionExecuted(ActionExecutedContext context)

Executes after action method execution

|Parameters| |
| - | - |
|context|ActionExecutedContext|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Filters.ControllerActionUserFilter'></a>

## CDCavell.ClassLibrary.Web.Mvc.Filters.ControllerActionUserFilter
Action user filter that runs before and after action method execution

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/12/2020 | Initial build |


### Methods:
#### ControllerActionUserFilter()

Initializes a new instance
## 
#### OnActionExecuting(ActionExecutingContext context)

Executes before action method execution

|Parameters| |
| - | - |
|context|ActionExecutingContext|
## 
#### OnActionExecuted(ActionExecutedContext context)

Executes after action method execution

|Parameters| |
| - | - |
|context|ActionExecutedContext|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings'></a>

## CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings
AppSettings model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Service |
| Christopher D. Cavell | 1.0.4.2 | 03/16/2021 | Email verification |


|Properties| |
| - | - |
|AssemblyName|string|
|AssemblyVersion|string|
|LastModifiedDate|DateTime|
|SecretKey|string|
|SiteAdministrator|SiteAdministrator|
|Authentication|Authentication|
|Authorization|Authorization|
|ConnectionStrings|ConnectionStrings|
|EmailService|EmailService|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.Authentication'></a>

## CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.Authentication
Authentication model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Service |


|Properties| |
| - | - |
|IdP|IdP|
|reCAPTCHA|reCAPTCHA|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.Authorization'></a>

## CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.Authorization
Authorization model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Service |


|Properties| |
| - | - |
|AuthorizationService|AuthorizationService|
||string|
||string|
||string|
||string|
||string|
||string|
||string|
||string|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.AuthorizationService'></a>

## CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.AuthorizationService
AuthorizationService model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Service |
| Christopher D. Cavell | 1.1.2.0 | 07/05/2021 | SignalR streaming |


|Properties| |
| - | - |
|API|string|
|UI|string|
|Main|string|
|RTC|string|
|ApiTrim|string|
|UiTrim|string|
|MainTrim|string|
|RtcTrim|string|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.ConnectionStrings'></a>

## CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.ConnectionStrings
ConnectionStrings model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Service |


|Properties| |
| - | - |
|AuthorizationConnection|string|
|ApplicationInsightsConnection|string|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.EmailService'></a>

## CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.EmailService
Site Administrator model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.4.2 | 03/16/2021 | Email verification |


|Properties| |
| - | - |
|Host|string|
|Port|int|
|EnableSsl|bool|
|UserId|string|
|Password|string|
|Email|string|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.IdP'></a>

## CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.IdP
IdP Model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Service |


|Properties| |
| - | - |
|Authority|string|
|ClientId|string|
|ClientSecret|string|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.reCAPTCHA'></a>

## CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.reCAPTCHA
reCAPTCHA Authentication model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Service |


|Properties| |
| - | - |
|SiteKey|string|
|SecretKey|string|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.SiteAdministrator'></a>

## CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings.SiteAdministrator
Site Administrator model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Service |


|Properties| |
| - | - |
|Email|string|
|FirstName|string|
|LastName|string|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Models.ErrorViewModel'></a>

## CDCavell.ClassLibrary.Web.Mvc.Models.ErrorViewModel
Error view model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 09/29/2020 | Initial build |


|Properties| |
| - | - |
|StatusCode|int|
|StatusMessage|string|
|Exception|Exception|
|RequestId|string|

### Methods:
#### ErrorViewModel(int statusCode)

Constructor method

|Parameters| |
| - | - |
|statusCode|int|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Models.PageViewModel'></a>

## CDCavell.ClassLibrary.Web.Mvc.Models.PageViewModel
Page view model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 09/29/2020 | Initial build |


|Properties| |
| - | - |
|ReturnURL|string|
|RequestId|string|
|ErrorMessage|string|
|ShowRequestId|bool|
|IsError|bool|
|Controller|string|
|Action|string|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Mvc.Models.UserViewModel'></a>

## CDCavell.ClassLibrary.Web.Mvc.Models.UserViewModel
User view model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 09/29/2020 | Initial build |


|Properties| |
| - | - |
|IsAuthenticated|string|
|Id|string|
|Name|string|
|Email|string|
|Roles|List<string>|
|IPAddress|IPAddress|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Security.AESGCM'></a>

## CDCavell.ClassLibrary.Web.Security.AESGCM
This work (Modern Encryption of a String C#, by James Tuley), identified by James Tuley, is free of known copyright restrictions. <br />https://gist.github.com/4336842 <br />http://creativecommons.org/publicdomain/mark/1.0/

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 05/16/2020 | Initial build |
| Christopher D. Cavell | 1.0.3.0 | 01/23/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.0.3.3 | 03/08/2021 | User Authorization Web Service |


|Fields| |
| - | - |
|NonceBitSize|int|
|MacBitSize|int|
|KeyBitSize|int|
|SaltBitSize|int|
|Iterations|int|
|MinPasswordLength|int|

### Methods:
#### NewKey

Helper that generates a random new key on each call.

#### Returns:
byte[] 
## 
#### SimpleEncrypt(System.String,System.Byte[],System.Byte[])

Simple Encryption And Authentication (AES-GCM) of a UTF8 string.

|Parameters| |
| - | - |
|secretMessage|The secret message.|
|key|The key.|
|nonSecretPayload|Optional non-secret payload.|

#### Returns:
Encrypted Message 

#### Exceptions:
System.ArgumentException ( Secret Message Required!;secretMessage )
## 
#### SimpleDecrypt(System.String,System.Byte[],System.Int32)

Simple Decryption and Authentication (AES-GCM) of a UTF8 Message

|Parameters| |
| - | - |
|encryptedMessage|The encrypted message.|
|key|The key.|
|nonSecretPayloadLength|Length of the optional non-secret payload.|

#### Returns:
Decrypted Message 
## 
#### SimpleEncryptWithPassword(System.String,System.String,System.Byte[])

Simple Encryption And Authentication (AES-GCM) of a UTF8 String using key derived from a supplied password (PBKDF2).

|Parameters| |
| - | - |
|secretMessage|The secret message.|
|password|The password.|
|nonSecretPayload|The non secret payload.|

#### Returns:
Encrypted Message 
## 
#### SimpleDecryptWithPassword(System.String,System.String,System.Int32)

Simple Decryption and Authentication (AES-GCM) of a UTF8 message using a key derived from a supplied password (PBKDF2)

|Parameters| |
| - | - |
|encryptedMessage|The encrypted message.|
|password|The password.|
|nonSecretPayloadLength|Length of the non secret payload.|

#### Returns:
Decrypted Message 

#### Exceptions:
System.ArgumentException ( Encrypted Message Required!;encryptedMessage )
## 
#### SimpleEncrypt(System.Byte[],System.Byte[],System.Byte[])

Simple Encryption And Authentication (AES-GCM) of a UTF8 String using key derived from a default internal password (PBKDF2).

|Parameters| |
| - | - |
|secretMessage|byte[]|
|key|byte[]|
|nonSecretPayload|byte[]|

#### Returns:
Encrypted Message 
## 
#### SimpleDecrypt(System.Byte[],System.Byte[],System.Int32)

Simple Decryption and Authentication (AES-GCM) of a UTF8 message using a key derived from a default internal password (PBKDF2)

|Parameters| |
| - | - |
|encryptedMessage|byte[]|
|key|byte[]|
|nonSecretPayloadLength|int|

#### Returns:
Decrypted Message 

#### Exceptions:
System.ArgumentException ( Encrypted Message Required!;encryptedMessage )
## 
#### SimpleEncryptWithPassword(System.Byte[],System.String,System.Byte[])

Simple Encryption With Password

|Parameters| |
| - | - |
|secretMessage|byte[]|
|password|string|
|nonSecretPayload|byte[]|

#### Returns:
byte[] 
## 
#### SimpleDecryptWithPassword(System.Byte[],System.String,System.Int32)

Simple Decryption With Password

|Parameters| |
| - | - |
|encryptedMessage|byte[]|
|password|string|
|nonSecretPayloadLength|int|

#### Returns:
 
## 
#### Encrypt(string plainText)

Method to encrypt plain text string

|Parameters| |
| - | - |
|plainText|string|

#### Returns:
string 
## 
#### Encrypt(string plainText, string password)

Method to encrypt plain text string with given password

|Parameters| |
| - | - |
|plainText|string|
|password|string|

#### Returns:
string 
## 
#### Decrypt(string encryptedText)

Method to decrypt encrypted string to plain text

|Parameters| |
| - | - |
|encryptedText|string|

#### Returns:
string 
## 
#### Decrypt(string encryptedText, string password)

Method to decrypt encrypted string to plain text with given password

|Parameters| |
| - | - |
|encryptedText|string|
|password|string|

#### Returns:
string 
## 
#### Seed(IConfiguration configuration)

Method to seed internal password with SecretKey from AppSettings:Application:SecretKey value in appsettings.json <br />https://www.random.org/cgi-bin/randbyte?nbytes=21&format=d

|Parameters| |
| - | - |
|secretKey|string|

#### Exceptions:
System.ArgumentNullException (  )
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Security.Nonce'></a>

## CDCavell.ClassLibrary.Web.Security.Nonce
Nonce - random value used to thwart replay attacks.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/15/2020 | Initial build |


### Methods:
#### Calculate

Generates random value used to thwart replay attacks.

#### Returns:
string 
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Security.RsaKeyService'></a>

## CDCavell.ClassLibrary.Web.Security.RsaKeyService
RsaKeyService to generate signing credentials as outlined by [Ikechi Michael's](https://gist.github.com/mykeels) posting: <br /> [For IdentityServer4's AddSigningCredentials in production](https://gist.github.com/mykeels/408a26fb9411aff8fb7506f53c77c57a)

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/01/2020 | Initial build |


### Methods:
#### RsaKeyService(IWebHostEnvironment environment, TimeSpan timeSpan)

Class Constructor

|Parameters| |
| - | - |
|environment|IWebHostEnvironment|
|timeSpan|TimeSpan|
## 
#### NeedsUpdate()

Does key need to be updated

#### Returns:
bool 
## 
#### GetRandomKey()

Get randome key

#### Returns:
RSAParameters 
## 
#### GenerateKeyAndSave(bool forceUpdate = false)

Generate and save key

|Parameters| |
| - | - |
|forceUpdate|bool|

#### Returns:
RsaKeyService 
## 
#### GetKeyParameters()

Get key parameters

#### Returns:
RSAParameters 
## 
#### GetKey()

Get key

#### Returns:
RsaSecurityKey 
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Security.RsaKeyService.RSAParametersWithPrivate'></a>

## CDCavell.ClassLibrary.Web.Security.RsaKeyService.RSAParametersWithPrivate
Util class to allow restoring RSA parameters from JSON as the normal RSA parameters class won't restore private key info.




( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Utilities.BingWebmaster'></a>

## CDCavell.ClassLibrary.Web.Utilities.BingWebmaster
Microsoft Bing Webmaster class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | User Authorization Web Service |


### Methods:
#### BingWebmaster(string apiKey)

Constructor method

|Parameters| |
| - | - |
|apiKey|string|
## 
#### BingWebmaster(string apiKey)

Get url submission quota

#### Returns:
Task<UrlSubmissionQuota> 
## 
#### SubmitUrl(string siteUrl, string submitUrl)

Submit url to Bing

|Parameters| |
| - | - |
|siteUrl|string|
|submitUrl|string|

#### Returns:
Task<HttpStatusCode> 
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Utilities.BingWebSearch'></a>

## CDCavell.ClassLibrary.Web.Utilities.BingWebSearch
Microsoft Bing Custom Search class

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.8 | 11/01/2020 | Bing Search APIs will transition from Azure Cognitive Services to Azure Marketplace on 31 October 2023 [#152](https://github.com/cdcavell/cdcavell.name/issues/152) |
| Christopher D. Cavell | 1.0.3.1 | 02/07/2021 | User Authorization Web Service |


### Methods:
#### BingWebSearch(string subscriptionKey, string customConfigId)

Constructor method

|Parameters| |
| - | - |
|subscriptionKey|string|
|customConfigId|string|
## 
#### Search(string searchType, string query)

Return Bing Web Search results

|Parameters| |
| - | - |
|searchType|string|
|query|string|

#### Returns:
Task<ResultModel> 

#### Exceptions:
System.Exception ( searchType - excepted (Web, Image or Video) )
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Utilities.Models.BingWebmasterModels.UrlSubmissionQuota'></a>

## CDCavell.ClassLibrary.Web.Utilities.Models.BingWebmasterModels.UrlSubmissionQuota
Microsoft Bing Webmaster Url Submission Quota

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.7 | 10/31/2020 | Integrate Bing’s Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |


|Properties| |
| - | - |
|__type|string|
|DailyQuota|int|
|MonthlyQuota|int|
|StatusCode|HttpStatusCode|
|StatusMessage|string|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Utilities.Models.BingWebSearchModels.ItemModel'></a>

## CDCavell.ClassLibrary.Web.Utilities.Models.BingWebSearchModels.ItemModel
Item Model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.8 | 11/01/2020 | Bing Search APIs will transition from Azure Cognitive Services to Azure Marketplace on 31 October 2023 [#152](https://github.com/cdcavell/cdcavell.name/issues/152) |


|Properties| |
| - | - |
|Name|string|
|Description|string|
|Snippet|string|
|DatePublished|DateTime|
|DatePublishedFormated|string|
|DateLastCrawled|DateTime|
|DateLastCrawledFormated|string|
|isFamilyFriendly|bool|
|Url|string|
|DisplayUrl|string|
|ContentUrl|string|
|HostPageUrl|string|
|ThumbnailUrl|string|
|EncodingFormat|string|


( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Utilities.Models.BingWebSearchModels.ResultModel'></a>

## CDCavell.ClassLibrary.Web.Utilities.Models.BingWebSearchModels.ResultModel
Result Model

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.8 | 11/01/2020 | Bing Search APIs will transition from Azure Cognitive Services to Azure Marketplace on 31 October 2023 [#152](https://github.com/cdcavell/cdcavell.name/issues/152) |


|Properties| |
| - | - |
|StatusCode|HttpStatusCode|
|StatusMessage|string|
|MaxResults|int|
|DisplayCount|int|
|PageNumber|int|
|TotalPages|int|
|Items|List<ItemModel>|
|Type|string - excepted values (Web, Image or Video)|

### Methods:
#### public ResultModel(string type)

Constructor method

|Parameters| |
| - | - |
|type|string|
## 

( [Home](Home) )

