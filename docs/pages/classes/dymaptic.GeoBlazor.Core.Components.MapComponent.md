---
layout: default
title: MapComponent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components](index.html#dymaptic.GeoBlazor.Core.Components 'dymaptic.GeoBlazor.Core.Components')

## MapComponent Class

The abstract base Razor Component class that all GeoBlazor components derive from.

```csharp
public abstract class MapComponent : Microsoft.AspNetCore.Components.ComponentBase,
System.IAsyncDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; MapComponent

Derived  
&#8627; [ActionBase](dymaptic.GeoBlazor.Core.Components.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.ActionBase')  
&#8627; [Basemap](dymaptic.GeoBlazor.Core.Components.Basemap.html 'dymaptic.GeoBlazor.Core.Components.Basemap')  
&#8627; [Constraints](dymaptic.GeoBlazor.Core.Components.Constraints.html 'dymaptic.GeoBlazor.Core.Components.Constraints')  
&#8627; [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')  
&#8627; [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')  
&#8627; [Field](dymaptic.GeoBlazor.Core.Components.Layers.Field.html 'dymaptic.GeoBlazor.Core.Components.Layers.Field')  
&#8627; [LabelExpressionInfo](dymaptic.GeoBlazor.Core.Components.Layers.LabelExpressionInfo.html 'dymaptic.GeoBlazor.Core.Components.Layers.LabelExpressionInfo')  
&#8627; [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')  
&#8627; [LayerObject](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject')  
&#8627; [LegendOptions](dymaptic.GeoBlazor.Core.Components.Layers.LegendOptions.html 'dymaptic.GeoBlazor.Core.Components.Layers.LegendOptions')  
&#8627; [OrderedLayerOrderBy](dymaptic.GeoBlazor.Core.Components.Layers.OrderedLayerOrderBy.html 'dymaptic.GeoBlazor.Core.Components.Layers.OrderedLayerOrderBy')  
&#8627; [TileInfo](dymaptic.GeoBlazor.Core.Components.Layers.TileInfo.html 'dymaptic.GeoBlazor.Core.Components.Layers.TileInfo')  
&#8627; [VisualVariable](dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.html 'dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable')  
&#8627; [LOD](dymaptic.GeoBlazor.Core.Components.LOD.html 'dymaptic.GeoBlazor.Core.Components.LOD')  
&#8627; [Map](dymaptic.GeoBlazor.Core.Components.Map.html 'dymaptic.GeoBlazor.Core.Components.Map')  
&#8627; [ChartMediaInfoValue](dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValue.html 'dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValue')  
&#8627; [ChartMediaInfoValueSeries](dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValueSeries.html 'dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValueSeries')  
&#8627; [ExpressionInfo](dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo')  
&#8627; [FieldInfo](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo')  
&#8627; [FieldInfoFormat](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat')  
&#8627; [ImageMediaInfoValue](dymaptic.GeoBlazor.Core.Components.Popups.ImageMediaInfoValue.html 'dymaptic.GeoBlazor.Core.Components.Popups.ImageMediaInfoValue')  
&#8627; [MediaInfo](dymaptic.GeoBlazor.Core.Components.Popups.MediaInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.MediaInfo')  
&#8627; [PopupContent](dymaptic.GeoBlazor.Core.Components.Popups.PopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupContent')  
&#8627; [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate')  
&#8627; [RelatedRecordsInfoFieldOrder](dymaptic.GeoBlazor.Core.Components.Popups.RelatedRecordsInfoFieldOrder.html 'dymaptic.GeoBlazor.Core.Components.Popups.RelatedRecordsInfoFieldOrder')  
&#8627; [Portal](dymaptic.GeoBlazor.Core.Components.Portal.html 'dymaptic.GeoBlazor.Core.Components.Portal')  
&#8627; [PortalBasemapsSource](dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.html 'dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource')  
&#8627; [PortalItem](dymaptic.GeoBlazor.Core.Components.PortalItem.html 'dymaptic.GeoBlazor.Core.Components.PortalItem')  
&#8627; [DefaultSymbol](dymaptic.GeoBlazor.Core.Components.Renderers.DefaultSymbol.html 'dymaptic.GeoBlazor.Core.Components.Renderers.DefaultSymbol')  
&#8627; [UniqueValueRendererLegendOptions](dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRendererLegendOptions.html 'dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRendererLegendOptions')  
&#8627; [MapFont](dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MapFont')  
&#8627; [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol')  
&#8627; [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView')  
&#8627; [LayerInfo](dymaptic.GeoBlazor.Core.Components.Widgets.LayerInfo.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerInfo')  
&#8627; [PopupDockOptions](dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupDockOptions')  
&#8627; [PopupVisibleElements](dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements.html 'dymaptic.GeoBlazor.Core.Components.Widgets.PopupVisibleElements')  
&#8627; [Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget')  
&#8627; [HighlightOptions](dymaptic.GeoBlazor.Core.Objects.HighlightOptions.html 'dymaptic.GeoBlazor.Core.Objects.HighlightOptions')

Implements [System.IAsyncDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable 'System.IAsyncDisposable')
### Fields

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AllowRender'></a>

## MapComponent.AllowRender Field

Whether to allow the component to render on the next cycle.

```csharp
public bool AllowRender;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.ChildContent'></a>

## MapComponent.ChildContent Property

ChildContent defines the ability to add other components within this component in the razor syntax.

```csharp
public Microsoft.AspNetCore.Components.RenderFragment? ChildContent { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.RenderFragment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.RenderFragment 'Microsoft.AspNetCore.Components.RenderFragment')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.Id'></a>

## MapComponent.Id Property

A unique identifier, used to track components across .NET and JavaScript.

```csharp
public System.Guid Id { get; set; }
```

#### Property Value
[System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.JsModule'></a>

## MapComponent.JsModule Property

The reference to arcGisJsInterop.ts from .NET

```csharp
public Microsoft.JSInterop.IJSObjectReference? JsModule { get; set; }
```

#### Property Value
[Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.JsRuntime'></a>

## MapComponent.JsRuntime Property

Represents an instance of a JavaScript runtime to which calls may be dispatched.

```csharp
public Microsoft.JSInterop.IJSRuntime JsRuntime { get; set; }
```

#### Property Value
[Microsoft.JSInterop.IJSRuntime](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSRuntime 'Microsoft.JSInterop.IJSRuntime')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.MapRendered'></a>

## MapComponent.MapRendered Property

A boolean flag that indicates that the current [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') has finished rendering.  
To listen for a map rendering event, use [OnMapRendered](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.OnMapRendered 'dymaptic.GeoBlazor.Core.Components.Views.MapView.OnMapRendered').

```csharp
public bool MapRendered { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.Parent'></a>

## MapComponent.Parent Property

The parent MapComponent of this component.

```csharp
public dymaptic.GeoBlazor.Core.Components.MapComponent? Parent { get; set; }
```

#### Property Value
[MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.View'></a>

## MapComponent.View Property

The parent [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') of the current component.

```csharp
public dymaptic.GeoBlazor.Core.Components.Views.MapView? View { get; set; }
```

#### Property Value
[MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.Add(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## MapComponent.Add(MapComponent) Method

Add a child component programmatically. Calls [RegisterChildComponent(MapComponent)](dymaptic.GeoBlazor.Core.Components.MapComponent.html#dymaptic.GeoBlazor.Core.Components.MapComponent.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent) 'dymaptic.GeoBlazor.Core.Components.MapComponent.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)') internally.

```csharp
public System.Threading.Tasks.Task Add(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.Add(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child component to add

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener_T_(string,System.Action_T_,bool)'></a>

## MapComponent.AddReactiveListener<T>(string, Action<T>, bool) Method

Tracks any properties accessed in the   
  
```csharp  
listenExpression  
``` and calls the callback when any of them change.

```csharp
public System.Threading.Tasks.Task AddReactiveListener<T>(string eventName, System.Action<T> handler, bool once=false);
```
#### Type parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener_T_(string,System.Action_T_,bool).T'></a>

`T`

The type of return value to expect in the handler.
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener_T_(string,System.Action_T_,bool).eventName'></a>

`eventName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the event to add a listener for.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener_T_(string,System.Action_T_,bool).handler'></a>

`handler` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](dymaptic.GeoBlazor.Core.Components.MapComponent.html#dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener_T_(string,System.Action_T_,bool).T 'dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener<T>(string, System.Action<T>, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The function to call when there are changes.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener_T_(string,System.Action_T_,bool).once'></a>

`once` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to fire the callback only once. Defaults to false.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener_T_(string,System.Func_T,System.Threading.Tasks.Task_,bool)'></a>

## MapComponent.AddReactiveListener<T>(string, Func<T,Task>, bool) Method

Tracks any properties accessed in the   
  
```csharp  
listenExpression  
``` and calls the callback when any of them change.

```csharp
public System.Threading.Tasks.Task AddReactiveListener<T>(string eventName, System.Func<T,System.Threading.Tasks.Task> handler, bool once=false);
```
#### Type parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener_T_(string,System.Func_T,System.Threading.Tasks.Task_,bool).T'></a>

`T`

The type of return value to expect in the handler.
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener_T_(string,System.Func_T,System.Threading.Tasks.Task_,bool).eventName'></a>

`eventName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the event to add a listener for.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener_T_(string,System.Func_T,System.Threading.Tasks.Task_,bool).handler'></a>

`handler` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](dymaptic.GeoBlazor.Core.Components.MapComponent.html#dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener_T_(string,System.Func_T,System.Threading.Tasks.Task_,bool).T 'dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener<T>(string, System.Func<T,System.Threading.Tasks.Task>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The function to call when the event triggers.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener_T_(string,System.Func_T,System.Threading.Tasks.Task_,bool).once'></a>

`once` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to fire the callback only once. Defaults to false.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string,System.Action,string,bool,bool)'></a>

## MapComponent.AddReactiveWaiter(string, Action, string, bool, bool) Method

Tracks a value in the   
  
```csharp  
waitExpression  
``` and calls the callback when it becomes  
<a target="_blank" href="https://developer.mozilla.org/en-US/docs/Glossary/Truthy">truthy</a>.

```csharp
public System.Threading.Tasks.Task AddReactiveWaiter(string waitExpression, System.Action handler, string? targetName=null, bool once=false, bool initial=false);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string,System.Action,string,bool,bool).waitExpression'></a>

`waitExpression` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Expression used to get the current value. All accessed properties will be tracked.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string,System.Action,string,bool,bool).handler'></a>

`handler` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The function to call when the value is truthy.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string,System.Action,string,bool,bool).targetName'></a>

`targetName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the target you are referencing in the   
  
```csharp  
waitExpression  
```. For example, if the expression is  
"layer?.refresh", then the targetName should be "layer". The type of the target should also match the class on  
which this method was called.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string,System.Action,string,bool,bool).once'></a>

`once` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to fire the callback only once.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string,System.Action,string,bool,bool).initial'></a>

`initial` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to fire the callback immediately after initialization, if the necessary conditions are met.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[UnMatchedTargetNameException](dymaptic.GeoBlazor.Core.Exceptions.UnMatchedTargetNameException.html 'dymaptic.GeoBlazor.Core.Exceptions.UnMatchedTargetNameException')  
This exception is thrown when a watchExpression's target object name doesn't match the targetName parameter.

### Remarks
For adding waiters to types other than [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') and [SceneView](dymaptic.GeoBlazor.Core.Components.Views.SceneView.html 'dymaptic.GeoBlazor.Core.Components.Views.SceneView'), the default  
  
```csharp  
targetName  
``` should not be relied upon. Make sure it matches the variable in your  
  
```csharp  
waitExpression  
```

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string,System.Func_System.Threading.Tasks.Task_,string,bool,bool)'></a>

## MapComponent.AddReactiveWaiter(string, Func<Task>, string, bool, bool) Method

Tracks a value in the   
  
```csharp  
waitExpression  
``` and calls the callback when it becomes  
<a target="_blank" href="https://developer.mozilla.org/en-US/docs/Glossary/Truthy">truthy</a>.

```csharp
public System.Threading.Tasks.Task AddReactiveWaiter(string waitExpression, System.Func<System.Threading.Tasks.Task> handler, string? targetName=null, bool once=false, bool initial=false);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string,System.Func_System.Threading.Tasks.Task_,string,bool,bool).waitExpression'></a>

`waitExpression` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Expression used to get the current value. All accessed properties will be tracked.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string,System.Func_System.Threading.Tasks.Task_,string,bool,bool).handler'></a>

`handler` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The function to call when the value is truthy.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string,System.Func_System.Threading.Tasks.Task_,string,bool,bool).targetName'></a>

`targetName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the target you are referencing in the   
  
```csharp  
waitExpression  
```. For example, if the expression is  
"layer?.refresh", then the targetName should be "layer". The type of the target should also match the class on  
which this method was called.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string,System.Func_System.Threading.Tasks.Task_,string,bool,bool).once'></a>

`once` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to fire the callback only once.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string,System.Func_System.Threading.Tasks.Task_,string,bool,bool).initial'></a>

`initial` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to fire the callback immediately after initialization, if the necessary conditions are met.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[UnMatchedTargetNameException](dymaptic.GeoBlazor.Core.Exceptions.UnMatchedTargetNameException.html 'dymaptic.GeoBlazor.Core.Exceptions.UnMatchedTargetNameException')  
This exception is thrown when a watchExpression's target object name doesn't match the targetName parameter.

### Remarks
For adding waiters to types other than [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') and [SceneView](dymaptic.GeoBlazor.Core.Components.Views.SceneView.html 'dymaptic.GeoBlazor.Core.Components.Views.SceneView'), the default  
  
```csharp  
targetName  
``` should not be relied upon. Make sure it matches the variable in your  
  
```csharp  
waitExpression  
```

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Action_T_,string,bool,bool)'></a>

## MapComponent.AddReactiveWatcher<T>(string, Action<T>, string, bool, bool) Method

Tracks any properties accessed in the   
  
```csharp  
watchExpression  
``` and calls the callback when any of them change.

```csharp
public System.Threading.Tasks.Task AddReactiveWatcher<T>(string watchExpression, System.Action<T> handler, string? targetName=null, bool once=false, bool initial=false);
```
#### Type parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Action_T_,string,bool,bool).T'></a>

`T`

The type of return value to expect in the handler.
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Action_T_,string,bool,bool).watchExpression'></a>

`watchExpression` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Expression used to get the current value. All accessed properties will be tracked.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Action_T_,string,bool,bool).handler'></a>

`handler` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](dymaptic.GeoBlazor.Core.Components.MapComponent.html#dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Action_T_,string,bool,bool).T 'dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher<T>(string, System.Action<T>, string, bool, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The function to call when there are changes.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Action_T_,string,bool,bool).targetName'></a>

`targetName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the target you are referencing in the   
  
```csharp  
watchExpression  
```. For example, if the expression is  
"layer?.refresh", then the targetName should be "layer". The type of the target should also match the class on  
which this method was called.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Action_T_,string,bool,bool).once'></a>

