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
public class LayerView
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LayerView

Derived  
&#8627; [FeatureLayerView](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayerView')
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
