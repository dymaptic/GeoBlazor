---
layout: default
title: BlurEvent
parent: Classes
---
---
layout: default
title: BlurEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## BlurEvent Class

Fires when browser focus is moved away from the view.

```csharp
public class BlurEvent : dymaptic.GeoBlazor.Core.Events.JsEvent,
System.IEquatable<dymaptic.GeoBlazor.Core.Events.BlurEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [JsEvent](dymaptic.GeoBlazor.Core.Events.JsEvent.html 'dymaptic.GeoBlazor.Core.Events.JsEvent') &#129106; BlurEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[BlurEvent](dymaptic.GeoBlazor.Core.Events.BlurEvent.html 'dymaptic.GeoBlazor.Core.Events.BlurEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.BlurEvent.BlurEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,string,double,System.Nullable_bool_)'></a>

## BlurEvent(MapView, DomPointerEvent, string, double, Nullable<bool>) Constructor

Fires when browser focus is moved away from the view.

```csharp
public BlurEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView Target, dymaptic.GeoBlazor.Core.Events.DomPointerEvent Native, string Type, double Timestamp, System.Nullable<bool> Cancelable);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.BlurEvent.BlurEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,string,double,System.Nullable_bool_).Target'></a>

`Target` [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView')

The view that the browser focus is currently on.

<a name='dymaptic.GeoBlazor.Core.Events.BlurEvent.BlurEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,string,double,System.Nullable_bool_).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Events.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Events.DomPointerEvent')

A standard DOM Pointer Event

<a name='dymaptic.GeoBlazor.Core.Events.BlurEvent.BlurEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,string,double,System.Nullable_bool_).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The event type.

<a name='dymaptic.GeoBlazor.Core.Events.BlurEvent.BlurEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,string,double,System.Nullable_bool_).Timestamp'></a>

`Timestamp` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Time stamp (in milliseconds) at which the event was emitted.

<a name='dymaptic.GeoBlazor.Core.Events.BlurEvent.BlurEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,string,double,System.Nullable_bool_).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Whether the event can be cancelled once begun.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.BlurEvent.Target'></a>

## BlurEvent.Target Property

The view that the browser focus is currently on.

```csharp
public dymaptic.GeoBlazor.Core.Components.Views.MapView Target { get; set; }
```

#### Property Value
[MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView')

