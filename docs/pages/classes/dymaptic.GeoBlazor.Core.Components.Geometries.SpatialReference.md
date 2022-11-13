---
layout: default
title: SpatialReference
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Geometries](index.html#dymaptic.GeoBlazor.Core.Components.Geometries 'dymaptic.GeoBlazor.Core.Components.Geometries')

## SpatialReference Class

Defines the spatial reference of a view, layer, or method parameters. This indicates the projected or geographic coordinate system used to locate geographic features in the map. Each projected and geographic coordinate system is defined by either a well-known ID (WKID) or a definition string (WKT). Note that for versions prior to ArcGIS 10, only WKID was supported. For a full list of supported spatial reference IDs and their corresponding definition strings, see Using spatial references.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html">ArcGIS JS API</a>

```csharp
public class SpatialReference : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; SpatialReference
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.SpatialReference()'></a>

## SpatialReference() Constructor

Parameterless constructor for use as a razor component

```csharp
public SpatialReference();
```

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.SpatialReference(double)'></a>

## SpatialReference(double) Constructor

Creates a new SpatialReference in code with a Wkid

```csharp
public SpatialReference(double wkid);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.SpatialReference(double).wkid'></a>

`wkid` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The well-known Id for the spatial reference
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.ImageCoordinateSystem'></a>

## SpatialReference.ImageCoordinateSystem Property

An image coordinate system defines the spatial reference used to display the image in its original coordinates without distortion, map transformations or ortho-rectification.

```csharp
public object? ImageCoordinateSystem { get; set; }
```

#### Property Value
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.IsGeographic'></a>

## SpatialReference.IsGeographic Property

Indicates if the spatial reference refers to a geographic coordinate system.

```csharp
public System.Nullable<bool> IsGeographic { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.IsWebMercator'></a>

## SpatialReference.IsWebMercator Property

Indicates if the wkid of the spatial reference object is one of the following values: 102113, 102100, 3857.

```csharp
public System.Nullable<bool> IsWebMercator { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.IsWgs84'></a>

## SpatialReference.IsWgs84 Property

Indicates if the wkid of the spatial reference object is 4326.

```csharp
public System.Nullable<bool> IsWgs84 { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.IsWrappable'></a>

## SpatialReference.IsWrappable Property

Indicates if the spatial reference of the map supports wrapping around the International Date Line.

```csharp
public System.Nullable<bool> IsWrappable { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.WebMercator'></a>

## SpatialReference.WebMercator Property

A convenience static instance for WebMercator Spatial Reference.

```csharp
public static dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference WebMercator { get; set; }
```

#### Property Value
[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.Wgs84'></a>

## SpatialReference.Wgs84 Property

A convenience static instance for WGS84 Spatial Reference.

```csharp
public static dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference Wgs84 { get; set; }
```

#### Property Value
[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.Wkid'></a>

## SpatialReference.Wkid Property

The well-known ID of a spatial reference.

```csharp
public System.Nullable<double> Wkid { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.Wkt'></a>

## SpatialReference.Wkt Property

The well-known text that defines a spatial reference.

```csharp
public string? Wkt { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
