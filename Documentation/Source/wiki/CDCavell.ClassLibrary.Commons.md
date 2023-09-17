
<a name='CDCavell.ClassLibrary.Commons.AsciiCodes'></a>

## CDCavell.ClassLibrary.Commons.AsciiCodes
Static class for converting ascii decimal value to string equivalent.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0 | 07/05/2020 | Initial build |


|Fields| |
| - | - |
|NUL|(null)|
|SOH|(start of heading)|
|STX|(start of text)|
|ETX|(end of text)|
|EOT|(end of transmission)|
|ENQ|(enquiry)|
|ACK|(acknowledge)|
|BEL|(bell)|
|BS|(backspace)|
|TAB|(horizontal tab)|
|LF|(NL line feed, new line)|
|VT|(vertical tab)|
|FF|(NP form feed, new page)|
|CR|(carriage return)|
|SO|(shift out)|
|SI|(shift in)|
|DLE|(data link escape)|
|DC1|(device control 1)|
|DC2|(device control 2)|
|DC3|(device control 3)|
|DC4|(device control 4)|
|NAK|(negative acknowledge)|
|SYN|(synchronous idle)|
|ETB|(end of trans. block)|
|CAN|(cancel)|
|EM|(end of medium)|
|SUB|(substitute)|
|ESC|(escape)|
|FS|(file separator)|
|GS|(group separator)|
|RS|(record separator)|
|US|(unit separator)|
|CRLF|(carriage return) + (NL line feed, new line)|

### Methods:
#### ToString(int dec)

Method to return string value of given ascii decimal

|Parameters| |
| - | - |
|dec|int|

#### Returns:
string 
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Commons.Logging.Logger'></a>

## CDCavell.ClassLibrary.Commons.Logging.Logger
Global application logger

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 07/05/2020 | Initial build |


### Methods:
#### Logger(ILogger logger)

Initialize logger class

|Parameters| |
| - | - |
|logger|ILogger|
## 
#### Information(string message)

Information logging

|Parameters| |
| - | - |
|message|string|
## 
#### Debug(string message)

Debug logging

|Parameters| |
| - | - |
|message|string|
## 
#### Debug(string message)

Debug logging

|Parameters| |
| - | - |
|message|string|
## 
#### Warning(string message)

Warning logging

|Parameters| |
| - | - |
|message|string|
## 
#### Critical(Exception exception, string message)

Warning logging

|Parameters| |
| - | - |
|exception|Exception|
|message|string|
## 
#### Exception(Exception exception, string message = null)

Exception logging

|Parameters| |
| - | - |
|exception|Exception|
|message|string|
## 
#### Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)

Implementation of ILogger method

|Parameters| |
| - | - |
|logLevel|LogLevel|
|eventId|EventId|
|state|TState|
|exception|Exception|
|formatter|Func<TState, Exception, string>|
## 
#### IsEnabled(LogLevel logLevel)

Implementation of ILogger method

|Parameters| |
| - | - |
|logLevel|LogLevel|

#### Returns:
bool 
## 
#### BeginScope<TState>(TState state)

Implementation of ILogger method

|Parameters| |
| - | - |
|state|TState|

#### Returns:
IDisposable 
## 

( [Home](Home) )


<a name='CDCavell.ClassLibrary.Commons.Xml.Transform'></a>

## CDCavell.ClassLibrary.Commons.Xml.Transform
Class to perform XSLT Transformation

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 07/05/2020 | Initial build |


### Methods:
#### Write(string inputXslt, string inputXml, string outputFile)

Method to perform XSLT Transformation and write out file

|Parameters| |
| - | - |
|inputXslt|string|
|inputXml|string|
|outputFile|string|
## 

( [Home](Home) )


<a name='System.DateTimeExtensions'></a>

## System.DateTimeExtensions
Extension methods for existing DateTime types.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 07/05/2020 | Initial build |


### Methods:
#### Timestamp(this DateTime value)

Method to return timestamp of current DateTime value

|Parameters| |
| - | - |
|value|this DateTime|

#### Returns:
string 
## 

( [Home](Home) )


<a name='System.Linq.EnumerableExtentions'></a>

## System.Linq.EnumerableExtentions
Extension methods for existing Enumerable types.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 07/05/2020 | Initial build |


### Methods:
#### DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)

Method to determine if string is a valid email address

|Parameters| |
| - | - |
|source|this IEnumerable<TSource>|
|keySelector|Func<TSource, TKey>|

#### Returns:
IEnumerable<TSource> 
## 

( [Home](Home) )


<a name='System.IntegerExtensions'></a>

## System.IntegerExtensions
Extension methods for existing Integer types.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 07/08/2020 | Initial build |


### Methods:
#### Length(this int n)

Method to return number of didgits in n

|Parameters| |
| - | - |
|n|this int|

#### Returns:
int 
## 
#### ToArray(this int n)

Method to return int[] of n

|Parameters| |
| - | - |
|n|this int|

#### Returns:
int[] 
## 

( [Home](Home) )


<a name='System.StringExtensions'></a>

## System.StringExtensions
Extension methods for existing string types.

__Revisions:__

| Contributor | Build | Revison Date | Description |
|-------------|-------|--------------|-------------|
| Christopher D. Cavell | 1.0.0.0 | 10/11/2020 | Initial build |
| Christopher D. Cavell | 1.0.3.0 | 02/01/2021 | Initial build Authorization Service |
| Christopher D. Cavell | 1.1.0.0 | 03/26/2021 | Integrate ASP.NET Core Identity |
| Christopher D. Cavell | 1.1.1.2 | 06/15/2021 | New IHtmlHelper Extension Gravatar |
| Christopher D. Cavell | 1.1.1.3 | 06/28/2021 | Fix Domain Mapper and Regular Expression |


### Methods:
#### IsValidEmail(this string value)

Method to determine if string is a valid email address

|Parameters| |
| - | - |
|value|this string|

#### Returns:
bool 
## 
#### Clean(this string value)

Method to remove "Carriage Return" and "Line Feed" as well as Html filtering to provide proper neutralization.

|Parameters| |
| - | - |
|value|this string|

#### Returns:
string 
## 
#### IsValidGuid(this string value)

Method to determine if string is a valid Guid

|Parameters| |
| - | - |
|value|this string|

#### Returns:
bool 
## 
#### CleanJsonResult(this string result)

Strip escape slash and beginning/ending quotes from Json result string

|Parameters| |
| - | - |
|value|this string|

#### Returns:
string 
## 
#### TrimEnd(this string input, string suffixToRemove, StringComparison comparisonType = StringComparison.CurrentCulture)

Strip suffix from end of string

|Parameters| |
| - | - |
|input|this string|
|suffixToRemove|string|
|comparisonType|StringComparison|

#### Returns:
string 
## 
#### TrimFromFirstChar(this string input, char startTrim)

Strip all from end of string starting at first char

|Parameters| |
| - | - |
|input|this string|
|startTrim|string|

#### Returns:
string 
## 
#### UTF8(this string input)

UTF8 Encoding

|Parameters| |
| - | - |
|input|this string|

#### Returns:
string 
## 

( [Home](Home) )

