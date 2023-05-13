---
layout: page
title: "Events and Property Changes"
nav_order: 8
---

# Reacting to Events and Property Changes

There are several ways to listen for events and property changes in GeoBlazor.

## View `EventCallbacks`

[MapView](classes/dymaptic.GeoBlazor.Core.Components.Views.MapView) has a full range of DOM-standard and ArcGIS-specific
event handlers in the form of `EventCallback` with strongly typed return values.
Implement handlers as Razor component parameters in your calling code.

- OnBlur: `void`
- OnClick: `ClickEvent`
- OnDoubleClick: `ClickEvent`
- OnDrag: `DragEvent` \*
- OnExtentChanged: `Extent` \*
- OnFocus: `FocusEvent`
- OnHold: `ClickEvent`
- OnImmediateClick: `ClickEvent`
- OnImmediateDoubleClick: `ClickEvent`
- OnKeyDown: `KeyDownEvent`
- OnKeyUp: `KeyDownEvent`
- OnLayerViewCreate: `LayerViewCreateEvent`
- OnLayerViewDestroy: `LayerViewDestroyEvent`
- OnMapRendered: `void`
- OnMouseWheel: `MouseWheelEvent` \*
- OnPointerDown: `PointerEvent`
- OnPointerEnter: `PointerEvent`
- OnPointerLeave: `PointerEvent`
- OnPointerMove: `PointerEvent` \*
- OnPointerUp: `PointerEvent`
- OnResize: `ResizeEvent` \*
- OnSpatialReferenceChanged: `SpatialReference`

A sample implementation:

```csharp
<MapView OnClick="OnClick">
    <Map>
        ...
    </Map>
</MapView>

@code 
{
    private async Task<ClickEvent> OnClick(ClickEvent event)
    {
        // use the click event
    }
}
```

Note that since an `EventCallback` in Blazor is a `Parameter`, you are limited to attaching a single listener method.
However, within that one method, you could perform as many actions as you need.

## Limiting the rate of responses

Some events, such as drag, pointer-move, and extent-changed, will fire rapidly while a user navigates the map.
The properties supported are marked with a `*` above.
Set the property `MapView.EventRateLimitInMilliseconds` to "throttle" the responses of these events to a reasonable
rate. This is especially useful in Blazor Server, where every response must be sent from the client back to the server.

## `ReactiveUtils` Handlers

Most components also support a pattern of attaching event handlers and watching properties
with loose typing. See [Reactive Utils](https://samples.GeoBlazor.com/reactive-utils).

### Watching a property value

A watcher (`watch` event in Javascript) reports back when a property value has changed. The `<T>` type should match
the expected return type, whether it be a primitive or map component. You can also return a `string` which should
return a string representation of the type, either primitive or JSON.

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

A waiter (`wait` in Javascript) is the same as a watcher, but it adds a boolean ("truthy") comparison.
See [the MDN Docs](https://developer.mozilla.org/en-US/docs/Glossary/Truthy) for more information on truthy.

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

Listeners (called `on` events in Javascript) support all the same return types as described in `View EventCallbacks`
above.
You can also return the value as a `string?`, which will return the un-parsed JSON of the event object, `object?`,
or `dynamic?`. You should always mark your return type as nullable (`?`).

```csharp
private async Task AddListener()
{
    await _view!.AddReactiveListener<DragEvent?>("drag", DragHandler);
}

private void DragHandler(DragEvent? result)
{
    // do something with the result
}
```

All of these reactive methods above support attaching to other components besides the `MapView` or `SceneView`. However,
you should always provide the optional parameter `targetName` and make sure it matches the named object in
your `expression`.
For example:

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

There is also a "Fire Once" method, `AwaitReactiveSingleWatchUpdate`. Unlike the other methods, this one returns the
value
asynchronously but inline, without a handler.

```csharp
private async Task<bool> AttachZoomWatcher()
{
    return await _view!.AwaitReactiveSingleWatchUpdate<bool>("view?.zoom > 20");
}
```

