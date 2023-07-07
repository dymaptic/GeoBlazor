---
layout: default
title: DragEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## DragEvent Class

Result of the view.on('drag') event.

```csharp
public class DragEvent : dymaptic.GeoBlazor.Core.Events.JsEvent,
System.IEquatable<dymaptic.GeoBlazor.Core.Events.DragEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [JsEvent](dymaptic.GeoBlazor.Core.Events.JsEvent.html 'dymaptic.GeoBlazor.Core.Events.JsEvent') &#129106; DragEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[DragEvent](dymaptic.GeoBlazor.Core.Events.DragEvent.html 'dymaptic.GeoBlazor.Core.Events.DragEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_)'></a>

## DragEvent(string, Nullable<int>, Nullable<bool>, DragAction, double, double, Point, int, int, double, double, double, DomPointerEvent, Nullable<PointerType>) Constructor

Result of the view.on('drag') event.

```csharp
public DragEvent(string Type, System.Nullable<int> EventId, System.Nullable<bool> Cancelable, dymaptic.GeoBlazor.Core.Events.DragAction Action, double X, double Y, dymaptic.GeoBlazor.Core.Components.Geometries.Point Origin, int Button, int Buttons, double Radius, double Angle, double Timestamp, dymaptic.GeoBlazor.Core.Events.DomPointerEvent Native, System.Nullable<dymaptic.GeoBlazor.Core.Events.PointerType> PointerType);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The event type.

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).EventId'></a>

`EventId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The unique Id of the event.

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Whether the event can be cancelled once begun.

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Action'></a>

`Action` [DragAction](dymaptic.GeoBlazor.Core.Events.DragAction.html 'dymaptic.GeoBlazor.Core.Events.DragAction')

The [DragAction](dymaptic.GeoBlazor.Core.Events.DragAction.html 'dymaptic.GeoBlazor.Core.Events.DragAction') type of the event callback.

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).X'></a>

`X` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The horizontal screen coordinate of the pointer on the view.

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Y'></a>

`Y` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The vertical screen coordinate of the pointer on the view.

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Origin'></a>

`Origin` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The starting point of the drag event.

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Button'></a>

`Button` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Indicates which mouse button was clicked.

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Buttons'></a>

`Buttons` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Indicates the current mouse button state. 0 = left click (or touch), 1 = middle click, 2 = right click.

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Radius'></a>

`Radius` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The radius of the drag.

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Angle'></a>

`Angle` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The angle of the drag.

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Timestamp'></a>

`Timestamp` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Time stamp (in milliseconds) at which the event was emitted.

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Events.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Events.DomPointerEvent')

A standard DOM Pointer Event

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Events.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).PointerType'></a>

`PointerType` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[PointerType](dymaptic.GeoBlazor.Core.Events.PointerType.html 'dymaptic.GeoBlazor.Core.Events.PointerType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates the pointer type.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.Action'></a>

## DragEvent.Action Property

The [DragAction](dymaptic.GeoBlazor.Core.Events.DragAction.html 'dymaptic.GeoBlazor.Core.Events.DragAction') type of the event callback.

```csharp
public dymaptic.GeoBlazor.Core.Events.DragAction Action { get; set; }
```

#### Property Value
[DragAction](dymaptic.GeoBlazor.Core.Events.DragAction.html 'dymaptic.GeoBlazor.Core.Events.DragAction')

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.Angle'></a>

## DragEvent.Angle Property

The angle of the drag.

```csharp
public double Angle { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.Button'></a>

## DragEvent.Button Property

Indicates which mouse button was clicked.

```csharp
public int Button { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.Buttons'></a>

## DragEvent.Buttons Property

Indicates the current mouse button state. 0 = left click (or touch), 1 = middle click, 2 = right click.

```csharp
public int Buttons { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.Origin'></a>

## DragEvent.Origin Property

The starting point of the drag event.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Point Origin { get; set; }
```

#### Property Value
[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.Radius'></a>

## DragEvent.Radius Property

The radius of the drag.

```csharp
public double Radius { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.X'></a>

## DragEvent.X Property

The horizontal screen coordinate of the pointer on the view.

```csharp
public double X { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Events.DragEvent.Y'></a>

## DragEvent.Y Property

The vertical screen coordinate of the pointer on the view.

```csharp
public double Y { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')
