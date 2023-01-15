---
layout: default
title: Layer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## Layer Class

The layer is the most fundamental component of a Map. It is a collection of spatial data in the form of vector graphics or raster images that represent real-world phenomena. Layers may contain discrete features that store vector data or continuous cells/pixels that store raster data.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html">ArcGIS JS API</a>

```csharp
public abstract class Layer : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; Layer

Derived  
&#8627; [FeatureLayer](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer')  
&#8627; [GeoJSONLayer](dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer')  
&#8627; [GeoRSSLayer](dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer')  
&#8627; [GraphicsLayer](dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer')  
&#8627; [TileLayer](dymaptic.GeoBlazor.Core.Components.Layers.TileLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.TileLayer')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.JsObjectReference'></a>

## Layer.JsObjectReference Property

The JavaScript object that represents the layer.

```csharp
public Microsoft.JSInterop.IJSObjectReference? JsObjectReference { get; set; }
```

#### Property Value
[Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.LayerIndex'></a>

## Layer.LayerIndex Property

Used internally to identify multiple layers.

```csharp
public int LayerIndex { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.LayerType'></a>

## Layer.LayerType Property

Used internally to identify the sub type of Layer

```csharp
public virtual string LayerType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.LayerView'></a>

## Layer.LayerView Property

Represents the view for a single layer after it has been added to either a MapView or a SceneView.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.LayerView? LayerView { get; set; }
```

#### Property Value
[LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.Opacity'></a>

## Layer.Opacity Property

The opacity of the layer.

```csharp
public System.Nullable<double> Opacity { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.Title'></a>

## Layer.Title Property

The title of the layer used to identify it in places such as the Legend and LayerList widgets.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