`once` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to fire the callback only once.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Action_T_,string,bool,bool).initial'></a>

`initial` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to fire the callback immediately after initialization, if the necessary conditions are met.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[UnMatchedTargetNameException](dymaptic.GeoBlazor.Core.Exceptions.UnMatchedTargetNameException.html 'dymaptic.GeoBlazor.Core.Exceptions.UnMatchedTargetNameException')  
This exception is thrown when a watchExpression's target object name doesn't match the targetName parameter.

### Remarks
For adding watchers to types other than [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') and [SceneView](dymaptic.GeoBlazor.Core.Components.Views.SceneView.html 'dymaptic.GeoBlazor.Core.Components.Views.SceneView'), the default  
  
```csharp  
targetName  
``` should not be relied upon. Make sure it matches the variable in your  
  
```csharp  
watchExpression  
```

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Func_T,System.Threading.Tasks.Task_,string,bool,bool)'></a>

## MapComponent.AddReactiveWatcher<T>(string, Func<T,Task>, string, bool, bool) Method

Tracks any properties accessed in the   
  
```csharp  
watchExpression  
``` and calls the callback when any of them change.

```csharp
public System.Threading.Tasks.Task AddReactiveWatcher<T>(string watchExpression, System.Func<T,System.Threading.Tasks.Task> handler, string? targetName=null, bool once=false, bool initial=false);
```
#### Type parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Func_T,System.Threading.Tasks.Task_,string,bool,bool).T'></a>

