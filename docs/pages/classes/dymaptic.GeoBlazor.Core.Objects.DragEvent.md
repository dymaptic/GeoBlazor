---
layout: default
title: DragEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## DragEvent Class

Result of the view.on('drag') event.

```csharp
public class DragEvent : dymaptic.GeoBlazor.Core.Objects.JsEvent,
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.DragEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [JsEvent](dymaptic.GeoBlazor.Core.Objects.JsEvent.html 'dymaptic.GeoBlazor.Core.Objects.JsEvent') &#129106; DragEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[DragEvent](dymaptic.GeoBlazor.Core.Objects.DragEvent.html 'dymaptic.GeoBlazor.Core.Objects.DragEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent)'></a>

## DragEvent(string, Nullable<int>, Nullable<bool>, DragAction, double, double, Point, int, int, double, double, long, DomPointerEvent) Constructor

Result of the view.on('drag') event.

```csharp
public DragEvent(string Type, System.Nullable<int> EventId, System.Nullable<bool> Cancelable, dymaptic.GeoBlazor.Core.Objects.DragAction Action, double X, double Y, dymaptic.GeoBlazor.Core.Components.Geometries.Point Origin, int Button, int Buttons, double Radius, double Angle, long Timestamp, dymaptic.GeoBlazor.Core.Objects.DomPointerEvent Native);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).EventId'></a>

`EventId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Action'></a>

`Action` [DragAction](dymaptic.GeoBlazor.Core.Objects.DragAction.html 'dymaptic.GeoBlazor.Core.Objects.DragAction')

The [DragAction](dymaptic.GeoBlazor.Core.Objects.DragAction.html 'dymaptic.GeoBlazor.Core.Objects.DragAction') type of the event callback.

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).X'></a>

`X` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Y'></a>

`Y` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Origin'></a>

`Origin` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The starting point of the drag event.

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Button'></a>

`Button` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Buttons'></a>

`Buttons` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Radius'></a>

`Radius` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Angle'></a>

`Angle` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Timestamp'></a>

`Timestamp` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.DragEvent(string,System.Nullable_int_,System.Nullable_bool_,dymaptic.GeoBlazor.Core.Objects.DragAction,double,double,dymaptic.GeoBlazor.Core.Components.Geometries.Point,int,int,double,double,long,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Objects.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.DomPointerEvent')
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.Action'></a>

## DragEvent.Action Property

The [DragAction](dymaptic.GeoBlazor.Core.Objects.DragAction.html 'dymaptic.GeoBlazor.Core.Objects.DragAction') type of the event callback.

```csharp
public dymaptic.GeoBlazor.Core.Objects.DragAction Action { get; set; }
```

#### Property Value
[DragAction](dymaptic.GeoBlazor.Core.Objects.DragAction.html 'dymaptic.GeoBlazor.Core.Objects.DragAction')

<a name='dymaptic.GeoBlazor.Core.Objects.DragEvent.Origin'></a>

## DragEvent.Origin Property

The starting point of the drag event.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Point Origin { get; set; }
```

#### Property Value
[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')
