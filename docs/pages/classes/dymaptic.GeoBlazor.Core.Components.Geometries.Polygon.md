---
layout: default
title: Polygon
parent: Classes
---
---
layout: default
title: Polygon
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Geometries](index.html#dymaptic.GeoBlazor.Core.Components.Geometries 'dymaptic.GeoBlazor.Core.Components.Geometries')

## Polygon Class

A polygon contains an array of rings and a spatialReference. Each ring is represented as an array of points. The  
first and last points of a ring must be the same. A polygon also has boolean-valued hasM and hasZ fields.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html">ArcGIS JS API</a>

```csharp
public class Polygon : dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Geometries.Polygon>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry') &#129106; Polygon

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Polygon()'></a>

## Polygon() Constructor

Parameterless constructor for use as a razor component

```csharp
public Polygon();
```

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Polygon(dymaptic.GeoBlazor.Core.Objects.MapPath[],dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## Polygon(MapPath[], SpatialReference, Extent) Constructor

Creates a new polygon in code with parameters

```csharp
public Polygon(dymaptic.GeoBlazor.Core.Objects.MapPath[] rings, dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? spatialReference=null, dymaptic.GeoBlazor.Core.Components.Geometries.Extent? extent=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Polygon(dymaptic.GeoBlazor.Core.Objects.MapPath[],dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).rings'></a>

`rings` [MapPath](dymaptic.GeoBlazor.Core.Objects.MapPath.html 'dymaptic.GeoBlazor.Core.Objects.MapPath')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

An array of [MapPath](dymaptic.GeoBlazor.Core.Objects.MapPath.html 'dymaptic.GeoBlazor.Core.Objects.MapPath') rings.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Polygon(dymaptic.GeoBlazor.Core.Objects.MapPath[],dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).spatialReference'></a>

`spatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

The [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference') of the geometry.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Polygon(dymaptic.GeoBlazor.Core.Objects.MapPath[],dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).extent'></a>

`extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

The [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent') of the geometry.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Rings'></a>

## Polygon.Rings Property

An array of [MapPath](dymaptic.GeoBlazor.Core.Objects.MapPath.html 'dymaptic.GeoBlazor.Core.Objects.MapPath') rings.

```csharp
public dymaptic.GeoBlazor.Core.Objects.MapPath[] Rings { get; set; }
```

#### Property Value
[MapPath](dymaptic.GeoBlazor.Core.Objects.MapPath.html 'dymaptic.GeoBlazor.Core.Objects.MapPath')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Type'></a>

## Polygon.Type Property

The Geometry "type", used internally to render.

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Clone()'></a>

## Polygon.Clone() Method

Returns a deep clone of the geometry.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Polygon Clone();
```

#### Returns
[Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Equals(object)'></a>

## Polygon.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.GetHashCode()'></a>

## Polygon.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.op_Equality(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon,dymaptic.GeoBlazor.Core.Components.Geometries.Polygon)'></a>

## Polygon.operator ==(Polygon, Polygon) Operator

Override equality operator

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon? left, dymaptic.GeoBlazor.Core.Components.Geometries.Polygon? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.op_Equality(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon,dymaptic.GeoBlazor.Core.Components.Geometries.Polygon).left'></a>

`left` [Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.op_Equality(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon,dymaptic.GeoBlazor.Core.Components.Geometries.Polygon).right'></a>

`right` [Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.op_Inequality(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon,dymaptic.GeoBlazor.Core.Components.Geometries.Polygon)'></a>

## Polygon.operator !=(Polygon, Polygon) Operator

Override inequality operator

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon? left, dymaptic.GeoBlazor.Core.Components.Geometries.Polygon? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.op_Inequality(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon,dymaptic.GeoBlazor.Core.Components.Geometries.Polygon).left'></a>

`left` [Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.op_Inequality(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon,dymaptic.GeoBlazor.Core.Components.Geometries.Polygon).right'></a>

`right` [Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

