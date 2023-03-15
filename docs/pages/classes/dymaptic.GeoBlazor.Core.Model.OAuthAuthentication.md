---
layout: default
title: OAuthAuthentication
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Model](index.html#dymaptic.GeoBlazor.Core.Model 'dymaptic.GeoBlazor.Core.Model')

## OAuthAuthentication Class

A simple class for handling OAuth authentication.

```csharp
public class OAuthAuthentication : dymaptic.GeoBlazor.Core.Model.LogicComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [LogicComponent](dymaptic.GeoBlazor.Core.Model.LogicComponent.html 'dymaptic.GeoBlazor.Core.Model.LogicComponent') &#129106; OAuthAuthentication
### Constructors

<a name='dymaptic.GeoBlazor.Core.Model.OAuthAuthentication.OAuthAuthentication(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration)'></a>

## OAuthAuthentication(IJSRuntime, IConfiguration) Constructor

Default Constructor

```csharp
public OAuthAuthentication(Microsoft.JSInterop.IJSRuntime jsRuntime, Microsoft.Extensions.Configuration.IConfiguration config);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.OAuthAuthentication.OAuthAuthentication(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration).jsRuntime'></a>

`jsRuntime` [Microsoft.JSInterop.IJSRuntime](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSRuntime 'Microsoft.JSInterop.IJSRuntime')

Injected JavaScript Runtime reference

<a name='dymaptic.GeoBlazor.Core.Model.OAuthAuthentication.OAuthAuthentication(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration).config'></a>

`config` [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')

Injected configuration object
### Methods

<a name='dymaptic.GeoBlazor.Core.Model.OAuthAuthentication.EnsureLoggedIn()'></a>

## OAuthAuthentication.EnsureLoggedIn() Method

Ensures that the user is logged in. If not, it will attempt to log them in.

```csharp
public System.Threading.Tasks.Task EnsureLoggedIn();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Model.OAuthAuthentication.GetCurrentToken()'></a>

## OAuthAuthentication.GetCurrentToken() Method

Returns the current OAuth Token for use in requests.

```csharp
public System.Threading.Tasks.Task<string> GetCurrentToken();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A string containing the current OAuth Token.

<a name='dymaptic.GeoBlazor.Core.Model.OAuthAuthentication.Initialize()'></a>

## OAuthAuthentication.Initialize() Method

Initializes the OAuth Authentication component with the ArcGIS App ID.

```csharp
public System.Threading.Tasks.Task Initialize();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Model.OAuthAuthentication.IsLoggedIn()'></a>

## OAuthAuthentication.IsLoggedIn() Method

Tests to see if the user is logged in. True if yes, false if otherwise.

```csharp
public System.Threading.Tasks.Task<bool> IsLoggedIn();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns a boolean value indicating whether or not the user is logged in.

<a name='dymaptic.GeoBlazor.Core.Model.OAuthAuthentication.Login()'></a>

## OAuthAuthentication.Login() Method

Logs the user in.

```csharp
public System.Threading.Tasks.Task Login();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')
