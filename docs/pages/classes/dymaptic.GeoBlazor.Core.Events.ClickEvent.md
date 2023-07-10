---
layout: default
title: ClickEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## ClickEvent Class

Event object for all click (single, double, immediate) and hold events.

```csharp
public class ClickEvent : dymaptic.GeoBlazor.Core.Events.JsEvent,
System.IEquatable<dymaptic.GeoBlazor.Core.Events.ClickEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [JsEvent](dymaptic.GeoBlazor.Core.Events.JsEvent.html 'dymaptic.GeoBlazor.Core.Events.JsEvent') &#129106; ClickEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_)'></a>

## ClickEvent(string, Nullable<int>, Nullable<bool>, Point, double, double, int, int, double, DomPointerEvent, Nullable<PointerType>) Constructor

Event object for all click (single, double, immediate) and hold events.

```csharp
public ClickEvent(string Type, System.Nullable<int> EventId, System.Nullable<bool> Cancelable, dymaptic.GeoBlazor.Core.Components.Geometries.Point MapPoint, double X, double Y, int Button, int Buttons, double Timestamp, dymaptic.GeoBlazor.Core.Events.DomPointerEvent Native, System.Nullable<dymaptic.GeoBlazor.Core.Events.PointerType> PointerType);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The event type.

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).EventId'></a>

`EventId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The unique Id of the event.

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Whether the event can be cancelled once begun.

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).MapPoint'></a>

`MapPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The point location of the click on the view in the spatial reference of the map.

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).X'></a>

`X` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The horizontal screen coordinate of the click on the view.

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Y'></a>

`Y` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The vertical screen coordinate of the click on the view.

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Button'></a>

`Button` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Indicates which mouse button was clicked.

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Buttons'></a>

`Buttons` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Indicates the current mouse button state. 0 = left click (or touch), 1 = middle click, 2 = right click.

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Timestamp'></a>

`Timestamp` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Time stamp (in milliseconds) at which the event was emitted.

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Events.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Events.DomPointerEvent')

A standard DOM Pointer Event

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).PointerType'></a>

`PointerType` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[PointerType](dymaptic.GeoBlazor.Core.Events.PointerType.html 'dymaptic.GeoBlazor.Core.Events.PointerType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates the pointer type.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.Button'></a>

## ClickEvent.Button Property

Indicates which mouse button was clicked.

```csharp
public int Button { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.Buttons'></a>

## ClickEvent.Buttons Property

Indicates the current mouse button state. 0 = left click (or touch), 1 = middle click, 2 = right click.

```csharp
public int Buttons { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.MapPoint'></a>

## ClickEvent.MapPoint Property

The point location of the click on the view in the spatial reference of the map.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Point MapPoint { get; set; }
```

#### Property Value
[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.X'></a>

## ClickEvent.X Property

The horizontal screen coordinate of the click on the view.

```csharp
public double X { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Events.ClickEvent.Y'></a>

## ClickEvent.Y Property

The vertical screen coordinate of the click on the view.

```csharp
public double Y { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')
