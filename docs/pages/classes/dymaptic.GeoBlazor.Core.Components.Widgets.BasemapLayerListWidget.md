---
layout: default
title: BasemapLayerListWidget
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## BasemapLayerListWidget Class

The Basemap ListItem class represents two of the operational Items in the LayerList ViewModel. In the Basemap  
LayerList widget UI, the list items represent any base or reference layers displayed in the view. To display the  
ListItems as separate types, a developer will need to specify a base or reference. It provides access to the  
associated layer's properties, allows the developer to configure actions related to the layer, and allows the  
developer to add content to the item related to the layer.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapLayerList.html">ArcGIS JS API</a>

```csharp
public class BasemapLayerListWidget : dymaptic.GeoBlazor.Core.Components.Widgets.Widget
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget') &#129106; BasemapLayerListWidget
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.BaseLayerListWidgetObjectReference'></a>

## BasemapLayerListWidget.BaseLayerListWidgetObjectReference Property

The .Net object reference to this class for calling from JavaScript.

```csharp
public Microsoft.JSInterop.DotNetObjectReference<dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget> BaseLayerListWidgetObjectReference { get; }
```

#### Property Value
[Microsoft.JSInterop.DotNetObjectReference&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.DotNetObjectReference-1 'Microsoft.JSInterop.DotNetObjectReference`1')[BasemapLayerListWidget](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.DotNetObjectReference-1 'Microsoft.JSInterop.DotNetObjectReference`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.HasCustomBaseListHandler'></a>

## BasemapLayerListWidget.HasCustomBaseListHandler Property

A convenience property that signifies whether a custom [OnBaseListItemCreatedHandler](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.html#dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.OnBaseListItemCreatedHandler 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.OnBaseListItemCreatedHandler') was registered.

```csharp
public bool HasCustomBaseListHandler { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.HasCustomReferenceListHandler'></a>

## BasemapLayerListWidget.HasCustomReferenceListHandler Property

A convenience property that signifies whether a custom [OnReferenceListItemCreatedHandler](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.html#dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.OnReferenceListItemCreatedHandler 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.OnReferenceListItemCreatedHandler') was  
registered.

```csharp
public bool HasCustomReferenceListHandler { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.IconClass'></a>

## BasemapLayerListWidget.IconClass Property

The widget's default CSS icon class.

```csharp
public string? IconClass { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.Label'></a>

## BasemapLayerListWidget.Label Property

The widget's default label.

```csharp
public string? Label { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.OnBaseListItemCreatedHandler'></a>

## BasemapLayerListWidget.OnBaseListItemCreatedHandler Property

A delegate to implement a custom handler for setting up a base type of[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem').  
Function must take in a ListItem and return a Task with the designated base type of item.

```csharp
public System.Func<dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem,System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem>>? OnBaseListItemCreatedHandler { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.OnReferenceListItemCreatedHandler'></a>

## BasemapLayerListWidget.OnReferenceListItemCreatedHandler Property

A delegate to implement a custom handler for setting up a reference type of[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem').  
Function must take in a ListItem and return a Task with the designated reference type of item.

```csharp
public System.Func<dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem,System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem>>? OnReferenceListItemCreatedHandler { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.WidgetType'></a>

## BasemapLayerListWidget.WidgetType Property

The type of widget

```csharp
public override string WidgetType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.OnBaseListItemCreated(dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem)'></a>

## BasemapLayerListWidget.OnBaseListItemCreated(ListItem) Method

A JavaScript invokable method that is triggered whenever a base type ListItem is created and a handler is attached.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem>? OnBaseListItemCreated(dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem item);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.OnBaseListItemCreated(dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem).item'></a>

`item` [ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')

The [ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem') from the original source.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns the modified base [ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.OnReferenceListItemCreated(dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem)'></a>

## BasemapLayerListWidget.OnReferenceListItemCreated(ListItem) Method

A JavaScript invokable method that is triggered whenever a reference type ListItem is created and a handler is  
attached.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem>? OnReferenceListItemCreated(dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem item);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BasemapLayerListWidget.OnReferenceListItemCreated(dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem).item'></a>

`item` [ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')

The [ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem') from the original source.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Returns the modified reference [ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem')
