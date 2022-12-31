---
layout: default
title: QuantizationParameters
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## QuantizationParameters Class

Used to project the geometry onto a virtual grid, likely representing pixels on the screen. Geometry coordinates are converted to integers by building a grid with a resolution matching the quantizationParameters.tolerance. Each coordinate is then snapped to one pixel on the grid.

```csharp
public class QuantizationParameters :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.QuantizationParameters>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; QuantizationParameters

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[QuantizationParameters](dymaptic.GeoBlazor.Core.Objects.QuantizationParameters.html 'dymaptic.GeoBlazor.Core.Objects.QuantizationParameters')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.QuantizationParameters.Extent'></a>

## QuantizationParameters.Extent Property

An extent defining the quantization grid bounds. Its SpatialReference matches the input geometry spatial reference if one is specified for the query. Otherwise, the extent will be in the layer's spatial reference.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Extent? Extent { get; set; }
```

#### Property Value
[Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

<a name='dymaptic.GeoBlazor.Core.Objects.QuantizationParameters.Mode'></a>

## QuantizationParameters.Mode Property

Geometry coordinates are optimized for viewing and displaying of data.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Objects.QuantizationMode> Mode { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[QuantizationMode](dymaptic.GeoBlazor.Core.Objects.QuantizationMode.html 'dymaptic.GeoBlazor.Core.Objects.QuantizationMode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.QuantizationParameters.OriginPosition'></a>

## QuantizationParameters.OriginPosition Property

The integer's coordinates will be returned relative to the origin position defined by this property value.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Objects.OriginPosition> OriginPosition { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[OriginPosition](dymaptic.GeoBlazor.Core.Objects.OriginPosition.html 'dymaptic.GeoBlazor.Core.Objects.OriginPosition')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.QuantizationParameters.Tolerance'></a>

## QuantizationParameters.Tolerance Property

The size of one pixel in the units of the outSpatialReference. This number is used to convert coordinates to integers by building a grid with a resolution matching the tolerance. Each coordinate is then snapped to one pixel on the grid. Consecutive coordinates snapped to the same pixel are removed for reducing the overall response size. The units of tolerance will match the units of outSpatialReference. If outSpatialReference is not specified, then tolerance is assumed to be in the units of the spatial reference of the layer. If tolerance is not specified, the maxAllowableOffset is used. If tolerance and maxAllowableOffset are not specified, a grid of 10,000 * 10,000 grid is used by default.  
Default Value: 1

```csharp
public System.Nullable<double> Tolerance { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
