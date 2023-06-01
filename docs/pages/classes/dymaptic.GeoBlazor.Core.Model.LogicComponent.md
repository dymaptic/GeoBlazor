---
layout: default
title: LogicComponent
parent: Classes
---
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
public abstract class LogicComponent :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LogicComponent

Derived  
&#8627; [GeometryEngine](dymaptic.GeoBlazor.Core.Model.GeometryEngine.html 'dymaptic.GeoBlazor.Core.Model.GeometryEngine')  
&#8627; [Projection](dymaptic.GeoBlazor.Core.Model.Projection.html 'dymaptic.GeoBlazor.Core.Model.Projection')

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.LogicComponent(Microsoft.JSInterop.IJSRuntime,dymaptic.GeoBlazor.Core.Model.AuthenticationManager)'></a>

## LogicComponent(IJSRuntime, AuthenticationManager) Constructor

Default constructor

```csharp
public LogicComponent(Microsoft.JSInterop.IJSRuntime jsRuntime, dymaptic.GeoBlazor.Core.Model.AuthenticationManager authenticationManager);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.LogicComponent(Microsoft.JSInterop.IJSRuntime,dymaptic.GeoBlazor.Core.Model.AuthenticationManager).jsRuntime'></a>

`jsRuntime` [Microsoft.JSInterop.IJSRuntime](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSRuntime 'Microsoft.JSInterop.IJSRuntime')

Injected JavaScript Runtime reference

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.LogicComponent(Microsoft.JSInterop.IJSRuntime,dymaptic.GeoBlazor.Core.Model.AuthenticationManager).authenticationManager'></a>

`authenticationManager` [AuthenticationManager](dymaptic.GeoBlazor.Core.Model.AuthenticationManager.html 'dymaptic.GeoBlazor.Core.Model.AuthenticationManager')

Injected Identity Manager reference
### Properties

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.OnJavascriptErrorHandler'></a>

## LogicComponent.OnJavascriptErrorHandler Property

Implement this handler in your calling code to catch and handle Javascript errors.

```csharp
public System.Func<dymaptic.GeoBlazor.Core.Exceptions.JavascriptException,System.Threading.Tasks.Task>? OnJavascriptErrorHandler { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[JavascriptException](dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptException')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')
### Methods

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.Dispose()'></a>

## LogicComponent.Dispose() Method

Disposes of the Logic Component and cancels all external calls

```csharp
public void Dispose();
```

Implements [Dispose()](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable.Dispose 'System.IDisposable.Dispose')

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.Initialize()'></a>

## LogicComponent.Initialize() Method

Initializes the JavaScript reference component, if not already initialized.

```csharp
public virtual System.Threading.Tasks.Task Initialize();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.OnJavascriptError(dymaptic.GeoBlazor.Core.Exceptions.JavascriptError)'></a>

## LogicComponent.OnJavascriptError(JavascriptError) Method

A JavaScript invokable method that returns a JS Error and converts it to an Exception.

```csharp
public void OnJavascriptError(dymaptic.GeoBlazor.Core.Exceptions.JavascriptError error);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.OnJavascriptError(dymaptic.GeoBlazor.Core.Exceptions.JavascriptError).error'></a>

`error` [JavascriptError](dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptError')

The original JavaScript error.

#### Exceptions

[JavascriptException](dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptException')  
The converted error to exception.

