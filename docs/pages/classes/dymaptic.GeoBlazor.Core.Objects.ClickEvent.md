---
layout: default
title: ClickEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## ClickEvent Class

Event object for all click (single, double, immediate) and hold events.

```csharp
public class ClickEvent : dymaptic.GeoBlazor.Core.Objects.JsEvent,
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.ClickEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [JsEvent](dymaptic.GeoBlazor.Core.Objects.JsEvent.html 'dymaptic.GeoBlazor.Core.Objects.JsEvent') &#129106; ClickEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ClickEvent](dymaptic.GeoBlazor.Core.Objects.ClickEvent.html 'dymaptic.GeoBlazor.Core.Objects.ClickEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent,dymaptic.GeoBlazor.Core.Objects.PointerType)'></a>

## ClickEvent(string, Nullable<int>, Nullable<bool>, Point, double, double, int, int, long, DomPointerEvent, PointerType) Constructor

Event object for all click (single, double, immediate) and hold events.

```csharp
public ClickEvent(string Type, System.Nullable<int> EventId, System.Nullable<bool> Cancelable, dymaptic.GeoBlazor.Core.Components.Geometries.Point MapPoint, double X, double Y, int Button, int Buttons, long Timestamp, dymaptic.GeoBlazor.Core.Objects.DomPointerEvent Native, dymaptic.GeoBlazor.Core.Objects.PointerType PointerType);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent,dymaptic.GeoBlazor.Core.Objects.PointerType).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The event type.

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent,dymaptic.GeoBlazor.Core.Objects.PointerType).EventId'></a>

`EventId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent,dymaptic.GeoBlazor.Core.Objects.PointerType).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent,dymaptic.GeoBlazor.Core.Objects.PointerType).MapPoint'></a>

`MapPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The point location of the click on the view in the spatial reference of the map.

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent,dymaptic.GeoBlazor.Core.Objects.PointerType).X'></a>

`X` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The horizontal screen coordinate of the click on the view.

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent,dymaptic.GeoBlazor.Core.Objects.PointerType).Y'></a>

`Y` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The vertical screen coordinate of the click on the view.

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent,dymaptic.GeoBlazor.Core.Objects.PointerType).Button'></a>

`Button` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Indicates which mouse button was clicked.

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent,dymaptic.GeoBlazor.Core.Objects.PointerType).Buttons'></a>

`Buttons` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Indicates the current mouse button state. 0 = left click (or touch), 1 = middle click, 2 = right click.

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent,dymaptic.GeoBlazor.Core.Objects.PointerType).Timestamp'></a>

`Timestamp` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

Time stamp (in milliseconds) at which the event was emitted.

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent,dymaptic.GeoBlazor.Core.Objects.PointerType).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Objects.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.DomPointerEvent')

A standard DOM Pointer Event

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.ClickEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,int,int,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent,dymaptic.GeoBlazor.Core.Objects.PointerType).PointerType'></a>

`PointerType` [PointerType](dymaptic.GeoBlazor.Core.Objects.PointerType.html 'dymaptic.GeoBlazor.Core.Objects.PointerType')
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.Button'></a>

## ClickEvent.Button Property

Indicates which mouse button was clicked.

```csharp
public int Button { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.Buttons'></a>

## ClickEvent.Buttons Property

Indicates the current mouse button state. 0 = left click (or touch), 1 = middle click, 2 = right click.

```csharp
public int Buttons { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.MapPoint'></a>

## ClickEvent.MapPoint Property

The point location of the click on the view in the spatial reference of the map.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Point MapPoint { get; set; }
```

#### Property Value
[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.Native'></a>

## ClickEvent.Native Property

A standard DOM Pointer Event

```csharp
public dymaptic.GeoBlazor.Core.Objects.DomPointerEvent Native { get; set; }
```

#### Property Value
[DomPointerEvent](dymaptic.GeoBlazor.Core.Objects.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.DomPointerEvent')

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.Timestamp'></a>

## ClickEvent.Timestamp Property

Time stamp (in milliseconds) at which the event was emitted.

```csharp
public long Timestamp { get; set; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.X'></a>

## ClickEvent.X Property

The horizontal screen coordinate of the click on the view.

```csharp
public double X { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.ClickEvent.Y'></a>

## ClickEvent.Y Property

The vertical screen coordinate of the click on the view.

```csharp
public double Y { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')
