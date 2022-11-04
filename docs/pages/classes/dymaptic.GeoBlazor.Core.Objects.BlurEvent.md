---
layout: default
title: BlurEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## BlurEvent Class

Fires when browser focus is moved away from the view.

```csharp
public class BlurEvent :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.BlurEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BlurEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[BlurEvent](dymaptic.GeoBlazor.Core.Objects.BlurEvent.html 'dymaptic.GeoBlazor.Core.Objects.BlurEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.BlurEvent.BlurEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent)'></a>

## BlurEvent(MapView, DomPointerEvent) Constructor

Fires when browser focus is moved away from the view.

```csharp
public BlurEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView Target, dymaptic.GeoBlazor.Core.Objects.DomPointerEvent Native);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.BlurEvent.BlurEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Target'></a>

`Target` [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView')

The view that the browser focus is currently on.

<a name='dymaptic.GeoBlazor.Core.Objects.BlurEvent.BlurEvent(dymaptic.GeoBlazor.Core.Components.Views.MapView,dymaptic.GeoBlazor.Core.Objects.DomPointerEvent).Native'></a>

`Native` [DomPointerEvent](dymaptic.GeoBlazor.Core.Objects.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.DomPointerEvent')

A standard DOM Pointer Event
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.BlurEvent.Native'></a>

## BlurEvent.Native Property

A standard DOM Pointer Event

```csharp
public dymaptic.GeoBlazor.Core.Objects.DomPointerEvent Native { get; set; }
```

#### Property Value
[DomPointerEvent](dymaptic.GeoBlazor.Core.Objects.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Objects.DomPointerEvent')

<a name='dymaptic.GeoBlazor.Core.Objects.BlurEvent.Target'></a>

## BlurEvent.Target Property

The view that the browser focus is currently on.

```csharp
public dymaptic.GeoBlazor.Core.Components.Views.MapView Target { get; set; }
```

#### Property Value
[MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView')
