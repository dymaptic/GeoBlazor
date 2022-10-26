---
layout: default
title: RequiredPropertyAttribute
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core](index.html#dymaptic.GeoBlazor.Core 'dymaptic.GeoBlazor.Core')

## RequiredPropertyAttribute Class

Add this attribute to any property on any subclass of [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent'), and if the user  
forgets to set that property, this will throw a [MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
or [MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException'). This works for both `[Parameter]`  
properties as well as Child Components registered with `RegisterChildComponent`

```csharp
public class RequiredPropertyAttribute : System.Attribute
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute') &#129106; RequiredPropertyAttribute
### Constructors

<a name='dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.RequiredPropertyAttribute(string[])'></a>

## RequiredPropertyAttribute(string[]) Constructor

```csharp
public RequiredPropertyAttribute(params string[]? otherOptions);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.RequiredPropertyAttribute(string[]).otherOptions'></a>

`otherOptions` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

If there are two or more acceptable properties that can be set, add the other property names  
here for the validation. Use `nameof(Property)` to ensure you get the right name.
### Properties

<a name='dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.OtherOptions'></a>

## RequiredPropertyAttribute.OtherOptions Property

The other potential properties that can replace this property.

```csharp
public string[]? OtherOptions { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')
