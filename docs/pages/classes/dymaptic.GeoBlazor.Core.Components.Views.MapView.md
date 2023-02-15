---
layout: default
title: MapView
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Views](index.html#dymaptic.GeoBlazor.Core.Components.Views 'dymaptic.GeoBlazor.Core.Components.Views')

## MapView Class

The Top-Level Map Component Container.  
A MapView displays a 2D view of a Map instance. An instance of MapView must be created to render a Map (along with its operational and base layers) in 2D. To render a map and its layers in 3D, see the documentation for SceneView. For a general overview of views, see View.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">ArcGIS JS API</a>

```csharp
public class MapView : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; MapView

Derived  
&#8627; [SceneView](dymaptic.GeoBlazor.Core.Components.Views.SceneView.html 'dymaptic.GeoBlazor.Core.Components.Views.SceneView')

### Example
<a target="_blank" href="https://samples.geoblazor.com/navigation">Sample - Navigation</a>
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.AllowDefaultEsriLogin'></a>

## MapView.AllowDefaultEsriLogin Property

Allows maps to be rendered without an Api or OAuth Token, which will trigger a default esri login popup.

```csharp
public System.Nullable<bool> AllowDefaultEsriLogin { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Center'></a>

## MapView.Center Property

The Center point of the view, equivalent to setting Latitude/Longitude

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Point? Center { get; set; }
```

#### Property Value
[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Class'></a>

## MapView.Class Property

Inline html/css class selector for applying css

```csharp
public string Class { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Configuration'></a>

## MapView.Configuration Property

A set of key/value application configuration properties, that can be populated from `appsettings.json, environment variables, or other sources.

```csharp
public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; set; }
```

#### Property Value
[Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.EventRateLimitInMilliseconds'></a>

## MapView.EventRateLimitInMilliseconds Property

Set this parameter to limit the rate at which recurring events are returned. Applies to [OnDrag](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.OnDrag 'dymaptic.GeoBlazor.Core.Components.Views.MapView.OnDrag'), [OnPointerMove](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.OnPointerMove 'dymaptic.GeoBlazor.Core.Components.Views.MapView.OnPointerMove'), [OnMouseWheel](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.OnMouseWheel 'dymaptic.GeoBlazor.Core.Components.Views.MapView.OnMouseWheel'), [OnResize](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.OnResize 'dymaptic.GeoBlazor.Core.Components.Views.MapView.OnResize'), and [OnExtentChanged](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.OnExtentChanged 'dymaptic.GeoBlazor.Core.Components.Views.MapView.OnExtentChanged')

```csharp
public System.Nullable<int> EventRateLimitInMilliseconds { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Graphics'></a>

## MapView.Graphics Property

The collection of [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')s in the view. These are directly on the view itself, not in a [GraphicsLayer](dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer').

```csharp
public System.Collections.Generic.IReadOnlyCollection<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> Graphics { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Latitude'></a>

## MapView.Latitude Property

The Latitude for the Center point of the view

```csharp
public System.Nullable<double> Latitude { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.LoadOnRender'></a>

## MapView.LoadOnRender Property

Boolean flag that can be set to false to prevent the MapView from automatically rendering with the Blazor components.

```csharp
public bool LoadOnRender { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Longitude'></a>

## MapView.Longitude Property

The Longitude for the Center point of the view

```csharp
public System.Nullable<double> Longitude { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Map'></a>

## MapView.Map Property

An instance of a [Map](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.Map 'dymaptic.GeoBlazor.Core.Components.Views.MapView.Map') object to display in the view.

```csharp
public dymaptic.GeoBlazor.Core.Components.Map? Map { get; set; }
```

#### Property Value
[Map](dymaptic.GeoBlazor.Core.Components.Map.html 'dymaptic.GeoBlazor.Core.Components.Map')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnBlur'></a>

## MapView.OnBlur Property

Handler delegate for blur (lost focus) events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.BlurEvent> OnBlur { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[BlurEvent](dymaptic.GeoBlazor.Core.Events.BlurEvent.html 'dymaptic.GeoBlazor.Core.Events.BlurEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnClick'></a>

## MapView.OnClick Property

Handler delegate for click events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.ClickEvent> OnClick { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnDoubleClick'></a>

## MapView.OnDoubleClick Property

Handler delegate for double-click events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.ClickEvent> OnDoubleClick { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnDrag'></a>

## MapView.OnDrag Property

Handler delegate for pointer drag events on the view, returns a [DragEvent](dymaptic.GeoBlazor.Core.Events.DragEvent.html 'dymaptic.GeoBlazor.Core.Events.DragEvent').

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.DragEvent> OnDrag { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[DragEvent](dymaptic.GeoBlazor.Core.Events.DragEvent.html 'dymaptic.GeoBlazor.Core.Events.DragEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
The real-time nature of this handler make it a challenge to use continuously over SignalR in Blazor Server.  
In this scenario, you should write a custom JavaScript handler instead.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnExtentChanged'></a>

## MapView.OnExtentChanged Property

Handler delegate for the view's Extent changing.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Geometries.Extent> OnExtentChanged { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnFocus'></a>

## MapView.OnFocus Property

Handler delegate for focus events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.FocusEvent> OnFocus { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[FocusEvent](dymaptic.GeoBlazor.Core.Events.FocusEvent.html 'dymaptic.GeoBlazor.Core.Events.FocusEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnHold'></a>

## MapView.OnHold Property

Handler delegate for hold events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.ClickEvent> OnHold { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnImmediateClick'></a>

## MapView.OnImmediateClick Property

Handler delegate for immediate-click events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.ClickEvent> OnImmediateClick { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnImmediateDoubleClick'></a>

## MapView.OnImmediateDoubleClick Property

Handler delegate for immediate-double-click events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.ClickEvent> OnImmediateDoubleClick { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptErrorHandler'></a>

## MapView.OnJavascriptErrorHandler Property

Implement this handler in your calling code to catch and handle Javascript errors.

```csharp
public System.Func<dymaptic.GeoBlazor.Core.Exceptions.JavascriptException,System.Threading.Tasks.Task>? OnJavascriptErrorHandler { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[JavascriptException](dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptException')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnKeyDown'></a>

## MapView.OnKeyDown Property

Handler delegate for key-down events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.KeyDownEvent> OnKeyDown { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[KeyDownEvent](dymaptic.GeoBlazor.Core.Events.KeyDownEvent.html 'dymaptic.GeoBlazor.Core.Events.KeyDownEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
Fires after a keyboard key is pressed.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnKeyUp'></a>

## MapView.OnKeyUp Property

Handler delegate for key-up events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.KeyUpEvent> OnKeyUp { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[KeyUpEvent](dymaptic.GeoBlazor.Core.Events.KeyUpEvent.html 'dymaptic.GeoBlazor.Core.Events.KeyUpEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
Fires after a keyboard key is released.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnLayerViewCreate'></a>

## MapView.OnLayerViewCreate Property

Fires after each layer in the map has a corresponding LayerView created and rendered in the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent> OnLayerViewCreate { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[LayerViewCreateEvent](dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.html 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnLayerViewCreateError'></a>

## MapView.OnLayerViewCreateError Property

Fires after a LayerView is destroyed and is no longer rendered in the view. This happens for example when a layer is removed from the map of the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent> OnLayerViewCreateError { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[LayerViewCreateErrorEvent](dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent.html 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnLayerViewDestroy'></a>

## MapView.OnLayerViewDestroy Property

Fires after a LayerView is destroyed and is no longer rendered in the view. This happens for example when a layer is removed from the map of the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent> OnLayerViewDestroy { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[LayerViewDestroyEvent](dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent.html 'dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnMapRendered'></a>

## MapView.OnMapRendered Property

Handler delegate for when the map view is fully rendered. Must return a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

```csharp
public Microsoft.AspNetCore.Components.EventCallback OnMapRendered { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback 'Microsoft.AspNetCore.Components.EventCallback')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnMouseWheel'></a>

## MapView.OnMouseWheel Property

Handler delegate for the view's Extent changing.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.MouseWheelEvent> OnMouseWheel { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[MouseWheelEvent](dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.html 'dymaptic.GeoBlazor.Core.Events.MouseWheelEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnPointerDown'></a>

## MapView.OnPointerDown Property

Handler delegate for pointer down events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.PointerEvent> OnPointerDown { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
Fires after a mouse button is pressed, or a finger touches the display.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnPointerEnter'></a>

## MapView.OnPointerEnter Property

Handler delegate for pointer enter events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.PointerEvent> OnPointerEnter { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
Fires after a mouse cursor enters the view, or a display touch begins.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnPointerLeave'></a>

## MapView.OnPointerLeave Property

Handler delegate for pointer leave events on the view. Must take in a [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') and return a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.PointerEvent> OnPointerLeave { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
Fires after a mouse cursor leaves the view, or a display touch ends.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnPointerMove'></a>

## MapView.OnPointerMove Property

Handler delegate for point move events on the view. Must take in a [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') and return a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.PointerEvent> OnPointerMove { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
The real-time nature of this handler make it a challenge to use continuously over SignalR in Blazor Server.  
In this scenario, you should write a custom JavaScript handler instead.  
See <a target="_blank" href="https://github.com/dymaptic/GeoBlazor/blob/develop/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/DisplayProjection.razor">Display Projection</a> code.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnPointerUp'></a>

## MapView.OnPointerUp Property

Handler delegate for pointer up events on the view. Must take in a [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') and return a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.PointerEvent> OnPointerUp { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
Fires after a mouse button is released, or a display touch ends.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnResize'></a>

## MapView.OnResize Property

Handler delegate for the view's Extent changing.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Events.ResizeEvent> OnResize { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[ResizeEvent](dymaptic.GeoBlazor.Core.Events.ResizeEvent.html 'dymaptic.GeoBlazor.Core.Events.ResizeEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnSpatialReferenceChanged'></a>

## MapView.OnSpatialReferenceChanged Property

Handler delegate for the view's Spatial Reference changing.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference> OnSpatialReferenceChanged { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnViewInitialized'></a>

## MapView.OnViewInitialized Property

Event triggered when the JS view is created, but before the full map is rendered.

```csharp
public Microsoft.AspNetCore.Components.EventCallback OnViewInitialized { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback 'Microsoft.AspNetCore.Components.EventCallback')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.PromptForArcGISKey'></a>

## MapView.PromptForArcGISKey Property

Provides an override for the default behavior of requiring an API key. By setting to "false", all calls to ArcGIS services will trigger a sign-in popup.

```csharp
public System.Nullable<bool> PromptForArcGISKey { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
Setting this to "false" is the same as setting [AllowDefaultEsriLogin](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.AllowDefaultEsriLogin 'dymaptic.GeoBlazor.Core.Components.Views.MapView.AllowDefaultEsriLogin') to "true". This is provided simply for convenience of discovery.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Rotation'></a>

## MapView.Rotation Property

The clockwise rotation of due north in relation to the top of the view in degrees.

```csharp
public double Rotation { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Scale'></a>

## MapView.Scale Property

Represents the map scale at the center of the view.

```csharp
public System.Nullable<double> Scale { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Style'></a>

## MapView.Style Property

Inline css styling attribute

```csharp
public string Style { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.WebMap'></a>

## MapView.WebMap Property

An instance of a [WebMap](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.WebMap 'dymaptic.GeoBlazor.Core.Components.Views.MapView.WebMap') object to display in the view.

```csharp
public dymaptic.GeoBlazor.Core.Components.WebMap? WebMap { get; set; }
```

#### Property Value
[WebMap](dymaptic.GeoBlazor.Core.Components.WebMap.html 'dymaptic.GeoBlazor.Core.Components.WebMap')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Widgets'></a>

## MapView.Widgets Property

The collection of [Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget')s in the view.

```csharp
public System.Collections.Generic.IReadOnlyCollection<dymaptic.GeoBlazor.Core.Components.Widgets.Widget> Widgets { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')[Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyCollection-1 'System.Collections.Generic.IReadOnlyCollection`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Zoom'></a>

## MapView.Zoom Property

Represents the level of detail (LOD) at the center of the view.

```csharp
public System.Nullable<double> Zoom { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.AddGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic)'></a>

## MapView.AddGraphic(Graphic) Method

Adds a [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') to the current view, or to a [GraphicsLayer](dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer').

```csharp
public System.Threading.Tasks.Task AddGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic graphic);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.AddGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic).graphic'></a>

`graphic` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

The [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') to add.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.AddGraphics(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_)'></a>

## MapView.AddGraphics(IEnumerable<Graphic>) Method

Adds a collection of [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')s to the current view

```csharp
public System.Threading.Tasks.Task AddGraphics(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> graphics);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.AddGraphics(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_).graphics'></a>

`graphics` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.AddLayer(dymaptic.GeoBlazor.Core.Components.Layers.Layer,System.Nullable_bool_)'></a>

## MapView.AddLayer(Layer, Nullable<bool>) Method

Adds a layer to the current Map

```csharp
public System.Threading.Tasks.Task AddLayer(dymaptic.GeoBlazor.Core.Components.Layers.Layer layer, System.Nullable<bool> isBasemapLayer=false);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.AddLayer(dymaptic.GeoBlazor.Core.Components.Layers.Layer,System.Nullable_bool_).layer'></a>

`layer` [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

The layer to add

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.AddLayer(dymaptic.GeoBlazor.Core.Components.Layers.Layer,System.Nullable_bool_).isBasemapLayer'></a>

`isBasemapLayer` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

If true, adds the layer as a Basemap

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.ClearGraphics()'></a>

## MapView.ClearGraphics() Method

Clears all graphics from the view.

```csharp
public System.Threading.Tasks.Task ClearGraphics();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.ClosePopup()'></a>

## MapView.ClosePopup() Method

Closes the popup by setting its visible property to false. Users can alternatively close the popup by directly setting the visible property to false.

```csharp
public System.Threading.Tasks.Task ClosePopup();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.DisposeAsync()'></a>

## MapView.DisposeAsync() Method

Implements the `IAsyncDisposable` pattern.

```csharp
public override System.Threading.Tasks.ValueTask DisposeAsync();
```

Implements [DisposeAsync()](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable.DisposeAsync 'System.IAsyncDisposable.DisposeAsync')

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.DrawRouteAndGetDirections(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,string)'></a>

## MapView.DrawRouteAndGetDirections(Symbol, string) Method

A custom method to set up the interaction for clicking a start and end point, and have the view render a driving route. Also returns a set of [Direction](dymaptic.GeoBlazor.Core.Objects.Direction.html 'dymaptic.GeoBlazor.Core.Objects.Direction')s for display.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Objects.Direction[]> DrawRouteAndGetDirections(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol routeSymbol, string routeUrl);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.DrawRouteAndGetDirections(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,string).routeSymbol'></a>

`routeSymbol` [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol')

The [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') used to render the route.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.DrawRouteAndGetDirections(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,string).routeUrl'></a>

`routeUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A routing service url for calculating the route.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Direction](dymaptic.GeoBlazor.Core.Objects.Direction.html 'dymaptic.GeoBlazor.Core.Objects.Direction')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A collection of [Direction](dymaptic.GeoBlazor.Core.Objects.Direction.html 'dymaptic.GeoBlazor.Core.Objects.Direction') steps to follow the route.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.FindPlaces(dymaptic.GeoBlazor.Core.Objects.AddressQuery,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate)'></a>

## MapView.FindPlaces(AddressQuery, Symbol, PopupTemplate) Method

A custom method to run an [AddressQuery](dymaptic.GeoBlazor.Core.Objects.AddressQuery.html 'dymaptic.GeoBlazor.Core.Objects.AddressQuery') against the current view, and display the results.

```csharp
public System.Threading.Tasks.Task FindPlaces(dymaptic.GeoBlazor.Core.Objects.AddressQuery query, dymaptic.GeoBlazor.Core.Components.Symbols.Symbol displaySymbol, dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate popupTemplate);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.FindPlaces(dymaptic.GeoBlazor.Core.Objects.AddressQuery,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate).query'></a>

`query` [AddressQuery](dymaptic.GeoBlazor.Core.Objects.AddressQuery.html 'dymaptic.GeoBlazor.Core.Objects.AddressQuery')

The [AddressQuery](dymaptic.GeoBlazor.Core.Objects.AddressQuery.html 'dymaptic.GeoBlazor.Core.Objects.AddressQuery') to run.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.FindPlaces(dymaptic.GeoBlazor.Core.Objects.AddressQuery,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate).displaySymbol'></a>

`displaySymbol` [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol')

The [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') to use to render the results of the query.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.FindPlaces(dymaptic.GeoBlazor.Core.Objects.AddressQuery,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate).popupTemplate'></a>

`popupTemplate` [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate')

A [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate') for displaying Popups on rendered results.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GetCenter()'></a>

## MapView.GetCenter() Method

Returns the center [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') of the current view extent.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Point?> GetCenter();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GetExtent()'></a>

## MapView.GetExtent() Method

Returns the current [dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent 'dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent') of the view.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Extent?> GetExtent();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GetRotation()'></a>

## MapView.GetRotation() Method

Returns the rotation of the current view.

```csharp
public System.Threading.Tasks.Task<System.Nullable<double>> GetRotation();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GetScale()'></a>

## MapView.GetScale() Method

Returns the scale of the current view.

```csharp
public System.Threading.Tasks.Task<System.Nullable<double>> GetScale();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GetSpatialReference()'></a>

## MapView.GetSpatialReference() Method

Returns the current [dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference 'dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference') of the view.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference?> GetSpatialReference();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GetZoom()'></a>

## MapView.GetZoom() Method

Returns the zoom level of the current view.

```csharp
public System.Threading.Tasks.Task<System.Nullable<double>> GetZoom();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GoTo(dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## MapView.GoTo(Extent) Method

Changes the view [dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent 'dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent') and redraws.

```csharp
public System.Threading.Tasks.Task GoTo(dymaptic.GeoBlazor.Core.Components.Geometries.Extent extent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GoTo(dymaptic.GeoBlazor.Core.Components.Geometries.Extent).extent'></a>

`extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

The new [dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent 'dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent') of the view.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GoTo(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_)'></a>

## MapView.GoTo(IEnumerable<Graphic>) Method

Changes the view [dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent 'dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent') and redraws.

```csharp
public virtual System.Threading.Tasks.Task GoTo(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> graphics);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GoTo(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_).graphics'></a>

`graphics` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')s to zoom to.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.HitTest(dymaptic.GeoBlazor.Core.Components.Geometries.Point,dymaptic.GeoBlazor.Core.Events.HitTestOptions)'></a>

## MapView.HitTest(Point, HitTestOptions) Method

Returns [HitTestResult](dymaptic.GeoBlazor.Core.Events.HitTestResult.html 'dymaptic.GeoBlazor.Core.Events.HitTestResult')s from each layer that intersects the specified screen coordinates. The results are organized as an array of objects containing different result types.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Events.HitTestResult> HitTest(dymaptic.GeoBlazor.Core.Components.Geometries.Point screenPoint, dymaptic.GeoBlazor.Core.Events.HitTestOptions? options=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.HitTest(dymaptic.GeoBlazor.Core.Components.Geometries.Point,dymaptic.GeoBlazor.Core.Events.HitTestOptions).screenPoint'></a>

`screenPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The screen point to check for hits.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.HitTest(dymaptic.GeoBlazor.Core.Components.Geometries.Point,dymaptic.GeoBlazor.Core.Events.HitTestOptions).options'></a>

`options` [HitTestOptions](dymaptic.GeoBlazor.Core.Events.HitTestOptions.html 'dymaptic.GeoBlazor.Core.Events.HitTestOptions')

Options to specify what is included in or excluded from the hitTest.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[HitTestResult](dymaptic.GeoBlazor.Core.Events.HitTestResult.html 'dymaptic.GeoBlazor.Core.Events.HitTestResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.HitTest(dymaptic.GeoBlazor.Core.Events.ClickEvent,dymaptic.GeoBlazor.Core.Events.HitTestOptions)'></a>

## MapView.HitTest(ClickEvent, HitTestOptions) Method

Returns [HitTestResult](dymaptic.GeoBlazor.Core.Events.HitTestResult.html 'dymaptic.GeoBlazor.Core.Events.HitTestResult')s from each layer that intersects the specified screen coordinates. The results are organized as an array of objects containing different result types.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Events.HitTestResult> HitTest(dymaptic.GeoBlazor.Core.Events.ClickEvent clickEvent, dymaptic.GeoBlazor.Core.Events.HitTestOptions? options=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.HitTest(dymaptic.GeoBlazor.Core.Events.ClickEvent,dymaptic.GeoBlazor.Core.Events.HitTestOptions).clickEvent'></a>

`clickEvent` [ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent')

The click event to test for hits.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.HitTest(dymaptic.GeoBlazor.Core.Events.ClickEvent,dymaptic.GeoBlazor.Core.Events.HitTestOptions).options'></a>

`options` [HitTestOptions](dymaptic.GeoBlazor.Core.Events.HitTestOptions.html 'dymaptic.GeoBlazor.Core.Events.HitTestOptions')

Options to specify what is included in or excluded from the hitTest.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[HitTestResult](dymaptic.GeoBlazor.Core.Events.HitTestResult.html 'dymaptic.GeoBlazor.Core.Events.HitTestResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.HitTest(dymaptic.GeoBlazor.Core.Events.PointerEvent,dymaptic.GeoBlazor.Core.Events.HitTestOptions)'></a>

## MapView.HitTest(PointerEvent, HitTestOptions) Method

Returns [HitTestResult](dymaptic.GeoBlazor.Core.Events.HitTestResult.html 'dymaptic.GeoBlazor.Core.Events.HitTestResult')s from each layer that intersects the specified screen coordinates. The results are organized as an array of objects containing different result types.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Events.HitTestResult> HitTest(dymaptic.GeoBlazor.Core.Events.PointerEvent pointerEvent, dymaptic.GeoBlazor.Core.Events.HitTestOptions? options=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.HitTest(dymaptic.GeoBlazor.Core.Events.PointerEvent,dymaptic.GeoBlazor.Core.Events.HitTestOptions).pointerEvent'></a>

`pointerEvent` [PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent')

The pointer event to test for hits.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.HitTest(dymaptic.GeoBlazor.Core.Events.PointerEvent,dymaptic.GeoBlazor.Core.Events.HitTestOptions).options'></a>

`options` [HitTestOptions](dymaptic.GeoBlazor.Core.Events.HitTestOptions.html 'dymaptic.GeoBlazor.Core.Events.HitTestOptions')

Options to specify what is included in or excluded from the hitTest.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[HitTestResult](dymaptic.GeoBlazor.Core.Events.HitTestResult.html 'dymaptic.GeoBlazor.Core.Events.HitTestResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Load()'></a>

## MapView.Load() Method

Manually loads and renders the MapView, if the consumer has also set [LoadOnRender](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.LoadOnRender 'dymaptic.GeoBlazor.Core.Components.Views.MapView.LoadOnRender') to false.  
If [LoadOnRender](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.LoadOnRender 'dymaptic.GeoBlazor.Core.Components.Views.MapView.LoadOnRender') is true, this method will function the same as [Refresh()](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.Refresh() 'dymaptic.GeoBlazor.Core.Components.Views.MapView.Refresh()').

```csharp
public void Load();
```

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptBlur(dymaptic.GeoBlazor.Core.Events.BlurEvent)'></a>

## MapView.OnJavascriptBlur(BlurEvent) Method

JS-Invokable method to return view blur (lost focus) events.

```csharp
public System.Threading.Tasks.Task OnJavascriptBlur(dymaptic.GeoBlazor.Core.Events.BlurEvent blurEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptBlur(dymaptic.GeoBlazor.Core.Events.BlurEvent).blurEvent'></a>

`blurEvent` [BlurEvent](dymaptic.GeoBlazor.Core.Events.BlurEvent.html 'dymaptic.GeoBlazor.Core.Events.BlurEvent')

The [BlurEvent](dymaptic.GeoBlazor.Core.Events.BlurEvent.html 'dymaptic.GeoBlazor.Core.Events.BlurEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptClick(dymaptic.GeoBlazor.Core.Events.ClickEvent)'></a>

## MapView.OnJavascriptClick(ClickEvent) Method

JS-Invokable method to return view clicks.

```csharp
public System.Threading.Tasks.Task OnJavascriptClick(dymaptic.GeoBlazor.Core.Events.ClickEvent clickEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptClick(dymaptic.GeoBlazor.Core.Events.ClickEvent).clickEvent'></a>

`clickEvent` [ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent')

The [ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

### Remarks
Fires after a user clicks on the view. This event emits slightly slower than an immediate-click event to make sure that a double-click event isn't triggered instead. The immediate-click event can be used for responding to a click event without delay.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptDoubleClick(dymaptic.GeoBlazor.Core.Events.ClickEvent)'></a>

## MapView.OnJavascriptDoubleClick(ClickEvent) Method

JS-Invokable method to return view double-clicks.

```csharp
public System.Threading.Tasks.Task OnJavascriptDoubleClick(dymaptic.GeoBlazor.Core.Events.ClickEvent clickEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptDoubleClick(dymaptic.GeoBlazor.Core.Events.ClickEvent).clickEvent'></a>

`clickEvent` [ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent')

The [ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptDrag(dymaptic.GeoBlazor.Core.Events.DragEvent)'></a>

## MapView.OnJavascriptDrag(DragEvent) Method

JS-Invokable method to return view drag events.

```csharp
public System.Threading.Tasks.Task OnJavascriptDrag(dymaptic.GeoBlazor.Core.Events.DragEvent dragEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptDrag(dymaptic.GeoBlazor.Core.Events.DragEvent).dragEvent'></a>

`dragEvent` [DragEvent](dymaptic.GeoBlazor.Core.Events.DragEvent.html 'dymaptic.GeoBlazor.Core.Events.DragEvent')

The [DragEvent](dymaptic.GeoBlazor.Core.Events.DragEvent.html 'dymaptic.GeoBlazor.Core.Events.DragEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptError(dymaptic.GeoBlazor.Core.Exceptions.JavascriptError)'></a>

## MapView.OnJavascriptError(JavascriptError) Method

Surfaces JavaScript errors to the .NET Code for debugging.

```csharp
public void OnJavascriptError(dymaptic.GeoBlazor.Core.Exceptions.JavascriptError error);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptError(dymaptic.GeoBlazor.Core.Exceptions.JavascriptError).error'></a>

`error` [JavascriptError](dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptError')

The original Javascript error.

#### Exceptions

[JavascriptException](dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptException')  
Wraps the JS Error and throws a .NET Exception.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_)'></a>

## MapView.OnJavascriptExtentChanged(Extent, Point, double, double, Nullable<double>, Nullable<double>) Method

JS-Invokable method to return when the map view Extent changes.

```csharp
public virtual System.Threading.Tasks.Task OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent extent, dymaptic.GeoBlazor.Core.Components.Geometries.Point? center, double zoom, double scale, System.Nullable<double> rotation=null, System.Nullable<double> tilt=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).extent'></a>

`extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).center'></a>

`center` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).zoom'></a>

`zoom` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).scale'></a>

`scale` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).rotation'></a>

`rotation` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).tilt'></a>

`tilt` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptFocus(dymaptic.GeoBlazor.Core.Events.FocusEvent)'></a>

## MapView.OnJavascriptFocus(FocusEvent) Method

JS-Invokable method to return view focus events.

```csharp
public System.Threading.Tasks.Task OnJavascriptFocus(dymaptic.GeoBlazor.Core.Events.FocusEvent focusEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptFocus(dymaptic.GeoBlazor.Core.Events.FocusEvent).focusEvent'></a>

`focusEvent` [FocusEvent](dymaptic.GeoBlazor.Core.Events.FocusEvent.html 'dymaptic.GeoBlazor.Core.Events.FocusEvent')

The [FocusEvent](dymaptic.GeoBlazor.Core.Events.FocusEvent.html 'dymaptic.GeoBlazor.Core.Events.FocusEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptHitTestResult(System.Guid,string)'></a>

## MapView.OnJavascriptHitTestResult(Guid, string) Method

The callback method for returning a chunk of data from a Blazor Server hit test.

```csharp
public void OnJavascriptHitTestResult(System.Guid eventId, string chunk);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptHitTestResult(System.Guid,string).eventId'></a>

`eventId` [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid')

The hit test event id.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptHitTestResult(System.Guid,string).chunk'></a>

`chunk` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A chunk of hit test data, to be combined with other data before deserialization.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptHold(dymaptic.GeoBlazor.Core.Events.ClickEvent)'></a>

## MapView.OnJavascriptHold(ClickEvent) Method

JS-Invokable method to return view hold events.

```csharp
public System.Threading.Tasks.Task OnJavascriptHold(dymaptic.GeoBlazor.Core.Events.ClickEvent holdEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptHold(dymaptic.GeoBlazor.Core.Events.ClickEvent).holdEvent'></a>

`holdEvent` [ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent')

The [ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptImmediateClick(dymaptic.GeoBlazor.Core.Events.ClickEvent)'></a>

## MapView.OnJavascriptImmediateClick(ClickEvent) Method

JS-Invokable method to return view immediate-clicks.

```csharp
public System.Threading.Tasks.Task OnJavascriptImmediateClick(dymaptic.GeoBlazor.Core.Events.ClickEvent clickEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptImmediateClick(dymaptic.GeoBlazor.Core.Events.ClickEvent).clickEvent'></a>

`clickEvent` [ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent')

The [ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptImmediateDoubleClick(dymaptic.GeoBlazor.Core.Events.ClickEvent)'></a>

## MapView.OnJavascriptImmediateDoubleClick(ClickEvent) Method

JS-Invokable method to return view immediate-double-clicks.

```csharp
public System.Threading.Tasks.Task OnJavascriptImmediateDoubleClick(dymaptic.GeoBlazor.Core.Events.ClickEvent clickEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptImmediateDoubleClick(dymaptic.GeoBlazor.Core.Events.ClickEvent).clickEvent'></a>

`clickEvent` [ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent')

The [ClickEvent](dymaptic.GeoBlazor.Core.Events.ClickEvent.html 'dymaptic.GeoBlazor.Core.Events.ClickEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptKeyDown(dymaptic.GeoBlazor.Core.Events.KeyDownEvent)'></a>

## MapView.OnJavascriptKeyDown(KeyDownEvent) Method

JS-Invokable method to return view key-down events.

```csharp
public System.Threading.Tasks.Task OnJavascriptKeyDown(dymaptic.GeoBlazor.Core.Events.KeyDownEvent keyDownEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptKeyDown(dymaptic.GeoBlazor.Core.Events.KeyDownEvent).keyDownEvent'></a>

`keyDownEvent` [KeyDownEvent](dymaptic.GeoBlazor.Core.Events.KeyDownEvent.html 'dymaptic.GeoBlazor.Core.Events.KeyDownEvent')

The [KeyDownEvent](dymaptic.GeoBlazor.Core.Events.KeyDownEvent.html 'dymaptic.GeoBlazor.Core.Events.KeyDownEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptKeyUp(dymaptic.GeoBlazor.Core.Events.KeyUpEvent)'></a>

## MapView.OnJavascriptKeyUp(KeyUpEvent) Method

JS-Invokable method to return view key-up events.

```csharp
public System.Threading.Tasks.Task OnJavascriptKeyUp(dymaptic.GeoBlazor.Core.Events.KeyUpEvent keyUpEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptKeyUp(dymaptic.GeoBlazor.Core.Events.KeyUpEvent).keyUpEvent'></a>

`keyUpEvent` [KeyUpEvent](dymaptic.GeoBlazor.Core.Events.KeyUpEvent.html 'dymaptic.GeoBlazor.Core.Events.KeyUpEvent')

The [KeyUpEvent](dymaptic.GeoBlazor.Core.Events.KeyUpEvent.html 'dymaptic.GeoBlazor.Core.Events.KeyUpEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerCreateChunk(string,string,int)'></a>

## MapView.OnJavascriptLayerCreateChunk(string, string, int) Method

JS-Invokable method for internal use only.

```csharp
public void OnJavascriptLayerCreateChunk(string layerUid, string chunk, int chunkIndex);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerCreateChunk(string,string,int).layerUid'></a>

`layerUid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerCreateChunk(string,string,int).chunk'></a>

`chunk` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerCreateChunk(string,string,int).chunkIndex'></a>

`chunkIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent)'></a>

## MapView.OnJavascriptLayerViewCreate(LayerViewCreateInternalEvent) Method

JS-Invokable method to return when a layer view is created.

```csharp
public System.Threading.Tasks.Task OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent layerViewCreateEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent).layerViewCreateEvent'></a>

`layerViewCreateEvent` [LayerViewCreateInternalEvent](dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent.html 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateInternalEvent')

The new [LayerViewCreateEvent](dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent.html 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateEvent')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateChunk(string,string,int)'></a>

## MapView.OnJavascriptLayerViewCreateChunk(string, string, int) Method

JS-Invokable method for internal use only.

```csharp
public void OnJavascriptLayerViewCreateChunk(string layerUid, string chunk, int chunkIndex);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateChunk(string,string,int).layerUid'></a>

`layerUid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateChunk(string,string,int).chunk'></a>

`chunk` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateChunk(string,string,int).chunkIndex'></a>

`chunkIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateComplete(System.Nullable_System.Guid_,string,Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference)'></a>

## MapView.OnJavascriptLayerViewCreateComplete(Nullable<Guid>, string, IJSObjectReference, IJSObjectReference) Method

JS-Invokable method for internal use only.

```csharp
public System.Threading.Tasks.Task OnJavascriptLayerViewCreateComplete(System.Nullable<System.Guid> geoBlazorLayerId, string layerUid, Microsoft.JSInterop.IJSObjectReference layerRef, Microsoft.JSInterop.IJSObjectReference layerViewRef);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateComplete(System.Nullable_System.Guid_,string,Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference).geoBlazorLayerId'></a>

`geoBlazorLayerId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateComplete(System.Nullable_System.Guid_,string,Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference).layerUid'></a>

`layerUid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateComplete(System.Nullable_System.Guid_,string,Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference).layerRef'></a>

`layerRef` [Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateComplete(System.Nullable_System.Guid_,string,Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference).layerViewRef'></a>

`layerViewRef` [Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateError(dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent)'></a>

## MapView.OnJavascriptLayerViewCreateError(LayerViewCreateErrorEvent) Method

JS-Invokable method to return when a layer view is destroyed.

```csharp
public System.Threading.Tasks.Task OnJavascriptLayerViewCreateError(dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent errorEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateError(dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent).errorEvent'></a>

`errorEvent` [LayerViewCreateErrorEvent](dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent.html 'dymaptic.GeoBlazor.Core.Events.LayerViewCreateErrorEvent')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewDestroy(dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent)'></a>

## MapView.OnJavascriptLayerViewDestroy(LayerViewDestroyEvent) Method

JS-Invokable method to return when a layer view is destroyed.

```csharp
public System.Threading.Tasks.Task OnJavascriptLayerViewDestroy(dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent layerViewDestroyEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewDestroy(dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent).layerViewDestroyEvent'></a>

`layerViewDestroyEvent` [LayerViewDestroyEvent](dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent.html 'dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent')

The destroyed [LayerViewDestroyEvent](dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent.html 'dymaptic.GeoBlazor.Core.Events.LayerViewDestroyEvent')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptMouseWheel(dymaptic.GeoBlazor.Core.Events.MouseWheelEvent)'></a>

## MapView.OnJavascriptMouseWheel(MouseWheelEvent) Method

JS-Invokable method to return when the mouse wheel is scrolled.

```csharp
public System.Threading.Tasks.Task OnJavascriptMouseWheel(dymaptic.GeoBlazor.Core.Events.MouseWheelEvent mouseWheelEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptMouseWheel(dymaptic.GeoBlazor.Core.Events.MouseWheelEvent).mouseWheelEvent'></a>

`mouseWheelEvent` [MouseWheelEvent](dymaptic.GeoBlazor.Core.Events.MouseWheelEvent.html 'dymaptic.GeoBlazor.Core.Events.MouseWheelEvent')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerDown(dymaptic.GeoBlazor.Core.Events.PointerEvent)'></a>

## MapView.OnJavascriptPointerDown(PointerEvent) Method

JS-Invokable method to return view pointer down events.

```csharp
public System.Threading.Tasks.Task OnJavascriptPointerDown(dymaptic.GeoBlazor.Core.Events.PointerEvent pointerEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerDown(dymaptic.GeoBlazor.Core.Events.PointerEvent).pointerEvent'></a>

`pointerEvent` [PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent')

The [PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerEnter(dymaptic.GeoBlazor.Core.Events.PointerEvent)'></a>

## MapView.OnJavascriptPointerEnter(PointerEvent) Method

JS-Invokable method to return view pointer enter events.

```csharp
public System.Threading.Tasks.Task OnJavascriptPointerEnter(dymaptic.GeoBlazor.Core.Events.PointerEvent pointerEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerEnter(dymaptic.GeoBlazor.Core.Events.PointerEvent).pointerEvent'></a>

`pointerEvent` [PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent')

The [PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerLeave(dymaptic.GeoBlazor.Core.Events.PointerEvent)'></a>

## MapView.OnJavascriptPointerLeave(PointerEvent) Method

JS-Invokable method to return view pointer leave events.

```csharp
public System.Threading.Tasks.Task OnJavascriptPointerLeave(dymaptic.GeoBlazor.Core.Events.PointerEvent pointerEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerLeave(dymaptic.GeoBlazor.Core.Events.PointerEvent).pointerEvent'></a>

`pointerEvent` [PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent')

The [PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerMove(dymaptic.GeoBlazor.Core.Events.PointerEvent)'></a>

## MapView.OnJavascriptPointerMove(PointerEvent) Method

JS-Invokable method to return view pointer movement.

```csharp
public System.Threading.Tasks.Task OnJavascriptPointerMove(dymaptic.GeoBlazor.Core.Events.PointerEvent pointerEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerMove(dymaptic.GeoBlazor.Core.Events.PointerEvent).pointerEvent'></a>

`pointerEvent` [PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent')

The [PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerUp(dymaptic.GeoBlazor.Core.Events.PointerEvent)'></a>

## MapView.OnJavascriptPointerUp(PointerEvent) Method

JS-Invokable method to return view pointer up events.

```csharp
public System.Threading.Tasks.Task OnJavascriptPointerUp(dymaptic.GeoBlazor.Core.Events.PointerEvent pointerEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerUp(dymaptic.GeoBlazor.Core.Events.PointerEvent).pointerEvent'></a>

`pointerEvent` [PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent')

The [PointerEvent](dymaptic.GeoBlazor.Core.Events.PointerEvent.html 'dymaptic.GeoBlazor.Core.Events.PointerEvent') return meta object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptResize(dymaptic.GeoBlazor.Core.Events.ResizeEvent)'></a>

## MapView.OnJavascriptResize(ResizeEvent) Method

JS-Invokable method to return when the map view is resized in the window.

```csharp
public System.Threading.Tasks.Task OnJavascriptResize(dymaptic.GeoBlazor.Core.Events.ResizeEvent resizeEvent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptResize(dymaptic.GeoBlazor.Core.Events.ResizeEvent).resizeEvent'></a>

`resizeEvent` [ResizeEvent](dymaptic.GeoBlazor.Core.Events.ResizeEvent.html 'dymaptic.GeoBlazor.Core.Events.ResizeEvent')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptSpatialReferenceChanged(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference)'></a>

## MapView.OnJavascriptSpatialReferenceChanged(SpatialReference) Method

JS-Invokable method to return when the map view Spatial Reference changes.

```csharp
public System.Threading.Tasks.Task OnJavascriptSpatialReferenceChanged(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference spatialReference);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptSpatialReferenceChanged(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).spatialReference'></a>

`spatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

The new [dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference 'dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJsViewInitialized()'></a>

## MapView.OnJsViewInitialized() Method

JS-Invokable callback that signifies when the view is created but not yet fully rendered.

```csharp
public System.Threading.Tasks.Task OnJsViewInitialized();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnViewRendered()'></a>

## MapView.OnViewRendered() Method

JS-Invokable method to return when the map view is fully rendered.

```csharp
public System.Threading.Tasks.Task OnViewRendered();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OpenPopup(dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions)'></a>

## MapView.OpenPopup(PopupOpenOptions) Method

Opens the popup at the given location with content defined either explicitly with content or driven from the PopupTemplate of input features. This method sets the popup's visible property to true. Users can alternatively open the popup by directly setting the visible property to true.

```csharp
public System.Threading.Tasks.Task OpenPopup(dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions? options=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OpenPopup(dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions).options'></a>

`options` [PopupOpenOptions](dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions')

Defines the location and content of the popup when opened.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query,dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate)'></a>

## MapView.QueryFeatures(Query, FeatureLayer, Symbol, PopupTemplate) Method

A custom method to query a provided [FeatureLayer](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer') on the current map view, and display the results.

```csharp
public System.Threading.Tasks.Task QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query query, dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer featureLayer, dymaptic.GeoBlazor.Core.Components.Symbols.Symbol displaySymbol, dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate popupTemplate);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query,dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate).query'></a>

`query` [Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query')

The [Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query') to run.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query,dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate).featureLayer'></a>

`featureLayer` [FeatureLayer](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer')

The [FeatureLayer](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer') to query against.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query,dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate).displaySymbol'></a>

`displaySymbol` [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol')

The [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') to use to render the results of the query.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.QueryFeatures(dymaptic.GeoBlazor.Core.Objects.Query,dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate).popupTemplate'></a>

`popupTemplate` [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate')

A [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate') for displaying Popups on rendered results.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Refresh()'></a>

## MapView.Refresh() Method

Provides a way to externally call `StateHasChanged` on the component.

```csharp
public override void Refresh();
```

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## MapView.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RemoveGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic)'></a>

## MapView.RemoveGraphic(Graphic) Method

Removes a graphic from the current view.

```csharp
public System.Threading.Tasks.Task RemoveGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic graphic);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RemoveGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic).graphic'></a>

`graphic` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

The [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') to remove.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RemoveGraphics(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_)'></a>

## MapView.RemoveGraphics(IEnumerable<Graphic>) Method

Removes a collection of graphics from the current view.

```csharp
public System.Threading.Tasks.Task RemoveGraphics(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> graphics);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RemoveGraphics(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_).graphics'></a>

`graphics` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')s to remove.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RemoveLayer(dymaptic.GeoBlazor.Core.Components.Layers.Layer,System.Nullable_bool_)'></a>

## MapView.RemoveLayer(Layer, Nullable<bool>) Method

Removes a layer from the current Map

```csharp
public System.Threading.Tasks.Task RemoveLayer(dymaptic.GeoBlazor.Core.Components.Layers.Layer layer, System.Nullable<bool> isBasemapLayer=false);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RemoveLayer(dymaptic.GeoBlazor.Core.Components.Layers.Layer,System.Nullable_bool_).layer'></a>

`layer` [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

The layer to remove

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RemoveLayer(dymaptic.GeoBlazor.Core.Components.Layers.Layer,System.Nullable_bool_).isBasemapLayer'></a>

`isBasemapLayer` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

If true, removes the layer as a Basemap

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetCenter(dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## MapView.SetCenter(Point) Method

Sets the center [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') of the current view.

```csharp
public virtual System.Threading.Tasks.Task SetCenter(dymaptic.GeoBlazor.Core.Components.Geometries.Point point);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetCenter(dymaptic.GeoBlazor.Core.Components.Geometries.Point).point'></a>

`point` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetConstraints(dymaptic.GeoBlazor.Core.Components.Constraints)'></a>

## MapView.SetConstraints(Constraints) Method

Sets the [dymaptic.GeoBlazor.Core.Components.Views.MapView.Constraints](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Views.MapView.Constraints 'dymaptic.GeoBlazor.Core.Components.Views.MapView.Constraints') of the view.

```csharp
public System.Threading.Tasks.Task SetConstraints(dymaptic.GeoBlazor.Core.Components.Constraints constraints);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetConstraints(dymaptic.GeoBlazor.Core.Components.Constraints).constraints'></a>

`constraints` [Constraints](dymaptic.GeoBlazor.Core.Components.Constraints.html 'dymaptic.GeoBlazor.Core.Components.Constraints')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetExtent(dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## MapView.SetExtent(Extent) Method

Sets the [dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent 'dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent') of the view.

```csharp
public virtual System.Threading.Tasks.Task SetExtent(dymaptic.GeoBlazor.Core.Components.Geometries.Extent extent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetExtent(dymaptic.GeoBlazor.Core.Components.Geometries.Extent).extent'></a>

`extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetHighlightOptions(dymaptic.GeoBlazor.Core.Objects.HighlightOptions)'></a>

## MapView.SetHighlightOptions(HighlightOptions) Method

Sets the [dymaptic.GeoBlazor.Core.Components.Views.MapView.HighlightOptions](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Views.MapView.HighlightOptions 'dymaptic.GeoBlazor.Core.Components.Views.MapView.HighlightOptions') of the view.

```csharp
public System.Threading.Tasks.Task SetHighlightOptions(dymaptic.GeoBlazor.Core.Objects.HighlightOptions highlightOptions);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetHighlightOptions(dymaptic.GeoBlazor.Core.Objects.HighlightOptions).highlightOptions'></a>

`highlightOptions` [HighlightOptions](dymaptic.GeoBlazor.Core.Objects.HighlightOptions.html 'dymaptic.GeoBlazor.Core.Objects.HighlightOptions')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetRotation(double)'></a>

## MapView.SetRotation(double) Method

Sets the rotation of the current view.

```csharp
public System.Threading.Tasks.Task SetRotation(double rotation);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetRotation(double).rotation'></a>

`rotation` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetScale(double)'></a>

## MapView.SetScale(double) Method

Sets the scale of the current view.

```csharp
public virtual System.Threading.Tasks.Task SetScale(double scale);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetScale(double).scale'></a>

`scale` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetSpatialReference(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference)'></a>

## MapView.SetSpatialReference(SpatialReference) Method

Sets the [dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference 'dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference') of the view.

```csharp
public System.Threading.Tasks.Task SetSpatialReference(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference spatialReference);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetSpatialReference(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).spatialReference'></a>

`spatialReference` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetZoom(double)'></a>

## MapView.SetZoom(double) Method

Sets the zoom level of the current view.

```csharp
public virtual System.Threading.Tasks.Task SetZoom(double zoom);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SetZoom(double).zoom'></a>

`zoom` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.ShowPopup(dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate,dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## MapView.ShowPopup(PopupTemplate, Point) Method

Opens a Popup on a particular [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') of the map view.

```csharp
public System.Threading.Tasks.Task ShowPopup(dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate template, dymaptic.GeoBlazor.Core.Components.Geometries.Point location);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.ShowPopup(dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate,dymaptic.GeoBlazor.Core.Components.Geometries.Point).template'></a>

`template` [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate')

The [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate') defining the Popup.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.ShowPopup(dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate,dymaptic.GeoBlazor.Core.Components.Geometries.Point).location'></a>

`location` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') on which to display the Popup.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.ShowPopupWithGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,dymaptic.GeoBlazor.Core.Components.Widgets.PopupOptions)'></a>

## MapView.ShowPopupWithGraphic(Graphic, PopupOptions) Method

Opens a Popup with a custom [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') on a particular [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') of the map view.

```csharp
public System.Threading.Tasks.Task ShowPopupWithGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic graphic, dymaptic.GeoBlazor.Core.Components.Widgets.PopupOptions options);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.ShowPopupWithGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,dymaptic.GeoBlazor.Core.Components.Widgets.PopupOptions).graphic'></a>

`graphic` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

The [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') to display in the Popup

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.ShowPopupWithGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,dymaptic.GeoBlazor.Core.Components.Widgets.PopupOptions).options'></a>

`options` [PopupOptions](dymaptic.GeoBlazor.Core.Components.Widgets.PopupOptions.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupOptions')

A set of [PopupOptions](dymaptic.GeoBlazor.Core.Components.Widgets.PopupOptions.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupOptions') that define the position and visible elements of the Popup.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SolveServiceArea(string,double[],dymaptic.GeoBlazor.Core.Components.Symbols.Symbol)'></a>

## MapView.SolveServiceArea(string, double[], Symbol) Method

A custom method to find and display Service Areas around a given point.

```csharp
public System.Threading.Tasks.Task SolveServiceArea(string serviceAreaUrl, double[] driveTimeCutOffs, dymaptic.GeoBlazor.Core.Components.Symbols.Symbol serviceAreaSymbol);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SolveServiceArea(string,double[],dymaptic.GeoBlazor.Core.Components.Symbols.Symbol).serviceAreaUrl'></a>

`serviceAreaUrl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A url for a Service Area rest service.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SolveServiceArea(string,double[],dymaptic.GeoBlazor.Core.Components.Symbols.Symbol).driveTimeCutOffs'></a>

`driveTimeCutOffs` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

A collection of drivable distances, calculated in minutes

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SolveServiceArea(string,double[],dymaptic.GeoBlazor.Core.Components.Symbols.Symbol).serviceAreaSymbol'></a>

`serviceAreaSymbol` [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol')

The [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') used to render the service areas.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## MapView.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.ValidateRequiredChildren()'></a>

## MapView.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components
