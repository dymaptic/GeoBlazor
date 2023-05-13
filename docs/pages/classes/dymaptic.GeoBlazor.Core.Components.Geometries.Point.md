---
layout: default
title: Point
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Geometries](index.html#dymaptic.GeoBlazor.Core.Components.Geometries 'dymaptic.GeoBlazor.Core.Components.Geometries')

## Point Class

A location defined by X, Y, and Z coordinates.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class Point : dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Geometries.Point>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry') &#129106; Point

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Point()'></a>

## Point() Constructor

Parameterless constructor for use as a razor component

```csharp
public Point();
```

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Point(System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## Point(Nullable<double>, Nullable<double>, Nullable<double>, Nullable<double>, Nullable<double>, SpatialReference, Extent) Constructor

Creates a new Point programmatically with parameters

```csharp
public Point(System.Nullable<double> longitude=null, System.Nullable<double> latitude=null, System.Nullable<double> x=null, System.Nullable<double> y=null, System.Nullable<double> z=null, dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? spatialReference=null, dymaptic.GeoBlazor.Core.Components.Geometries.Extent? extent=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Point(System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).longitude'></a>

`longitude` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The longitude of the point.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Point(System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).latitude'></a>

`latitude` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The latitude of the point.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Point(System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).x'></a>

`x` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The x-coordinate (easting) of the point in map units.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Point(System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).y'></a>

`y` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The y-coordinate (northing) of the point in map units.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Point(System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).z'></a>

`z` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The z-coordinate (or elevation) of the point in map units.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Point(System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).spatialReference'></a>

`spatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

The [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference') of the geometry.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Point(System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).extent'></a>

`extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

The [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent') of the geometry.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Latitude'></a>

## Point.Latitude Property

The latitude of the point.

```csharp
public System.Nullable<double> Latitude { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Longitude'></a>

## Point.Longitude Property

The longitude of the point.

```csharp
public System.Nullable<double> Longitude { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.M'></a>

## Point.M Property

The m-coordinate of the point in map units.

```csharp
public System.Nullable<double> M { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Type'></a>

## Point.Type Property

The Geometry "type", used internally to render.

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.X'></a>

## Point.X Property

The x-coordinate (easting) of the point in map units.

```csharp
public System.Nullable<double> X { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Y'></a>

## Point.Y Property

The y-coordinate (northing) of the point in map units.

```csharp
public System.Nullable<double> Y { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Z'></a>

## Point.Z Property

The z-coordinate (or elevation) of the point in map units.

```csharp
public System.Nullable<double> Z { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Clone()'></a>

## Point.Clone() Method

Returns a deep clone of the geometry.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Point Clone();
```

#### Returns
[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Equals(dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## Point.Equals(Point) Method

Implements custom equality checks

```csharp
public bool Equals(dymaptic.GeoBlazor.Core.Components.Geometries.Point? other);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Equals(dymaptic.GeoBlazor.Core.Components.Geometries.Point).other'></a>

`other` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Equals(object)'></a>

## Point.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Point.GetHashCode()'></a>

## Point.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.
