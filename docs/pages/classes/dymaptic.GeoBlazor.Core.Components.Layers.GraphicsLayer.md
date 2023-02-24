---
layout: default
title: GraphicsLayer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## GraphicsLayer Class

A GraphicsLayer contains one or more client-side Graphics. Each graphic in the GraphicsLayer is rendered in a  
LayerView inside either a SceneView or a MapView. The graphics contain discrete vector geometries that represent  
real-world phenomena.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html">ArcGIS JS API</a>

```csharp
public class GraphicsLayer : dymaptic.GeoBlazor.Core.Components.Layers.Layer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') &#129106; GraphicsLayer
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.GraphicsLayer()'></a>

## GraphicsLayer() Constructor

Parameterless constructor for use as a razor component

```csharp
public GraphicsLayer();
```

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.GraphicsLayer(System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_)'></a>

## GraphicsLayer(IReadOnlyCollection<Graphic>, string, Nullable<double>, Nullable<bool>, Nullable<ListMode>) Constructor

Constructor for use in code

```csharp
public GraphicsLayer(System.Collections.Generic.IReadOnlyCollection<dymaptic.GeoBlazor.Core.Components.Layers.Graphic>? graphics=null, string? title=null, System.Nullable<double> opacity=null, System.Nullable<bool> visible=null, System.Nullable<dymaptic.GeoBlazor.Core.Components.Layers.ListMode> listMode=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.GraphicsLayer(System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).graphics'></a>

`graphics` [System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

A collection of [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')s in the layer.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.GraphicsLayer(System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).title'></a>

`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The title of the layer used to identify it in places such as the Legend and LayerList widgets.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.GraphicsLayer(System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).opacity'></a>

`opacity` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The opacity of the layer.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.GraphicsLayer(System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).visible'></a>

`visible` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is referenced in a view, but its features will not be visible in the view.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.GraphicsLayer(System.Collections.Generic.IReadOnlyCollection_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).listMode'></a>

`listMode` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[ListMode](dymaptic.GeoBlazor.Core.Components.Layers.ListMode.html 'dymaptic.GeoBlazor.Core.Components.Layers.ListMode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates how the layer should display in the LayerList widget. The possible values are listed below.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.Graphics'></a>

## GraphicsLayer.Graphics Property

A collection of [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')s in the layer.

```csharp
public System.Collections.Generic.IReadOnlyCollection<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> Graphics { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.LayerType'></a>

## GraphicsLayer.LayerType Property

Used internally to identify the sub type of Layer

```csharp
public override string LayerType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.Add(dymaptic.GeoBlazor.Core.Components.Layers.Graphic)'></a>

## GraphicsLayer.Add(Graphic) Method

Add a graphic to the current layer

```csharp
public System.Threading.Tasks.Task Add(dymaptic.GeoBlazor.Core.Components.Layers.Graphic graphic);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.Add(dymaptic.GeoBlazor.Core.Components.Layers.Graphic).graphic'></a>

`graphic` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

The graphic to add

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.Add(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_)'></a>

## GraphicsLayer.Add(IEnumerable<Graphic>) Method

Adds a collection of graphics to the graphics layer

```csharp
public System.Threading.Tasks.Task Add(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> graphics);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.Add(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_).graphics'></a>

`graphics` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The graphics to add

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.Clear()'></a>

## GraphicsLayer.Clear() Method

Removes all graphics from the current layer

```csharp
public System.Threading.Tasks.Task Clear();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## GraphicsLayer.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.RegisterExistingGraphicFromJavaScript(dymaptic.GeoBlazor.Core.Components.Layers.Graphic)'></a>

## GraphicsLayer.RegisterExistingGraphicFromJavaScript(Graphic) Method

Register a graphic that was created in JavaScript

```csharp
public void RegisterExistingGraphicFromJavaScript(dymaptic.GeoBlazor.Core.Components.Layers.Graphic graphic);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.RegisterExistingGraphicFromJavaScript(dymaptic.GeoBlazor.Core.Components.Layers.Graphic).graphic'></a>

`graphic` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.Remove(dymaptic.GeoBlazor.Core.Components.Layers.Graphic)'></a>

## GraphicsLayer.Remove(Graphic) Method

Remove a graphic from the current layer

```csharp
public System.Threading.Tasks.Task Remove(dymaptic.GeoBlazor.Core.Components.Layers.Graphic graphic);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.Remove(dymaptic.GeoBlazor.Core.Components.Layers.Graphic).graphic'></a>

`graphic` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

The graphic to remove

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.Remove(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_)'></a>

## GraphicsLayer.Remove(IEnumerable<Graphic>) Method

Removes a set of graphics from the current layer

```csharp
public System.Threading.Tasks.Task Remove(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> graphics);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.Remove(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_).graphics'></a>

`graphics` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The graphics to remove

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## GraphicsLayer.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.ValidateRequiredChildren()'></a>

## GraphicsLayer.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components
