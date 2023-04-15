---
layout: default
title: SearchWidget
parent: Classes
---
---
layout: default
title: SearchWidget
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## SearchWidget Class

The Search widget provides a way to perform search operations on locator service(s), map/feature service feature  
layer(s), SceneLayers with an associated feature layer, BuildingComponentSublayer with an associated feature layer,  
GeoJSONLayer, CSVLayer, OGCFeatureLayer, and/or table(s). If using a locator with a geocoding service, the  
findAddressCandidates operation is used, whereas queries are used on feature layers.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class SearchWidget : dymaptic.GeoBlazor.Core.Components.Widgets.Widget
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget') &#129106; SearchWidget
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.SearchWidget.OnSearchSelectResultEvent'></a>

## SearchWidget.OnSearchSelectResultEvent Property

A delegate for a handler of search selection result events.  
Function must take in a [SearchResult](dymaptic.GeoBlazor.Core.Objects.SearchResult.html 'dymaptic.GeoBlazor.Core.Objects.SearchResult') parameter, and return a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

```csharp
public Microsoft.AspNetCore.Components.EventCallback<dymaptic.GeoBlazor.Core.Objects.SearchResult> OnSearchSelectResultEvent { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.EventCallback&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')[SearchResult](dymaptic.GeoBlazor.Core.Objects.SearchResult.html 'dymaptic.GeoBlazor.Core.Objects.SearchResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.EventCallback-1 'Microsoft.AspNetCore.Components.EventCallback`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.SearchWidget.SearchWidgetObjectReference'></a>

## SearchWidget.SearchWidgetObjectReference Property

A .NET object reference for calling this class from JavaScript.

```csharp
public Microsoft.JSInterop.DotNetObjectReference<dymaptic.GeoBlazor.Core.Components.Widgets.SearchWidget> SearchWidgetObjectReference { get; }
```

#### Property Value
[Microsoft.JSInterop.DotNetObjectReference&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.DotNetObjectReference-1 'Microsoft.JSInterop.DotNetObjectReference`1')[SearchWidget](dymaptic.GeoBlazor.Core.Components.Widgets.SearchWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.SearchWidget')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.DotNetObjectReference-1 'Microsoft.JSInterop.DotNetObjectReference`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.SearchWidget.WidgetType'></a>

## SearchWidget.WidgetType Property

The type of widget

```csharp
public override string WidgetType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.SearchWidget.OnJavaScriptSearchSelectResult(dymaptic.GeoBlazor.Core.Objects.SearchResult)'></a>

## SearchWidget.OnJavaScriptSearchSelectResult(SearchResult) Method

A JavaScript invokable method that is triggered whenever a "select-result" event is fired by the search widget.

```csharp
public System.Threading.Tasks.Task OnJavaScriptSearchSelectResult(dymaptic.GeoBlazor.Core.Objects.SearchResult searchResult);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.SearchWidget.OnJavaScriptSearchSelectResult(dymaptic.GeoBlazor.Core.Objects.SearchResult).searchResult'></a>

`searchResult` [SearchResult](dymaptic.GeoBlazor.Core.Objects.SearchResult.html 'dymaptic.GeoBlazor.Core.Objects.SearchResult')

The result selected in the search widget.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

