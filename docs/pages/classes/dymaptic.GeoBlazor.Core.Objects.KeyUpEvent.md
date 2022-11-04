---
layout: default
title: KeyUpEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## KeyUpEvent Class

Fires after a keyboard key is released.

```csharp
public class KeyUpEvent : dymaptic.GeoBlazor.Core.Objects.JsEvent,
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.KeyUpEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [JsEvent](dymaptic.GeoBlazor.Core.Objects.JsEvent.html 'dymaptic.GeoBlazor.Core.Objects.JsEvent') &#129106; KeyUpEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[KeyUpEvent](dymaptic.GeoBlazor.Core.Objects.KeyUpEvent.html 'dymaptic.GeoBlazor.Core.Objects.KeyUpEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent)'></a>

## KeyUpEvent(string, Nullable<int>, Nullable<bool>, string, long, DomPointerEvent) Constructor

Fires after a keyboard key is released.

```csharp
public KeyUpEvent(string Type, System.Nullable<int> EventId, System.Nullable<bool> Cancelable, string Key, long Timestamp, dymaptic.GeoBlazor.Core.Objects.DomPointerEvent Native);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The event type.

<a name='dymaptic.GeoBlazor.Core.Objects.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).EventId'></a>

`EventId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Key'></a>

`Key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key value that was pressed, according to the <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/UI_Events/Keyboard_event_key_values".htmlN full list of key values</a>.

<a name='dymaptic.GeoBlazor.Core.Objects.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Timestamp'></a>

`Timestamp` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

Time stamp (in milliseconds) at which the event was emitted.

<a name='dymaptic.GeoBlazor.Core.Objects.KeyUpEvent.KeyUpEvent(string,System.Nullable_int_,System.Nullable_bool_,string,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Objects.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.DomPointerEvent')

A standard DOM Pointer Event
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.KeyUpEvent.Key'></a>

## KeyUpEvent.Key Property

The key value that was pressed, according to the <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Web/API/UI_Events/Keyboard_event_key_values".htmlN full list of key values</a>.

```csharp
public string Key { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.KeyUpEvent.Native'></a>

## KeyUpEvent.Native Property

A standard DOM Pointer Event

```csharp
public dymaptic.GeoBlazor.Core.Objects.DomPointerEvent Native { get; set; }
```

#### Property Value
[DomPointerEvent](dymaptic.GeoBlazor.Core.Objects.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.DomPointerEvent')

<a name='dymaptic.GeoBlazor.Core.Objects.KeyUpEvent.Timestamp'></a>

## KeyUpEvent.Timestamp Property

Time stamp (in milliseconds) at which the event was emitted.

```csharp
public long Timestamp { get; set; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')
