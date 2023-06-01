---
layout: default
title: MissingRequiredOptionsChildElementException
parent: Classes
---
---
layout: default
title: MissingRequiredOptionsChildElementException
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Exceptions](index.html#dymaptic.GeoBlazor.Core.Exceptions 'dymaptic.GeoBlazor.Core.Exceptions')

## MissingRequiredOptionsChildElementException Class

An exception that specifies that none of the choices of required child components were added.

```csharp
public class MissingRequiredOptionsChildElementException : System.Exception
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') &#129106; MissingRequiredOptionsChildElementException
### Constructors

<a name='dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.MissingRequiredOptionsChildElementException(string,System.Collections.Generic.IEnumerable_string_)'></a>

## MissingRequiredOptionsChildElementException(string, IEnumerable<string>) Constructor

Generates a new MissingRequiredOptionsChildElementException

```csharp
public MissingRequiredOptionsChildElementException(string parentType, System.Collections.Generic.IEnumerable<string> options);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.MissingRequiredOptionsChildElementException(string,System.Collections.Generic.IEnumerable_string_).parentType'></a>

`parentType` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The parent type which requires one child out of a collection of options.

<a name='dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.MissingRequiredOptionsChildElementException(string,System.Collections.Generic.IEnumerable_string_).options'></a>

`options` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The potential required children, none of which were present.

