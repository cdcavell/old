
<a name='CDCavell.ClassLibrary.Web.Services.AppSettings.AppSettingsService'></a>

## CDCavell.ClassLibrary.Web.Services.AppSettings.AppSettingsService
AppSettings Web Service

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.3 | 03/09/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.1.1.0 | 04/02/2021 | Permission-Based Authorization |
| Christopher D. Cavell | 1.1.2.0 | 07/05/2021 | SignalR streaming |


|Properties| |
| - | - |
||object|

### Methods:
#### UserAuthorizationService(ILogger<UserAuthorizationService> logger, IOptions<UserAuthorizationServiceOptions> options)

Constructor

|Parameters| |
| - | - |
|logger|ILogger<AppSettingsService>|
|options|IOptions<AppSettingsServiceOptions>|
## 
#### AssemblyName

Get AssemblyName value

#### Returns:
string 
## 
#### AssemblyVersion

Get AssemblyVersion value

#### Returns:
string 
## 
#### LastModifiedDate

Get LastModifiedDate value

#### Returns:
string 
## 
#### MainUrl

Get main site url value

#### Returns:
string 
## 
#### ApiUrl

Get api site url value

#### Returns:
string 
## 
#### AuthorizationUrl

Get authorization ui site url value

#### Returns:
string 
## 
#### RtcUrl

Get rtc site url value

#### Returns:
string 
## 
#### AddAppSettingsService(this IServiceCollection serviceCollection, Action<UserAuthorizationServiceOptions> options)

Add AppSettings Web Service Options Extention

|Parameters| |
| - | - |
|serviceCollection|IServiceCollection|
|options|Action<UserAuthorizationServiceOptions>|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Services.AppSettings.AppSettingsServiceOptions'></a>

## CDCavell.ClassLibrary.Web.Services.AppSettings.AppSettingsServiceOptions
AppSettings Service Options

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.3 | 03/09/2021 | User Authorization Web Service |


|Properties| |
| - | - |
|AppSettings|object|

### Methods:
#### AddAppSettingsService(this IServiceCollection serviceCollection, Action<UserAuthorizationServiceOptions> options)

Add AppSettings Web Service Options Extention

|Parameters| |
| - | - |
|serviceCollection|IServiceCollection|
|options|Action<UserAuthorizationServiceOptions>|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Services.AppSettings.AppSettingsServiceOptionsExtention'></a>

## CDCavell.ClassLibrary.Web.Services.AppSettings.AppSettingsServiceOptionsExtention
AppSettings Web Service Options Extension

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.3 | 03/09/2021 | User Authorization Web Service |


### Methods:
#### AddAppSettingsService(this IServiceCollection serviceCollection, Action<UserAuthorizationServiceOptions> options)

Add AppSettings Web Service Options Extention

|Parameters| |
| - | - |
|serviceCollection|IServiceCollection|
|options|Action<UserAuthorizationServiceOptions>|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Services.AppSettings.IAppSettingsService'></a>

## CDCavell.ClassLibrary.Web.Services.AppSettings.IAppSettingsService
AppSettings Web Service Interface

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.3.1 | 02/09/2021 | User Authorization Web Service |
| Christopher D. Cavell | 1.1.2.0 | 07/05/2021 | SignalR streaming |


### Methods:
#### AssemblyName

Get AssemblyName value

#### Returns:
string 
## 
#### AssemblyVersion

Get AssemblyVersion value

#### Returns:
string 
## 
#### LastModifiedDate

Get LastModifiedDate value

#### Returns:
string 
## 
#### MainUrl

Get main site url value

#### Returns:
string 
## 
#### ApiUrl

Get api site url value

#### Returns:
string 
## 
#### AuthorizationUrl

Get authorization ui site url value

#### Returns:
string 
## 
#### RtcUrl

Get rtc site url value

#### Returns:
string 
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Services.Email.EmailService'></a>

## CDCavell.ClassLibrary.Web.Services.Email.EmailService
Email Web Service

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.4.2 | 03/16/2021 | Email verification |
| Christopher D. Cavell | 1.1.0.0 | 03/26/2021 | Integrate ASP.NET Core Identity |


|Properties| |
| - | - |
|MailMessage|MailMessage|
||string|
||int|
||NetworkCredential|
||bool|

### Methods:
#### EmailService(ILogger<EmailService> logger, IOptions<EmailServiceOptions> options)

Constructor

|Parameters| |
| - | - |
|logger|ILogger<EmailService>|
|options|IOptions<EmailServiceOptions>|
## 
#### Send(System.Net.Mail.MailMessage)

Send mail message

|Parameters| |
| - | - |
|mailMessage|MailMessage|

#### Returns:
Task 

#### Exceptions:
System.Exception ( Invalid Property )
## 
#### AddAppSettingsService(this IServiceCollection serviceCollection, Action<UserAuthorizationServiceOptions> options)

Add Email Web Service Options Extention

|Parameters| |
| - | - |
|serviceCollection|IServiceCollection|
|options|Action<UserAuthorizationServiceOptions>|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Services.Email.EmailServiceOptions'></a>

## CDCavell.ClassLibrary.Web.Services.Email.EmailServiceOptions
Email Web Service Options

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.4.2 | 03/16/2021 | Email verification |


|Properties| |
| - | - |
|Host|string|
|Port|int|
|Credentials|NetworkCredential|
|EnableSsl|bool|

### Methods:
#### AddAppSettingsService(this IServiceCollection serviceCollection, Action<UserAuthorizationServiceOptions> options)

Add Email Web Service Options Extention

|Parameters| |
| - | - |
|serviceCollection|IServiceCollection|
|options|Action<UserAuthorizationServiceOptions>|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Services.Email.EmailServiceOptionsExtention'></a>

## CDCavell.ClassLibrary.Web.Services.Email.EmailServiceOptionsExtention
Email Web Service Options Extension

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.4.2 | 03/16/2021 | Email verification |


### Methods:
#### AddAppSettingsService(this IServiceCollection serviceCollection, Action<UserAuthorizationServiceOptions> options)

Add Email Web Service Options Extention

|Parameters| |
| - | - |
|serviceCollection|IServiceCollection|
|options|Action<UserAuthorizationServiceOptions>|
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Web.Services.Email.IEmailService'></a>

## CDCavell.ClassLibrary.Web.Services.Email.IEmailService
Email Web Service Interface

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.4.2 | 03/16/2021 | Email verification |


### Methods:
#### Send(System.Net.Mail.MailMessage)

Send mail message

|Parameters| |
| - | - |
|mailMessage|MailMessage|

#### Returns:
Task 
## 

( [Home](Home) )

