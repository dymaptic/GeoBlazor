---
layout: default
title: PopupOpenOptions
parent: Classes
---
---
layout: default
title: PopupOpenOptions
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## PopupOpenOptions Class

Defines the location and content of the popup when opened with [OpenPopup(PopupOpenOptions)](dymaptic.GeoBlazor.Core.Components.Views.MapView.html#dymaptic.GeoBlazor.Core.Components.Views.MapView.OpenPopup(dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions) 'dymaptic.GeoBlazor.Core.Components.Views.MapView.OpenPopup(dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions)')

```csharp
public class PopupOpenOptions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PopupOpenOptions
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions.Collapsed'></a>

## PopupOpenOptions.Collapsed Property

When true, indicates that only the popup header will display.

```csharp
public System.Nullable<bool> Collapsed { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions.FeatureMenuOpen'></a>

## PopupOpenOptions.FeatureMenuOpen Property

This property enables multiple features in a popup to display in a list rather than displaying the first selected  
feature. Setting this to true allows the user to scroll through the list of features returned from the query and  
choose the selection they want to display within the popup.

```csharp
public System.Nullable<bool> FeatureMenuOpen { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions.Features'></a>

## PopupOpenOptions.Features Property

Sets the popup's features, which populate the title and content of the popup based on each graphic's PopupTemplate.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Graphic[]? Features { get; set; }
```

#### Property Value
[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions.FetchFeatures'></a>

## PopupOpenOptions.FetchFeatures Property

When true, indicates the popup should fetch the content of this feature and display it. If no PopupTemplate exists,  
a default template is created for the layer if defaultPopupTemplateEnabled = true. In order for this option to  
work, there must be a valid view and location set.

```csharp
public System.Nullable<bool> FetchFeatures { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions.Location'></a>

## PopupOpenOptions.Location Property

Sets the popup's location, which is the geometry used to position the popup.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Geometry? Location { get; set; }
```

#### Property Value
[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions.ShouldFocus'></a>

## PopupOpenOptions.ShouldFocus Property

When true, indicates that the focus should be on the popup after it has been opened.

```csharp
public System.Nullable<bool> ShouldFocus { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions.StringContent'></a>

## PopupOpenOptions.StringContent Property

Sets the content of the popup to a raw or html string.

```csharp
public string? StringContent { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions.Title'></a>

## PopupOpenOptions.Title Property

Sets the title of the popup.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions.UpdateLocationEnabled'></a>

## PopupOpenOptions.UpdateLocationEnabled Property

When true indicates the popup should update its location for each paginated feature based on the selected feature's  
geometry.

```csharp
public System.Nullable<bool> UpdateLocationEnabled { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.PopupOpenOptions.WidgetContent'></a>

## PopupOpenOptions.WidgetContent Property

Sets the content of the popup to a [Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget').

```csharp
public dymaptic.GeoBlazor.Core.Components.Widgets.Widget? WidgetContent { get; set; }
```

#### Property Value
[Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget')

