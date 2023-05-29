---
layout: default
title: LayerViewCreateEvent
parent: Classes
---
---
layout: default
title: LayerViewCreateEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## LayerViewCreateEvent Class

Return event from the [OnJavascriptLayerViewCreate(LayerViewCreateInternalEvent)](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent) 'dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent)') event.

```csharp
public class LayerViewCreateEvent :
System.IEquatable<dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LayerViewCreateEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[LayerViewCreateEvent](dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.html 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.LayerViewCreateEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView)'></a>

## LayerViewCreateEvent(Layer, LayerView) Constructor

Return event from the [OnJavascriptLayerViewCreate(LayerViewCreateInternalEvent)](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent) 'dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent)') event.

```csharp
public LayerViewCreateEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer? Layer, dymaptic.GeoBlazor.Core.Components.Layers.LayerView? LayerView);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.LayerViewCreateEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView).Layer'></a>

`Layer` [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

A deserialized copy of the [Layer](dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.html#dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.Layer 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.Layer') object.

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.LayerViewCreateEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView).LayerView'></a>

`LayerView` [LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')

A deserialized copy of the [LayerView](dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.html#dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.LayerView 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.LayerView') object.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.Layer'></a>

## LayerViewCreateEvent.Layer Property

A deserialized copy of the [Layer](dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.html#dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.Layer 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.Layer') object.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Layer? Layer { get; set; }
```

#### Property Value
[Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.LayerView'></a>

## LayerViewCreateEvent.LayerView Property

A deserialized copy of the [LayerView](dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.html#dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.LayerView 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.LayerView') object.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.LayerView? LayerView { get; set; }
```

#### Property Value
[LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')

