---
layout: default
title: JavascriptError
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Exceptions](index.html#dymaptic.GeoBlazor.Core.Exceptions 'dymaptic.GeoBlazor.Core.Exceptions')

## JavascriptError Class

A JavaScript error

```csharp
public class JavascriptError :
System.IEquatable<dymaptic.GeoBlazor.Core.Exceptions.JavascriptError>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; JavascriptError

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[JavascriptError](dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptError')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.JavascriptError(string,string,string)'></a>

## JavascriptError(string, string, string) Constructor

A JavaScript error

```csharp
public JavascriptError(string? Message, string? Name, string? Stack=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.JavascriptError(string,string,string).Message'></a>

`Message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The message of the error.

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.JavascriptError(string,string,string).Name'></a>

`Name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the error.

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.JavascriptError(string,string,string).Stack'></a>

`Stack` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The stack trace of the error.
### Properties

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.Message'></a>

## JavascriptError.Message Property

The message of the error.

```csharp
public string? Message { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.Name'></a>

## JavascriptError.Name Property

The name of the error.

```csharp
public string? Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.Stack'></a>

## JavascriptError.Stack Property

The stack trace of the error.

```csharp
public string? Stack { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
