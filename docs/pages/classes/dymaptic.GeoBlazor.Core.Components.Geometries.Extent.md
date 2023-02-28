---
layout: default
title: Extent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Geometries](index.html#dymaptic.GeoBlazor.Core.Components.Geometries 'dymaptic.GeoBlazor.Core.Components.Geometries')

## Extent Class

The minimum and maximum X and Y coordinates of a bounding box. Extent is used to describe the visible portion of a  
MapView. When working in a SceneView, Camera is used to define the visible part of the map within the view.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class Extent : dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Geometries.Extent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry') &#129106; Extent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Extent()'></a>

## Extent() Constructor

Parameterless constructor for use as a razor component

```csharp
public Extent();
```

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Extent(double,double,double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference)'></a>

## Extent(double, double, double, double, Nullable<double>, Nullable<double>, Nullable<double>, Nullable<double>, SpatialReference) Constructor

Creates a new Extent in code with parameters

```csharp
public Extent(double xmax, double xmin, double ymax, double ymin, System.Nullable<double> zmax=null, System.Nullable<double> zmin=null, System.Nullable<double> mmax=null, System.Nullable<double> mmin=null, dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? spatialReference=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Extent(double,double,double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).xmax'></a>

`xmax` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The maximum X-coordinate of an extent envelope.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Extent(double,double,double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).xmin'></a>

`xmin` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The minimum X-coordinate of an extent envelope.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Extent(double,double,double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).ymax'></a>

`ymax` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The maximum Y-coordinate of an extent envelope.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Extent(double,double,double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).ymin'></a>

`ymin` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The minimum Y-coordinate of an extent envelope.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Extent(double,double,double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).zmax'></a>

`zmax` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The maximum possible z, or elevation, value in an extent envelope.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Extent(double,double,double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).zmin'></a>

`zmin` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The minimum possible z, or elevation, value in an extent envelope.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Extent(double,double,double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).mmax'></a>

`mmax` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The maximum possible m value in an extent envelope.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Extent(double,double,double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).mmin'></a>

`mmin` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The minimum possible m value in an extent envelope.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Extent(double,double,double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).spatialReference'></a>

`spatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

The [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference') of the geometry.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Mmax'></a>

## Extent.Mmax Property

The maximum possible m value in an extent envelope.

```csharp
public System.Nullable<double> Mmax { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Mmin'></a>

## Extent.Mmin Property

The minimum possible m value in an extent envelope.

```csharp
public System.Nullable<double> Mmin { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Type'></a>

## Extent.Type Property

The Geometry "type", used internally to render.

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Xmax'></a>

## Extent.Xmax Property

The maximum X-coordinate of an extent envelope.

```csharp
public double Xmax { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Xmin'></a>

## Extent.Xmin Property

The minimum X-coordinate of an extent envelope.

```csharp
public double Xmin { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Ymax'></a>

## Extent.Ymax Property

The maximum Y-coordinate of an extent envelope.

```csharp
public double Ymax { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Ymin'></a>

## Extent.Ymin Property

The minimum Y-coordinate of an extent envelope.

```csharp
public double Ymin { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Zmax'></a>

## Extent.Zmax Property

The maximum possible z, or elevation, value in an extent envelope.

```csharp
public System.Nullable<double> Zmax { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Zmin'></a>

## Extent.Zmin Property

The minimum possible z, or elevation, value in an extent envelope.

```csharp
public System.Nullable<double> Zmin { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Equals(object)'></a>

## Extent.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.GetHashCode()'></a>

## Extent.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.op_Equality(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## Extent.operator ==(Extent, Extent) Operator

Compares two Extent objects for equality

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.Geometries.Extent? left, dymaptic.GeoBlazor.Core.Components.Geometries.Extent? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.op_Equality(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).left'></a>

`left` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.op_Equality(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).right'></a>

`right` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.op_Inequality(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## Extent.operator !=(Extent, Extent) Operator

Compares two Extent objects for inequality

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.Geometries.Extent? left, dymaptic.GeoBlazor.Core.Components.Geometries.Extent? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.op_Inequality(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).left'></a>

`left` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Extent.op_Inequality(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).right'></a>

`right` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
