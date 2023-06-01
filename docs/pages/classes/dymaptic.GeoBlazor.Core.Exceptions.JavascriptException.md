---
layout: default
title: JavascriptException
parent: Classes
---
---
layout: default
title: JavascriptException
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Exceptions](index.html#dymaptic.GeoBlazor.Core.Exceptions 'dymaptic.GeoBlazor.Core.Exceptions')

## JavascriptException Class

Converts a JavaScript Error into a .NET Exception

```csharp
public class JavascriptException : System.Exception
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') &#129106; JavascriptException
### Constructors

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.JavascriptException(dymaptic.GeoBlazor.Core.Exceptions.JavascriptError)'></a>

## JavascriptException(JavascriptError) Constructor

Creates a new Exception from a JavaScript Error

```csharp
public JavascriptException(dymaptic.GeoBlazor.Core.Exceptions.JavascriptError error);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.JavascriptException(dymaptic.GeoBlazor.Core.Exceptions.JavascriptError).error'></a>

`error` [JavascriptError](dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptError')

The original JavaScript error.
### Properties

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.Name'></a>

## JavascriptException.Name Property

The name of the JavaScript error.

```csharp
public string? Name { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.Stack'></a>

## JavascriptException.Stack Property

The JavaScript stack trace.

```csharp
public string? Stack { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

