---
layout: default
title: HighlightOptions
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## HighlightOptions Class

Options for configuring the highlight. Use the highlight method on the appropriate LayerView to highlight a  
feature. With version 4.19, highlighting a feature influences the shadow of the feature as well. By default, the  
shadow of the highlighted feature is displayed in a darker shade.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#highlightOptions">  
    ArcGIS  
    JS API (LayerView)  
</a><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html#highlightOptions">  
    ArcGIS  
    JS API (SceneView)  
</a>

```csharp
public class HighlightOptions : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; HighlightOptions
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.HighlightOptions()'></a>

## HighlightOptions() Constructor

Default Constructor for use as a Blazor Component.

```csharp
public HighlightOptions();
```

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.HighlightOptions(dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_)'></a>

## HighlightOptions(MapColor, MapColor, Nullable<double>, Nullable<double>, MapColor, Nullable<double>, Nullable<double>) Constructor

Constructor for use in C# code.

```csharp
public HighlightOptions(dymaptic.GeoBlazor.Core.Objects.MapColor? color=null, dymaptic.GeoBlazor.Core.Objects.MapColor? haloColor=null, System.Nullable<double> haloOpacity=null, System.Nullable<double> fillOpacity=null, dymaptic.GeoBlazor.Core.Objects.MapColor? shadowColor=null, System.Nullable<double> shadowOpacity=null, System.Nullable<double> shadowDifference=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.HighlightOptions(dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_).color'></a>

`color` [MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor')

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.HighlightOptions(dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_).haloColor'></a>

`haloColor` [MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor')

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.HighlightOptions(dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_).haloOpacity'></a>

`haloOpacity` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.HighlightOptions(dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_).fillOpacity'></a>

`fillOpacity` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.HighlightOptions(dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_).shadowColor'></a>

`shadowColor` [MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor')

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.HighlightOptions(dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_).shadowOpacity'></a>

`shadowOpacity` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.HighlightOptions(dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_double_).shadowDifference'></a>

`shadowDifference` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.Color'></a>

## HighlightOptions.Color Property

The color of the highlight fill.  
DefaultValue: #00ffff

```csharp
public dymaptic.GeoBlazor.Core.Objects.MapColor? Color { get; set; }
```

#### Property Value
[MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor')

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.FillOpacity'></a>

## HighlightOptions.FillOpacity Property

The opacity of the fill (area within the halo). This will be multiplied with the opacity specified in color.  
DefaultValue: 0.25

```csharp
public System.Nullable<double> FillOpacity { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.HaloColor'></a>

## HighlightOptions.HaloColor Property

The color of the halo surrounding the highlight. If no haloColor is provided, then the halo will be colored with  
the specified color.

```csharp
public dymaptic.GeoBlazor.Core.Objects.MapColor? HaloColor { get; set; }
```

#### Property Value
[MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor')

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.HaloOpacity'></a>

## HighlightOptions.HaloOpacity Property

The opacity of the highlight halo. This will be multiplied with any opacity specified in color.  
DefaultValue: 1

```csharp
public System.Nullable<double> HaloOpacity { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.ShadowColor'></a>

## HighlightOptions.ShadowColor Property

The color of the highlighted feature's shadow.  
DefaultValue: #000000

```csharp
public dymaptic.GeoBlazor.Core.Objects.MapColor? ShadowColor { get; set; }
```

#### Property Value
[MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor')

### Remarks
Only supported on 3D scene views.

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.ShadowDifference'></a>

## HighlightOptions.ShadowDifference Property

Defines the intensity of the shadow area obtained by overlapping the shadow of the highlighted feature and the  
shadow of other objects in the scene. The value ranges from 0 to 1. A value of 0 highlights the overlapping shadow  
areas in the same way (no difference). Setting it to 1 highlights only the difference between the shadow areas, so  
the overlapping shadow areas aren't highlighted at all.  
DefaultValue: 0.375

```csharp
public System.Nullable<double> ShadowDifference { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
Only supported on 3D scene views.

<a name='dymaptic.GeoBlazor.Core.Objects.HighlightOptions.ShadowOpacity'></a>

## HighlightOptions.ShadowOpacity Property

The opacity of the highlighted feature's shadow. This will be multiplied with the opacity specified in shadowColor.  
DefaultValue: 0.4

```csharp
public System.Nullable<double> ShadowOpacity { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
Only supported on 3D scene views.
