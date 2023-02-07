---
layout: default
title: MapFont
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Symbols](index.html#dymaptic.GeoBlazor.Core.Components.Symbols 'dymaptic.GeoBlazor.Core.Components.Symbols')

## MapFont Class

The font used to display 2D text symbols and 3D text symbols. This class allows the developer to set the font's family, decoration, size, style, and weight properties. Take note of the "Known Limitations" for each property to understand how they differ depending on the layer type, and if you working with a MapView or SceneView.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Font.html">ArcGIS JS API</a>

```csharp
public class MapFont : dymaptic.GeoBlazor.Core.Components.MapComponent,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Symbols.MapFont>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; MapFont

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[MapFont](dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MapFont')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.Family'></a>

## MapFont.Family Property

The font family of the text.

```csharp
public string? Family { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.FontStyle'></a>

## MapFont.FontStyle Property

The text style.

```csharp
public string? FontStyle { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.Size'></a>

## MapFont.Size Property

The font size in points.

```csharp
public System.Nullable<int> Size { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.Weight'></a>

## MapFont.Weight Property

The text weight.

```csharp
public string? Weight { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.Equals(object)'></a>

## MapFont.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.GetHashCode()'></a>

## MapFont.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.MapFont,dymaptic.GeoBlazor.Core.Components.Symbols.MapFont)'></a>

## MapFont.operator ==(MapFont, MapFont) Operator

Compares two MapFont objects for equality

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.Symbols.MapFont? left, dymaptic.GeoBlazor.Core.Components.Symbols.MapFont? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.MapFont,dymaptic.GeoBlazor.Core.Components.Symbols.MapFont).left'></a>

`left` [MapFont](dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MapFont')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.MapFont,dymaptic.GeoBlazor.Core.Components.Symbols.MapFont).right'></a>

`right` [MapFont](dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MapFont')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.MapFont,dymaptic.GeoBlazor.Core.Components.Symbols.MapFont)'></a>

## MapFont.operator !=(MapFont, MapFont) Operator

Compares two MapFont objects for inequality

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.Symbols.MapFont? left, dymaptic.GeoBlazor.Core.Components.Symbols.MapFont? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.MapFont,dymaptic.GeoBlazor.Core.Components.Symbols.MapFont).left'></a>

`left` [MapFont](dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MapFont')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.MapFont,dymaptic.GeoBlazor.Core.Components.Symbols.MapFont).right'></a>

`right` [MapFont](dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MapFont')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
