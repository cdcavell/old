﻿# [cdcavell.name](https://cdcavell.name)
Personal Website for Christopher D. Cavell
<hr />

[![GitHub license](https://img.shields.io/github/license/cdcavell/cdcavell.name)](https://github.com/cdcavell/cdcavell.name/blob/main/LICENSE)
![GitHub tag (latest by date)](https://img.shields.io/github/v/tag/cdcavell/cdcavell.name)
![GitHub top language](https://img.shields.io/github/languages/top/cdcavell/cdcavell.name)
![GitHub language count](https://img.shields.io/github/languages/count/cdcavell/cdcavell.name)
[![CodeQL Analysis](https://github.com/cdcavell/cdcavell.name/workflows/CodeQL%20Analysis/badge.svg)](https://github.com/cdcavell/cdcavell.name/actions?query=workflow%3A%22CodeQL+Analysis%22)
[![W3C Validation](https://img.shields.io/w3c-validation/default?targetUrl=https%3A%2F%2Fcdcavell.name)](https://validator.nu/?doc=https%3A%2F%2Fcdcavell.name)
[![Security Headers](https://img.shields.io/security-headers?url=https%3A%2F%2Fcdcavell.name)](https://securityheaders.com/?q=https%3A%2F%2Fcdcavell.name)

<hr />

Project incorporates generation of markdown files in Documentation folder, during project builds, from comment syntax of source code, through console application XmlToMarkdown. Documentation changes are maintained in a [wiki submodule](https://brendancleary.com/2013/03/08/including-a-github-wiki-in-a-repository-as-a-submodule/) that is also updated during project build.

Target Frameworks are [ASP.NET Core 5.0](https://dotnet.microsoft.com/download/dotnet/5.0) and [.NET Standard 2.1](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) respectfully. Developed and built in a Windows environment utilizing [Visual Studio Community 2019 ](https://visualstudio.microsoft.com/vs/) source-code editor. Repository is [Git](https://git-scm.com/) utilizing [git-flow](https://danielkummer.github.io/git-flow-cheatsheet/) extention to provide high-level repository operations for [Vincent Driessen's branching model](https://nvie.com/posts/a-successful-git-branching-model/).

This work is [licensed](https://github.com/cdcavell/cdcavell.name/blob/main/LICENSE) under the [MIT License](https://opensource.org/licenses/MIT), with the exception of Duende&trade; IdentityServer software libraries which are licensed under the [Duende&trade; Software License Agreement](https://duendesoftware.com/license/identityserver.pdf). All other software libraries are licensed under their respective license agreements. Source Code documentation is found in repository [Wiki](https://github.com/cdcavell/cdcavell.name/wiki) section. 

<hr />

_If you are cloning this repository, please enter commands as follows:_

```
$ git clone --recurse-submodules https://github.com/cdcavell/cdcavell.name.git

$ cd cdcavell.name

$ git flow init -d
```

<hr />

## Donation ##
You can show your support to this project by making a donation via PayPal

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/donate?hosted_button_id=96LQH846TE2E2)

<hr />

[__Website__](https://cdcavell.name) deployment 

| Build | Date | Description |
|-------|------|-------------|
| 1.1.2.0 | 07/28/2021 | __Add:__ SignalR streaming <br/>__Update:__ App Services Action Build And Deployment Pipeline <br/>__Update:__ Migrate to AWS Lightsail <br />__Update:__ Dependency update |
| 1.1.1.5 | 07/05/2021 | __Add:__ Microsoft Clarity <br />__Add:__ Google Analytics |
| 1.1.1.4 | 07/03/2021 | __Add:__ Permission-Based Authorization <br />__Revert:__ ASP.NET Core 5.0 <br />__Update:__ Dependency update <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.JwtBearer 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.IdentityModel.Protocols 6.7.1_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.IdentityModel.Protocols.OpenIdConnect 6.7.1_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.OpenIdConnect 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Cryptography.Internal 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Cryptography.KeyDerivation 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Identity.EntityFrameworkCore 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Identity.Core 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Identity.Stores 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Logging.Abstractions 5.0.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Data.Sqlite.Core 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.DotNet.PlatformAbstractions 3.1.6_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Sqlite 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Sqlite.Core 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.DependencyModel 5.0.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_SQLitePCLRaw.bundle_e_sqlite3 2.0.4_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_SQLitePCLRaw.core 2.0.4_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_SQLitePCLRaw.lib.e_sqlite3 2.0.4_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_SQLitePCLRaw.provider.dynamic_cdecl 2.0.4_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.Text.Encodings.Web 5.0.1_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.Text.Json 5.0.1_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Tools 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.CSharp 4.7.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Design 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Relational 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Configuration.Abstractions 5.0.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Abstractions 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Analyzers 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Caching.Abstractions 5.0.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Caching.Memory 5.0.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.DependencyInjection 5.0.1_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.DependencyInjection.Abstractions 5.0.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Logging 5.0.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Logging.Abstractions 5.0.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Options 5.0.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Primitives 5.0.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.Collections.Immutable 5.0.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.ComponentModel.Annotations 5.0.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.Diagnostics.DiagnosticSource 5.0.1_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.Memory 4.5.3_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Facebook 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Google 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.MicrosoftAccount 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Twitter 5.0.7_ |
| 1.1.1.3 | 06/30/2021 | __Fix:__ Domain Mapper and Regular Expression <br />__Update:__ ASP.NET Core 6.0 Preview <br />__Update:__ Dependency update <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.OpenIdConnect 6.0.0-preview.5.21301.17_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.CSharp 4.5.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Data.Sqlite.Core 6.0.0-preview.5.21301.9_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore 6.0.0-preview.5.21301.9_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Abstractions 6.0.0-preview.5.21301.9_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Analyzers 6.0.0-preview.5.21301.9_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Design 6.0.0-preview.5.21301.9_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Relational 6.0.0-preview.5.21301.9_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Sqlite 6.0.0-preview.5.21301.9_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Sqlite.Core 6.0.0-preview.5.21301.9_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Tools 6.0.0-preview.5.21301.9_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Caching.Abstractions 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Caching.Memory 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Configuration.Abstractions 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.DependencyInjection 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.DependencyInjection.Abstractions 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.DependencyModel 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Logging 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Logging.Abstractions 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Options 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Primitives 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.IdentityModel.Protocols 6.10.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.IdentityModel.Protocols.OpenIdConnect 6.10.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_SQLitePCLRaw.bundle_e_sqlite3 2.0.5-pre20210119130047_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_SQLitePCLRaw.core 2.0.5-pre20210119130047_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_SQLitePCLRaw.lib.e_sqlite3 2.0.5-pre20210119130047_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_SQLitePCLRaw.provider.dynamic_cdecl 2.0.5-pre20210119130047_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.Buffers 4.5.1_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.Collections.Immutable 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.ComponentModel.Annotations 4.5.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.Diagnostics.DiagnosticSource 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.Memory 4.5.4_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.Runtime.CompilerServices.Unsafe 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.Text.Encodings.Web 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.Text.Json 6.0.0-preview.5.21301.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.JwtBearer 6.0.0-preview.5.21301.17_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Cryptography.Internal 6.0.0-preview.5.21301.17_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Cryptography.KeyDerivation 6.0.0-preview.5.21301.17_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.Numerics.Vectors 4.4.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Facebook 6.0.0-preview.5.21301.17_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Google 6.0.0-preview.5.21301.17_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.MicrosoftAccount 6.0.0-preview.5.21301.17_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Twitter 6.0.0-preview.5.21301.17_ |
| 1.1.1.2 | 06/20/2021 | __Add:__ Permission-Based Authorization <br />__Add:__ New IHtmlHelper Extension Gravatar <br />__Update:__ Terms Of Service <br />__Update:__ Privacy Policy <br />__Update:__ Twitter Card <br />__Update:__ Dependency update <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.JwtBearer v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Cryptography.Internal v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Cryptography.KeyDerivation v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Identity.EntityFrameworkCore v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Data.Sqlite.Core v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Abstractions v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Analyzers v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Design v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Relational v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Sqlite v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Sqlite.Core v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Tools v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Identity.Core v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Identity.Stores v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.OpenIdConnect v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Facebook v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Google v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.MicrosoftAccount v 5.0.7_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Twitter v 5.0.7_ |
| 1.1.1.1 | 06/07/2021 | __Add:__ Permission-Based Authorization <br />__Update:__ Dependency update <br />&nbsp;&nbsp;&nbsp;&nbsp;_Duende.IdentityServer v 5.2.1_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Duende.IdentityServer.AspNetIdentity v 5.2.1_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_AspNet.Security.OAuth.GitHub v 5.0.6_ |
| 1.1.1.0 | 05/16/2021 | __Add:__ Permission-Based Authorization <br />__Update:__ CVE-2020-7729 security vulnerability <br />__Update:__ Dependency update <br />&nbsp;&nbsp;&nbsp;&nbsp;_Duende.IdentityServer v 5.2.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Duende.IdentityServer.AspNetIdentity v 5.2.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_System.IdentityModel.Tokens.Jwt v 6.11.0_ |
| 1.1.0.0 | 03/28/2021 | __Update:__ Integrate ASP.NET Core Identity |
| 1.0.4.3 | 03/20/2021 | __Add:__ 2FA using TOTP |
| 1.0.4.2 | 03/16/2021 | __Add:__ Email verification |
| 1.0.4.1 | 03/15/2021 | __Update:__ Dependency update <br />&nbsp;&nbsp;&nbsp;&nbsp;_AspNet.Security.OAuth.GitHub v5.0.2_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Facebook v5.0.4_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Google v5.0.4_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.MicrosoftAccount v5.0.4_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Twitter v5.0.4_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.JwtBearer v5.0.4_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.OpenIdConnect v5.0.4_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore v5.0.4_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Design v5.0.4_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Sqlite v5.0.4_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Tools v5.0.4_ |
| 1.0.4.0 | 03/15/2021 | __Fix:__ EntityFramework NetCore Migrations <br /> __Add:__ New IdToken Field |
| 1.0.3.3 | 03/12/2021 | __Update:__ User Authorization Web Service <br /> __Update:__ Dependency update <br />&nbsp;&nbsp;&nbsp;&nbsp;_Duende.IdentityServer v5.0.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Duende.IdentityServer.Storage v5.0.5_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Duende.IdentityServer.AspNetIdentity v5.0.5_ |
| 1.0.3.2 | 02/20/2021 | __Update:__ Dependency update <br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.Extensions.Logging.ApplicationInsights v2.17.0_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Duende.IdentityServer v5.0.4_ <br />&nbsp;&nbsp;&nbsp;&nbsp;_Duende.IdentityServer.AspNetIdentity v5.0.4_ |
| 1.0.3.1 | 02/09/2021 | __Update:__ User Authorization Web Service |
| 1.0.3.0 | 02/06/2021 | __Add:__ Initial build Authorization Service |
| 1.0.2.3 | 01/21/2021 | __Update:__ Update Duende software libraries v5.0.1 |
| 1.0.2.2 | 01/18/2021 | __Update:__ Convert GrantType from Implicit to Pkce |
| 1.0.2.1 | 01/17/2021 | __Update:__ Handle HttpRequestException as http status instead of application exception |
| 1.0.2.0 | 01/16/2021 | __Add:__ Initial build Duende IdentityServer5 |
| 1.0.1.3 | 01/16/2021 | __Update:__ Change wiki submodule branch from main to master <br />  __Update:__ Dependency update<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Facebook v5.0.2_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Google v5.0.2_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.MicrosoftAccount v5.0.2_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.Twitter v5.0.2_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Identity.EntityFrameworkCore v5.0.2_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore v5.0.2_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Sqlite v5.0.2_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.EntityFrameworkCore.Tools v5.0.2_<br />&nbsp;&nbsp;&nbsp;&nbsp;_Microsoft.AspNetCore.Authentication.OpenIdConnect v5.0.2_ |
| 1.0.1.2 | 11/29/2020 | __Update:__ Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) |
| 1.0.1.1 | 11/27/2020 | __Update:__ Convert master repository to main |
| 1.0.1.0 | 11/27/2020 | __Update:__ Target Framework netcoreapp3.1 to net5.0 <br /> __Update:__ use cdcavell/automerge-action@v0.12.0 |
| 1.0.0.9 | 11/22/2020 | __Add:__ Implement Registration/Roles/Permissions [#183](https://github.com/cdcavell/cdcavell.name/issues/183) <br /> __Add:__ Blog Site link <br /> __Fix:__ Meta description length <br /> __Add:__ Ping Google with the location of sitemap <br /> __Update:__ allowed-branch version |
| 1.0.0.8 | 11/01/2020 | __Update:__ Bing Search APIs will transition from Azure Cognitive Services to Azure Marketplace on 31 October 2023 [#152](https://github.com/cdcavell/cdcavell.name/issues/152) |
| 1.0.0.7 | 10/31/2020 | __Fix:__ Eliminate render-blocking resources [#171](https://github.com/cdcavell/cdcavell.name/issues/171) <br /> __Fix:__ Serve static assets with an efficient cache policy [#172](https://github.com/cdcavell/cdcavell.name/issues/172) <br /> __Add:__ Integrate Bing's Adaptive URL submission API with your website [#144](https://github.com/cdcavell/cdcavell.name/issues/144) |
| 1.0.0.6 | 10/31/2020 | __Update:__ Convert Sitemap class to build sitemap.xml dynamic based on existing controllers in project [#145](https://github.com/cdcavell/cdcavell.name/issues/145) |
| 1.0.0.5 | 10/31/2020 | __Add:__ EU General Data Protection Regulation (GDPR) support in ASP.NET Core [#161](https://github.com/cdcavell/cdcavell.name/issues/161) |
| 1.0.0.4 | 10/30/2020 | __Add:__ Enforce HTTPS in ASP.NET Core [#158](https://github.com/cdcavell/cdcavell.name/issues/158) |
| 1.0.0.3 | 10/30/2020 | __Fix:__ Addressed Issues [#142](https://github.com/cdcavell/cdcavell.name/issues/142) [#143](https://github.com/cdcavell/cdcavell.name/issues/143) [#146](https://github.com/cdcavell/cdcavell.name/issues/146) [#147](https://github.com/cdcavell/cdcavell.name/issues/147) [#150](https://github.com/cdcavell/cdcavell.name/issues/150) |
| 1.0.0.2 | 10/28/2020 | __Fix:__ Change twitter description in layout |
| 1.0.0.1 | 10/28/2020 | __Fix:__ Center Search Pagination |
| 1.0.0.0 | 10/28/2020 | __Initial Development__ |
