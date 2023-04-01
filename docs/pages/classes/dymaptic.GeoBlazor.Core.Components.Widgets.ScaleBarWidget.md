---
layout: default
title: ScaleBarWidget
parent: Classes
---
---
layout: default
title: ScaleBarWidget
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## ScaleBarWidget Class

The ScaleBar widget displays a scale bar on the map or in a specified HTML node. The widget respects various  
coordinate systems and displays units in metric or non-metric values. Metric values shows either kilometers or  
meters depending on the scale, and likewise non-metric values shows miles and feet depending on the scale.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-ScaleBar.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class ScaleBarWidget : dymaptic.GeoBlazor.Core.Components.Widgets.Widget
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget') &#129106; ScaleBarWidget
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.ScaleBarWidget.Unit'></a>

## ScaleBarWidget.Unit Property

Units to use for the scale bar

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Widgets.ScaleUnit> Unit { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[ScaleUnit](dymaptic.GeoBlazor.Core.Components.Widgets.ScaleUnit.html 'dymaptic.GeoBlazor.Core.Components.Widgets.ScaleUnit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.ScaleBarWidget.WidgetType'></a>

## ScaleBarWidget.WidgetType Property

The type of widget

```csharp
public override string WidgetType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