`T`

The type of return value to expect in the handler.
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Func_T,System.Threading.Tasks.Task_,string,bool,bool).watchExpression'></a>

`watchExpression` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Expression used to get the current value. All accessed properties will be tracked.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Func_T,System.Threading.Tasks.Task_,string,bool,bool).handler'></a>

`handler` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](dymaptic.GeoBlazor.Core.Components.MapComponent.html#dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Func_T,System.Threading.Tasks.Task_,string,bool,bool).T 'dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher<T>(string, System.Func<T,System.Threading.Tasks.Task>, string, bool, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The function to call when there are changes.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Func_T,System.Threading.Tasks.Task_,string,bool,bool).targetName'></a>

`targetName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the target you are referencing in the   
  
```csharp  
watchExpression  
```. For example, if the expression is  
"layer?.refresh", then the targetName should be "layer". The type of the target should also match the class on  
which this method was called.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Func_T,System.Threading.Tasks.Task_,string,bool,bool).once'></a>

`once` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to fire the callback only once.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Func_T,System.Threading.Tasks.Task_,string,bool,bool).initial'></a>

`initial` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to fire the callback immediately after initialization, if the necessary conditions are met.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[UnMatchedTargetNameException](dymaptic.GeoBlazor.Core.Exceptions.UnMatchedTargetNameException.html 'dymaptic.GeoBlazor.Core.Exceptions.UnMatchedTargetNameException')  
This exception is thrown when a watchExpression's target object name doesn't match the targetName parameter.

### Remarks
For adding watchers to types other than [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') and [SceneView](dymaptic.GeoBlazor.Core.Components.Views.SceneView.html 'dymaptic.GeoBlazor.Core.Components.Views.SceneView'), the default  
  
```csharp  
targetName  
``` should not be relied upon. Make sure it matches the variable in your  
  
```csharp  
watchExpression  
```

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AwaitReactiveSingleWatchUpdate_T_(string,string,System.Threading.CancellationToken)'></a>

## MapComponent.AwaitReactiveSingleWatchUpdate<T>(string, string, CancellationToken) Method

Tracks any properties being evaluated by the getValue function. When getValue changes, it returns a Task containing  
the value. This method only tracks a single change.

```csharp
public System.Threading.Tasks.Task<T> AwaitReactiveSingleWatchUpdate<T>(string watchExpression, string? targetName=null, System.Threading.CancellationToken token=default(System.Threading.CancellationToken));
```
#### Type parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AwaitReactiveSingleWatchUpdate_T_(string,string,System.Threading.CancellationToken).T'></a>

`T`

The expected return type.
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AwaitReactiveSingleWatchUpdate_T_(string,string,System.Threading.CancellationToken).watchExpression'></a>

`watchExpression` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The expression to be tracked.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AwaitReactiveSingleWatchUpdate_T_(string,string,System.Threading.CancellationToken).targetName'></a>

`targetName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the target you are referencing in the   
  
```csharp  
waitExpression  
```. For example, if the expression is  
"layer?.refresh", then the targetName should be "layer". The type of the target should also match the class on  
which this method was called.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.AwaitReactiveSingleWatchUpdate_T_(string,string,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Optional Cancellation Token to abort a listener.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[T](dymaptic.GeoBlazor.Core.Components.MapComponent.html#dymaptic.GeoBlazor.Core.Components.MapComponent.AwaitReactiveSingleWatchUpdate_T_(string,string,System.Threading.CancellationToken).T 'dymaptic.GeoBlazor.Core.Components.MapComponent.AwaitReactiveSingleWatchUpdate<T>(string, string, System.Threading.CancellationToken).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns the value from the evaluated property when it changes.

#### Exceptions

[UnMatchedTargetNameException](dymaptic.GeoBlazor.Core.Exceptions.UnMatchedTargetNameException.html 'dymaptic.GeoBlazor.Core.Exceptions.UnMatchedTargetNameException')  
This exception is thrown when a watchExpression's target object name doesn't match the targetName parameter.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.DisposeAsync()'></a>

## MapComponent.DisposeAsync() Method

Implements the `IAsyncDisposable` pattern.

```csharp
public virtual System.Threading.Tasks.ValueTask DisposeAsync();
```

Implements [DisposeAsync()](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable.DisposeAsync 'System.IAsyncDisposable.DisposeAsync')

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.OnReactiveListenerTriggered(string,System.Nullable_System.Text.Json.JsonElement_)'></a>

## MapComponent.OnReactiveListenerTriggered(string, Nullable<JsonElement>) Method

JS-Invokable method that is triggered by the reactiveUtils 'on' listeners. This method will dynamically trigger  
handlers passed to [AddReactiveListener&lt;T&gt;(string, Func&lt;T,Task&gt;, bool)](dymaptic.GeoBlazor.Core.Components.MapComponent.html#dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener_T_(string,System.Func_T,System.Threading.Tasks.Task_,bool) 'dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveListener<T>(string, System.Func<T,System.Threading.Tasks.Task>, bool)')

```csharp
public void OnReactiveListenerTriggered(string eventName, System.Nullable<System.Text.Json.JsonElement> value);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.OnReactiveListenerTriggered(string,System.Nullable_System.Text.Json.JsonElement_).eventName'></a>

`eventName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The tracked event that was triggered.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.OnReactiveListenerTriggered(string,System.Nullable_System.Text.Json.JsonElement_).value'></a>

`value` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Text.Json.JsonElement](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Json.JsonElement 'System.Text.Json.JsonElement')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The return value of the watcher callback.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.OnReactiveWaiterTrue(string)'></a>

## MapComponent.OnReactiveWaiterTrue(string) Method

JS-Invokable method that is triggered by the reactiveUtils waiters. This method will dynamically trigger handlers  
passed to [AddReactiveWaiter(string, Func&lt;Task&gt;, string, bool, bool)](dymaptic.GeoBlazor.Core.Components.MapComponent.html#dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string,System.Func_System.Threading.Tasks.Task_,string,bool,bool) 'dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWaiter(string, System.Func<System.Threading.Tasks.Task>, string, bool, bool)')

```csharp
public void OnReactiveWaiterTrue(string waitExpression);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.OnReactiveWaiterTrue(string).waitExpression'></a>

`waitExpression` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The tracked expression that was triggered.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.OnReactiveWatcherUpdate(string,System.Nullable_System.Text.Json.JsonElement_)'></a>

## MapComponent.OnReactiveWatcherUpdate(string, Nullable<JsonElement>) Method

JS-Invokable method that is triggered by the reactiveUtils watchers. This method will dynamically trigger handlers  
passed to [AddReactiveWatcher&lt;T&gt;(string, Func&lt;T,Task&gt;, string, bool, bool)](dymaptic.GeoBlazor.Core.Components.MapComponent.html#dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher_T_(string,System.Func_T,System.Threading.Tasks.Task_,string,bool,bool) 'dymaptic.GeoBlazor.Core.Components.MapComponent.AddReactiveWatcher<T>(string, System.Func<T,System.Threading.Tasks.Task>, string, bool, bool)')

```csharp
public void OnReactiveWatcherUpdate(string watchExpression, System.Nullable<System.Text.Json.JsonElement> value);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.OnReactiveWatcherUpdate(string,System.Nullable_System.Text.Json.JsonElement_).watchExpression'></a>

`watchExpression` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The tracked expression that was triggered.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.OnReactiveWatcherUpdate(string,System.Nullable_System.Text.Json.JsonElement_).value'></a>

`value` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Text.Json.JsonElement](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Json.JsonElement 'System.Text.Json.JsonElement')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The return value of the watcher callback.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.Refresh()'></a>

## MapComponent.Refresh() Method

Provides a way to externally call `StateHasChanged` on the component.

```csharp
public virtual void Refresh();
```

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## MapComponent.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public virtual System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method. If you see no other way to register a child component, please open an issue on GitHub.

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.RemoveReactiveListener(string)'></a>

## MapComponent.RemoveReactiveListener(string) Method

Removes the tracker on a particular expression.

```csharp
public System.Threading.Tasks.Task RemoveReactiveListener(string eventName);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.RemoveReactiveListener(string).eventName'></a>

`eventName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The expression to stop tracking.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.RemoveReactiveWaiter(string)'></a>

## MapComponent.RemoveReactiveWaiter(string) Method

Removes the tracker on a particular expression.

```csharp
public System.Threading.Tasks.Task RemoveReactiveWaiter(string waitExpression);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.RemoveReactiveWaiter(string).waitExpression'></a>

`waitExpression` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The expression to stop tracking.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.RemoveReactiveWatcher(string)'></a>

## MapComponent.RemoveReactiveWatcher(string) Method

Removes the tracker on a particular expression.

```csharp
public System.Threading.Tasks.Task RemoveReactiveWatcher(string watchExpression);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.RemoveReactiveWatcher(string).watchExpression'></a>

`watchExpression` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The expression to stop tracking.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.SetVisibility(bool)'></a>

## MapComponent.SetVisibility(bool) Method

Toggles the visibility of the component.

```csharp
public System.Threading.Tasks.Task SetVisibility(bool visible);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.SetVisibility(bool).visible'></a>

`visible` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

The new value to set for visibility of the component.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## MapComponent.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public virtual System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.MapComponent.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method.
