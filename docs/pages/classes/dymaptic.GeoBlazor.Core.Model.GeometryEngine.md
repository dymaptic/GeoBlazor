---
layout: default
title: GeometryEngine
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Model](index.html#dymaptic.GeoBlazor.Core.Model 'dymaptic.GeoBlazor.Core.Model')

## GeometryEngine Class

A client-side geometry engine for testing, measuring, and analyzing the spatial relationship between two or more 2D geometries. If more than one geometry is required for any of the methods below, all geometries must have the same spatial reference for the methods to work as expected.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-geometryEngine.html">ArcGIS JS API</a>

```csharp
public class GeometryEngine : dymaptic.GeoBlazor.Core.Model.LogicComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [LogicComponent](dymaptic.GeoBlazor.Core.Model.LogicComponent.html 'dymaptic.GeoBlazor.Core.Model.LogicComponent') &#129106; GeometryEngine
### Constructors

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeometryEngine(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration)'></a>

## GeometryEngine(IJSRuntime, IConfiguration) Constructor

Default Constructor

```csharp
public GeometryEngine(Microsoft.JSInterop.IJSRuntime jsRuntime, Microsoft.Extensions.Configuration.IConfiguration configuration);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeometryEngine(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration).jsRuntime'></a>

`jsRuntime` [Microsoft.JSInterop.IJSRuntime](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSRuntime 'Microsoft.JSInterop.IJSRuntime')

Injected JavaScript Runtime reference

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeometryEngine(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration).configuration'></a>

`configuration` [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')

Injected configuration object
### Methods

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.AreEqual(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.AreEqual(Geometry, Geometry) Method

Indicates if two geometries are equal.

```csharp
public System.Threading.Tasks.Task<bool> AreEqual(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry1, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry2);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.AreEqual(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry1'></a>

`geometry1` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

First input geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.AreEqual(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry2'></a>

`geometry2` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

Second input geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns true if the two input geometries are equal.

### Remarks
In ArcGIS for JS, this method is called `Equals`. However, this term has special meaning in .NET, so we have renamed here.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Buffer(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_)'></a>

## GeometryEngine.Buffer(Geometry, double, Nullable<LinearUnit>) Method

Creates planar (or Euclidean) buffer polygons at a specified distance around the input geometries.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Polygon> Buffer(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, double distance, System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> unit=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Buffer(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The buffer input geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Buffer(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).distance'></a>

`distance` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The specified distance(s) for buffering.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Buffer(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).unit'></a>

`unit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit of the distance(s). Defaults to the units of the input geometries.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The resulting buffer.

### Remarks
The GeometryEngine has two methods for buffering geometries client-side: buffer and geodesicBuffer. Use caution when deciding which method to use. As a general rule, use geodesicBuffer if the input geometries have a spatial reference of either WGS84 (wkid: 4326) or Web Mercator. Only use buffer (this method) when attempting to buffer geometries with a projected coordinate system other than Web Mercator. If you need to buffer geometries with a geographic coordinate system other than WGS84 (wkid: 4326), use geometryService.buffer().

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Buffer(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,System.Collections.Generic.IEnumerable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_bool_)'></a>

## GeometryEngine.Buffer(IEnumerable<Geometry>, IEnumerable<double>, Nullable<LinearUnit>, Nullable<bool>) Method

Creates planar (or Euclidean) buffer polygons at a specified distance around the input geometries.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Polygon[]> Buffer(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> geometries, System.Collections.Generic.IEnumerable<double> distances, System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> unit=null, System.Nullable<bool> unionResults=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Buffer(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,System.Collections.Generic.IEnumerable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_bool_).geometries'></a>

`geometries` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The buffer input geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Buffer(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,System.Collections.Generic.IEnumerable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_bool_).distances'></a>

`distances` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The specified distance(s) for buffering. The length of the geometry array does not have to equal the length of the distance array. For example, if you pass an array of four geometries: [g1, g2, g3, g4] and an array with one distance: [d1], all four geometries will be buffered by the single distance value. If instead you use an array of three distances: [d1, d2, d3], g1 will be buffered by d1, g2 by d2, and g3 and g4 will both be buffered by d3. The value of the geometry array will be matched one to one with those in the distance array until the final value of the distance array is reached, in which case that value will be applied to the remaining geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Buffer(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,System.Collections.Generic.IEnumerable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_bool_).unit'></a>

`unit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit of the distance(s). Defaults to the units of the input geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Buffer(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,System.Collections.Generic.IEnumerable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_bool_).unionResults'></a>

`unionResults` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Determines whether the output geometries should be unioned into a single polygon.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The resulting buffers.

### Remarks
The GeometryEngine has two methods for buffering geometries client-side: buffer and geodesicBuffer. Use caution when deciding which method to use. As a general rule, use geodesicBuffer if the input geometries have a spatial reference of either WGS84 (wkid: 4326) or Web Mercator. Only use buffer (this method) when attempting to buffer geometries with a projected coordinate system other than Web Mercator. If you need to buffer geometries with a geographic coordinate system other than WGS84 (wkid: 4326), use geometryService.buffer().

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Clip(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## GeometryEngine.Clip(Geometry, Extent) Method

Calculates the clipped geometry from a target geometry by an envelope.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> Clip(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, dymaptic.GeoBlazor.Core.Components.Geometries.Extent extent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Clip(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to be clipped.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Clip(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).extent'></a>

`extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

The envelope used to clip.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Clipped geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Contains(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.Contains(Geometry, Geometry) Method

Indicates if one geometry contains another geometry.

```csharp
public System.Threading.Tasks.Task<bool> Contains(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry containerGeometry, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry insideGeometry);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Contains(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).containerGeometry'></a>

`containerGeometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry that is tested for the "contains" relationship to the other geometry. Think of this geometry as the potential "container" of the insideGeometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Contains(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).insideGeometry'></a>

`insideGeometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry that is tested for the "within" relationship to the containerGeometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns true if the containerGeometry contains the insideGeometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.ConvexHull(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.ConvexHull(Geometry) Method

Calculates the convex hull of one or more geometries. A convex hull is the smallest convex polygon that encloses a group of geometries or vertices. The input can be a single geometry (such as a polyline) or an array of any geometry type. The hull is typically a polygon but can also be a polyline or a point in degenerate cases.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> ConvexHull(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.ConvexHull(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The input geometry used to calculate the convex hull.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns the convex hull of the input geometries. This is usually a polygon, but can also be a polyline (if the input is a set of points or polylines forming a straight line), or a point (in degenerate cases).

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.ConvexHull(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,System.Nullable_bool_)'></a>

## GeometryEngine.ConvexHull(IEnumerable<Geometry>, Nullable<bool>) Method

Calculates the convex hull of one or more geometries. A convex hull is the smallest convex polygon that encloses a group of geometries or vertices. The input can be a single geometry (such as a polyline) or an array of any geometry type. The hull is typically a polygon but can also be a polyline or a point in degenerate cases.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[]> ConvexHull(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> geometries, System.Nullable<bool> merge=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.ConvexHull(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,System.Nullable_bool_).geometries'></a>

`geometries` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The input geometries used to calculate the convex hull. The input array can include various geometry types.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.ConvexHull(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,System.Nullable_bool_).merge'></a>

`merge` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates whether to merge the output into a single geometry (usually a polygon).

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns the convex hull of the input geometries. This is usually a polygon, but can also be a polyline (if the input is a set of points or polylines forming a straight line), or a point (in degenerate cases).

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Crosses(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.Crosses(Geometry, Geometry) Method

Indicates if one geometry crosses another geometry.

```csharp
public System.Threading.Tasks.Task<bool> Crosses(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry1, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry2);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Crosses(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry1'></a>

`geometry1` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to cross.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Crosses(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry2'></a>

`geometry2` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry being crossed.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns true if geometry1 crosses geometry2.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Cut(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine)'></a>

## GeometryEngine.Cut(Geometry, PolyLine) Method

Splits the input Polyline or Polygon where it crosses a cutting Polyline. For Polylines, all left cuts are grouped together in the first Geometry. Right cuts and coincident cuts are grouped in the second Geometry and each undefined cut, along with any uncut parts, are output as separate Polylines. For Polygons, all left cuts are grouped in the first Polygon, all right cuts are grouped in the second Polygon, and each undefined cut, along with any leftover parts after cutting, are output as a separate Polygon. If no cuts are returned then the array will be empty. An undefined cut will only be produced if a left cut or right cut was produced and there was a part left over after cutting, or a cut is bounded to the left and right of the cutter.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[]> Cut(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine cutter);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Cut(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to be cut.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Cut(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine).cutter'></a>

`cutter` [PolyLine](dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.html 'dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine')

The polyline to cut the geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns an array of geometries created by cutting the input geometry with the cutter.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Densify(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_)'></a>

## GeometryEngine.Densify(Geometry, double, Nullable<LinearUnit>) Method

Densify geometries by plotting points between existing vertices.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> Densify(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, double maxSegmentLength, System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> maxSegmentLengthUnit=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Densify(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to be densified.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Densify(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).maxSegmentLength'></a>

`maxSegmentLength` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The maximum segment length allowed. Must be a positive value.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Densify(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).maxSegmentLengthUnit'></a>

`maxSegmentLengthUnit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit for maxSegmentLength. Defaults to the units of the input geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The densified geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Difference(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.Difference(Geometry, Geometry) Method

Creates the difference of two geometries. The resultant geometry is the portion of inputGeometry not in the subtractor. The dimension of the subtractor has to be equal to or greater than that of the inputGeometry.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> Difference(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry subtractor);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Difference(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The input geometry to subtract from.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Difference(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).subtractor'></a>

`subtractor` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry being subtracted from inputGeometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns the geometry of inputGeometry minus the subtractor geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Difference(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.Difference(IEnumerable<Geometry>, Geometry) Method

Creates the difference of two geometries. The resultant geometry is the portion of inputGeometry not in the subtractor. The dimension of the subtractor has to be equal to or greater than that of the inputGeometry.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[]> Difference(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> geometries, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry subtractor);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Difference(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometries'></a>

`geometries` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The input geometries to subtract from.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Difference(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).subtractor'></a>

`subtractor` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry being subtracted from inputGeometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns the geometry of inputGeometry minus the subtractor geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Disjoint(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.Disjoint(Geometry, Geometry) Method

Indicates if one geometry is disjoint (doesn't intersect in any way) with another geometry.

```csharp
public System.Threading.Tasks.Task<bool> Disjoint(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry1, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry2);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Disjoint(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry1'></a>

`geometry1` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The base geometry that is tested for the "disjoint" relationship to the other geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Disjoint(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry2'></a>

`geometry2` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The comparison geometry that is tested for the "disjoint" relationship to the other geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns true if geometry1 and geometry2 are disjoint (don't intersect in any way).

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Distance(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_)'></a>

## GeometryEngine.Distance(Geometry, Geometry, Nullable<LinearUnit>) Method

Calculates the shortest planar distance between two geometries. Distance is reported in the linear units specified by distanceUnit or, if distanceUnit is null, the units of the spatialReference of input geometry.

```csharp
public System.Threading.Tasks.Task<double> Distance(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry1, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry2, System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> distanceUnit=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Distance(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).geometry1'></a>

`geometry1` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

First input geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Distance(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).geometry2'></a>

`geometry2` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

Second input geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Distance(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).distanceUnit'></a>

`distanceUnit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit of the return value. Defaults to the units of the input geometries.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Distance between the two input geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.ExtendedSpatialReferenceInfo(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference)'></a>

## GeometryEngine.ExtendedSpatialReferenceInfo(SpatialReference) Method

Returns an object containing additional information about the input spatial reference.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReferenceInfo> ExtendedSpatialReferenceInfo(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference spatialReference);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.ExtendedSpatialReferenceInfo(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).spatialReference'></a>

`spatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

The input spatial reference.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[SpatialReferenceInfo](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReferenceInfo.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReferenceInfo')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Resolves to a [SpatialReferenceInfo](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReferenceInfo.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReferenceInfo') object.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.FlipHorizontal(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## GeometryEngine.FlipHorizontal(Geometry, Point) Method

Flips a geometry on the horizontal axis. Can optionally be flipped around a point.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> FlipHorizontal(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, dymaptic.GeoBlazor.Core.Components.Geometries.Point? flipOrigin=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.FlipHorizontal(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The input geometry to be flipped.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.FlipHorizontal(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point).flipOrigin'></a>

`flipOrigin` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

Point to flip the geometry around. Defaults to the centroid of the geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The flipped geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.FlipVertical(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## GeometryEngine.FlipVertical(Geometry, Point) Method

Flips a geometry on the vertical axis. Can optionally be flipped around a point.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> FlipVertical(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, dymaptic.GeoBlazor.Core.Components.Geometries.Point? flipOrigin=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.FlipVertical(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The input geometry to be flipped.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.FlipVertical(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point).flipOrigin'></a>

`flipOrigin` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

Point to flip the geometry around. Defaults to the centroid of the geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The flipped geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Generalize(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_)'></a>

## GeometryEngine.Generalize(Geometry, double, Nullable<bool>, Nullable<LinearUnit>) Method

Performs the generalize operation on the geometries in the cursor. Point and Multipoint geometries are left unchanged. Envelope is converted to a Polygon and then generalized.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> Generalize(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, double maxDeviation, System.Nullable<bool> removeDegenerateParts=null, System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> maxDeviationUnit=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Generalize(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The input geometry to be generalized.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Generalize(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).maxDeviation'></a>

`maxDeviation` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The maximum allowed deviation from the generalized geometry to the original geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Generalize(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).removeDegenerateParts'></a>

`removeDegenerateParts` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

When true the degenerate parts of the geometry will be removed from the output (may be undesired for drawing).

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Generalize(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).maxDeviationUnit'></a>

`maxDeviationUnit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit for maxDeviation. Defaults to the units of the input geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The generalized geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicArea(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon,System.Nullable_dymaptic.GeoBlazor.Core.Objects.ArealUnit_)'></a>

## GeometryEngine.GeodesicArea(Polygon, Nullable<ArealUnit>) Method

Calculates the area of the input geometry. As opposed to planarArea(), geodesicArea takes into account the curvature of the earth when performing this calculation. Therefore, when using input geometries with a spatial reference of either WGS84 (wkid: 4326) or Web Mercator, it is best practice to calculate areas using geodesicArea(). If the input geometries have a projected coordinate system other than Web Mercator, use planarArea() instead.

```csharp
public System.Threading.Tasks.Task<double> GeodesicArea(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon geometry, System.Nullable<dymaptic.GeoBlazor.Core.Objects.ArealUnit> unit=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicArea(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon,System.Nullable_dymaptic.GeoBlazor.Core.Objects.ArealUnit_).geometry'></a>

`geometry` [Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon')

The input polygon

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicArea(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon,System.Nullable_dymaptic.GeoBlazor.Core.Objects.ArealUnit_).unit'></a>

`unit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[ArealUnit](dymaptic.GeoBlazor.Core.Objects.ArealUnit.html 'dymaptic.GeoBlazor.Core.Objects.ArealUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit of the return value. Defaults to the units of the input geometries.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Area of the input geometry.

### Remarks
This method only works with WGS84 (wkid: 4326) and Web Mercator spatial references.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicBuffer(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_)'></a>

## GeometryEngine.GeodesicBuffer(Geometry, double, Nullable<LinearUnit>) Method

Creates geodesic buffer polygons at a specified distance around the input geometries. When calculating distances, this method takes the curvature of the earth into account, which provides highly accurate results when dealing with very large geometries and/or geometries that spatially vary on a global scale where one projected coordinate system could not accurately plot coordinates and measure distances for all the geometries.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Polygon> GeodesicBuffer(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, double distance, System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> unit=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicBuffer(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicBuffer(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).distance'></a>

`distance` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicBuffer(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).unit'></a>

`unit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit of the distance. Defaults to the units of the input geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The resulting buffers

### Remarks
This method only works with WGS84 (wkid: 4326) and Web Mercator spatial references. In general, if your input geometries are assigned one of those two spatial references, you should always use geodesicBuffer() to obtain the most accurate results for those geometries. If needing to buffer points assigned a projected coordinate system other than Web Mercator, use buffer() instead. If the input geometries have a geographic coordinate system other than WGS84 (wkid: 4326), use geometryService.buffer().

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicBuffer(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,System.Collections.Generic.IEnumerable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_bool_)'></a>

## GeometryEngine.GeodesicBuffer(IEnumerable<Geometry>, IEnumerable<double>, Nullable<LinearUnit>, Nullable<bool>) Method

Creates geodesic buffer polygons at a specified distance around the input geometries. When calculating distances, this method takes the curvature of the earth into account, which provides highly accurate results when dealing with very large geometries and/or geometries that spatially vary on a global scale where one projected coordinate system could not accurately plot coordinates and measure distances for all the geometries.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Polygon[]> GeodesicBuffer(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> geometries, System.Collections.Generic.IEnumerable<double> distances, System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> unit=null, System.Nullable<bool> unionResults=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicBuffer(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,System.Collections.Generic.IEnumerable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_bool_).geometries'></a>

`geometries` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The buffer input geometries

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicBuffer(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,System.Collections.Generic.IEnumerable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_bool_).distances'></a>

`distances` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The specified distance(s) for buffering. The length of the geometry array does not have to equal the length of the distance array. For example, if you pass an array of four geometries: [g1, g2, g3, g4] and an array with one distance: [d1], all four geometries will be buffered by the single distance value. If instead you use an array of three distances: [d1, d2, d3], g1 will be buffered by d1, g2 by d2, and g3 and g4 will both be buffered by d3. The value of the geometry array will be matched one to one with those in the distance array until the final value of the distance array is reached, in which case that value will be applied to the remaining geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicBuffer(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,System.Collections.Generic.IEnumerable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_bool_).unit'></a>

`unit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit of the distance(s). Defaults to the units of the input geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicBuffer(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,System.Collections.Generic.IEnumerable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_bool_).unionResults'></a>

`unionResults` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Determines whether the output geometries should be unioned into a single polygon.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The resulting buffers

### Remarks
This method only works with WGS84 (wkid: 4326) and Web Mercator spatial references. In general, if your input geometries are assigned one of those two spatial references, you should always use geodesicBuffer() to obtain the most accurate results for those geometries. If needing to buffer points assigned a projected coordinate system other than Web Mercator, use buffer() instead. If the input geometries have a geographic coordinate system other than WGS84 (wkid: 4326), use geometryService.buffer().

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicDensify(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_)'></a>

## GeometryEngine.GeodesicDensify(Geometry, double, Nullable<LinearUnit>) Method

Returns a geodesically densified version of the input geometry. Use this function to draw the line(s) of the geometry along great circles.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> GeodesicDensify(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, double maxSegmentLength, System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> maxSegmentLenghtUnit=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicDensify(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

A polyline or polygon to densify.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicDensify(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).maxSegmentLength'></a>

`maxSegmentLength` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The maximum segment length allowed (in meters if a maxSegmentLengthUnit is not provided). This must be a positive value.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicDensify(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).maxSegmentLenghtUnit'></a>

`maxSegmentLenghtUnit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit for maxSegmentLength. If not provided, the unit will default to meters.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns the densified geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicLength(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_)'></a>

## GeometryEngine.GeodesicLength(Geometry, Nullable<LinearUnit>) Method

Calculates the length of the input geometry. As opposed to planarLength(), geodesicLength() takes into account the curvature of the earth when performing this calculation. Therefore, when using input geometries with a spatial reference of either WGS84 (wkid: 4326) or Web Mercator, it is best practice to calculate lengths using geodesicLength(). If the input geometries have a projected coordinate system other than Web Mercator, use planarLength() instead.

```csharp
public System.Threading.Tasks.Task<double> GeodesicLength(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> unit=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicLength(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The input geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.GeodesicLength(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).unit'></a>

`unit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit of the return value. Defaults to the units of the input geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Length of the input geometry.

### Remarks
This method only works with WGS84 (wkid: 4326) and Web Mercator spatial references.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Intersect(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.Intersect(Geometry, Geometry) Method

Creates new geometries from the intersections between two geometries. If the input geometries have different dimensions (i.e. point = 0; polyline = 1; polygon = 2), then the result's dimension will be equal to the lowest dimension of the inputs.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> Intersect(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry1, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry2);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Intersect(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry1'></a>

`geometry1` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The input geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Intersect(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry2'></a>

`geometry2` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to intersect with geometry1.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The intersections of the geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Intersect(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.Intersect(IEnumerable<Geometry>, Geometry) Method

Creates new geometries from the intersections between two geometries. If the input geometries have different dimensions (i.e. point = 0; polyline = 1; polygon = 2), then the result's dimension will be equal to the lowest dimension of the inputs. The table below describes the expected output for various combinations of geometry types.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[]> Intersect(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> geometries1, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry2);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Intersect(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometries1'></a>

`geometries1` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The input array of geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Intersect(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry2'></a>

`geometry2` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to intersect with geometries1.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The intersections of the geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Intersects(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.Intersects(Geometry, Geometry) Method

Indicates if one geometry intersects another geometry.

```csharp
public System.Threading.Tasks.Task<bool> Intersects(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry1, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry2);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Intersects(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry1'></a>

`geometry1` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry that is tested for the intersects relationship to the other geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Intersects(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry2'></a>

`geometry2` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry being intersected.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns true if the input geometries intersect each other.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.IsSimple(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.IsSimple(Geometry) Method

Indicates if the given geometry is topologically simple. In a simplified geometry, no polygon rings or polyline paths will overlap, and no self-intersection will occur.

```csharp
public System.Threading.Tasks.Task<bool> IsSimple(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.IsSimple(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The input geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns true if the geometry is topologically simple.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.NearestCoordinate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## GeometryEngine.NearestCoordinate(Geometry, Point) Method

Finds the coordinate of the geometry that is closest to the specified point.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.NearestPointResult> NearestCoordinate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, dymaptic.GeoBlazor.Core.Components.Geometries.Point inputPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.NearestCoordinate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to consider.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.NearestCoordinate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point).inputPoint'></a>

`inputPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The point used to search the nearest coordinate in the geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[NearestPointResult](dymaptic.GeoBlazor.Core.Components.Geometries.NearestPointResult.html 'dymaptic.GeoBlazor.Core.Components.Geometries.NearestPointResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns an object containing the nearest coordinate.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.NearestVertex(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## GeometryEngine.NearestVertex(Geometry, Point) Method

Finds the vertex on the geometry nearest to the specified point.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.NearestPointResult> NearestVertex(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, dymaptic.GeoBlazor.Core.Components.Geometries.Point inputPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.NearestVertex(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to consider.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.NearestVertex(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point).inputPoint'></a>

`inputPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The point used to search the nearest vertex in the geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[NearestPointResult](dymaptic.GeoBlazor.Core.Components.Geometries.NearestPointResult.html 'dymaptic.GeoBlazor.Core.Components.Geometries.NearestPointResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns an object containing the nearest vertex.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.NearestVertices(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,int)'></a>

## GeometryEngine.NearestVertices(Geometry, Point, double, int) Method

Finds all vertices in the given distance from the specified point, sorted from the closest to the furthest and returns them as an array of Objects.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.NearestPointResult[]> NearestVertices(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, dymaptic.GeoBlazor.Core.Components.Geometries.Point inputPoint, double searchRadius, int maxVertexCountToReturn);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.NearestVertices(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,int).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to consider.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.NearestVertices(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,int).inputPoint'></a>

`inputPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The point from which to measure.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.NearestVertices(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,int).searchRadius'></a>

`searchRadius` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The distance to search from the inputPoint in the units of the view's spatial reference.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.NearestVertices(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,int).maxVertexCountToReturn'></a>

`maxVertexCountToReturn` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The maximum number of vertices to return.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[NearestPointResult](dymaptic.GeoBlazor.Core.Components.Geometries.NearestPointResult.html 'dymaptic.GeoBlazor.Core.Components.Geometries.NearestPointResult')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
An array of objects containing the nearest vertices within the given searchRadius.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_)'></a>

## GeometryEngine.Offset(Geometry, double, Nullable<LinearUnit>, Nullable<JoinType>, Nullable<double>, Nullable<double>) Method

The offset operation creates a geometry that is a constant planar distance from an input polyline or polygon. It is similar to buffering, but produces a one-sided result.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> Offset(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, double offsetDistance, System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> offsetUnit=null, System.Nullable<dymaptic.GeoBlazor.Core.Model.JoinType> joinType=null, System.Nullable<double> bevelRatio=null, System.Nullable<double> flattenError=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to offset.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_).offsetDistance'></a>

`offsetDistance` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The planar distance to offset from the input geometry. If offsetDistance > 0, then the offset geometry is constructed to the right of the oriented input geometry, if offsetDistance = 0, then there is no change in the geometries, otherwise it is constructed to the left. For a simple polygon, the orientation of outer rings is clockwise and for inner rings it is counter clockwise. So the "right side" of a simple polygon is always its inside.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_).offsetUnit'></a>

`offsetUnit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit of the offset distance. Defaults to the units of the input geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_).joinType'></a>

`joinType` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[JoinType](dymaptic.GeoBlazor.Core.Model.JoinType.html 'dymaptic.GeoBlazor.Core.Model.JoinType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The [JoinType](dymaptic.GeoBlazor.Core.Model.JoinType.html 'dymaptic.GeoBlazor.Core.Model.JoinType')

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_).bevelRatio'></a>

`bevelRatio` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Applicable when joinType = 'miter'; bevelRatio is multiplied by the offset distance and the result determines how far a mitered offset intersection can be located before it is beveled.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_).flattenError'></a>

`flattenError` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Applicable when joinType = 'round'; flattenError determines the maximum distance of the resulting segments compared to the true circular arc. The algorithm never produces more than around 180 vertices for each round join.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The offset geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_)'></a>

## GeometryEngine.Offset(IEnumerable<Geometry>, double, Nullable<LinearUnit>, Nullable<JoinType>, Nullable<double>, Nullable<double>) Method

The offset operation creates a geometry that is a constant planar distance from an input polyline or polygon. It is similar to buffering, but produces a one-sided result.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[]> Offset(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> geometries, double offsetDistance, System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> offsetUnit=null, System.Nullable<dymaptic.GeoBlazor.Core.Model.JoinType> joinType=null, System.Nullable<double> bevelRatio=null, System.Nullable<double> flattenError=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_).geometries'></a>

`geometries` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The geometries to offset.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_).offsetDistance'></a>

`offsetDistance` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The planar distance to offset from the input geometry. If offsetDistance > 0, then the offset geometry is constructed to the right of the oriented input geometry, if offsetDistance = 0, then there is no change in the geometries, otherwise it is constructed to the left. For a simple polygon, the orientation of outer rings is clockwise and for inner rings it is counter clockwise. So the "right side" of a simple polygon is always its inside.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_).offsetUnit'></a>

`offsetUnit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit of the offset distance. Defaults to the units of the input geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_).joinType'></a>

`joinType` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[JoinType](dymaptic.GeoBlazor.Core.Model.JoinType.html 'dymaptic.GeoBlazor.Core.Model.JoinType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The [JoinType](dymaptic.GeoBlazor.Core.Model.JoinType.html 'dymaptic.GeoBlazor.Core.Model.JoinType')

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_).bevelRatio'></a>

`bevelRatio` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Applicable when joinType = 'miter'; bevelRatio is multiplied by the offset distance and the result determines how far a mitered offset intersection can be located before it is beveled.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Offset(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,double,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_,System.Nullable_dymaptic.GeoBlazor.Core.Model.JoinType_,System.Nullable_double_,System.Nullable_double_).flattenError'></a>

`flattenError` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Applicable when joinType = 'round'; flattenError determines the maximum distance of the resulting segments compared to the true circular arc. The algorithm never produces more than around 180 vertices for each round join.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The offset geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Overlaps(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.Overlaps(Geometry, Geometry) Method

Indicates if one geometry overlaps another geometry.

```csharp
public System.Threading.Tasks.Task<bool> Overlaps(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry1, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry2);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Overlaps(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry1'></a>

`geometry1` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The base geometry that is tested for the "overlaps" relationship with the other geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Overlaps(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry2'></a>

`geometry2` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The comparison geometry that is tested for the "overlaps" relationship with the other geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns true if the two geometries overlap.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.PlanarArea(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon,System.Nullable_dymaptic.GeoBlazor.Core.Objects.ArealUnit_)'></a>

## GeometryEngine.PlanarArea(Polygon, Nullable<ArealUnit>) Method

Calculates the area of the input geometry. As opposed to geodesicArea(), planarArea() performs this calculation using projected coordinates and does not take into account the earth's curvature. When using input geometries with a spatial reference of either WGS84 (wkid: 4326) or Web Mercator, it is best practice to calculate areas using geodesicArea(). If the input geometries have a projected coordinate system other than Web Mercator, use planarArea() instead.

```csharp
public System.Threading.Tasks.Task<double> PlanarArea(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon geometry, System.Nullable<dymaptic.GeoBlazor.Core.Objects.ArealUnit> unit=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.PlanarArea(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon,System.Nullable_dymaptic.GeoBlazor.Core.Objects.ArealUnit_).geometry'></a>

`geometry` [Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon')

The input polygon.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.PlanarArea(dymaptic.GeoBlazor.Core.Components.Geometries.Polygon,System.Nullable_dymaptic.GeoBlazor.Core.Objects.ArealUnit_).unit'></a>

`unit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[ArealUnit](dymaptic.GeoBlazor.Core.Objects.ArealUnit.html 'dymaptic.GeoBlazor.Core.Objects.ArealUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit of the return value. Defaults to the units of the input geometries.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The area of the input geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.PlanarLength(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_)'></a>

## GeometryEngine.PlanarLength(Geometry, Nullable<LinearUnit>) Method

Calculates the length of the input geometry. As opposed to geodesicLength(), planarLength() uses projected coordinates and does not take into account the curvature of the earth when performing this calculation. When using input geometries with a spatial reference of either WGS84 (wkid: 4326) or Web Mercator, it is best practice to calculate lengths using geodesicLength(). If the input geometries have a projected coordinate system other than Web Mercator, use planarLength() instead.

```csharp
public System.Threading.Tasks.Task<double> PlanarLength(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, System.Nullable<dymaptic.GeoBlazor.Core.Objects.LinearUnit> unit=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.PlanarLength(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The input geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.PlanarLength(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,System.Nullable_dymaptic.GeoBlazor.Core.Objects.LinearUnit_).unit'></a>

`unit` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Measurement unit of the return value. Defaults to the units of the input geometries.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The length of the input geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Relate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,string)'></a>

## GeometryEngine.Relate(Geometry, Geometry, string) Method

Indicates if the given DE-9IM relation is true for the two geometries.

```csharp
public System.Threading.Tasks.Task<bool> Relate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry1, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry2, string relation);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Relate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,string).geometry1'></a>

`geometry1` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The first geometry for the relation.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Relate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,string).geometry2'></a>

`geometry2` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The second geometry for the relation.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Relate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,string).relation'></a>

`relation` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The Dimensionally Extended 9 Intersection Model (DE-9IM) matrix relation (encoded as a string) to test against the relationship of the two geometries. This string contains the test result of each intersection represented in the DE-9IM matrix. Each result is one character of the string and may be represented as either a number (maximum dimension returned: 0,1,2), a Boolean value (T or F), or a mask character (for ignoring results: '*'). For example, each of the following DE-9IM string codes are valid for testing whether a polygon geometry completely contains a line geometry: TTTFFTFFT (Boolean), 'T******FF*' (ignore irrelevant intersections), or '102FF*FF*' (dimension form). Each returns the same result. See <a target="_blank" href="https://en.wikipedia.org/wiki/DE-9IM">this article</a> and <a target="_blank" href="https://desktop.arcgis.com/en/arcmap/latest/manage-data/using-sql-with-gdbs/relational-functions-for-st-geometry.htm">this ArcGIS help page</a> for more information about the DE-9IM model and how string codes are constructed.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns true if the relation of the input geometries is accurate.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Rotate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## GeometryEngine.Rotate(Geometry, double, Point) Method

Rotates a geometry counterclockwise by the specified number of degrees. Rotation is around the centroid, or a given rotation point.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> Rotate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, double angle, dymaptic.GeoBlazor.Core.Components.Geometries.Point rotationOrigin);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Rotate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to rotate.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Rotate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point).angle'></a>

`angle` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The rotation angle in degrees.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Rotate(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point).rotationOrigin'></a>

`rotationOrigin` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

Point to rotate the geometry around. Defaults to the centroid of the geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The rotated geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Simplify(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.Simplify(Geometry) Method

Performs the simplify operation on the geometry, which alters the given geometries to make their definitions topologically legal with respect to their geometry type. At the end of a simplify operation, no polygon rings or polyline paths will overlap, and no self-intersection will occur.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> Simplify(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Simplify(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to be simplified.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The simplified geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.SymmetricDifference(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.SymmetricDifference(Geometry, Geometry) Method

Creates the symmetric difference of two geometries. The symmetric difference includes the parts that are in either of the sets, but not in both.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> SymmetricDifference(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry leftGeometry, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry rightGeometry);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.SymmetricDifference(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).leftGeometry'></a>

`leftGeometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

One of the Geometry instances in the XOR operation.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.SymmetricDifference(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).rightGeometry'></a>

`rightGeometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

One of the Geometry instances in the XOR operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The symmetric differences of the two geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.SymmetricDifference(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.SymmetricDifference(IEnumerable<Geometry>, Geometry) Method

Creates the symmetric difference of two geometries. The symmetric difference includes the parts that are in either of the sets, but not in both.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[]> SymmetricDifference(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> leftGeometries, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry rightGeometry);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.SymmetricDifference(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).leftGeometries'></a>

`leftGeometries` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

One of the Geometry instances in the XOR operation.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.SymmetricDifference(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).rightGeometry'></a>

`rightGeometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

One of the Geometry instances in the XOR operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The symmetric differences of the two geometries.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Touches(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.Touches(Geometry, Geometry) Method

Indicates if one geometry touches another geometry.

```csharp
public System.Threading.Tasks.Task<bool> Touches(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry1, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry2);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Touches(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry1'></a>

`geometry1` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to test the "touches" relationship with the other geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Touches(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry2'></a>

`geometry2` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry to be touched.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
When true, geometry1 touches geometry2.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Union(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[])'></a>

## GeometryEngine.Union(Geometry[]) Method

All inputs must be of the same type of geometries and share one spatial reference.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> Union(params dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[] geometries);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Union(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[]).geometries'></a>

`geometries` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

An array of Geometries to union.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The union of the geometries

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Union(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_)'></a>

## GeometryEngine.Union(IEnumerable<Geometry>) Method

All inputs must be of the same type of geometries and share one spatial reference.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> Union(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> geometries);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Union(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Geometries.Geometry_).geometries'></a>

`geometries` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

An array of Geometries to union.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The union of the geometries

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Within(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## GeometryEngine.Within(Geometry, Geometry) Method

Indicates if one geometry is within another geometry.

```csharp
public System.Threading.Tasks.Task<bool> Within(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry innerGeometry, dymaptic.GeoBlazor.Core.Components.Geometries.Geometry outerGeometry);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Within(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).innerGeometry'></a>

`innerGeometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The base geometry that is tested for the "within" relationship to the other geometry.

<a name='dymaptic.GeoBlazor.Core.Model.GeometryEngine.Within(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).outerGeometry'></a>

`outerGeometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The comparison geometry that is tested for the "contains" relationship to the other geometry.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns true if innerGeometry is within outerGeometry.
