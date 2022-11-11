---
layout: default
title: KeyUpEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## KeyUpEvent Class

Fires after a keyboard key is released.

```csharp
public class KeyUpEvent : dymaptic.GeoBlazor.Core.Events.JsEvent,
System.IEquatable<dymaptic.GeoBlazor.Core.Events.KeyUpEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [JsEvent](dymaptic.GeoBlazor.Core.Events.JsEvent.html 'dymaptic.GeoBlazor.Core.Events.JsEvent') &#129106; KeyUpEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[KeyUpEvent](dymaptic.GeoBlazor.Core.Events.KeyUpEvent.html 'dymaptic.GeoBlazor.Core.Events.KeyUpEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_)'></a>

## KeyUpEvent(string, Nullable<int>, Nullable<bool>, string, double, DomPointerEvent, Nullable<PointerType>) Constructor

Fires after a keyboard key is released.

```csharp
public KeyUpEvent(string Type, System.Nullable<int> EventId, System.Nullable<bool> Cancelable, string Key, double Timestamp, dymaptic.GeoBlazor.Core.Events.DomPointerEvent Native, System.Nullable<dymaptic.GeoBlazor.Core.Events.PointerType> PointerType);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The event type.

<a name='dymaptic.GeoBlazor.Core.Events.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).EventId'></a>

`EventId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The unique Id of the event.

<a name='dymaptic.GeoBlazor.Core.Events.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Whether the event can be cancelled once begun.

<a name='dymaptic.GeoBlazor.Core.Events.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Key'></a>

`Key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key value that was pressed, according to the <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/UI_Events/Keyboard_event_key_values".htmlN full list of key values</a>.

<a name='dymaptic.GeoBlazor.Core.Events.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Timestamp'></a>

`Timestamp` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Time stamp (in milliseconds) at which the event was emitted.

<a name='dymaptic.GeoBlazor.Core.Events.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Events.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Events.DomPointerEvent')

A standard DOM Pointer Event

<a name='dymaptic.GeoBlazor.Core.Events.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).PointerType'></a>

`PointerType` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[PointerType](dymaptic.GeoBlazor.Core.Events.PointerType.html 'dymaptic.GeoBlazor.Core.Events.PointerType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates the pointer type.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.KeyUpEvent.Key'></a>

## KeyUpEvent.Key Property

The key value that was pressed, according to the <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/UI_Events/Keyboard_event_key_values".htmlN full list of key values</a>.

```csharp
public string Key { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
