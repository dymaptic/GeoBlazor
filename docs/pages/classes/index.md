---
layout: default
title: Index
nav_order: 1
parent: 
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')

## dymaptic.GeoBlazor.Core Assembly
### Namespaces

<a name='dymaptic.GeoBlazor.Core'></a>

## dymaptic.GeoBlazor.Core Namespace

| Classes | |
| :--- | :--- |
| [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') | Add this attribute to any property on any subclass of [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent'), and if the user<br/>forgets to set that property, this will throw a [dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')<br/>or [dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException'). This works for both `[Parameter]`<br/>properties as well as Child Components registered with `RegisterChildComponent` |

<a name='dymaptic.GeoBlazor.Core.Components'></a>

## dymaptic.GeoBlazor.Core.Components Namespace

| Classes | |
| :--- | :--- |
| [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') | The abstract base Razor Component class that all GeoBlazor components derive from. |

<a name='dymaptic.GeoBlazor.Core.Components.Geometries'></a>

## dymaptic.GeoBlazor.Core.Components.Geometries Namespace

| Classes | |
| :--- | :--- |
| [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent') | The minimum and maximum X and Y coordinates of a bounding box. Extent is used to describe the visible portion of a MapView. When working in a SceneView, Camera is used to define the visible part of the map within the view.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">ArcGIS JS API</a> |
| [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry') | The base class for geometry objects. This class has no constructor. To construct geometries see [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point'), [PolyLine](dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.html 'dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine'), or [Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon').<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html">ArcGIS JS API</a> |
| [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') | A location defined by X, Y, and Z coordinates.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html">ArcGIS JS API</a> |
| [Polygon](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon') | A polygon contains an array of rings and a spatialReference. Each ring is represented as an array of points. The first and last points of a ring must be the same. A polygon also has boolean-valued hasM and hasZ fields.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html">ArcGIS JS API</a> |
| [PolyLine](dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.html 'dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine') | A polyline contains an array of paths and spatialReference. Each path is represented as an array of points. A polyline also has boolean-valued hasM and hasZ properties.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polyline.html">ArcGIS JS API</a> |
| [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference') | Defines the spatial reference of a view, layer, or method parameters. This indicates the projected or geographic coordinate system used to locate geographic features in the map. Each projected and geographic coordinate system is defined by either a well-known ID (WKID) or a definition string (WKT). Note that for versions prior to ArcGIS 10, only WKID was supported. For a full list of supported spatial reference IDs and their corresponding definition strings, see Using spatial references.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html">ArcGIS JS API</a> |

<a name='dymaptic.GeoBlazor.Core.Components.Layers'></a>

## dymaptic.GeoBlazor.Core.Components.Layers Namespace

| Classes | |
| :--- | :--- |
| [FeatureLayer](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer') | A FeatureLayer is a single layer that can be created from a Map Service or Feature Service; ArcGIS Online or ArcGIS Enterprise portal items; or from an array of client-side features. The layer can be either a spatial (has geographic features) or non-spatial (table).<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">ArcGIS JS API</a> |
| [GeoJSONLayer](dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer') | The GeoJSONLayer class is used to create a layer based on GeoJSON. GeoJSON is a format for encoding a variety of geographic data structures. The GeoJSON data must comply with the RFC 7946 specification which states that the coordinates are in SpatialReference.WGS84.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html">ArcGIS JS API</a> |
| [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') | A Graphic is a vector representation of real world geographic phenomena. It can contain geometry, a symbol, and attributes. A Graphic is displayed in the GraphicsLayer.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html">ArcGIS JS API</a> |
| [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') | The layer is the most fundamental component of a Map. It is a collection of spatial data in the form of vector graphics or raster images that represent real-world phenomena. Layers may contain discrete features that store vector data or continuous cells/pixels that store raster data.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html">ArcGIS JS API</a> |

<a name='dymaptic.GeoBlazor.Core.Components.Views'></a>

## dymaptic.GeoBlazor.Core.Components.Views Namespace

| Classes | |
| :--- | :--- |
| [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') | The Top-Level Map Component Container.<br/>A MapView displays a 2D view of a Map instance. An instance of MapView must be created to render a Map (along with its operational and base layers) in 2D. To render a map and its layers in 3D, see the documentation for SceneView. For a general overview of views, see View.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">ArcGIS JS API</a> |
| [SceneView](dymaptic.GeoBlazor.Core.Components.Views.SceneView.html 'dymaptic.GeoBlazor.Core.Components.Views.SceneView') | A SceneView displays a 3D view of a Map or WebScene instance using WebGL. To render a map and its layers in 2D, see the documentation for MapView. For a general overview of views, see View.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">ArcGIS JS API</a> |

<a name='dymaptic.GeoBlazor.Core.Components.Widgets'></a>

## dymaptic.GeoBlazor.Core.Components.Widgets Namespace

| Classes | |
| :--- | :--- |
| [LayerListWidget](dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget') | Displays a widget with a list of all layers in a view. |

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList'></a>

## dymaptic.GeoBlazor.Core.Components.Widgets.LayerList Namespace

| Classes | |
| :--- | :--- |
| [ActionSection](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionSection.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionSection') | The Action Sections property and corresponding functionality will be fully implemented<br/>in a future iteration.  Currently, a user can view available layers in the layer list widget<br/>and toggle the selected layer's visiblity. More capabilities will be available after full<br/>implementation of ActionSection. |
| [ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem') | The description of a layer for display in a [LayerListWidget](dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget'). |

<a name='dymaptic.GeoBlazor.Core.Objects'></a>

## dymaptic.GeoBlazor.Core.Objects Namespace

| Classes | |
| :--- | :--- |
| [GeographicTransformationStep](dymaptic.GeoBlazor.Core.Objects.GeographicTransformationStep.html 'dymaptic.GeoBlazor.Core.Objects.GeographicTransformationStep') | |

