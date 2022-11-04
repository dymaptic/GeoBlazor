---
layout: default
title: JsEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## JsEvent Class

Base class for many events triggered in Javascript.

```csharp
public class JsEvent :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.JsEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; JsEvent

Derived  
&#8627; [ClickEvent](dymaptic.GeoBlazor.Core.Objects.ClickEvent.html 'dymaptic.GeoBlazor.Core.Objects.ClickEvent')  
&#8627; [DragEvent](dymaptic.GeoBlazor.Core.Objects.DragEvent.html 'dymaptic.GeoBlazor.Core.Objects.DragEvent')  
&#8627; [KeyDownEvent](dymaptic.GeoBlazor.Core.Objects.KeyDownEvent.html 'dymaptic.GeoBlazor.Core.Objects.KeyDownEvent')  
&#8627; [KeyUpEvent](dymaptic.GeoBlazor.Core.Objects.KeyUpEvent.html 'dymaptic.GeoBlazor.Core.Objects.KeyUpEvent')  
&#8627; [MouseWheelEvent](dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent.html 'dymaptic.GeoBlazor.Core.Objects.MouseWheelEvent')  
&#8627; [PointerEvent](dymaptic.GeoBlazor.Core.Objects.PointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.PointerEvent')

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[JsEvent](dymaptic.GeoBlazor.Core.Objects.JsEvent.html 'dymaptic.GeoBlazor.Core.Objects.JsEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.JsEvent.JsEvent(string,System.Nullable_int_,System.Nullable_bool_)'></a>

## JsEvent(string, Nullable<int>, Nullable<bool>) Constructor

Base class for many events triggered in Javascript.

```csharp
public JsEvent(string Type, System.Nullable<int> EventId, System.Nullable<bool> Cancelable);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.JsEvent.JsEvent(string,System.Nullable_int_,System.Nullable_bool_).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The type of the event.

<a name='dymaptic.GeoBlazor.Core.Objects.JsEvent.JsEvent(string,System.Nullable_int_,System.Nullable_bool_).EventId'></a>

`EventId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.JsEvent.JsEvent(string,System.Nullable_int_,System.Nullable_bool_).Cancelable'></a>

`Cancelable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.JsEvent.Type'></a>

## JsEvent.Type Property

The type of the event.

```csharp
public string Type { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
