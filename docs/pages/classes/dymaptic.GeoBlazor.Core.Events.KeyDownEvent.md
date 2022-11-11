---
layout: default
title: KeyDownEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## KeyDownEvent Class

Fires after a keyboard key is pressed.

```csharp
public class KeyDownEvent : dymaptic.GeoBlazor.Core.Events.JsEvent,
System.IEquatable<dymaptic.GeoBlazor.Core.Events.KeyDownEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [JsEvent](dymaptic.GeoBlazor.Core.Events.JsEvent.html 'dymaptic.GeoBlazor.Core.Events.JsEvent') &#129106; KeyDownEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[KeyDownEvent](dymaptic.GeoBlazor.Core.Events.KeyDownEvent.html 'dymaptic.GeoBlazor.Core.Events.KeyDownEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.KeyDownEvent.KeyDownEvent(string,System.Nullable_int_,System.Nullable_bool_,bool,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_)'></a>

## KeyDownEvent(string, Nullable<int>, Nullable<bool>, bool, string, double, DomPointerEvent, Nullable<PointerType>) Constructor

Fires after a keyboard key is pressed.

```csharp
public KeyDownEvent(string Type, System.Nullable<int> EventId, System.Nullable<bool> Cancelable, bool Repeat, string Key, double Timestamp, dymaptic.GeoBlazor.Core.Events.DomPointerEvent Native, System.Nullable<dymaptic.GeoBlazor.Core.Events.PointerType> PointerType);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.KeyDownEvent.KeyDownEvent(string,System.Nullable_int_,System.Nullable_bool_,bool,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The event type.

<a name='dymaptic.GeoBlazor.Core.Events.KeyDownEvent.KeyDownEvent(string,System.Nullable_int_,System.Nullable_bool_,bool,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).EventId'></a>

`EventId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The unique Id of the event.

<a name='dymaptic.GeoBlazor.Core.Events.KeyDownEvent.KeyDownEvent(string,System.Nullable_int_,System.Nullable_bool_,bool,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Whether the event can be cancelled once begun.

<a name='dymaptic.GeoBlazor.Core.Events.KeyDownEvent.KeyDownEvent(string,System.Nullable_int_,System.Nullable_bool_,bool,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Repeat'></a>

`Repeat` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates whether this is the first event emitted due to the key press, or a repeat.

<a name='dymaptic.GeoBlazor.Core.Events.KeyDownEvent.KeyDownEvent(string,System.Nullable_int_,System.Nullable_bool_,bool,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Key'></a>

`Key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key value that was pressed, according to the <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/UI_Events/Keyboard_event_key_values".htmlN full list of key values</a>.

<a name='dymaptic.GeoBlazor.Core.Events.KeyDownEvent.KeyDownEvent(string,System.Nullable_int_,System.Nullable_bool_,bool,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Timestamp'></a>

`Timestamp` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Time stamp (in milliseconds) at which the event was emitted.

<a name='dymaptic.GeoBlazor.Core.Events.KeyDownEvent.KeyDownEvent(string,System.Nullable_int_,System.Nullable_bool_,bool,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Events.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Events.DomPointerEvent')

A standard DOM Pointer Event

<a name='dymaptic.GeoBlazor.Core.Events.KeyDownEvent.KeyDownEvent(string,System.Nullable_int_,System.Nullable_bool_,bool,string,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).PointerType'></a>

`PointerType` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[PointerType](dymaptic.GeoBlazor.Core.Events.PointerType.html 'dymaptic.GeoBlazor.Core.Events.PointerType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates the pointer type.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.KeyDownEvent.Key'></a>

## KeyDownEvent.Key Property

The key value that was pressed, according to the <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/UI_Events/Keyboard_event_key_values".htmlN full list of key values</a>.

```csharp
public string Key { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Events.KeyDownEvent.Repeat'></a>

## KeyDownEvent.Repeat Property

Indicates whether this is the first event emitted due to the key press, or a repeat.

```csharp
public bool Repeat { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
