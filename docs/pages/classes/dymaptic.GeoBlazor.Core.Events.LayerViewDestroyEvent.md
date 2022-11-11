---
layout: default
title: LayerViewDestroyEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## LayerViewDestroyEvent Class

Fires after a LayerView is destroyed and is no longer rendered in the view. This happens for example when a layer is removed from the map of the view.

```csharp
public class LayerViewDestroyEvent :
System.IEquatable<dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LayerViewDestroyEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[LayerViewDestroyEvent](dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent.html 'dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent.LayerViewDestroyEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView)'></a>

## LayerViewDestroyEvent(Layer, LayerView) Constructor

Fires after a LayerView is destroyed and is no longer rendered in the view. This happens for example when a layer is removed from the map of the view.

```csharp
public LayerViewDestroyEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer Layer, dymaptic.GeoBlazor.Core.Components.Layers.LayerView LayerView);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent.LayerViewDestroyEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView).Layer'></a>

`Layer` [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

The layer in the map for which the layerView was destroyed.

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent.LayerViewDestroyEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView).LayerView'></a>

`LayerView` [LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')

The LayerView that was destroyed in the view.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent.Layer'></a>

## LayerViewDestroyEvent.Layer Property

The layer in the map for which the layerView was destroyed.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Layer Layer { get; set; }
```

#### Property Value
[Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent.LayerView'></a>

## LayerViewDestroyEvent.LayerView Property

The LayerView that was destroyed in the view.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.LayerView LayerView { get; set; }
```

#### Property Value
[LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')
