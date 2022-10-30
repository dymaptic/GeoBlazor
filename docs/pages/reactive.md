---
layout: page
title: "Events and Property Changes"
nav_order: 3
---

# Reacting to Events and Property Changes

There are several ways to listen for events and property changes in GeoBlazor.

## View `EventCallbacks`
[MapView](classes/dymaptic.GeoBlazor.Core.Components.Views.MapView) has a full range of DOM-standard and ArcGIS-specific
event handlers in the form of `EventCallback` with strongly typed return values. 
Implement handlers as Razor component parameters in your calling code.

- OnBlur: `void`
- OnClick: `Point`
- OnDoubleClick: `Point`
- OnDrag: `DragResult`
- OnExtentChanged: `Extent`
- OnFocus: `void`
- OnHold: `Point`
- OnImmediateClick: `Point`
- OnImmediateDoubleClick: `Point`
- OnKeyDown: `string`
- OnKeyUp: `string`
- OnLayerViewCreate: `LayerView`
- OnLayerViewDestroy: `LayerView`
- OnMapRendered: `void`
- OnMouseWheel: `MouseWheelResult`
- OnPointerDown: `Point`
- OnPointerEnter: `Point`
- OnPointerLeave: `Point`
- OnPointerMove: `Point`
- OnPointerUp: `Point`
- OnResize: `ResizeResult`
- OnSpatialReferenceChanged: `SpatialReference`

## `ReactiveUtils` Handlers
Most components also support a pattern of attaching event handlers and watching properties
with loose typing. See [Reactive Utils](https://samples.GeoBlazor.com/reactive-utils).

### Watching a property value
```csharp
private async Task AddWatcher()
{
    await _view.AddReactiveWatcher<bool>("view?.center", CenterWatchHandler);
}

private void CenterWatchHandler(bool result)
{
    // do something with the result
}
```

### Waiting for a property value to equal `true`
```csharp
private async Task AddWaiter()
{
    await _view.AddReactiveWaiter("view?.popup?.visible", PopupWatchHandler);
}

private void PopupWatchHandler()
{
    // do something once the value is true
}
```

### Listening to an event
```csharp
private async Task AddListener()
{
    await _view!.AddReactiveListener<object?>("drag", DragHandler);
}

private void DragHandler(object? result)
{
    // do something with the result
}
```

All of these reactive methods above support attaching to other components besides the `MapView` or `SceneView`. However,
you should always provide the optional parameter `targetName` and make sure it matches the named object in your `expression`.

```csharp
private async Task AddWaiter()
{
    await _homeWidget.AddReactiveWaiter("myWidget?.visible", WidgetHandler, "myWidget");
}

private void WidgetHandler()
{
    // do something once the value is true
}
```

There is also a "Fire Once" method, `AwaitReactiveSingleWatchUpdate`. Unlike the other methods, this one returns the value
asynchronously but inline, without a handler.

```csharp
private async Task<bool> AttachZoomWatcher()
{
    return await _view!.AwaitReactiveSingleWatchUpdate<bool>("view?.zoom > 20");
}
```