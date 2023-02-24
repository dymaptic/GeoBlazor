---
layout: default
title: FeatureLayerView
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## FeatureLayerView Class

The FeatureLayerView is responsible for rendering a FeatureLayer's features as graphics in the View. The methods in the FeatureLayerView provide developers with the ability to query and highlight graphics in the view. See the code snippets in the methods below for examples of how to access client-side graphics from the view.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#whenLayerView">ArcGIS JS API</a>

```csharp
public class FeatureLayerView : dymaptic.GeoBlazor.Core.Components.Layers.LayerView
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView') &#129106; FeatureLayerView
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.Filter'></a>

## FeatureLayerView.Filter Property

The attribute, geometry, and time extent filter. Only the features that satisfy the filter are displayed on the view.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter? Filter { get; }
```

#### Property Value
[FeatureFilter](dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.CreateQuery()'></a>

## FeatureLayerView.CreateQuery() Method

Creates query parameter object that can be used to fetch features as they are being displayed. It sets the query parameter's outFields property to ["*"] and returnGeometry to true. The output spatial reference outSpatialReference is set to the spatial reference of the view. Parameters of the filter currently applied to the layerview are also incorporated in the returned query object. The results will include geometries of features and values for availableFields.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Objects.Query> CreateQuery();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.Highlight(dymaptic.GeoBlazor.Core.Components.Layers.Graphic)'></a>

## FeatureLayerView.Highlight(Graphic) Method

Highlights the given feature(s).

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle> Highlight(dymaptic.GeoBlazor.Core.Components.Layers.Graphic graphic);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.Highlight(dymaptic.GeoBlazor.Core.Components.Layers.Graphic).graphic'></a>

`graphic` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

The [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') to highlight.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[HighlightHandle](dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle.html 'dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A handle that allows the highlight to be removed later.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.Highlight(int)'></a>

## FeatureLayerView.Highlight(int) Method

Highlights the given feature(s).

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle> Highlight(int objectId);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.Highlight(int).objectId'></a>

`objectId` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The ObjectID of the graphic to highlight.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[HighlightHandle](dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle.html 'dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A handle that allows the highlight to be removed later.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.Highlight(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_)'></a>

## FeatureLayerView.Highlight(IEnumerable<Graphic>) Method

Highlights the given feature(s).

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle> Highlight(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> graphics);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.Highlight(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_).graphics'></a>

`graphics` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The graphics to highlight.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[HighlightHandle](dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle.html 'dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A handle that allows the highlight to be removed later.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.Highlight(System.Collections.Generic.IEnumerable_int_)'></a>

## FeatureLayerView.Highlight(IEnumerable<int>) Method

Highlights the given feature(s).

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle> Highlight(System.Collections.Generic.IEnumerable<int> objectIds);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.Highlight(System.Collections.Generic.IEnumerable_int_).objectIds'></a>

`objectIds` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The ObjectIDs of the graphics to highlight.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[HighlightHandle](dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle.html 'dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A handle that allows the highlight to be removed later.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.OnQueryFeaturesCreateChunk(string,int)'></a>

## FeatureLayerView.OnQueryFeaturesCreateChunk(string, int) Method

partial query result return for Blazor Server, to avoid SignalR size limits

```csharp
public void OnQueryFeaturesCreateChunk(string chunk, int chunkIndex);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.OnQueryFeaturesCreateChunk(string,int).chunk'></a>

`chunk` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.OnQueryFeaturesCreateChunk(string,int).chunkIndex'></a>

`chunkIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken)'></a>

## FeatureLayerView.QueryExtent(Query, CancellationToken) Method

Executes a Query against features available for drawing in the layerView and returns the Extent of features that satisfy the query. Valid only for hosted feature services on arcgis.com and for ArcGIS Server 10.3.1 and later. If query parameters are not provided, the extent and count of all features available for drawing are returned.  
To query for the extent of features directly from a Feature Service rather than those visible in the view, you must use the [QueryExtent(Query, CancellationToken)](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query, System.Threading.CancellationToken)') method.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult> QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query query, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).query'></a>

`query` [Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query')

Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the geometry parameter in the query object to the view's extent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used to cancel the query operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ExtentQueryResult](dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult.html 'dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

### Remarks
Spatial queries are executed against quantized geometries in the layerView. The resolution of layerView geometries, is only as precise as the scale resolution of the view. Therefore, the results of the same query could be different when executed at different scales. This also means that geometries returned from any layerView query will likewise be at the same scale resolution of the view.  
Spatial queries have the same limitations as those listed in the projection engine documentation.  
Spatial queries are not currently supported if the FeatureLayerView has any of the following SpatialReferences:  
    GDM 2000 (4742) – Malaysia,  
    Gusterberg (Ferro) (8042) – Austria/Czech Republic,  
    ISN2016 (8086) - Iceland,  
    SVY21 (4757) - Singapore

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken)'></a>

## FeatureLayerView.QueryFeatureCount(Query, CancellationToken) Method

Executes a Query against features available for drawing in the layerView and returns the number of features that satisfy the query. If query parameters are not provided, the count of all features available for drawing is returned.  
To query for the count of features directly from a Feature Service rather than those visible in the view, you must use the [QueryFeatureCount(Query, CancellationToken)](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query, System.Threading.CancellationToken)') method.

```csharp
public System.Threading.Tasks.Task<int> QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query? query=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).query'></a>

`query` [Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query')

Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the geometry parameter in the query object to the view's extent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used to cancel the query operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

### Remarks
Spatial queries are executed against quantized geometries in the layerView. The resolution of layerView geometries, is only as precise as the scale resolution of the view. Therefore, the results of the same query could be different when executed at different scales. This also means that geometries returned from any layerView query will likewise be at the same scale resolution of the view.  
Spatial queries have the same limitations as those listed in the projection engine documentation.  
Spatial queries are not currently supported if the FeatureLayerView has any of the following SpatialReferences:  
    GDM 2000 (4742) – Malaysia,  
    Gusterberg (Ferro) (8042) – Austria/Czech Republic,  
    ISN2016 (8086) - Iceland,  
    SVY21 (4757) - Singapore

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken)'></a>

## FeatureLayerView.QueryFeatures(Query, CancellationToken) Method

Executes a Query against features available for drawing in the layerView and returns a FeatureSet. If query parameters are not provided, all features available for drawing are returned along with their attributes that are available on the client. For client-side attribute queries, relevant fields should exist in availableFields list for the query to be successful.  
To execute a query against all the features in a feature service rather than only those in the client, you must use the [QueryFeatures(Query, CancellationToken)](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query, System.Threading.CancellationToken)') method.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet?> QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query? query=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).query'></a>

`query` [Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query')

Specifies the attributes and spatial filter of the query. When this parameter is not passed to queryFeatures() method, all features available for drawing are returned along with their attributes that are available on the client. To only return features visible in the view, set the geometry parameter in the query object to the view's extent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used to cancel the query operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[FeatureSet](dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

### Remarks
Attribute values used in attribute queries executed against layerViews are case sensitive.  
Spatial queries are executed against quantized geometries in the layerView. The resolution of layerView geometries, is only as precise as the scale resolution of the view. Therefore, the results of the same query could be different when executed at different scales. This also means that geometries returned from any layerView query will likewise be at the same scale resolution of the view.  
Spatial queries have the same limitations as those listed in the projection engine documentation.  
Spatial queries are not currently supported if the FeatureLayerView has any of the following SpatialReferences:  
    GDM 2000 (4742) – Malaysia,  
    Gsterberg (Ferro) (8042) – Austria/Czech Republic,  
    ISN2016 (8086) - Iceland,  
    SVY21 (4757) - Singapore

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken)'></a>

## FeatureLayerView.QueryObjectIds(Query, CancellationToken) Method

Executes a Query against features available for drawing in the layerView and returns array of the ObjectIDs of features that satisfy the input query. If query parameters are not provided, the ObjectIDs of all features available for drawing are returned.  
To query for ObjectIDs of features directly from a Feature Service rather than those visible in the view, you must use the [QueryObjectIds(Query, CancellationToken)](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query, System.Threading.CancellationToken)') method.

```csharp
public System.Threading.Tasks.Task<int[]> QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query query, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).query'></a>

`query` [Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query')

Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the geometry parameter in the query object to the view's extent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used to cancel the query operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.SetFilter(dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter)'></a>

## FeatureLayerView.SetFilter(FeatureFilter) Method

Sets the [FeatureFilter](dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter') for this view.

```csharp
public System.Threading.Tasks.Task SetFilter(dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter? filter);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.SetFilter(dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter).filter'></a>

`filter` [FeatureFilter](dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureFilter')

The new filter (or null to clear) to apply to this view.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')
