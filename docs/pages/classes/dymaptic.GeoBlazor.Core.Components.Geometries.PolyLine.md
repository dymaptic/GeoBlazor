---
layout: default
title: PolyLine
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Geometries](index.html#dymaptic.GeoBlazor.Core.Components.Geometries 'dymaptic.GeoBlazor.Core.Components.Geometries')

## PolyLine Class

A polyline contains an array of paths and spatialReference. Each path is represented as an array of points. A polyline also has boolean-valued hasM and hasZ properties.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polyline.html">ArcGIS JS API</a>

```csharp
public class PolyLine : dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry') &#129106; PolyLine

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[PolyLine](dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.html 'dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.PolyLine()'></a>

## PolyLine() Constructor

A parameterless constructor for using as a razor component

```csharp
public PolyLine();
```

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.PolyLine(dymaptic.GeoBlazor.Core.Objects.MapPath[],dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## PolyLine(MapPath[], SpatialReference, Extent) Constructor

Creates a new PolyLine in code with parameters

```csharp
public PolyLine(dymaptic.GeoBlazor.Core.Objects.MapPath[] paths, dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? spatialReference=null, dymaptic.GeoBlazor.Core.Components.Geometries.Extent? extent=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.PolyLine(dymaptic.GeoBlazor.Core.Objects.MapPath[],dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).paths'></a>

`paths` [MapPath](dymaptic.GeoBlazor.Core.Objects.MapPath.html 'dymaptic.GeoBlazor.Core.Objects.MapPath')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

An array of [MapPath](dymaptic.GeoBlazor.Core.Objects.MapPath.html 'dymaptic.GeoBlazor.Core.Objects.MapPath') paths, or line segments, that make up the polyline.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.PolyLine(dymaptic.GeoBlazor.Core.Objects.MapPath[],dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).spatialReference'></a>

`spatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

The [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference') of the geometry.

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.PolyLine(dymaptic.GeoBlazor.Core.Objects.MapPath[],dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).extent'></a>

`extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

The [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent') of the geometry.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.Paths'></a>

## PolyLine.Paths Property

An array of [MapPath](dymaptic.GeoBlazor.Core.Objects.MapPath.html 'dymaptic.GeoBlazor.Core.Objects.MapPath') paths, or line segments, that make up the polyline.

```csharp
public dymaptic.GeoBlazor.Core.Objects.MapPath[] Paths { get; set; }
```

#### Property Value
[MapPath](dymaptic.GeoBlazor.Core.Objects.MapPath.html 'dymaptic.GeoBlazor.Core.Objects.MapPath')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.Type'></a>

## PolyLine.Type Property

The Geometry "type", used internally to render.

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.Equals(object)'></a>

## PolyLine.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.GetHashCode()'></a>

## PolyLine.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.op_Equality(dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine,dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine)'></a>

## PolyLine.operator ==(PolyLine, PolyLine) Operator

Compares two [PolyLine](dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.html 'dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine') objects for equality

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine? left, dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.op_Equality(dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine,dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine).left'></a>

`left` [PolyLine](dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.html 'dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.op_Equality(dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine,dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine).right'></a>

`right` [PolyLine](dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.html 'dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.op_Inequality(dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine,dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine)'></a>

## PolyLine.operator !=(PolyLine, PolyLine) Operator

Compares two [PolyLine](dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.html 'dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine') objects for inequality

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine? left, dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.op_Inequality(dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine,dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine).left'></a>

`left` [PolyLine](dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.html 'dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.op_Inequality(dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine,dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine).right'></a>

`right` [PolyLine](dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.html 'dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
