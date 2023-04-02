---
layout: default
title: BarChartMediaInfo
parent: Classes
---
---
layout: default
title: BarChartMediaInfo
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## BarChartMediaInfo Class

A BarChartMediaInfo is a type of chart media element that represents a bar chart displayed within a popup.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-BarChartMediaInfo.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class BarChartMediaInfo : dymaptic.GeoBlazor.Core.Components.Popups.MediaInfo
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [MediaInfo](dymaptic.GeoBlazor.Core.Components.Popups.MediaInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.MediaInfo') &#129106; BarChartMediaInfo
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.BarChartMediaInfo.AltText'></a>

## BarChartMediaInfo.AltText Property

Provides an alternate text for an image if the image cannot be displayed.

```csharp
public string? AltText { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.BarChartMediaInfo.Caption'></a>

## BarChartMediaInfo.Caption Property

Defines a caption for the media.

```csharp
public string? Caption { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.BarChartMediaInfo.Title'></a>

## BarChartMediaInfo.Title Property

The title of the media element.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.BarChartMediaInfo.Type'></a>

## BarChartMediaInfo.Type Property

Indicates the type of media

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.BarChartMediaInfo.Value'></a>

## BarChartMediaInfo.Value Property

Defines the chart value.

```csharp
public dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValue? Value { get; set; }
```

#### Property Value
[ChartMediaInfoValue](dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValue.html 'dymaptic.GeoBlazor.Core.Components.Popups.ChartMediaInfoValue')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Popups.BarChartMediaInfo.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## BarChartMediaInfo.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.BarChartMediaInfo.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.BarChartMediaInfo.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## BarChartMediaInfo.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.BarChartMediaInfo.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.BarChartMediaInfo.ValidateRequiredChildren()'></a>

## BarChartMediaInfo.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the  
[RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components

