---
layout: default
title: LayerListWidget
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## LayerListWidget Class

The LayerList widget provides a way to display a list of layers, and switch on/off their visibility. The ListItem API provides access to each layer's properties, allows the developer to configure actions related to the layer, and allows the developer to add content to the item related to the layer.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html">ArcGIS JS API</a>

```csharp
public class LayerListWidget : dymaptic.GeoBlazor.Core.Components.Widgets.Widget
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget') &#129106; LayerListWidget

Derived  
&#8627; [BasemapLayerListWidget](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.HasCustomHandler'></a>

## LayerListWidget.HasCustomHandler Property

A convenience property that signifies whether a custom [OnListItemCreatedHandler](dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.html#dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.OnListItemCreatedHandler 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.OnListItemCreatedHandler') was registered.

```csharp
public bool HasCustomHandler { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.IconClass'></a>

## LayerListWidget.IconClass Property

The widget's default CSS icon class.

```csharp
public string? IconClass { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.Label'></a>

## LayerListWidget.Label Property

The widget's default label.

```csharp
public string? Label { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.LayerListWidgetObjectReference'></a>

## LayerListWidget.LayerListWidgetObjectReference Property

The .Net object reference to this class for calling from JavaScript.

```csharp
public Microsoft.JSInterop.DotNetObjectReference<dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget> LayerListWidgetObjectReference { get; }
```

#### Property Value
[Microsoft.JSInterop.DotNetObjectReference&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.DotNetObjectReference-1 'Microsoft.JSInterop.DotNetObjectReference`1')[LayerListWidget](dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.DotNetObjectReference-1 'Microsoft.JSInterop.DotNetObjectReference`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.OnListItemCreatedHandler'></a>

## LayerListWidget.OnListItemCreatedHandler Property

A delegate to implement a custom handler for setting up each [ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem').  
Function must take in a ListItem and return a Task with the same (updated) item.

```csharp
public System.Func<dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem,System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem>>? OnListItemCreatedHandler { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.WidgetType'></a>

## LayerListWidget.WidgetType Property

The type of widget

```csharp
public override string WidgetType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.OnListItemCreated(dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem)'></a>

## LayerListWidget.OnListItemCreated(ListItem) Method

A JavaScript invokable method that is triggered whenever a ListItem is created and a handler is attached.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem>? OnListItemCreated(dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem item);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.OnListItemCreated(dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem).item'></a>

`item` [ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')

The [ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem') from the original source.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns the modified [ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')
