---
layout: default
title: GeoJSONLayer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## GeoJSONLayer Class

The GeoJSONLayer class is used to create a layer based on GeoJSON. GeoJSON is a format for encoding a variety of geographic data structures. The GeoJSON data must comply with the RFC 7946 specification which states that the coordinates are in SpatialReference.WGS84.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html">ArcGIS JS API</a>

```csharp
public class GeoJSONLayer : dymaptic.GeoBlazor.Core.Components.Layers.Layer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') &#129106; GeoJSONLayer

### Example
<a target="_blank" href="https://samples.geoblazor.com/pro-projection">Sample - Display Projection</a>
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.GeoJSONLayer()'></a>

## GeoJSONLayer() Constructor

Parameterless constructor for using as a razor component

```csharp
public GeoJSONLayer();
```

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.GeoJSONLayer(string,string,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_)'></a>

## GeoJSONLayer(string, string, string, Nullable<double>, Nullable<bool>, Nullable<ListMode>) Constructor

Constructs a new GeoJSONLayer in code with parameters

```csharp
public GeoJSONLayer(string? url=null, string? copyright=null, string? title=null, System.Nullable<double> opacity=null, System.Nullable<bool> visible=null, System.Nullable<dymaptic.GeoBlazor.Core.Components.Layers.ListMode> listMode=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.GeoJSONLayer(string,string,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The url for the GeoJSON source data.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.GeoJSONLayer(string,string,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).copyright'></a>

`copyright` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A copyright string to identify ownership of the data.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.GeoJSONLayer(string,string,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).title'></a>

`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The title of the layer used to identify it in places such as the Legend and LayerList widgets.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.GeoJSONLayer(string,string,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).opacity'></a>

`opacity` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The opacity of the layer.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.GeoJSONLayer(string,string,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).visible'></a>

`visible` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is referenced in a view, but its features will not be visible in the view.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.GeoJSONLayer(string,string,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).listMode'></a>

`listMode` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[ListMode](dymaptic.GeoBlazor.Core.Components.Layers.ListMode.html 'dymaptic.GeoBlazor.Core.Components.Layers.ListMode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates how the layer should display in the LayerList widget. The possible values are listed below.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.Copyright'></a>

## GeoJSONLayer.Copyright Property

A copyright string to identify ownership of the data.

```csharp
public string? Copyright { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.LayerType'></a>

## GeoJSONLayer.LayerType Property

Used internally to identify the sub type of Layer

```csharp
public override string LayerType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.Renderer'></a>

## GeoJSONLayer.Renderer Property

The [Renderer](dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.Renderer 'dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.Renderer') that defines how the GeoJSON data will be displayed.

```csharp
public dymaptic.GeoBlazor.Core.Components.Renderers.Renderer? Renderer { get; set; }
```

#### Property Value
[Renderer](dymaptic.GeoBlazor.Core.Components.Renderers.Renderer.html 'dymaptic.GeoBlazor.Core.Components.Renderers.Renderer')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.SpatialReference'></a>

## GeoJSONLayer.SpatialReference Property

The [SpatialReference](dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.SpatialReference 'dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.SpatialReference') to render the GeoJSON data.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? SpatialReference { get; set; }
```

#### Property Value
[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.Url'></a>

## GeoJSONLayer.Url Property

The url for the GeoJSON source data.

```csharp
public string? Url { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## GeoJSONLayer.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## GeoJSONLayer.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')
