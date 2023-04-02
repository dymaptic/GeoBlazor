---
layout: default
title: FeatureLayer
parent: Classes
---
---
layout: default
title: FeatureLayer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## FeatureLayer Class

A FeatureLayer is a single layer that can be created from a Map Service or Feature Service; ArcGIS Online or ArcGIS  
Enterprise portal items; or from an array of client-side features. The layer can be either a spatial (has  
geographic features) or non-spatial (table).  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class FeatureLayer : dymaptic.GeoBlazor.Core.Components.Layers.Layer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') &#129106; FeatureLayer

### Example
<a target="_blank" href="https://samples.geoblazor.com/feature-layers">Sample - Feature Layers</a>
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer()'></a>

## FeatureLayer() Constructor

Constructor for use as a razor component

```csharp
public FeatureLayer();
```

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_)'></a>

## FeatureLayer(string, PortalItem, IReadOnlyCollection<Graphic>, string[], string, Nullable<double>, Nullable<double>, string, Nullable<GeometryType>, string, Nullable<double>, Nullable<bool>, Nullable<ListMode>) Constructor

Constructor for creating a new FeatureLayer in code. Either the url, portalItem, or source parameter must be  
specified.

```csharp
public FeatureLayer(string? url=null, dymaptic.GeoBlazor.Core.Components.PortalItem? portalItem=null, System.Collections.Generic.IReadOnlyCollection<dymaptic.GeoBlazor.Core.Components.Layers.Graphic>? source=null, string[]? outFields=null, string? definitionExpression=null, System.Nullable<double> minScale=null, System.Nullable<double> maxScale=null, string? objectIdField=null, System.Nullable<dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType> geometryType=null, string? title=null, System.Nullable<double> opacity=null, System.Nullable<bool> visible=null, System.Nullable<dymaptic.GeoBlazor.Core.Components.Layers.ListMode> listMode=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The absolute URL of the REST endpoint of the layer, non-spatial table or service

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).portalItem'></a>

`portalItem` [PortalItem](dymaptic.GeoBlazor.Core.Components.PortalItem.html 'dymaptic.GeoBlazor.Core.Components.PortalItem')

The [PortalItem](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.PortalItem 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.PortalItem') from which the layer is loaded.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).source'></a>

`source` [System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

A collection of Graphic objects used to create a FeatureLayer.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).outFields'></a>

`outFields` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

An array of field names from the service to include with each feature.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).definitionExpression'></a>

`definitionExpression` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The SQL where clause used to filter features on the client.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).minScale'></a>

`minScale` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The minimum scale (most zoomed out) at which the layer is visible in the view.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).maxScale'></a>

`maxScale` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The maximum scale (most zoomed in) at which the layer is visible in the view.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).objectIdField'></a>

`objectIdField` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of an oidfield containing a unique value or identifier for each feature in the layer.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).geometryType'></a>

`geometryType` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[GeometryType](dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType.html 'dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The geometry type of the feature layer. All features must be of the same type.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).title'></a>

`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The title of the layer used to identify it in places such as the Legend and LayerList widgets.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).opacity'></a>

`opacity` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The opacity of the layer.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).visible'></a>

`visible` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is  
referenced in a view, but its features will not be visible in the view.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.FeatureLayer(string,dymaptic.GeoBlazor.Core.Components.PortalItem,System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string[],string,System.Nullable_double_,System.Nullable_double_,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).listMode'></a>

