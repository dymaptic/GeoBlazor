---
layout: default
title: LogicComponent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Model](index.html#dymaptic.GeoBlazor.Core.Model 'dymaptic.GeoBlazor.Core.Model')

## LogicComponent Class

A base class for non-map components, such as GeometryEngine, Projection, etc.

```csharp
public abstract class LogicComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LogicComponent

Derived  
&#8627; [Projection](dymaptic.GeoBlazor.Core.Model.Projection.html 'dymaptic.GeoBlazor.Core.Model.Projection')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.LogicComponent(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration)'></a>

## LogicComponent(IJSRuntime, IConfiguration) Constructor

Default constructor

```csharp
public LogicComponent(Microsoft.JSInterop.IJSRuntime jsRuntime, Microsoft.Extensions.Configuration.IConfiguration configuration);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.LogicComponent(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration).jsRuntime'></a>

`jsRuntime` [Microsoft.JSInterop.IJSRuntime](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSRuntime 'Microsoft.JSInterop.IJSRuntime')

Injected JavaScript Runtime reference

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.LogicComponent(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration).configuration'></a>

`configuration` [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')

Injected configuration object
### Methods

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.OnJavascriptError(string)'></a>

## LogicComponent.OnJavascriptError(string) Method

A JavaScript invokable method that returns a JS Error and converts it to an Exception.

```csharp
public void OnJavascriptError(string error);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.OnJavascriptError(string).error'></a>

`error` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The JavaScript error stacktrace and/or details.

#### Exceptions

[JavascriptException](dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptException')  
The converted error to exception.
