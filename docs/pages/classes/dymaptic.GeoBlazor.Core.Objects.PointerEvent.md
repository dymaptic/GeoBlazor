---
layout: default
title: PointerEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## PointerEvent Class

This event type returns for all pointer events (down, up, enter, leave, move, etc.).

```csharp
public class PointerEvent : dymaptic.GeoBlazor.Core.Objects.JsEvent,
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.PointerEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [JsEvent](dymaptic.GeoBlazor.Core.Objects.JsEvent.html 'dymaptic.GeoBlazor.Core.Objects.JsEvent') &#129106; PointerEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[PointerEvent](dymaptic.GeoBlazor.Core.Objects.PointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.PointerEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,dymaptic.GeoBlazor.Core.Objects.PointerType,double,double,bool,bool,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent)'></a>

## PointerEvent(string, Nullable<int>, Nullable<bool>, long, PointerType, double, double, bool, bool, long, DomPointerEvent) Constructor

This event type returns for all pointer events (down, up, enter, leave, move, etc.).

```csharp
public PointerEvent(string Type, System.Nullable<int> EventId, System.Nullable<bool> Cancelable, long PointerId, dymaptic.GeoBlazor.Core.Objects.PointerType PointerType, double X, double Y, bool Button, bool Buttons, long Timestamp, dymaptic.GeoBlazor.Core.Objects.DomPointerEvent Native);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,dymaptic.GeoBlazor.Core.Objects.PointerType,double,double,bool,bool,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The event type.

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,dymaptic.GeoBlazor.Core.Objects.PointerType,double,double,bool,bool,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).EventId'></a>

`EventId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,dymaptic.GeoBlazor.Core.Objects.PointerType,double,double,bool,bool,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,dymaptic.GeoBlazor.Core.Objects.PointerType,double,double,bool,bool,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).PointerId'></a>

`PointerId` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

Uniquely identifies a pointer between multiple down, move, and up events. Ids might get reused after a pointer-up event.

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,dymaptic.GeoBlazor.Core.Objects.PointerType,double,double,bool,bool,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).PointerType'></a>

`PointerType` [PointerType](dymaptic.GeoBlazor.Core.Objects.PointerType.html 'dymaptic.GeoBlazor.Core.Objects.PointerType')

Indicates the pointer type.

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,dymaptic.GeoBlazor.Core.Objects.PointerType,double,double,bool,bool,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).X'></a>

`X` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The horizontal screen coordinate of the pointer on the view.

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,dymaptic.GeoBlazor.Core.Objects.PointerType,double,double,bool,bool,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Y'></a>

`Y` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The vertical screen coordinate of the pointer on the view.

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,dymaptic.GeoBlazor.Core.Objects.PointerType,double,double,bool,bool,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Button'></a>

`Button` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates which mouse button was clicked.

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,dymaptic.GeoBlazor.Core.Objects.PointerType,double,double,bool,bool,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Buttons'></a>

`Buttons` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates the current mouse button state. 0 = left click (or touch), 1 = middle click, 2 = right click.

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,dymaptic.GeoBlazor.Core.Objects.PointerType,double,double,bool,bool,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Timestamp'></a>

`Timestamp` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

Time stamp (in milliseconds) at which the event was emitted.

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerEvent(string,System.Nullable_int_,System.Nullable_bool_,long,dymaptic.GeoBlazor.Core.Objects.PointerType,double,double,bool,bool,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Objects.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.DomPointerEvent')

A standard DOM Pointer Event
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.Button'></a>

## PointerEvent.Button Property

Indicates which mouse button was clicked.

```csharp
public bool Button { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.Buttons'></a>

## PointerEvent.Buttons Property

Indicates the current mouse button state. 0 = left click (or touch), 1 = middle click, 2 = right click.

```csharp
public bool Buttons { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.Native'></a>

## PointerEvent.Native Property

A standard DOM Pointer Event

```csharp
public dymaptic.GeoBlazor.Core.Objects.DomPointerEvent Native { get; set; }
```

#### Property Value
[DomPointerEvent](dymaptic.GeoBlazor.Core.Objects.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.DomPointerEvent')

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerId'></a>

## PointerEvent.PointerId Property

Uniquely identifies a pointer between multiple down, move, and up events. Ids might get reused after a pointer-up event.

```csharp
public long PointerId { get; set; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.PointerType'></a>

## PointerEvent.PointerType Property

Indicates the pointer type.

```csharp
public dymaptic.GeoBlazor.Core.Objects.PointerType PointerType { get; set; }
```

#### Property Value
[PointerType](dymaptic.GeoBlazor.Core.Objects.PointerType.html 'dymaptic.GeoBlazor.Core.Objects.PointerType')

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.Timestamp'></a>

## PointerEvent.Timestamp Property

Time stamp (in milliseconds) at which the event was emitted.

```csharp
public long Timestamp { get; set; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.X'></a>

## PointerEvent.X Property

The horizontal screen coordinate of the pointer on the view.

```csharp
public double X { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.PointerEvent.Y'></a>

## PointerEvent.Y Property

The vertical screen coordinate of the pointer on the view.

```csharp
public double Y { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')
