---
layout: default
title: InvalidChildElementException
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Exceptions](index.html#dymaptic.GeoBlazor.Core.Exceptions 'dymaptic.GeoBlazor.Core.Exceptions')

## InvalidChildElementException Class

Exception thrown when a component is added to the wrong type of parent component.

```csharp
public class InvalidChildElementException : System.Exception
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') &#129106; InvalidChildElementException
### Constructors

<a name='dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.InvalidChildElementException(string,string)'></a>

## InvalidChildElementException(string, string) Constructor

Constructs an InvalidChildElementException.

```csharp
public InvalidChildElementException(string parentType, string childType);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.InvalidChildElementException(string,string).parentType'></a>

`parentType` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The parent type attempting to register the child.

<a name='dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.InvalidChildElementException(string,string).childType'></a>

`childType` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The child type attempting to register with the parent.
