---
layout: default
title: PointerEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## PointerEvent Class

This event type returns for all pointer events (down, up, enter, leave, move, etc.).

```csharp
public class PointerEvent : dymaptic.GeoBlazor.Core.Events.JsEvent,
System.IEquatable<dymaptic.GeoBlazor.Core.Events.PointerEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [JsEvent](dymaptic.GeoBlazor.Core.Events.JsEvent.html 'dymaptic.GeoBlazor.Core.Events.JsEvent') &#129106; PointerEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent)'></a>

## PointerEvent(string, Nullable<int>, Nullable<bool>, long, Nullable<PointerType>, double, double, int, int, double, DomPointerEvent) Constructor

This event type returns for all pointer events (down, up, enter, leave, move, etc.).

```csharp
public PointerEvent(string Type, System.Nullable<int> EventId, System.Nullable<bool> Cancelable, long PointerId, System.Nullable<dymaptic.GeoBlazor.Core.Events.PointerType> PointerType, double X, double Y, int Button, int Buttons, double Timestamp, dymaptic.GeoBlazor.Core.Events.DomPointerEvent Native);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The event type.

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent).EventId'></a>

`EventId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The unique Id of the event.

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Whether the event can be cancelled once begun.

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent).PointerId'></a>

`PointerId` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

Uniquely identifies a pointer between multiple down, move, and up events. Ids might get reused after a pointer-up event.

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent).PointerType'></a>

`PointerType` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[PointerType](dymaptic.GeoBlazor.Core.Events.PointerType.html 'dymaptic.GeoBlazor.Core.Events.PointerType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates the pointer type.

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent).X'></a>

`X` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The horizontal screen coordinate of the pointer on the view.

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent).Y'></a>

`Y` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The vertical screen coordinate of the pointer on the view.

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent).Button'></a>

`Button` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Indicates which mouse button was clicked.

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent).Buttons'></a>

`Buttons` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Indicates the current mouse button state. 0 = left click (or touch), 1 = middle click, 2 = right click.

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent).Timestamp'></a>

`Timestamp` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Time stamp (in milliseconds) at which the event was emitted.

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Events.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Events.DomPointerEvent')

A standard DOM Pointer Event
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.Button'></a>

## PointerEvent.Button Property

Indicates which mouse button was clicked.

```csharp
public int Button { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.Buttons'></a>

## PointerEvent.Buttons Property

Indicates the current mouse button state. 0 = left click (or touch), 1 = middle click, 2 = right click.

```csharp
public int Buttons { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.PointerId'></a>

## PointerEvent.PointerId Property

Uniquely identifies a pointer between multiple down, move, and up events. Ids might get reused after a pointer-up event.

```csharp
public long PointerId { get; set; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.X'></a>

## PointerEvent.X Property

The horizontal screen coordinate of the pointer on the view.

```csharp
public double X { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Events.PointerEvent.Y'></a>

## PointerEvent.Y Property

The vertical screen coordinate of the pointer on the view.

```csharp
public double Y { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')
