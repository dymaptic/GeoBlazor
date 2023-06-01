---
layout: default
title: MouseWheelEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## MouseWheelEvent Class

Fires when a wheel button of a pointing device (typically a mouse) is scrolled on the view.

```csharp
public class MouseWheelEvent : dymaptic.GeoBlazor.Core.Events.JsEvent,
System.IEquatable<dymaptic.GeoBlazor.Core.Events.MouseWheelEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [JsEvent](dymaptic.GeoBlazor.Core.Events.JsEvent.html 'dymaptic.GeoBlazor.Core.Events.JsEvent') &#129106; MouseWheelEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[MouseWheelEvent](dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.html 'dymaptic.GeoBlazor.Core.Events.MouseWheelEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_)'></a>

## MouseWheelEvent(string, Nullable<int>, Nullable<bool>, double, double, double, double, DomPointerEvent, Nullable<PointerType>) Constructor

Fires when a wheel button of a pointing device (typically a mouse) is scrolled on the view.

```csharp
public MouseWheelEvent(string Type, System.Nullable<int> EventId, System.Nullable<bool> Cancelable, double X, double Y, double DeltaY, double Timestamp, dymaptic.GeoBlazor.Core.Events.DomPointerEvent Native, System.Nullable<dymaptic.GeoBlazor.Core.Events.PointerType> PointerType);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Indicates the type of the event.

<a name='dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).EventId'></a>

`EventId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The unique Id of the event.

<a name='dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Whether the event can be cancelled once begun.

<a name='dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).X'></a>

`X` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The horizontal screen coordinate of the click on the view.

<a name='dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Y'></a>

`Y` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The vertical screen coordinate of the click on the view.

<a name='dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).DeltaY'></a>

`DeltaY` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Number representing the vertical scroll amount.

<a name='dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Timestamp'></a>

`Timestamp` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Time stamp (in milliseconds) at which the event was emitted.

<a name='dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Events.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Events.DomPointerEvent')

A standard DOM Pointer Event

<a name='dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.MouseWheelEvent(string,System.Nullable_int_,System.Nullable_bool_,double,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).PointerType'></a>

`PointerType` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[PointerType](dymaptic.GeoBlazor.Core.Events.PointerType.html 'dymaptic.GeoBlazor.Core.Events.PointerType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates the pointer type.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.DeltaY'></a>

## MouseWheelEvent.DeltaY Property

Number representing the vertical scroll amount.

```csharp
public double DeltaY { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.X'></a>

## MouseWheelEvent.X Property

The horizontal screen coordinate of the click on the view.

```csharp
public double X { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.Y'></a>

## MouseWheelEvent.Y Property

The vertical screen coordinate of the click on the view.

```csharp
public double Y { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')
