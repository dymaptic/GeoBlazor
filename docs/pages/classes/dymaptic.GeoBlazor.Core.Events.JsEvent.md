---
layout: default
title: JsEvent
parent: Classes
---
---
layout: default
title: JsEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## JsEvent Class

Base class for many events triggered in Javascript.

```csharp
public class JsEvent :
System.IEquatable<dymaptic.GeoBlazor.Core.Events.JsEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; JsEvent

Derived  
&#8627; [BlurEvent](dymaptic.GeoBlazor.Core.Events.BlurEvent.html 'dymaptic.GeoBlazor.Core.Events.BlurEvent')  
&#8627; [ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent')  
&#8627; [DragEvent](dymaptic.GeoBlazor.Core.Events.DragEvent.html 'dymaptic.GeoBlazor.Core.Events.DragEvent')  
&#8627; [FocusEvent](dymaptic.GeoBlazor.Core.Events.FocusEvent.html 'dymaptic.GeoBlazor.Core.Events.FocusEvent')  
&#8627; [KeyDownEvent](dymaptic.GeoBlazor.Core.Events.KeyDownEvent.html 'dymaptic.GeoBlazor.Core.Events.KeyDownEvent')  
&#8627; [KeyUpEvent](dymaptic.GeoBlazor.Core.Events.KeyUpEvent.html 'dymaptic.GeoBlazor.Core.Events.KeyUpEvent')  
&#8627; [MouseWheelEvent](dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.html 'dymaptic.GeoBlazor.Core.Events.MouseWheelEvent')  
&#8627; [PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent')

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[JsEvent](dymaptic.GeoBlazor.Core.Events.JsEvent.html 'dymaptic.GeoBlazor.Core.Events.JsEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.JsEvent.JsEvent(string,System.Nullable_int_,System.Nullable_bool_,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_)'></a>

## JsEvent(string, Nullable<int>, Nullable<bool>, double, DomPointerEvent, Nullable<PointerType>) Constructor

Base class for many events triggered in Javascript.

```csharp
public JsEvent(string Type, System.Nullable<int> EventId, System.Nullable<bool> Cancelable, double Timestamp, dymaptic.GeoBlazor.Core.Events.DomPointerEvent Native, System.Nullable<dymaptic.GeoBlazor.Core.Events.PointerType> PointerType);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.JsEvent.JsEvent(string,System.Nullable_int_,System.Nullable_bool_,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The type of the event.

<a name='dymaptic.GeoBlazor.Core.Events.JsEvent.JsEvent(string,System.Nullable_int_,System.Nullable_bool_,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).EventId'></a>

`EventId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The unique Id of the event.

<a name='dymaptic.GeoBlazor.Core.Events.JsEvent.JsEvent(string,System.Nullable_int_,System.Nullable_bool_,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Whether the event can be cancelled once begun.

<a name='dymaptic.GeoBlazor.Core.Events.JsEvent.JsEvent(string,System.Nullable_int_,System.Nullable_bool_,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Timestamp'></a>

`Timestamp` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Time stamp (in milliseconds) at which the event was emitted.

<a name='dymaptic.GeoBlazor.Core.Events.JsEvent.JsEvent(string,System.Nullable_int_,System.Nullable_bool_,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Events.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Events.DomPointerEvent')

A standard DOM Pointer Event

<a name='dymaptic.GeoBlazor.Core.Events.JsEvent.JsEvent(string,System.Nullable_int_,System.Nullable_bool_,double,dymaptic.GeoBlazor.Core.Events.DomPointerEvent,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_).PointerType'></a>

`PointerType` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[PointerType](dymaptic.GeoBlazor.Core.Events.PointerType.html 'dymaptic.GeoBlazor.Core.Events.PointerType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates the pointer type. (optional)
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.JsEvent.Cancelable'></a>

## JsEvent.Cancelable Property

Whether the event can be cancelled once begun.

```csharp
public System.Nullable<bool> Cancelable { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Events.JsEvent.EventId'></a>

## JsEvent.EventId Property

The unique Id of the event.

```csharp
public System.Nullable<int> EventId { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Events.JsEvent.Native'></a>

## JsEvent.Native Property

A standard DOM Pointer Event

```csharp
public dymaptic.GeoBlazor.Core.Events.DomPointerEvent Native { get; set; }
```

#### Property Value
[DomPointerEvent](dymaptic.GeoBlazor.Core.Events.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Events.DomPointerEvent')

<a name='dymaptic.GeoBlazor.Core.Events.JsEvent.PointerType'></a>

## JsEvent.PointerType Property

Indicates the pointer type. (optional)

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Events.PointerType> PointerType { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[PointerType](dymaptic.GeoBlazor.Core.Events.PointerType.html 'dymaptic.GeoBlazor.Core.Events.PointerType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Events.JsEvent.Timestamp'></a>

## JsEvent.Timestamp Property

Time stamp (in milliseconds) at which the event was emitted.

```csharp
public double Timestamp { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Events.JsEvent.Type'></a>

## JsEvent.Type Property

The type of the event.

```csharp
public string Type { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

