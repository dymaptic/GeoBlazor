---
layout: default
title: Widget
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## Widget Class

The base class for widgets. Each widget's presentation is separate from its properties, methods, and data.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html">ArcGIS JS API</a>

```csharp
public abstract class Widget : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; Widget

Derived  
&#8627; [BasemapGalleryWidget](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget')  
&#8627; [BasemapToggleWidget](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget')  
&#8627; [CompassWidget](dymaptic.GeoBlazor.Core.Components.Widgets.CompassWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.CompassWidget')  
&#8627; [HomeWidget](dymaptic.GeoBlazor.Core.Components.Widgets.HomeWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.HomeWidget')  
&#8627; [LayerListWidget](dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget')  
&#8627; [LegendWidget](dymaptic.GeoBlazor.Core.Components.Widgets.LegendWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LegendWidget')  
&#8627; [LocateWidget](dymaptic.GeoBlazor.Core.Components.Widgets.LocateWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LocateWidget')  
&#8627; [ScaleBarWidget](dymaptic.GeoBlazor.Core.Components.Widgets.ScaleBarWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.ScaleBarWidget')  
&#8627; [SearchWidget](dymaptic.GeoBlazor.Core.Components.Widgets.SearchWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.SearchWidget')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.Widget.ContainerId'></a>

## Widget.ContainerId Property

The id of an external HTML Element (div). If provided, the widget will be placed inside that element, instead of on the map.

```csharp
public string? ContainerId { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
Either [Position](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html#dymaptic.GeoBlazor.Core.Components.Widgets.Widget.Position 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget.Position') or [ContainerId](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html#dymaptic.GeoBlazor.Core.Components.Widgets.Widget.ContainerId 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget.ContainerId') should be set, but not both.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.Widget.Position'></a>

## Widget.Position Property

The position of the widget in relation to the map view.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.OverlayPosition> Position { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[OverlayPosition](dymaptic.GeoBlazor.Core.Components.OverlayPosition.html 'dymaptic.GeoBlazor.Core.Components.OverlayPosition')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
Either [Position](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html#dymaptic.GeoBlazor.Core.Components.Widgets.Widget.Position 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget.Position') or [ContainerId](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html#dymaptic.GeoBlazor.Core.Components.Widgets.Widget.ContainerId 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget.ContainerId') should be set, but not both.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.Widget.WidgetType'></a>

## Widget.WidgetType Property

The type of widget

```csharp
public abstract string WidgetType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
