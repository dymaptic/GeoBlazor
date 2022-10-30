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
