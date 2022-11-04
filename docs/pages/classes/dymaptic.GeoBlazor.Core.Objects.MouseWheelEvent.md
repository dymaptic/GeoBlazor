---
layout: default
title: MouseWheelEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## MouseWheelEvent Class

Fires when a wheel button of a pointing device (typically a mouse) is scrolled on the view.

```csharp
public class MouseWheelEvent : dymaptic.GeoBlazor.Core.Objects.JsEvent,
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [JsEvent](dymaptic.GeoBlazor.Core.Objects.JsEvent.html 'dymaptic.GeoBlazor.Core.Objects.JsEvent') &#129106; MouseWheelEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[MouseWheelEvent](dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.html 'dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent)'></a>

## MouseWheelEvent(string, Nullable<int>, Nullable<bool>, double, double, double, long, DomPointerEvent) Constructor

Fires when a wheel button of a pointing device (typically a mouse) is scrolled on the view.

```csharp
public MouseWheelEvent(string Type, System.Nullable<int> EventId, System.Nullable<bool> Cancelable, double X, double Y, double DeltaY, long Timestamp, dymaptic.GeoBlazor.Core.Objects.DomPointerEvent Native);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).EventId'></a>

`EventId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).X'></a>

`X` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The horizontal screen coordinate of the click on the view.

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Y'></a>

`Y` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The vertical screen coordinate of the click on the view.

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).DeltaY'></a>

`DeltaY` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Number representing the vertical scroll amount.

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Timestamp'></a>

`Timestamp` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

Time stamp (in milliseconds) at which the event was emitted.

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Objects.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.DomPointerEvent')

A standard DOM Pointer Event
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.DeltaY'></a>

## MouseWheelEvent.DeltaY Property

Number representing the vertical scroll amount.

```csharp
public double DeltaY { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.Native'></a>

## MouseWheelEvent.Native Property

A standard DOM Pointer Event

```csharp
public dymaptic.GeoBlazor.Core.Objects.DomPointerEvent Native { get; set; }
```

#### Property Value
[DomPointerEvent](dymaptic.GeoBlazor.Core.Objects.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.DomPointerEvent')

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.Timestamp'></a>

## MouseWheelEvent.Timestamp Property

Time stamp (in milliseconds) at which the event was emitted.

```csharp
public long Timestamp { get; set; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.X'></a>

## MouseWheelEvent.X Property

The horizontal screen coordinate of the click on the view.

```csharp
public double X { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.Y'></a>

## MouseWheelEvent.Y Property

The vertical screen coordinate of the click on the view.

```csharp
public double Y { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')
