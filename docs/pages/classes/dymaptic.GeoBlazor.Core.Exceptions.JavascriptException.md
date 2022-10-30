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

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.JavascriptException(string,string,string)'></a>

## JavascriptException(string, string, string) Constructor

Creates a new Exception from a JavaScript Error

```csharp
public JavascriptException(string message, string name, string stack);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.JavascriptException(string,string,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The JavaScript error message.

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.JavascriptException(string,string,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the JavaScript error.

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.JavascriptException(string,string,string).stack'></a>

`stack` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The JavaScript stack trace.
### Properties

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.Name'></a>

## JavascriptException.Name Property

The name of the JavaScript error.

```csharp
public string Name { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.Stack'></a>

## JavascriptException.Stack Property

The JavaScript stack trace.

```csharp
public string Stack { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
