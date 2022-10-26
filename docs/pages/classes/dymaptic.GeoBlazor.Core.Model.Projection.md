---
layout: default
title: Projection
parent: Classes
---
---
layout: default
title: Projection
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Model](index.html#dymaptic.GeoBlazor.Core.Model 'dymaptic.GeoBlazor.Core.Model')

## Projection Class

A client-side projection engine for converting geometries from one SpatialReference to another. When projecting geometries the starting spatial reference must be specified on the input geometry. You can specify a specific geographic (datum) transformation for the project operation, or accept the default transformation if one is needed.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-projection.html">ArcGIS JS API</a>

```csharp
public class Projection : dymaptic.GeoBlazor.Core.Model.LogicComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [LogicComponent](dymaptic.GeoBlazor.Core.Model.LogicComponent.html 'dymaptic.GeoBlazor.Core.Model.LogicComponent') &#129106; Projection
### Constructors

<a name='dymaptic.GeoBlazor.Core.Model.Projection.Projection(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration)'></a>

## Projection(IJSRuntime, IConfiguration) Constructor

Default Constructor

```csharp
public Projection(Microsoft.JSInterop.IJSRuntime jsRuntime, Microsoft.Extensions.Configuration.IConfiguration configuration);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.Projection.Projection(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration).jsRuntime'></a>

`jsRuntime` [Microsoft.JSInterop.IJSRuntime](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSRuntime 'Microsoft.JSInterop.IJSRuntime')

Injected JavaScript Runtime reference

<a name='dymaptic.GeoBlazor.Core.Model.Projection.Projection(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration).configuration'></a>

`configuration` [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')

Injected configuration object
### Methods

<a name='dymaptic.GeoBlazor.Core.Model.Projection.GetTransformation(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## Projection.GetTransformation(SpatialReference, SpatialReference, Extent) Method

Returns the default geographic transformation used to convert the geometry from the input spatial reference to the output spatial reference. The default transformation is used when projecting geometries where the datum transformation is required but not specified in the geographicTransformation parameter.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Objects.GeographicTransformation?> GetTransformation(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference inSpatialReference, dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference outSpatialReference, dymaptic.GeoBlazor.Core.Components.Geometries.Extent extent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.Projection.GetTransformation(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).inSpatialReference'></a>

`inSpatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

The input spatial reference from which to project geometries. This is the spatial reference of the input geometries.

<a name='dymaptic.GeoBlazor.Core.Model.Projection.GetTransformation(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).outSpatialReference'></a>

`outSpatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

The spatial reference to which you are converting the geometries.

<a name='dymaptic.GeoBlazor.Core.Model.Projection.GetTransformation(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).extent'></a>

`extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

The optional spatial reference to which you are converting the geometries.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[GeographicTransformation](dymaptic.GeoBlazor.Core.Objects.GeographicTransformation.html 'dymaptic.GeoBlazor.Core.Objects.GeographicTransformation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A geographic transformation.

<a name='dymaptic.GeoBlazor.Core.Model.Projection.GetTransformations(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## Projection.GetTransformations(SpatialReference, SpatialReference, Extent) Method

Returns a list of all geographic transformations suitable to convert geometries from the input spatial reference to the specified output spatial reference. The list is ordered in descending order by suitability, with the most suitable being first in the list.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Objects.GeographicTransformation[]?> GetTransformations(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference inSpatialReference, dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference outSpatialReference, dymaptic.GeoBlazor.Core.Components.Geometries.Extent extent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.Projection.GetTransformations(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).inSpatialReference'></a>

`inSpatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

The spatial reference that the geometries are currently using.

<a name='dymaptic.GeoBlazor.Core.Model.Projection.GetTransformations(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).outSpatialReference'></a>

`outSpatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

The spatial reference to which you are converting the geometries.

<a name='dymaptic.GeoBlazor.Core.Model.Projection.GetTransformations(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).extent'></a>

`extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

An optional extent used to determine the suitability of the returned transformations. The extent will be re-projected to the input spatial reference if necessary.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[GeographicTransformation](dymaptic.GeoBlazor.Core.Objects.GeographicTransformation.html 'dymaptic.GeoBlazor.Core.Objects.GeographicTransformation')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A collection of geographic transformation.

<a name='dymaptic.GeoBlazor.Core.Model.Projection.Project(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Objects.GeographicTransformation)'></a>

## Projection.Project(Geometry, SpatialReference, GeographicTransformation) Method

Projects a geometry to the specified output spatial reference.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry?> Project(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry, dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference spatialReference, dymaptic.GeoBlazor.Core.Objects.GeographicTransformation? geographicTransformation=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.Projection.Project(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Objects.GeographicTransformation).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The input geometry to project

<a name='dymaptic.GeoBlazor.Core.Model.Projection.Project(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Objects.GeographicTransformation).spatialReference'></a>

`spatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

The spatial reference to which you are converting the geometries' coordinates.

<a name='dymaptic.GeoBlazor.Core.Model.Projection.Project(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Objects.GeographicTransformation).geographicTransformation'></a>

`geographicTransformation` [GeographicTransformation](dymaptic.GeoBlazor.Core.Objects.GeographicTransformation.html 'dymaptic.GeoBlazor.Core.Objects.GeographicTransformation')

The optional geographic transformation used to transform the geometries. Specify this parameter to project a geometry when the default transformation is not appropriate for your requirements.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A projected geometry.

<a name='dymaptic.GeoBlazor.Core.Model.Projection.Project(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[],dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Objects.GeographicTransformation)'></a>

## Projection.Project(Geometry[], SpatialReference, GeographicTransformation) Method

Projects an array of geometries to the specified output spatial reference.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[]?> Project(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[] geometries, dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference spatialReference, dymaptic.GeoBlazor.Core.Objects.GeographicTransformation? geographicTransformation=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.Projection.Project(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[],dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Objects.GeographicTransformation).geometries'></a>

`geometries` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The input geometries to project

<a name='dymaptic.GeoBlazor.Core.Model.Projection.Project(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[],dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Objects.GeographicTransformation).spatialReference'></a>

`spatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

The spatial reference to which you are converting the geometries' coordinates.

<a name='dymaptic.GeoBlazor.Core.Model.Projection.Project(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry[],dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Objects.GeographicTransformation).geographicTransformation'></a>

`geographicTransformation` [GeographicTransformation](dymaptic.GeoBlazor.Core.Objects.GeographicTransformation.html 'dymaptic.GeoBlazor.Core.Objects.GeographicTransformation')

The optional geographic transformation used to transform the geometries. Specify this parameter to project a geometry when the default transformation is not appropriate for your requirements.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A collection of projected geometries.

