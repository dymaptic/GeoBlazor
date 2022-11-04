---
layout: default
title: LayerViewCreateErrorEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## LayerViewCreateErrorEvent Class

Fires when an error emits during the creation of a LayerView after a layer has been added to the map.

```csharp
public class LayerViewCreateErrorEvent :
System.IEquatable<dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LayerViewCreateErrorEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[LayerViewCreateErrorEvent](dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent.html 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent.LayerViewCreateErrorEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Exceptions.JavascriptError)'></a>

## LayerViewCreateErrorEvent(Layer, JavascriptError) Constructor

Fires when an error emits during the creation of a LayerView after a layer has been added to the map.

```csharp
public LayerViewCreateErrorEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer Layer, dymaptic.GeoBlazor.Core.Exceptions.JavascriptError Error);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent.LayerViewCreateErrorEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Exceptions.JavascriptError).Layer'></a>

`Layer` [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

The layer in the map for which the view emitting this event failed to create a layer view.

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent.LayerViewCreateErrorEvent(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Exceptions.JavascriptError).Error'></a>

`Error` [JavascriptError](dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptError')

An error object describing why the layer view failed to create.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent.Error'></a>

## LayerViewCreateErrorEvent.Error Property

An error object describing why the layer view failed to create.

```csharp
public dymaptic.GeoBlazor.Core.Exceptions.JavascriptError Error { get; set; }
```

#### Property Value
[JavascriptError](dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptError')

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent.Layer'></a>

## LayerViewCreateErrorEvent.Layer Property

The layer in the map for which the view emitting this event failed to create a layer view.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Layer Layer { get; set; }
```

#### Property Value
[Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')
