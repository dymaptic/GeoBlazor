---
layout: default
title: LayerView
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## LayerView Class

Represents the view for a single layer after it has been added to either a MapView or a SceneView.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">ArcGIS JS API</a>

```csharp
public class LayerView :
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Layers.LayerView>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LayerView

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.LayerView(dymaptic.GeoBlazor.Core.Components.Layers.Layer,bool,bool,bool,bool)'></a>

## LayerView(Layer, bool, bool, bool, bool) Constructor

Represents the view for a single layer after it has been added to either a MapView or a SceneView.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">ArcGIS JS API</a>

```csharp
public LayerView(dymaptic.GeoBlazor.Core.Components.Layers.Layer Layer, bool SpatialReferenceSupported, bool Suspended, bool Updating, bool Visible);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.LayerView(dymaptic.GeoBlazor.Core.Components.Layers.Layer,bool,bool,bool,bool).Layer'></a>

`Layer` [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

The layer being viewed.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.LayerView(dymaptic.GeoBlazor.Core.Components.Layers.Layer,bool,bool,bool,bool).SpatialReferenceSupported'></a>

`SpatialReferenceSupported` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates if the spatialReference of the MapView is supported by the layer view.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.LayerView(dymaptic.GeoBlazor.Core.Components.Layers.Layer,bool,bool,bool,bool).Suspended'></a>

`Suspended` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Value is true if the layer is suspended (i.e., layer will not redraw or update itself when the extent changes).

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.LayerView(dymaptic.GeoBlazor.Core.Components.Layers.Layer,bool,bool,bool,bool).Updating'></a>

`Updating` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Value is true when the layer is updating; for example, if it is in the process of fetching data.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.LayerView(dymaptic.GeoBlazor.Core.Components.Layers.Layer,bool,bool,bool,bool).Visible'></a>

`Visible` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Value is true when the layer is updating; for example, if it is in the process of fetching data.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.JsObjectReference'></a>

## LayerView.JsObjectReference Property

The JavaScript object reference used by the LayerView.

```csharp
public Microsoft.JSInterop.IJSObjectReference? JsObjectReference { get; set; }
```

#### Property Value
[Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Layer'></a>

## LayerView.Layer Property

The layer being viewed.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Layer Layer { get; set; }
```

#### Property Value
[Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.SpatialReferenceSupported'></a>

## LayerView.SpatialReferenceSupported Property

Indicates if the spatialReference of the MapView is supported by the layer view.

```csharp
public bool SpatialReferenceSupported { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Suspended'></a>

## LayerView.Suspended Property

Value is true if the layer is suspended (i.e., layer will not redraw or update itself when the extent changes).

```csharp
public bool Suspended { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Updating'></a>

## LayerView.Updating Property

Value is true when the layer is updating; for example, if it is in the process of fetching data.

```csharp
public bool Updating { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Visible'></a>

## LayerView.Visible Property

Value is true when the layer is updating; for example, if it is in the process of fetching data.

```csharp
public bool Visible { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.CreateQuery()'></a>

## LayerView.CreateQuery() Method

Creates query parameter object that can be used to fetch features as they are being displayed. It sets the query parameter's outFields property to ["*"] and returnGeometry to true. The output spatial reference outSpatialReference is set to the spatial reference of the view. Parameters of the filter currently applied to the layerview are also incorporated in the returned query object. The results will include geometries of features and values for availableFields.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Objects.Query> CreateQuery();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Highlight(dymaptic.GeoBlazor.Core.Components.Layers.Graphic)'></a>

## LayerView.Highlight(Graphic) Method

Highlights the given feature(s).

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle> Highlight(dymaptic.GeoBlazor.Core.Components.Layers.Graphic graphic);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Highlight(dymaptic.GeoBlazor.Core.Components.Layers.Graphic).graphic'></a>

`graphic` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

The [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') to highlight.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[HighlightHandle](dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle.html 'dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A handle that allows the highlight to be removed later.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Highlight(int)'></a>

## LayerView.Highlight(int) Method

Highlights the given feature(s).

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle> Highlight(int objectId);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Highlight(int).objectId'></a>

`objectId` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The ObjectID of the graphic to highlight.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[HighlightHandle](dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle.html 'dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A handle that allows the highlight to be removed later.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Highlight(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_)'></a>

## LayerView.Highlight(IEnumerable<Graphic>) Method

Highlights the given feature(s).

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle> Highlight(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> graphics);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Highlight(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_).graphics'></a>

`graphics` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The graphics to highlight.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[HighlightHandle](dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle.html 'dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A handle that allows the highlight to be removed later.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Highlight(System.Collections.Generic.IEnumerable_int_)'></a>

## LayerView.Highlight(IEnumerable<int>) Method

Highlights the given feature(s).

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle> Highlight(System.Collections.Generic.IEnumerable<int> objectIds);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.Highlight(System.Collections.Generic.IEnumerable_int_).objectIds'></a>

`objectIds` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The ObjectIDs of the graphics to highlight.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[HighlightHandle](dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle.html 'dymaptic.GeoBlazor.Core.Components.Layers.HighlightHandle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A handle that allows the highlight to be removed later.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query)'></a>

## LayerView.QueryObjectIds(Query) Method

Executes a Query against features available for drawing in the layerView and returns array of the ObjectIDs of features that satisfy the input query. If query parameters are not provided, the ObjectIDs of all features available for drawing are returned.  
To query for ObjectIDs of features directly from a Feature Service rather than those visible in the view, you must use the FeatureLayer.queryObjectIds() method.

```csharp
public System.Threading.Tasks.Task<int[]> QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query query);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerView.QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query).query'></a>

`query` [Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query')

Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the geometry parameter in the query object to the view's extent.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')
