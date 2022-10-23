---
layout: default
title: FeatureLayer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## FeatureLayer Class

A FeatureLayer is a single layer that can be created from a Map Service or Feature Service; ArcGIS Online or ArcGIS Enterprise portal items; or from an array of client-side features. The layer can be either a spatial (has geographic features) or non-spatial (table).  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">ArcGIS JS API</a>

```csharp
public class FeatureLayer : dymaptic.GeoBlazor.Core.Components.Layers.Layer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') &#129106; FeatureLayer

### Example
<a target="_blank" href="https://blazor.dymaptic.com/feature-layers">Sample - Feature Layers</a>
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

The geometry type of the feature layer. All featuers must be of the same type.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType> GeometryType { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[GeometryType](dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType.html 'dymaptic.GeoBlazor.Core.Components.Geometries.GeometryType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.LabelingInfo'></a>

## FeatureLayer.LabelingInfo Property

The label definition for this layer, specified as an array of [Label](dymaptic.GeoBlazor.Core.Components.Layers.Label.html 'dymaptic.GeoBlazor.Core.Components.Layers.Label').

```csharp
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.Layers.Label> LabelingInfo { get; set; }
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

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Title'></a>

## FeatureLayer.Title Property

The title of the layer used to identify it in places such as the Legend and LayerList widgets.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.Url'></a>

## FeatureLayer.Url Property

The absolute URL of the REST endpoint of the layer, non-spatial table or service

```csharp
public string Url { get; set; }
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

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## FeatureLayer.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

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

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.UpdateComponent()'></a>

## FeatureLayer.UpdateComponent() Method

Checks if the map is already rendered, and if so, performs forced updates as defined by the component type.

```csharp
public override System.Threading.Tasks.Task UpdateComponent();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.ValidateRequiredChildren()'></a>

## FeatureLayer.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components
