---
layout: default
title: LayerViewCreateEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## LayerViewCreateEvent Class

Fires after each layer in the map has a corresponding LayerView created and rendered in the view.

```csharp
public class LayerViewCreateEvent :
System.IEquatable<dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LayerViewCreateEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[LayerViewCreateEvent](dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.html 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.LayerViewCreateEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView)'></a>

## LayerViewCreateEvent(Layer, LayerView) Constructor

Fires after each layer in the map has a corresponding LayerView created and rendered in the view.

```csharp
public LayerViewCreateEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer Layer, dymaptic.GeoBlazor.Core.Components.Layers.LayerView LayerView);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.LayerViewCreateEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView).Layer'></a>

`Layer` [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

The layer in the map for which the layerView was created.

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.LayerViewCreateEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView).LayerView'></a>

`LayerView` [LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')

The LayerView rendered in the view representing the layer.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.Layer'></a>

## LayerViewCreateEvent.Layer Property

The layer in the map for which the layerView was created.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Layer Layer { get; set; }
```

#### Property Value
[Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.LayerView'></a>

## LayerViewCreateEvent.LayerView Property

The LayerView rendered in the view representing the layer.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.LayerView LayerView { get; set; }
```

#### Property Value
[LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')
