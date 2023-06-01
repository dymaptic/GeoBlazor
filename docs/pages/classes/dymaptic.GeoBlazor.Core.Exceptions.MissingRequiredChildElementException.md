---
layout: default
title: MissingRequiredChildElementException
parent: Classes
---
---
layout: default
title: MissingRequiredChildElementException
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Exceptions](index.html#dymaptic.GeoBlazor.Core.Exceptions 'dymaptic.GeoBlazor.Core.Exceptions')

## MissingRequiredChildElementException Class

An exception that specifies that a required child component was not added to the parent.

```csharp
public class MissingRequiredChildElementException : System.Exception
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') &#129106; MissingRequiredChildElementException
### Constructors

<a name='dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.MissingRequiredChildElementException(string,string)'></a>

## MissingRequiredChildElementException(string, string) Constructor

Generates a new MissingRequiredChildElementException

```csharp
public MissingRequiredChildElementException(string parentType, string childType);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.MissingRequiredChildElementException(string,string).parentType'></a>

`parentType` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The parent type with a required child.

<a name='dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.MissingRequiredChildElementException(string,string).childType'></a>

`childType` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The missing required child type.

