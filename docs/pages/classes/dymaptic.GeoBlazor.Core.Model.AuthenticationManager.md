---
layout: default
title: AuthenticationManager
parent: Classes
---
---
layout: default
title: AuthenticationManager
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Model](index.html#dymaptic.GeoBlazor.Core.Model 'dymaptic.GeoBlazor.Core.Model')

## AuthenticationManager Class

Manager for all authentication-related tasks, tokens, and keys

```csharp
public class AuthenticationManager
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AuthenticationManager
### Constructors

<a name='dymaptic.GeoBlazor.Core.Model.AuthenticationManager.AuthenticationManager(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration)'></a>

## AuthenticationManager(IJSRuntime, IConfiguration) Constructor

Default Constructor

```csharp
public AuthenticationManager(Microsoft.JSInterop.IJSRuntime jsRuntime, Microsoft.Extensions.Configuration.IConfiguration configuration);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.AuthenticationManager.AuthenticationManager(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration).jsRuntime'></a>

`jsRuntime` [Microsoft.JSInterop.IJSRuntime](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSRuntime 'Microsoft.JSInterop.IJSRuntime')

Injected JavaScript Runtime reference

<a name='dymaptic.GeoBlazor.Core.Model.AuthenticationManager.AuthenticationManager(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration).configuration'></a>

`configuration` [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')

Injected configuration object
### Properties

<a name='dymaptic.GeoBlazor.Core.Model.AuthenticationManager.ApiKey'></a>

## AuthenticationManager.ApiKey Property

Get or set the ArcGIS Application Api Key.

```csharp
public string? ApiKey { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Model.AuthenticationManager.AppId'></a>

## AuthenticationManager.AppId Property

Get or set the OAuth App ID.

```csharp
public string? AppId { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Model.AuthenticationManager.PortalUrl'></a>

## AuthenticationManager.PortalUrl Property

The ArcGIS Enterprise Portal URL, only required if using Enterprise authentication.

```csharp
public string? PortalUrl { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Model.AuthenticationManager.EnsureLoggedIn()'></a>

## AuthenticationManager.EnsureLoggedIn() Method

Ensures that the user is logged in. If not, it will attempt to log them in.

```csharp
public System.Threading.Tasks.Task EnsureLoggedIn();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Model.AuthenticationManager.GetArcGisJsInterop()'></a>

## AuthenticationManager.GetArcGisJsInterop() Method

Retrieves the correct copy of the ArcGisJsInterop based on the nuget package

```csharp
public System.Threading.Tasks.Task<Microsoft.JSInterop.IJSObjectReference> GetArcGisJsInterop();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Model.AuthenticationManager.GetCurrentToken()'></a>

## AuthenticationManager.GetCurrentToken() Method

Provides an implementation-agnostic way to fetch the current authentication token, whether it's an OAuth token or an API Key

```csharp
public System.Threading.Tasks.Task<string?> GetCurrentToken();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Model.AuthenticationManager.Initialize()'></a>

## AuthenticationManager.Initialize() Method

Initializes authentication based on either an OAuth App ID or an API Key. This is called automatically by [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') on first render, but can also be called manually for other actions such as rest calls.

```csharp
public System.Threading.Tasks.Task Initialize();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Model.AuthenticationManager.IsLoggedIn()'></a>

## AuthenticationManager.IsLoggedIn() Method

Tests to see if the user is logged in. True if yes, false if otherwise.

```csharp
public System.Threading.Tasks.Task<bool> IsLoggedIn();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns a boolean value indicating whether or not the user is logged in.

<a name='dymaptic.GeoBlazor.Core.Model.AuthenticationManager.Login()'></a>

## AuthenticationManager.Login() Method

Initiates an OAuth login flow

```csharp
public System.Threading.Tasks.Task Login();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

