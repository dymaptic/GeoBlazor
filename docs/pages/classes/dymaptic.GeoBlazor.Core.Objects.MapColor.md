---
layout: default
title: MapColor
parent: Classes
---
---
layout: default
title: MapColor
parent: Classes
---
---
layout: default
title: MapColor
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## MapColor Class

Creates a new color object by passing either a hex, rgb(a), hsl(a) or named color value. Hex, hsl(a) and named color values can be passed as a string:  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Color.html">ArcGIS JS API</a>

```csharp
public class MapColor
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; MapColor
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.MapColor.MapColor(double[])'></a>

## MapColor(double[]) Constructor

Creates a new color with a collection of numeric values in rgb or rgba format.

```csharp
public MapColor(params double[] values);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.MapColor.MapColor(double[]).values'></a>

`values` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Requires 3 or 4 values, in the order R(0-255), G(0-255), B(0-255), A(0-1). A is optional.

<a name='dymaptic.GeoBlazor.Core.Objects.MapColor.MapColor(string)'></a>

## MapColor(string) Constructor

Creates a new color with a common color name, or a hex value starting with the # sign.

```csharp
public MapColor(string hexOrNameValue);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.MapColor.MapColor(string).hexOrNameValue'></a>

`hexOrNameValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The value of the hex or name.
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.MapColor.HexOrNameValue'></a>

## MapColor.HexOrNameValue Property

The name or hex value of the color.

```csharp
public string? HexOrNameValue { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.MapColor.Values'></a>

## MapColor.Values Property

The numeric values for calculating a color (rgb/rgba).

```csharp
public System.Collections.Generic.List<double> Values { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')


