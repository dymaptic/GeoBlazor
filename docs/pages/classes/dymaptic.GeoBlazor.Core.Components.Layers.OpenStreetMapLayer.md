---
layout: default
title: OpenStreetMapLayer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## OpenStreetMapLayer Class

Allows you to use basemaps from OpenStreetMap. Set the tileservers property to change which OpenStreetMap tiles you  
want to use.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-OpenStreetMapLayer.html">ArcGIS JS API</a>

```csharp
public class OpenStreetMapLayer : dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') &#129106; [WebTileLayer](dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer') &#129106; OpenStreetMapLayer
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer()'></a>

## OpenStreetMapLayer() Constructor

Parameterless constructor for use as a razor component

```csharp
public OpenStreetMapLayer();
```

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.BlendMode_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IList_string_,dymaptic.GeoBlazor.Core.Components.Layers.TileInfo,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_)'></a>

## OpenStreetMapLayer(PortalItem, string, Nullable<BlendMode>, string, Nullable<double>, Nullable<double>, Nullable<double>, IList<string>, TileInfo, Nullable<double>, Nullable<bool>, Nullable<ListMode>) Constructor

Constructor for use in code

```csharp
public OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem? portalItem=null, string? title=null, System.Nullable<dymaptic.GeoBlazor.Core.Components.Layers.BlendMode> blendMode=null, string? copyright=null, System.Nullable<double> maxScale=null, System.Nullable<double> minScale=null, System.Nullable<double> refreshInterval=null, System.Collections.Generic.IList<string>? subDomains=null, dymaptic.GeoBlazor.Core.Components.Layers.TileInfo? tileInfo=null, System.Nullable<double> opacity=null, System.Nullable<bool> visible=null, System.Nullable<dymaptic.GeoBlazor.Core.Components.Layers.ListMode> listMode=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.BlendMode_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IList_string_,dymaptic.GeoBlazor.Core.Components.Layers.TileInfo,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).portalItem'></a>

`portalItem` [PortalItem](dymaptic.GeoBlazor.Core.Components.PortalItem.html 'dymaptic.GeoBlazor.Core.Components.PortalItem')

The portal item from which to load the layer.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.BlendMode_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IList_string_,dymaptic.GeoBlazor.Core.Components.Layers.TileInfo,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).title'></a>

`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The title of the layer used to identify it in places such as the Legend and LayerList widgets.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.BlendMode_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IList_string_,dymaptic.GeoBlazor.Core.Components.Layers.TileInfo,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).blendMode'></a>

`blendMode` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[BlendMode](dymaptic.GeoBlazor.Core.Components.Layers.BlendMode.html 'dymaptic.GeoBlazor.Core.Components.Layers.BlendMode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what  
seems like a new layer.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.BlendMode_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IList_string_,dymaptic.GeoBlazor.Core.Components.Layers.TileInfo,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).copyright'></a>

`copyright` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The attribution information for the layer.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.BlendMode_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IList_string_,dymaptic.GeoBlazor.Core.Components.Layers.TileInfo,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).maxScale'></a>

`maxScale` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The maximum scale (most zoomed in) at which the layer is visible in the view.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.BlendMode_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IList_string_,dymaptic.GeoBlazor.Core.Components.Layers.TileInfo,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).minScale'></a>

`minScale` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The minimum scale (most zoomed out) at which the layer is visible in the view.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.BlendMode_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IList_string_,dymaptic.GeoBlazor.Core.Components.Layers.TileInfo,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).refreshInterval'></a>

`refreshInterval` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Refresh interval of the layer in minutes.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.BlendMode_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IList_string_,dymaptic.GeoBlazor.Core.Components.Layers.TileInfo,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).subDomains'></a>

`subDomains` [System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')

A string of subDomain names where tiles are served to speed up tile retrieval. If subDomains are specified, the  
UrlTemplate should include a {subDomain} place holder.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.BlendMode_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IList_string_,dymaptic.GeoBlazor.Core.Components.Layers.TileInfo,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).tileInfo'></a>

`tileInfo` [TileInfo](dymaptic.GeoBlazor.Core.Components.Layers.TileInfo.html 'dymaptic.GeoBlazor.Core.Components.Layers.TileInfo')

The tiling scheme information for the layer.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.BlendMode_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IList_string_,dymaptic.GeoBlazor.Core.Components.Layers.TileInfo,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).opacity'></a>

`opacity` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The opacity of the layer.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.BlendMode_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IList_string_,dymaptic.GeoBlazor.Core.Components.Layers.TileInfo,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).visible'></a>

`visible` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is  
referenced in a view, but its features will not be visible in the view.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.OpenStreetMapLayer(dymaptic.GeoBlazor.Core.Components.PortalItem,string,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.BlendMode_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IList_string_,dymaptic.GeoBlazor.Core.Components.Layers.TileInfo,System.Nullable_double_,System.Nullable_bool_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.ListMode_).listMode'></a>

`listMode` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[ListMode](dymaptic.GeoBlazor.Core.Components.Layers.ListMode.html 'dymaptic.GeoBlazor.Core.Components.Layers.ListMode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates how the layer should display in the LayerList widget. The possible values are listed below.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OpenStreetMapLayer.LayerType'></a>

## OpenStreetMapLayer.LayerType Property

Used internally to identify the sub type of Layer

```csharp
public override string LayerType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