`listMode` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[ListMode](dymaptic.GeoBlazor.Core.Components.Layers.ListMode.html 'dymaptic.GeoBlazor.Core.Components.Layers.ListMode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates how the layer should display in the LayerList widget. The possible values are listed below.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.DefinitionExpression'></a>

## FeatureLayer.DefinitionExpression Property

The SQL where clause used to filter features on the client.

```csharp
public string? DefinitionExpression { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Fields'></a>

## FeatureLayer.Fields Property

An array of fields in the layer.

```csharp
public System.Collections.Generic.IReadOnlyCollection<dymaptic.GeoBlazor.Core.Components.Layers.Field>? Fields { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[Field](dymaptic.GeoBlazor.Core.Components.Layers.Field.html 'dymaptic.GeoBlazor.Core.Components.Layers.Field')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.GeometryType'></a>

## FeatureLayer.GeometryType Property

The geometry type of the feature layer. All features must be of the same type.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType> GeometryType { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[GeometryType](dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType.html 'dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.LabelingInfo'></a>

## FeatureLayer.LabelingInfo Property

The label definition for this layer, specified as an array of [Label](dymaptic.GeoBlazor.Core.Components.Layers.Label.html 'dymaptic.GeoBlazor.Core.Components.Layers.Label').

```csharp
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.Layers.Label>? LabelingInfo { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[Label](dymaptic.GeoBlazor.Core.Components.Layers.Label.html 'dymaptic.GeoBlazor.Core.Components.Layers.Label')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.LayerType'></a>

## FeatureLayer.LayerType Property

Used internally to identify the sub type of Layer

```csharp
public override string LayerType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.MaxScale'></a>

## FeatureLayer.MaxScale Property

The maximum scale (most zoomed in) at which the layer is visible in the view.

```csharp
public System.Nullable<double> MaxScale { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.MinScale'></a>

## FeatureLayer.MinScale Property

The minimum scale (most zoomed out) at which the layer is visible in the view.

```csharp
public System.Nullable<double> MinScale { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.ObjectIdField'></a>

## FeatureLayer.ObjectIdField Property

The name of an oidfield containing a unique value or identifier for each feature in the layer.

```csharp
public string? ObjectIdField { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.OrderBy'></a>

## FeatureLayer.OrderBy Property

Determines the order in which features are drawn in the view.

```csharp
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.Layers.OrderedLayerOrderBy>? OrderBy { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[OrderedLayerOrderBy](dymaptic.GeoBlazor.Core.Components.Layers.OrderedLayerOrderBy.html 'dymaptic.GeoBlazor.Core.Components.Layers.OrderedLayerOrderBy')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.OutFields'></a>

## FeatureLayer.OutFields Property

An array of field names from the service to include with each feature.

```csharp
public string[]? OutFields { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.PopupTemplate'></a>

## FeatureLayer.PopupTemplate Property

The [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.PopupTemplate 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.PopupTemplate') for the layer.

```csharp
public dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate? PopupTemplate { get; set; }
```

#### Property Value
[PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.PortalItem'></a>

## FeatureLayer.PortalItem Property

The [PortalItem](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.PortalItem 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.PortalItem') from which the layer is loaded.

```csharp
public dymaptic.GeoBlazor.Core.Components.PortalItem? PortalItem { get; set; }
```

#### Property Value
[PortalItem](dymaptic.GeoBlazor.Core.Components.PortalItem.html 'dymaptic.GeoBlazor.Core.Components.PortalItem')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Relationships'></a>

## FeatureLayer.Relationships Property

Array of relationships set up for the layer. Each object in the array describes the layer's relationship with  
another layer or table.

```csharp
public dymaptic.GeoBlazor.Core.Objects.Relationship[]? Relationships { get; set; }
```

#### Property Value
[Relationship](dymaptic.GeoBlazor.Core.Objects.Relationship.html 'dymaptic.GeoBlazor.Core.Objects.Relationship')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Renderer'></a>

## FeatureLayer.Renderer Property

The [Renderer](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Renderer 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Renderer') assigned to the layer.

```csharp
public dymaptic.GeoBlazor.Core.Components.Renderers.Renderer? Renderer { get; set; }
```

#### Property Value
[Renderer](dymaptic.GeoBlazor.Core.Components.Renderers.Renderer.html 'dymaptic.GeoBlazor.Core.Components.Renderers.Renderer')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Source'></a>

## FeatureLayer.Source Property

A collection of Graphic objects used to create a FeatureLayer.

```csharp
public System.Collections.Generic.IReadOnlyCollection<dymaptic.GeoBlazor.Core.Components.Layers.Graphic>? Source { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.SpatialReference'></a>

## FeatureLayer.SpatialReference Property

The spatial reference for the feature layer

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? SpatialReference { get; set; }
```

#### Property Value
[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Url'></a>

## FeatureLayer.Url Property

The absolute URL of the REST endpoint of the layer, non-spatial table or service

```csharp
public string? Url { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Add(dymaptic.GeoBlazor.Core.Components.Layers.Field)'></a>

## FeatureLayer.Add(Field) Method

Add a field to the current layer's source

```csharp
public System.Threading.Tasks.Task Add(dymaptic.GeoBlazor.Core.Components.Layers.Field field);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Add(dymaptic.GeoBlazor.Core.Components.Layers.Field).field'></a>

`field` [Field](dymaptic.GeoBlazor.Core.Components.Layers.Field.html 'dymaptic.GeoBlazor.Core.Components.Layers.Field')

The field to add

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Add(dymaptic.GeoBlazor.Core.Components.Layers.Graphic)'></a>

## FeatureLayer.Add(Graphic) Method

Add a graphic to the current layer's source

```csharp
public System.Threading.Tasks.Task Add(dymaptic.GeoBlazor.Core.Components.Layers.Graphic graphic);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Add(dymaptic.GeoBlazor.Core.Components.Layers.Graphic).graphic'></a>

`graphic` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

The graphic to add

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Add(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_)'></a>

## FeatureLayer.Add(IEnumerable<Graphic>) Method

Adds a collection of graphics to the feature layer

```csharp
public System.Threading.Tasks.Task Add(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> graphics);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Add(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_).graphics'></a>

`graphics` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The graphics to add

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.CreatePopupTemplate(dymaptic.GeoBlazor.Core.Components.Layers.CreatePopupTemplateOptions)'></a>

## FeatureLayer.CreatePopupTemplate(CreatePopupTemplateOptions) Method

Creates a popup template for the layer, populated with all the fields of the layer.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate> CreatePopupTemplate(dymaptic.GeoBlazor.Core.Components.Layers.CreatePopupTemplateOptions? options=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.CreatePopupTemplate(dymaptic.GeoBlazor.Core.Components.Layers.CreatePopupTemplateOptions).options'></a>

`options` [CreatePopupTemplateOptions](dymaptic.GeoBlazor.Core.Components.Layers.CreatePopupTemplateOptions.html 'dymaptic.GeoBlazor.Core.Components.Layers.CreatePopupTemplateOptions')

Options for creating the popup template.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.CreateQuery()'></a>

## FeatureLayer.CreateQuery() Method

Creates query parameter object that can be used to fetch features that satisfy the layer's configurations such as  
definitionExpression, gdbVersion, and historicMoment. It will return Z and M values based on the layer's data  
capabilities. It sets the query parameter's outFields property to ["*"]. The results will include geometries of  
features and values for all available fields for client-side queries or all fields in the layer for server side  
queries.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Objects.Query> CreateQuery();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.OnQueryFeaturesCreateChunk(string,int)'></a>

## FeatureLayer.OnQueryFeaturesCreateChunk(string, int) Method

partial query result return for Blazor Server, to avoid SignalR size limits

```csharp
public void OnQueryFeaturesCreateChunk(string chunk, int chunkIndex);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.OnQueryFeaturesCreateChunk(string,int).chunk'></a>

`chunk` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.OnQueryFeaturesCreateChunk(string,int).chunkIndex'></a>

`chunkIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken)'></a>

## FeatureLayer.QueryExtent(Query, CancellationToken) Method

Executes a Query against the feature service and returns the Extent of features that satisfy the query. If no  
parameters are specified, then the extent and count of all features satisfying the layer's configuration/filters  
are returned.  
To query for the extent of features/graphics available to or visible in the View on the client rather than making a  
server-side query, you must use the [QueryExtent(Query, CancellationToken)](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query, System.Threading.CancellationToken)') method.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult> QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query? query=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).query'></a>

`query` [Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query')

Specifies the attributes and spatial filter of the query. If no parameters are specified, then the extent and count  
of all features satisfying the layer's configuration/filters are returned.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used to cancel the query operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ExtentQueryResult](dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult.html 'dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken)'></a>

## FeatureLayer.QueryFeatureCount(Query, CancellationToken) Method

Executes a Query against the feature service and returns the number of features that satisfy the query. If no  
parameters are specified, the total number of features satisfying the layer's configuration/filters is returned.  
To query for the count of features/graphics available to or visible in the View on the client rather than making a  
server-side query, you must use the [QueryFeatureCount(Query, CancellationToken)](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query, System.Threading.CancellationToken)') method.

```csharp
public System.Threading.Tasks.Task<int> QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query? query=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).query'></a>

`query` [Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query')

Specifies the attributes and spatial filter of the query. If no parameters are specified, the total number of  
features satisfying the layer's configuration/filters is returned.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used to cancel the query operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken)'></a>

## FeatureLayer.QueryFeatures(Query, CancellationToken) Method

Executes a Query against the feature service and returns the number of features that satisfy the query. If no  
parameters are specified, the total number of features satisfying the layer's configuration/filters is returned.  
To query for the count of features/graphics available to or visible in the View on the client rather than making a  
server-side query, you must use the [QueryFeatureCount(Query, CancellationToken)](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryFeatureCount(dymaptic.GeoBlazor.Core.Objects.Query, System.Threading.CancellationToken)') method.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet?> QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query? query=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).query'></a>

`query` [Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query')

Specifies the attributes and spatial filter of the query. If no parameters are specified, the total number of  
features satisfying the layer's configuration/filters is returned.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used to cancel the query operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[FeatureSet](dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken)'></a>

## FeatureLayer.QueryObjectIds(Query, CancellationToken) Method

Executes a Query against the feature service and returns an array of Object IDs for features that satisfy the input  
query. If no parameters are specified, then the Object IDs of all features satisfying the layer's  
configuration/filters are returned.  
To query for ObjectIDs of features/graphics available to or visible in the View on the client rather than making a  
server-side query, you must use the [QueryObjectIds(Query, CancellationToken)](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query, System.Threading.CancellationToken)') method.

```csharp
public System.Threading.Tasks.Task<int[]> QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query query, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).query'></a>

`query` [Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query')

Specifies the attributes and spatial filter of the query. If no parameters are specified, then the Object IDs of  
all features satisfying the layer's configuration/filters are returned.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryObjectIds(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used to cancel the query operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryRelatedFeatures(dymaptic.GeoBlazor.Core.Objects.RelationshipQuery,System.Threading.CancellationToken)'></a>

## FeatureLayer.QueryRelatedFeatures(RelationshipQuery, CancellationToken) Method

Executes a RelationshipQuery against the feature service and returns FeatureSets grouped by source layer or table  
objectIds.

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int,dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet?>?> QueryRelatedFeatures(dymaptic.GeoBlazor.Core.Objects.RelationshipQuery query, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryRelatedFeatures(dymaptic.GeoBlazor.Core.Objects.RelationshipQuery,System.Threading.CancellationToken).query'></a>

`query` [RelationshipQuery](dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.html 'dymaptic.GeoBlazor.Core.Objects.RelationshipQuery')

Specifies relationship parameters for querying related features or records from a layer or a table.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryRelatedFeatures(dymaptic.GeoBlazor.Core.Objects.RelationshipQuery,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used to cancel the query operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[FeatureSet](dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryRelatedFeaturesCount(dymaptic.GeoBlazor.Core.Objects.RelationshipQuery,System.Threading.CancellationToken)'></a>

## FeatureLayer.QueryRelatedFeaturesCount(RelationshipQuery, CancellationToken) Method

Executes a RelationshipQuery against the feature service and when resolved, it returns an object containing key  
value pairs. Key in this case is the objectId of the feature and value is the number of related features associated  
with the feature.

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int,int>> QueryRelatedFeaturesCount(dymaptic.GeoBlazor.Core.Objects.RelationshipQuery query, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryRelatedFeaturesCount(dymaptic.GeoBlazor.Core.Objects.RelationshipQuery,System.Threading.CancellationToken).query'></a>

`query` [RelationshipQuery](dymaptic.GeoBlazor.Core.Objects.RelationshipQuery.html 'dymaptic.GeoBlazor.Core.Objects.RelationshipQuery')

Specifies relationship parameters for querying related features or records from a layer or a table.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryRelatedFeaturesCount(dymaptic.GeoBlazor.Core.Objects.RelationshipQuery,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used to cancel the query operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeatureCount(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken)'></a>

## FeatureLayer.QueryTopFeatureCount(TopFeaturesQuery, CancellationToken) Method

Executes a TopFeaturesQuery against a feature service and returns the count of features or records that satisfy the  
query.

```csharp
public System.Threading.Tasks.Task<int> QueryTopFeatureCount(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery query, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeatureCount(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken).query'></a>

`query` [TopFeaturesQuery](dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.html 'dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery')

Specifies the attributes, spatial, temporal, and top filter of the query. The topFilter parameter must be set.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeatureCount(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used to cancel the query operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

### Remarks
Known Limitations: Currently, the [QueryTopFeatureCount(TopFeaturesQuery, CancellationToken)](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeatureCount(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeatureCount(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery, System.Threading.CancellationToken)') is only supported with server-side  
[FeatureLayer](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer')s.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeatures(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken)'></a>

## FeatureLayer.QueryTopFeatures(TopFeaturesQuery, CancellationToken) Method

Executes a TopFeaturesQuery against a feature service and returns a FeatureSet once the promise resolves. The  
FeatureSet contains an array of top features grouped and ordered by specified fields. For example, you can call  
this method to query top three counties grouped by state names while ordering them based on their populations in a  
descending order.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet?> QueryTopFeatures(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery query, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeatures(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken).query'></a>

`query` [TopFeaturesQuery](dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.html 'dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery')

Specifies the attributes, spatial, temporal, and top filter of the query. The topFilter parameter must be set.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeatures(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used to cancel the query operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[FeatureSet](dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureSet')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

### Remarks
Known Limitations: Currently, the [QueryTopFeatures(TopFeaturesQuery, CancellationToken)](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeatures(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeatures(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery, System.Threading.CancellationToken)') is only supported with server-side  
[FeatureLayer](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer')s.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeaturesExtent(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken)'></a>

## FeatureLayer.QueryTopFeaturesExtent(TopFeaturesQuery, CancellationToken) Method

Executes a TopFeaturesQuery against a feature service and returns the Extent of features that satisfy the query.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult> QueryTopFeaturesExtent(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery? query=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeaturesExtent(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken).query'></a>

`query` [TopFeaturesQuery](dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.html 'dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery')

Specifies the attributes, spatial, temporal, and top filter of the query. The topFilter parameter must be set.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeaturesExtent(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used to cancel the query operation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ExtentQueryResult](dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult.html 'dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

### Remarks
Known Limitations: Currently, the [QueryTopFeaturesExtent(TopFeaturesQuery, CancellationToken)](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeaturesExtent(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopFeaturesExtent(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery, System.Threading.CancellationToken)') is only supported with server-side  
[FeatureLayer](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer')s.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopObjectIds(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken)'></a>

## FeatureLayer.QueryTopObjectIds(TopFeaturesQuery, CancellationToken) Method

```csharp
public System.Threading.Tasks.Task<int[]> QueryTopObjectIds(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery query, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopObjectIds(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken).query'></a>

`query` [TopFeaturesQuery](dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery.html 'dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryTopObjectIds(dymaptic.GeoBlazor.Core.Objects.TopFeaturesQuery,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## FeatureLayer.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Remove(dymaptic.GeoBlazor.Core.Components.Layers.Field)'></a>

## FeatureLayer.Remove(Field) Method

Remove a field from the current layer

```csharp
public System.Threading.Tasks.Task Remove(dymaptic.GeoBlazor.Core.Components.Layers.Field field);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Remove(dymaptic.GeoBlazor.Core.Components.Layers.Field).field'></a>

`field` [Field](dymaptic.GeoBlazor.Core.Components.Layers.Field.html 'dymaptic.GeoBlazor.Core.Components.Layers.Field')

The field to remove

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Remove(dymaptic.GeoBlazor.Core.Components.Layers.Graphic)'></a>

## FeatureLayer.Remove(Graphic) Method

Remove a graphic from the current layer

```csharp
public System.Threading.Tasks.Task Remove(dymaptic.GeoBlazor.Core.Components.Layers.Graphic graphic);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Remove(dymaptic.GeoBlazor.Core.Components.Layers.Graphic).graphic'></a>

`graphic` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

The graphic to remove

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## FeatureLayer.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.ValidateRequiredChildren()'></a>

## FeatureLayer.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the  
[RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components

