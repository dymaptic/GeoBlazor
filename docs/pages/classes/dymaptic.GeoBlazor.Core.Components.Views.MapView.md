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
<a target="_blank" href="https://blazor.dymaptic.com/navigation">Sample - Navigation</a>
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.AllowDefaultEsriLogin'></a>

## MapView.AllowDefaultEsriLogin Property

Allows maps to be rendered without an Api or OAuth Token, which will trigger a default esri login popup.

```csharp
public System.Nullable<bool> AllowDefaultEsriLogin { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

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

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Constraints'></a>

## MapView.Constraints Property

Specifies constraints to scale, zoom, and rotation that may be applied to the MapView.

```csharp
public dymaptic.GeoBlazor.Core.Components.Constraints? Constraints { get; set; }
```

#### Property Value
[Constraints](dymaptic.GeoBlazor.Core.Components.Constraints.html 'dymaptic.GeoBlazor.Core.Components.Constraints')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.ErrorMessage'></a>

## MapView.ErrorMessage Property

Surfaces errors to the UI for easy debugging of issues.

```csharp
public string? ErrorMessage { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.EventRateLimitInMilliseconds'></a>

## MapView.EventRateLimitInMilliseconds Property

Set this parameter to limit the rate at which recurring events (pointer-move, drag, etc.) are returned.

```csharp
public System.Nullable<int> EventRateLimitInMilliseconds { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent'></a>

## MapView.Extent Property

The extent represents the visible portion of a map within the view as an instance of Extent.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Extent? Extent { get; set; }
```

#### Property Value
[Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Graphics'></a>

## MapView.Graphics Property

The collection of [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')s in the view. These are directly on the view itself, not in a [GraphicsLayer](dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer').

```csharp
public System.Collections.Generic.List<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> Graphics { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.JsRuntime'></a>

## MapView.JsRuntime Property

Represents an instance of a JavaScript runtime to which calls may be dispatched.

```csharp
public Microsoft.JSInterop.IJSRuntime JsRuntime { get; set; }
```

#### Property Value
[Microsoft.JSInterop.IJSRuntime](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSRuntime 'Microsoft.JSInterop.IJSRuntime')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Latitude'></a>

## MapView.Latitude Property

The Latitude for the Center point of the view

```csharp
public double Latitude { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Longitude'></a>

## MapView.Longitude Property

The Longitude for the Center point of the view

```csharp
public double Longitude { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

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
public Microsoft.AspNetCore.Components.EventCallback OnBlur { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback 'Microsoft.AspNetCore.Components.EventCallback')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnClick'></a>

## MapView.OnClick Property

Handler delegate for click events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Geometries.Point> OnClick { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnClickAsyncHandler'></a>

## MapView.OnClickAsyncHandler Property

Handler delegate for click events on the view. Must take in a [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') and return a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

```csharp
public System.Func<dymaptic.GeoBlazor.Core.Components.Geometries.Point,System.Threading.Tasks.Task>? OnClickAsyncHandler { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnDoubleClick'></a>

## MapView.OnDoubleClick Property

Handler delegate for double-click events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Geometries.Point> OnDoubleClick { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnDrag'></a>

## MapView.OnDrag Property

Handler delegate for pointer drag events on the view, returns a [DragResult](dymaptic.GeoBlazor.Core.Objects.DragResult.html 'dymaptic.GeoBlazor.Core.Objects.DragResult').

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Objects.DragResult> OnDrag { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[DragResult](dymaptic.GeoBlazor.Core.Objects.DragResult.html 'dymaptic.GeoBlazor.Core.Objects.DragResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

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
public Microsoft.AspNetCore.Components.EventCallback OnFocus { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback 'Microsoft.AspNetCore.Components.EventCallback')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnHold'></a>

## MapView.OnHold Property

Handler delegate for hold events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Geometries.Point> OnHold { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnImmediateClick'></a>

## MapView.OnImmediateClick Property

Handler delegate for immediate-click events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Geometries.Point> OnImmediateClick { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnImmediateDoubleClick'></a>

## MapView.OnImmediateDoubleClick Property

Handler delegate for immediate-double-click events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Geometries.Point> OnImmediateDoubleClick { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

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

Handler delegate for key-down events on the view. Parameter is the Key value that was pressed, according to the <a href="https://developer.mozilla.org/en-US/docs/Web/API/UI_Events/Keyboard_event_key_values".htmlN Full List of Key Values</a>.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<string> OnKeyDown { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
Fires after a keyboard key is pressed.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnKeyUp'></a>

## MapView.OnKeyUp Property

Handler delegate for key-up events on the view. Parameter is the Key value that was pressed, according to the <a href="https://developer.mozilla.org/en-US/docs/Web/API/UI_Events/Keyboard_event_key_values".htmlN Full List of Key Values</a>.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<string> OnKeyUp { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
Fires after a keyboard key is released.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnLayerViewCreate'></a>

## MapView.OnLayerViewCreate Property

Fires after each layer in the map has a corresponding LayerView created and rendered in the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Layers.LayerView> OnLayerViewCreate { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnLayerViewCreateError'></a>

## MapView.OnLayerViewCreateError Property

Fires after a LayerView is destroyed and is no longer rendered in the view. This happens for example when a layer is removed from the map of the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult> OnLayerViewCreateError { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[LayerViewCreateErrorResult](dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult.html 'dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnLayerViewDestroy'></a>

## MapView.OnLayerViewDestroy Property

Fires after a LayerView is destroyed and is no longer rendered in the view. This happens for example when a layer is removed from the map of the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Layers.LayerView> OnLayerViewDestroy { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnMapRendered'></a>

## MapView.OnMapRendered Property

Handler delegate for when the map view is fully rendered. Must return a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

```csharp
public Microsoft.AspNetCore.Components.EventCallback OnMapRendered { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback 'Microsoft.AspNetCore.Components.EventCallback')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnMapRenderedHandler'></a>

## MapView.OnMapRenderedHandler Property

Handler delegate for when the map view is fully rendered. Must return a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

```csharp
public System.Func<System.Threading.Tasks.Task>? OnMapRenderedHandler { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnMouseWheel'></a>

## MapView.OnMouseWheel Property

Handler delegate for the view's Extent changing.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Objects.MouseWheelResult> OnMouseWheel { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[MouseWheelResult](dymaptic.GeoBlazor.Core.Objects.MouseWheelResult.html 'dymaptic.GeoBlazor.Core.Objects.MouseWheelResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnPointerDown'></a>

## MapView.OnPointerDown Property

Handler delegate for pointer down events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Geometries.Point> OnPointerDown { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
Fires after a mouse button is pressed, or a finger touches the display.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnPointerEnter'></a>

## MapView.OnPointerEnter Property

Handler delegate for pointer enter events on the view.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Geometries.Point> OnPointerEnter { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
Fires after a mouse cursor enters the view, or a display touch begins.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnPointerLeave'></a>

## MapView.OnPointerLeave Property

Handler delegate for pointer leave events on the view. Must take in a [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') and return a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Geometries.Point> OnPointerLeave { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
Fires after a mouse cursor leaves the view, or a display touch ends.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnPointerMove'></a>

## MapView.OnPointerMove Property

Handler delegate for point move events on the view. Must take in a [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') and return a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Geometries.Point> OnPointerMove { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
The real-time nature of this handler make it a challenge to use continuously over SignalR in Blazor Server.  
In this scenario, you should write a custom JavaScript handler instead.  
See <a target="_blank" href="https://github.com/dymaptic/GeoBlazor/blob/develop/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/DisplayProjection.razor">Display Projection</a> code.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnPointerMoveHandler'></a>

## MapView.OnPointerMoveHandler Property

Handler delegate for point move events on the view. Must take in a [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') and return a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

```csharp
public System.Func<dymaptic.GeoBlazor.Core.Components.Geometries.Point,System.Threading.Tasks.Task>? OnPointerMoveHandler { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

### Remarks
Fires after the mouse or a finger on the display moves.  
The real-time nature of this handler make it a challenge to use continuously over SignalR in Blazor Server.  
In this scenario, you should write a custom JavaScript handler instead.  
See <a target="_blank" href="https://github.com/dymaptic/GeoBlazor/blob/develop/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/DisplayProjection.razor">Display Projection</a> code.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnPointerUp'></a>

## MapView.OnPointerUp Property

Handler delegate for pointer up events on the view. Must take in a [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') and return a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Geometries.Point> OnPointerUp { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

### Remarks
Fires after a mouse button is released, or a display touch ends.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnResize'></a>

## MapView.OnResize Property

Handler delegate for the view's Extent changing.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Objects.ResizeResult> OnResize { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[ResizeResult](dymaptic.GeoBlazor.Core.Objects.ResizeResult.html 'dymaptic.GeoBlazor.Core.Objects.ResizeResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnSpatialReferenceChanged'></a>

## MapView.OnSpatialReferenceChanged Property

Handler delegate for the view's Spatial Reference changing.

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference> OnSpatialReferenceChanged { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnSpatialReferenceChangedHandler'></a>

## MapView.OnSpatialReferenceChangedHandler Property

Handler delegate for the view's Spatial Reference changing.  
Must take in a [SpatialReference](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference 'dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference') and return a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

```csharp
public System.Func<dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,System.Threading.Tasks.Task>? OnSpatialReferenceChangedHandler { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

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

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference'></a>

## MapView.SpatialReference Property

The [SpatialReference](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference 'dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference') of the view.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? SpatialReference { get; set; }
```

#### Property Value
[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

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
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.Widgets.Widget> Widgets { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.Zoom'></a>

## MapView.Zoom Property

Represents the level of detail (LOD) at the center of the view.

```csharp
public double Zoom { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.AddGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,System.Nullable_int_)'></a>

## MapView.AddGraphic(Graphic, Nullable<int>) Method

Adds a [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') to the current view, or to a [GraphicsLayer](dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer').

```csharp
public System.Threading.Tasks.Task AddGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic graphic, System.Nullable<int> layerIndex=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.AddGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,System.Nullable_int_).graphic'></a>

`graphic` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

The [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') to add.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.AddGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,System.Nullable_int_).layerIndex'></a>

`layerIndex` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

An optional index, that determines which [GraphicsLayer](dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer') to add the graphic to. If omitted, the graphic will be placed directly on the view.

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

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GetAllGraphics(System.Nullable_int_)'></a>

## MapView.GetAllGraphics(Nullable<int>) Method

Returns all graphics for the view, or for a particular [GraphicsLayer](dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer').

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Layers.Graphic[]> GetAllGraphics(System.Nullable<int> layerIndex);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GetAllGraphics(System.Nullable_int_).layerIndex'></a>

`layerIndex` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Optional [GraphicsLayer](dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer') index. If not provided, this will return the graphics from the view itself.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
A collection of [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')s.

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

Returns the current [Extent](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent 'dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent') of the view.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Extent?> GetExtent();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GetSpatialReference()'></a>

## MapView.GetSpatialReference() Method

Returns the current [SpatialReference](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference 'dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference') of the view.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference?> GetSpatialReference();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GoTo(dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## MapView.GoTo(Extent) Method

Changes the view [Extent](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent 'dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent') and redraws.

```csharp
public System.Threading.Tasks.Task GoTo(dymaptic.GeoBlazor.Core.Components.Geometries.Extent extent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.GoTo(dymaptic.GeoBlazor.Core.Components.Geometries.Extent).extent'></a>

`extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

The new [Extent](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent 'dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent') of the view.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptBlur()'></a>

## MapView.OnJavascriptBlur() Method

JS-Invokable method to return view blur (lost focus) events.

```csharp
public System.Threading.Tasks.Task OnJavascriptBlur();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptClick(dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## MapView.OnJavascriptClick(Point) Method

JS-Invokable method to return view clicks.

```csharp
public System.Threading.Tasks.Task OnJavascriptClick(dymaptic.GeoBlazor.Core.Components.Geometries.Point mapPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptClick(dymaptic.GeoBlazor.Core.Components.Geometries.Point).mapPoint'></a>

`mapPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') that was clicked.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptDoubleClick(dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## MapView.OnJavascriptDoubleClick(Point) Method

JS-Invokable method to return view double-clicks.

```csharp
public System.Threading.Tasks.Task OnJavascriptDoubleClick(dymaptic.GeoBlazor.Core.Components.Geometries.Point mapPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptDoubleClick(dymaptic.GeoBlazor.Core.Components.Geometries.Point).mapPoint'></a>

`mapPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') that was double-clicked.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptDrag(string,dymaptic.GeoBlazor.Core.Components.Geometries.Point,dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## MapView.OnJavascriptDrag(string, Point, Point) Method

JS-Invokable method to return view drag events.

```csharp
public System.Threading.Tasks.Task OnJavascriptDrag(string action, dymaptic.GeoBlazor.Core.Components.Geometries.Point origin, dymaptic.GeoBlazor.Core.Components.Geometries.Point currentPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptDrag(string,dymaptic.GeoBlazor.Core.Components.Geometries.Point,dymaptic.GeoBlazor.Core.Components.Geometries.Point).action'></a>

`action` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptDrag(string,dymaptic.GeoBlazor.Core.Components.Geometries.Point,dymaptic.GeoBlazor.Core.Components.Geometries.Point).origin'></a>

`origin` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptDrag(string,dymaptic.GeoBlazor.Core.Components.Geometries.Point,dymaptic.GeoBlazor.Core.Components.Geometries.Point).currentPoint'></a>

`currentPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptError(string,string,string)'></a>

## MapView.OnJavascriptError(string, string, string) Method

Surfaces JavaScript errors to the .NET Code for debugging.

```csharp
public void OnJavascriptError(string message, string name="", string stack="");
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptError(string,string,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The JavaScript error message.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptError(string,string,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the JavaScript error.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptError(string,string,string).stack'></a>

`stack` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The JavaScript stack trace.

#### Exceptions

[JavascriptException](dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptException')  
Wraps the JS Error and throws a .NET Exception.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## MapView.OnJavascriptExtentChanged(Extent) Method

JS-Invokable method to return when the map view Extent changes.

```csharp
public System.Threading.Tasks.Task OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent extent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent).extent'></a>

`extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptFocus()'></a>

## MapView.OnJavascriptFocus() Method

JS-Invokable method to return view focus events.

```csharp
public System.Threading.Tasks.Task OnJavascriptFocus();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptHold(dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## MapView.OnJavascriptHold(Point) Method

JS-Invokable method to return view hold events.

```csharp
public System.Threading.Tasks.Task OnJavascriptHold(dymaptic.GeoBlazor.Core.Components.Geometries.Point mapPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptHold(dymaptic.GeoBlazor.Core.Components.Geometries.Point).mapPoint'></a>

`mapPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') that was pressed.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptImmediateClick(dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## MapView.OnJavascriptImmediateClick(Point) Method

JS-Invokable method to return view immediate-clicks.

```csharp
public System.Threading.Tasks.Task OnJavascriptImmediateClick(dymaptic.GeoBlazor.Core.Components.Geometries.Point mapPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptImmediateClick(dymaptic.GeoBlazor.Core.Components.Geometries.Point).mapPoint'></a>

`mapPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') that was clicked.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptImmediateDoubleClick(dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## MapView.OnJavascriptImmediateDoubleClick(Point) Method

JS-Invokable method to return view immediate-double-clicks.

```csharp
public System.Threading.Tasks.Task OnJavascriptImmediateDoubleClick(dymaptic.GeoBlazor.Core.Components.Geometries.Point mapPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptImmediateDoubleClick(dymaptic.GeoBlazor.Core.Components.Geometries.Point).mapPoint'></a>

`mapPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') that was double-clicked.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptKeyDown(string)'></a>

## MapView.OnJavascriptKeyDown(string) Method

JS-Invokable method to return view key-down events.

```csharp
public System.Threading.Tasks.Task OnJavascriptKeyDown(string key);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptKeyDown(string).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptKeyUp(string)'></a>

## MapView.OnJavascriptKeyUp(string) Method

JS-Invokable method to return view key-up events.

```csharp
public System.Threading.Tasks.Task OnJavascriptKeyUp(string key);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptKeyUp(string).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Components.Layers.LayerView)'></a>

## MapView.OnJavascriptLayerViewCreate(LayerView) Method

JS-Invokable method to return when a layer view is created.

```csharp
public System.Threading.Tasks.Task OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Components.Layers.LayerView layerView);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreate(dymaptic.GeoBlazor.Core.Components.Layers.LayerView).layerView'></a>

`layerView` [LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')

The new [LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateError(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Exceptions.JavascriptException)'></a>

## MapView.OnJavascriptLayerViewCreateError(Layer, JavascriptException) Method

JS-Invokable method to return when a layer view is destroyed.

```csharp
public System.Threading.Tasks.Task OnJavascriptLayerViewCreateError(dymaptic.GeoBlazor.Core.Components.Layers.Layer layer, dymaptic.GeoBlazor.Core.Exceptions.JavascriptException exception);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateError(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Exceptions.JavascriptException).layer'></a>

`layer` [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

The [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') that failed to be added to the view.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewCreateError(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Exceptions.JavascriptException).exception'></a>

`exception` [JavascriptException](dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptException')

The Javascript error wrapped in a .NET Exception.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewDestroy(dymaptic.GeoBlazor.Core.Components.Layers.LayerView)'></a>

## MapView.OnJavascriptLayerViewDestroy(LayerView) Method

JS-Invokable method to return when a layer view is destroyed.

```csharp
public System.Threading.Tasks.Task OnJavascriptLayerViewDestroy(dymaptic.GeoBlazor.Core.Components.Layers.LayerView layerView);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptLayerViewDestroy(dymaptic.GeoBlazor.Core.Components.Layers.LayerView).layerView'></a>

`layerView` [LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')

The destroyed [LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptMouseWheel(double,double,double)'></a>

## MapView.OnJavascriptMouseWheel(double, double, double) Method

JS-Invokable method to return when the mouse wheel is scrolled.

```csharp
public System.Threading.Tasks.Task OnJavascriptMouseWheel(double x, double y, double deltaY);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptMouseWheel(double,double,double).x'></a>

`x` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptMouseWheel(double,double,double).y'></a>

`y` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptMouseWheel(double,double,double).deltaY'></a>

`deltaY` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerDown(dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## MapView.OnJavascriptPointerDown(Point) Method

JS-Invokable method to return view pointer down events.

```csharp
public System.Threading.Tasks.Task OnJavascriptPointerDown(dymaptic.GeoBlazor.Core.Components.Geometries.Point mapPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerDown(dymaptic.GeoBlazor.Core.Components.Geometries.Point).mapPoint'></a>

`mapPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') where the pointer was pressed.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerEnter(dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## MapView.OnJavascriptPointerEnter(Point) Method

JS-Invokable method to return view pointer enter events.

```csharp
public System.Threading.Tasks.Task OnJavascriptPointerEnter(dymaptic.GeoBlazor.Core.Components.Geometries.Point mapPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerEnter(dymaptic.GeoBlazor.Core.Components.Geometries.Point).mapPoint'></a>

`mapPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') where the pointer entered the view.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerLeave(dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## MapView.OnJavascriptPointerLeave(Point) Method

JS-Invokable method to return view pointer leave events.

```csharp
public System.Threading.Tasks.Task OnJavascriptPointerLeave(dymaptic.GeoBlazor.Core.Components.Geometries.Point mapPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerLeave(dymaptic.GeoBlazor.Core.Components.Geometries.Point).mapPoint'></a>

`mapPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') where the pointer left the view.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerMove(dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## MapView.OnJavascriptPointerMove(Point) Method

JS-Invokable method to return view pointer movement.

```csharp
public System.Threading.Tasks.Task OnJavascriptPointerMove(dymaptic.GeoBlazor.Core.Components.Geometries.Point mapPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerMove(dymaptic.GeoBlazor.Core.Components.Geometries.Point).mapPoint'></a>

`mapPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') where the cursor last moved.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerUp(dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## MapView.OnJavascriptPointerUp(Point) Method

JS-Invokable method to return view pointer up events.

```csharp
public System.Threading.Tasks.Task OnJavascriptPointerUp(dymaptic.GeoBlazor.Core.Components.Geometries.Point mapPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptPointerUp(dymaptic.GeoBlazor.Core.Components.Geometries.Point).mapPoint'></a>

`mapPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') where the pointer was released.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptResize(double,double,double,double)'></a>

## MapView.OnJavascriptResize(double, double, double, double) Method

JS-Invokable method to return when the map view is resized in the window.

```csharp
public System.Threading.Tasks.Task OnJavascriptResize(double oldWidth, double oldHeight, double width, double height);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptResize(double,double,double,double).oldWidth'></a>

`oldWidth` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptResize(double,double,double,double).oldHeight'></a>

`oldHeight` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptResize(double,double,double,double).width'></a>

`width` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.OnJavascriptResize(double,double,double,double).height'></a>

`height` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

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

The new [SpatialReference](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference 'dymaptic.GeoBlazor.Core.Components.Views.MapView.SpatialReference')

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

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RemoveGraphicAtIndex(int,System.Nullable_int_)'></a>

## MapView.RemoveGraphicAtIndex(int, Nullable<int>) Method

Removes a graphic based on the graphic index and optional layer index.

```csharp
public System.Threading.Tasks.Task RemoveGraphicAtIndex(int index, System.Nullable<int> layerIndex=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RemoveGraphicAtIndex(int,System.Nullable_int_).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Within the layer or view, the position of the graphic to be removed in the collection.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RemoveGraphicAtIndex(int,System.Nullable_int_).layerIndex'></a>

`layerIndex` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Optional layer index. If omitted, will remove the graphic from the view itself.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RemoveGraphicsAtIndexes(int[],System.Nullable_int_)'></a>

## MapView.RemoveGraphicsAtIndexes(int[], Nullable<int>) Method

Removes a collection of graphics based on index.

```csharp
public System.Threading.Tasks.Task RemoveGraphicsAtIndexes(int[] indexes, System.Nullable<int> layerIndex=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RemoveGraphicsAtIndexes(int[],System.Nullable_int_).indexes'></a>

`indexes` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Within the layer or view, remove all graphics at these indexes in the collection.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.RemoveGraphicsAtIndexes(int[],System.Nullable_int_).layerIndex'></a>

`layerIndex` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Optional layer index. If omitted, will remove the graphics from the view itself.

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

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.ShowPopupWithGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,dymaptic.GeoBlazor.Core.Objects.PopupOptions)'></a>

## MapView.ShowPopupWithGraphic(Graphic, PopupOptions) Method

Opens a Popup with a custom [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') on a particular [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') of the map view.

```csharp
public System.Threading.Tasks.Task ShowPopupWithGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic graphic, dymaptic.GeoBlazor.Core.Objects.PopupOptions options);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.ShowPopupWithGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,dymaptic.GeoBlazor.Core.Objects.PopupOptions).graphic'></a>

`graphic` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

The [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') to display in the Popup

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.ShowPopupWithGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,dymaptic.GeoBlazor.Core.Objects.PopupOptions).options'></a>

`options` [PopupOptions](dymaptic.GeoBlazor.Core.Objects.PopupOptions.html 'dymaptic.GeoBlazor.Core.Objects.PopupOptions')

A set of [PopupOptions](dymaptic.GeoBlazor.Core.Objects.PopupOptions.html 'dymaptic.GeoBlazor.Core.Objects.PopupOptions') that define the position and visible elements of the Popup.

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

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.UpdateComponent()'></a>

## MapView.UpdateComponent() Method

Checks if the map is already rendered, and if so, performs forced updates as defined by the component type.

```csharp
public override System.Threading.Tasks.Task UpdateComponent();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.UpdateGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,System.Nullable_int_)'></a>

## MapView.UpdateGraphic(Graphic, Nullable<int>) Method

Redraws a particular graphic.

```csharp
public System.Threading.Tasks.Task UpdateGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic graphic, System.Nullable<int> layerIndex);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.UpdateGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,System.Nullable_int_).graphic'></a>

`graphic` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

The [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') to redraw.

<a name='dymaptic.GeoBlazor.Core.Components.Views.MapView.UpdateGraphic(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,System.Nullable_int_).layerIndex'></a>

`layerIndex` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Optional layer index. If omitted, will look for the graphic on the view itself.

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
