---
layout: default
title: LayerViewCreateInternalEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## LayerViewCreateInternalEvent Class

Custom return event from the [OnJavascriptLayerViewCreate(LayerViewCreateInternalEvent)](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent) 'dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent)') event.

```csharp
public class LayerViewCreateInternalEvent :
System.IEquatable<dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LayerViewCreateInternalEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[LayerViewCreateInternalEvent](dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.html 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerViewCreateInternalEvent(Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference,System.Guid,dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView,bool)'></a>

## LayerViewCreateInternalEvent(IJSObjectReference, IJSObjectReference, Guid, Layer, LayerView, bool) Constructor

Custom return event from the [OnJavascriptLayerViewCreate(LayerViewCreateInternalEvent)](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent) 'dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent)') event.

```csharp
public LayerViewCreateInternalEvent(Microsoft.JSInterop.IJSObjectReference LayerObjectRef, Microsoft.JSInterop.IJSObjectReference LayerViewObjectRef, System.Guid LayerGeoBlazorId, dymaptic.GeoBlazor.Core.Components.Layers.Layer? Layer, dymaptic.GeoBlazor.Core.Components.Layers.LayerView? LayerView, bool IsBasemapLayer);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerViewCreateInternalEvent(Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference,System.Guid,dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView,bool).LayerObjectRef'></a>

`LayerObjectRef` [Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

A JavaScript object reference for the Layer created.

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerViewCreateInternalEvent(Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference,System.Guid,dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView,bool).LayerViewObjectRef'></a>

`LayerViewObjectRef` [Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

A JavaScript object reference for the LayerView created.

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerViewCreateInternalEvent(Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference,System.Guid,dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView,bool).LayerGeoBlazorId'></a>

`LayerGeoBlazorId` [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid')

The unique GeoBlazor ID for the Layer created.

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerViewCreateInternalEvent(Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference,System.Guid,dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView,bool).Layer'></a>

`Layer` [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

A deserialized copy of the [Layer](dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.html#dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.Layer 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.Layer') object.

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerViewCreateInternalEvent(Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference,System.Guid,dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView,bool).LayerView'></a>

`LayerView` [LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')

A deserialized copy of the [LayerView](dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.html#dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerView 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerView') object.

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerViewCreateInternalEvent(Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference,System.Guid,dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Components.Layers.LayerView,bool).IsBasemapLayer'></a>

`IsBasemapLayer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

A boolean value indicating whether the Layer is a basemap layer.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.IsBasemapLayer'></a>

## LayerViewCreateInternalEvent.IsBasemapLayer Property

A boolean value indicating whether the Layer is a basemap layer.

```csharp
public bool IsBasemapLayer { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.Layer'></a>

## LayerViewCreateInternalEvent.Layer Property

A deserialized copy of the [Layer](dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.html#dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.Layer 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.Layer') object.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Layer? Layer { get; set; }
```

#### Property Value
[Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerGeoBlazorId'></a>

## LayerViewCreateInternalEvent.LayerGeoBlazorId Property

The unique GeoBlazor ID for the Layer created.

```csharp
public System.Guid LayerGeoBlazorId { get; set; }
```

#### Property Value
[System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid')

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerObjectRef'></a>

## LayerViewCreateInternalEvent.LayerObjectRef Property

A JavaScript object reference for the Layer created.

```csharp
public Microsoft.JSInterop.IJSObjectReference LayerObjectRef { get; set; }
```

#### Property Value
[Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerView'></a>

## LayerViewCreateInternalEvent.LayerView Property

A deserialized copy of the [LayerView](dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.html#dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerView 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerView') object.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.LayerView? LayerView { get; set; }
```

#### Property Value
[LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')

<a name='dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.LayerViewObjectRef'></a>

## LayerViewCreateInternalEvent.LayerViewObjectRef Property

A JavaScript object reference for the LayerView created.

```csharp
public Microsoft.JSInterop.IJSObjectReference LayerViewObjectRef { get; set; }
```

#### Property Value
[Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')
