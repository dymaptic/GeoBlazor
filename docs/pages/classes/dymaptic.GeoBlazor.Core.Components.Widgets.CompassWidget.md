---
layout: default
title: CompassWidget
parent: Classes
---
---
layout: default
title: CompassWidget
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## CompassWidget Class

The Compass widget indicates where north is in relation to the current view rotation or camera heading. Clicking the Compass widget rotates the view to face north (heading = 0). This widget is added to a SceneView by default. The icon for the Compass widget is determined based upon the view's spatial reference. If the view's spatial reference is not Web Mercator or WGS84 a dial icon will be used, however when the spatial reference is Web Mercator or WGS84 the icon will be a north arrow.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Compass.html">ArcGIS JS API</a>

```csharp
public class CompassWidget : dymaptic.GeoBlazor.Core.Components.Widgets.Widget
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget') &#129106; CompassWidget
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.CompassWidget.IconClass'></a>

## CompassWidget.IconClass Property

The widget's default CSS icon class.

```csharp
public string? IconClass { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.CompassWidget.Label'></a>

## CompassWidget.Label Property

The widget's default label.

```csharp
public string? Label { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.CompassWidget.WidgetType'></a>

## CompassWidget.WidgetType Property

The type of widget

```csharp
public override string WidgetType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

