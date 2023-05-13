---
layout: default
title: GeoRSSLayer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## GeoRSSLayer Class

The GeoRSSLayer class is used to create a layer based on GeoRSS. GeoRSS is a way to add geographic information to  
an RSS feed. The GeoRSSLayer supports both GeoRSS-Simple and GeoRSS GML encodings, and multiple geometry types.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoRSSLayer.html">ArcGIS JS API</a>

```csharp
public class GeoRSSLayer : dymaptic.GeoBlazor.Core.Components.Layers.Layer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') &#129106; GeoRSSLayer
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer.GeoRSSLayer()'></a>

## GeoRSSLayer() Constructor

Parameterless constructor for use as a razor component

```csharp
public GeoRSSLayer();
```

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer.GeoRSSLayer(string,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_)'></a>

## GeoRSSLayer(string, string, Nullable<double>, Nullable<bool>, Nullable<ListMode>) Constructor

Constructor for use in code

```csharp
public GeoRSSLayer(string url, string? title=null, System.Nullable<double> opacity=null, System.Nullable<bool> visible=null, System.Nullable<dymaptic.GeoBlazor.Core.Components.Layers.ListMode> listMode=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer.GeoRSSLayer(string,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The url for the GeoRSS source data.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer.GeoRSSLayer(string,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).title'></a>

`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The title of the layer used to identify it in places such as the Legend and LayerList widgets.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer.GeoRSSLayer(string,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).opacity'></a>

`opacity` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The opacity of the layer.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer.GeoRSSLayer(string,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).visible'></a>

`visible` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is  
referenced in a view, but its features will not be visible in the view.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer.GeoRSSLayer(string,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).listMode'></a>

`listMode` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[ListMode](dymaptic.GeoBlazor.Core.Components.Layers.ListMode.html 'dymaptic.GeoBlazor.Core.Components.Layers.ListMode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates how the layer should display in the LayerList widget. The possible values are listed below.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer.LayerType'></a>

## GeoRSSLayer.LayerType Property

Used internally to identify the sub type of Layer

```csharp
public override string LayerType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer.Url'></a>

## GeoRSSLayer.Url Property

The url for the GeoRSS source data.

```csharp
public string? Url { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
