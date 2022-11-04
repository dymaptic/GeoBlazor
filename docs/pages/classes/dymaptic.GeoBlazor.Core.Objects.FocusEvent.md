---
layout: default
title: FocusEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## FocusEvent Class

Fires when browser focus is on the view.

```csharp
public class FocusEvent :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.FocusEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FocusEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[FocusEvent](dymaptic.GeoBlazor.Core.Objects.FocusEvent.html 'dymaptic.GeoBlazor.Core.Objects.FocusEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.FocusEvent.FocusEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent)'></a>

## FocusEvent(MapView, DomPointerEvent) Constructor

Fires when browser focus is on the view.

```csharp
public FocusEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView Target, dymaptic.GeoBlazor.Core.Objects.DomPointerEvent Native);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.FocusEvent.FocusEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Target'></a>

`Target` [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView')

The view that the browser focus is currently on.

<a name='dymaptic.GeoBlazor.Core.Objects.FocusEvent.FocusEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Objects.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.DomPointerEvent')

A standard DOM Pointer Event
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.FocusEvent.Native'></a>

## FocusEvent.Native Property

A standard DOM Pointer Event

```csharp
public dymaptic.GeoBlazor.Core.Objects.DomPointerEvent Native { get; set; }
```

#### Property Value
[DomPointerEvent](dymaptic.GeoBlazor.Core.Objects.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.DomPointerEvent')

<a name='dymaptic.GeoBlazor.Core.Objects.FocusEvent.Target'></a>

## FocusEvent.Target Property

The view that the browser focus is currently on.

```csharp
public dymaptic.GeoBlazor.Core.Components.Views.MapView Target { get; set; }
```

#### Property Value
[MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView')
