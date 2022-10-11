---
layout: default
title: Index
nav_order: 1
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')

## dymaptic.GeoBlazor.Core Assembly
### Namespaces

<a name='dymaptic.GeoBlazor.Core'></a>

## dymaptic.GeoBlazor.Core Namespace

| Classes | |
| :--- | :--- |
| [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') | Add this attribute to any property on any subclass of [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent'), and if the user<br/>forgets to set that property, this will throw a [MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')<br/>or [MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException'). This works for both `[Parameter]`<br/>properties as well as Child Components registered with `RegisterChildComponent` |

<a name='dymaptic.GeoBlazor.Core.Components'></a>

## dymaptic.GeoBlazor.Core.Components Namespace

| Classes | |
| :--- | :--- |
| [Basemap](dymaptic.GeoBlazor.Core.Components.Basemap.html 'dymaptic.GeoBlazor.Core.Components.Basemap') | Creates a new basemap object. Basemaps can be created from a PortalItem, from a well known basemap ID, or can be used for creating custom basemaps. These basemaps may be created from tiled services you publish to your own server, or from tiled services published by third parties.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html">ArcGIS JS API</a> |
| [Constraints](dymaptic.GeoBlazor.Core.Components.Constraints.html 'dymaptic.GeoBlazor.Core.Components.Constraints') | Specifies constraints to scale, zoom, and rotation that may be applied to the MapView. The constraints.lods should be set in the MapView constructor, if the map does not have a basemap or when the basemap does not have tileInfo.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#constraints">ArcGIS JS API</a> |
| [CustomOverlay](dymaptic.GeoBlazor.Core.Components.CustomOverlay.html 'dymaptic.GeoBlazor.Core.Components.CustomOverlay') | <a target="_blank" href="">ArcGIS JS API</a> |
| [LOD](dymaptic.GeoBlazor.Core.Components.LOD.html 'dymaptic.GeoBlazor.Core.Components.LOD') | A TileLayer has a number of LODs (Levels of Detail). Each LOD corresponds to a map at a given scale or resolution. LOD has no constructor.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LOD.html">ArcGIS JS API</a> |
| [Map](dymaptic.GeoBlazor.Core.Components.Map.html 'dymaptic.GeoBlazor.Core.Components.Map') | The Map class contains properties and methods for storing, managing, and overlaying layers common to both 2D and 3D viewing. Layers can be added and removed from the map, but are rendered via a MapView (for viewing data in 2D) or a SceneView (for viewing data in 3D). Thus a map instance is a simple container that holds the layers, while the View is the means of displaying and interacting with a map's layers and basemap.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Map.html">ArcGIS JS API</a> |
| [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') | The abstract base Razor Component class that all GeoBlazor components derive from. |
| [Portal](dymaptic.GeoBlazor.Core.Components.Portal.html 'dymaptic.GeoBlazor.Core.Components.Portal') | The Portal class is part of the ArcGIS Enterprise portal that provides a way to build applications that work with content from ArcGIS Online or an ArcGIS Enterprise portal. <br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html">ArcGIS JS API</a> |
| [PortalBasemapsSource](dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource.html 'dymaptic.GeoBlazor.Core.Components.PortalBasemapsSource') | The PortalBasemapsSource class is a Portal-driven Basemap source in the BasemapGalleryViewModel or BasemapGallery widget.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapGallery-support-PortalBasemapsSource.html">ArcGIS JS API</a> |
| [PortalItem](dymaptic.GeoBlazor.Core.Components.PortalItem.html 'dymaptic.GeoBlazor.Core.Components.PortalItem') | An item (a unit of content) in the Portal. Each item has a unique identifier and a well known URL that is independent of the user owning the item. An item may have associated binary or textual data which is available via the item data resource. View the ArcGIS portal API REST documentation for the item for more details.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html">ArcGIS JS API</a> |
| [WebMap](dymaptic.GeoBlazor.Core.Components.WebMap.html 'dymaptic.GeoBlazor.Core.Components.WebMap') | Loads a WebMap from ArcGIS Online or ArcGIS Enterprise portal into a MapView. It defines the content, style, and bookmarks of your webmap, and it can be shared across multiple ArcGIS web and desktop applications.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html">ArcGIS JS API</a> |
| [WebScene](dymaptic.GeoBlazor.Core.Components.WebScene.html 'dymaptic.GeoBlazor.Core.Components.WebScene') | The web scene is the core element of 3D mapping across ArcGIS. It defines the content, style, environment, and slides of your scene and it can be shared across multiple ArcGIS web and desktop applications<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html">ArcGIS JS API</a> |

| Enums | |
| :--- | :--- |
| [OverlayPosition](dymaptic.GeoBlazor.Core.Components.OverlayPosition.html 'dymaptic.GeoBlazor.Core.Components.OverlayPosition') | A collection of possible positions for setting a [Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget') or [CustomOverlay](dymaptic.GeoBlazor.Core.Components.CustomOverlay.html 'dymaptic.GeoBlazor.Core.Components.CustomOverlay') |

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
| [GraphicsLayer](dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer') | A GraphicsLayer contains one or more client-side Graphics. Each graphic in the GraphicsLayer is rendered in a LayerView inside either a SceneView or a MapView. The graphics contain discrete vector geometries that represent real-world phenomena.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GraphicsLayer.html">ArcGIS JS API</a> |
| [Label](dymaptic.GeoBlazor.Core.Components.Layers.Label.html 'dymaptic.GeoBlazor.Core.Components.Layers.Label') | Defines label expressions, symbols, scale ranges, label priorities, and label placement options for labels on a layer. See the Labeling guide for more information about labeling.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html">ArcGIS JS API</a> |
| [LabelExpressionInfo](dymaptic.GeoBlazor.Core.Components.Layers.LabelExpressionInfo.html 'dymaptic.GeoBlazor.Core.Components.Layers.LabelExpressionInfo') | If working with a MapImageLayer that supports Arcade, you can also use labelExpressionInfo. To determine this, check the supportsArcadeExpressionForLabeling property. If true, then labelExpression or labelExpressionInfo can be used. If false, then only labelExpression can be used.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#labelExpressionInfo">ArcGIS JS API</a> |
| [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') | The layer is the most fundamental component of a Map. It is a collection of spatial data in the form of vector graphics or raster images that represent real-world phenomena. Layers may contain discrete features that store vector data or continuous cells/pixels that store raster data.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html">ArcGIS JS API</a> |
| [LayerObject](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject') | Abstract base class for objects that are a child of a [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') and have a [Symbol](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html#dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol') property. |
| [SizeVariable](dymaptic.GeoBlazor.Core.Components.Layers.SizeVariable.html 'dymaptic.GeoBlazor.Core.Components.Layers.SizeVariable') | The size visual variable defines the size of individual features in a layer based on a numeric (often thematic) value.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html">ArcGIS JS API</a> |
| [TileLayer](dymaptic.GeoBlazor.Core.Components.Layers.TileLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.TileLayer') | The TileLayer allows you work with a cached map service exposed by the ArcGIS Server REST API and add it to a Map as a tile layer. A cached service accesses tiles from a cache instead of dynamically rendering images. Because they are cached, tiled layers render faster than MapImageLayers. To create an instance of TileLayer, you must reference the URL of the cached map service.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-TileLayer.html">ArcGIS JS API</a> |
| [VectorTileLayer](dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer') | VectorTileLayer accesses cached tiles of data and renders it in vector format. It is similar to a WebTileLayer in the context of caching; however, a WebTileLayer renders as a series of images, not vector data. Unlike raster tiles, vector tiles can adapt to the resolution of their display device and can be restyled for multiple uses. VectorTileLayer delivers styled maps while taking advantage of cached raster map tiles with vector map data.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html">ArcGIS JS API</a> |
| [VisualVariable](dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.html 'dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable') | The visual variable base class. See each of the subclasses that extend this class to learn how to create continuous data-driven thematic visualizations.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-VisualVariable.html">ArcGIS JS API</a> |

| Enums | |
| :--- | :--- |
| [VisualVariableType](dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType.html 'dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType') | A collection of [VisualVariable](dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.html 'dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable') Types |

<a name='dymaptic.GeoBlazor.Core.Components.Popups'></a>

## dymaptic.GeoBlazor.Core.Components.Popups Namespace

| Classes | |
| :--- | :--- |
| [FieldInfo](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo') | The FieldInfo class defines how a Field participates, or in some cases, does not participate, in a PopupTemplate.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-FieldInfo.html">ArcGIS JS API</a> |
| [FieldInfoFormat](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat') | The FieldInfoFormat class is used with numerical or date fields to provide more detail about how the value should be displayed in a popup. Use this class in place of the legacy formatting functions: DateString, DateFormat, and/or NumberFormat.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-support-FieldInfoFormat.html">ArcGIS JS API</a> |
| [FieldsPopupContent](dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent') | A FieldsContent popup element represents the FieldInfo associated with a feature. If this is not set within the content, it will revert to whatever may be set within the PopupTemplate.fieldInfos property.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-FieldsContent.html">ArcGIS JS API</a> |
| [PopupContent](dymaptic.GeoBlazor.Core.Components.Popups.PopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupContent') | Abstract base class, PopupContent elements define what should display within the PopupTemplate content.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-Content.html">ArcGIS JS API</a> |
| [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate') | A PopupTemplate formats and defines the content of a Popup for a specific Layer or Graphic. The user can also use the PopupTemplate to access values from feature attributes and values returned from Arcade expressions when a feature in the view is selected.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-PopupTemplate.html">ArcGIS JS API</a> |

<a name='dymaptic.GeoBlazor.Core.Components.Renderers'></a>

## dymaptic.GeoBlazor.Core.Components.Renderers Namespace

| Classes | |
| :--- | :--- |
| [Renderer](dymaptic.GeoBlazor.Core.Components.Renderers.Renderer.html 'dymaptic.GeoBlazor.Core.Components.Renderers.Renderer') | Abstract base class, renderers define how to visually represent each feature in one of the following layer types: FeatureLayer, SceneLayer, MapImageLayer, CSVLayer, GeoJSONLayer, OGCFeatureLayer, StreamLayer, WFSLayer.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-Renderer.html">ArcGIS JS API</a> |
| [SimpleRenderer](dymaptic.GeoBlazor.Core.Components.Renderers.SimpleRenderer.html 'dymaptic.GeoBlazor.Core.Components.Renderers.SimpleRenderer') | SimpleRenderer renders all features in a Layer with one Symbol. This renderer may be used to simply visualize the location of geographic features.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-SimpleRenderer.html">ArcGIS JS API</a> |

| Enums | |
| :--- | :--- |
| [RendererType](dymaptic.GeoBlazor.Core.Components.Renderers.RendererType.html 'dymaptic.GeoBlazor.Core.Components.Renderers.RendererType') | A collection of renderer types |

<a name='dymaptic.GeoBlazor.Core.Components.Symbols'></a>

## dymaptic.GeoBlazor.Core.Components.Symbols Namespace

| Classes | |
| :--- | :--- |
| [FillSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.FillSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.FillSymbol') | Fill symbols are used to draw Polygon graphics in a GraphicsLayer or a FeatureLayer in a 2D MapView. To create new fill symbols, use either SimpleFillSymbol or PictureFillSymbol.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-FillSymbol.html">ArcGIS JS API</a> |
| [LineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.LineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.LineSymbol') | Abstract class. Line symbols are used to draw Polyline features in a FeatureLayer in a 2D MapView.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-LineSymbol.html">ArcGIS JS API</a> |
| [MarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.MarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MarkerSymbol') | Marker symbols are used to draw Point graphics in a FeatureLayer or individual graphics in a 2D MapView. To create new marker symbols, use either SimpleMarkerSymbol or PictureMarkerSymbol.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-MarkerSymbol.html">ArcGIS JS API</a> |
| [Outline](dymaptic.GeoBlazor.Core.Components.Symbols.Outline.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Outline') | A convenience sub-class of [SimpleLineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol') for defining outlines of other symbols. |
| [SimpleFillSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleFillSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleFillSymbol') | SimpleFillSymbol is used for rendering 2D polygons in either a MapView or a SceneView. It can be filled with a solid color, or a pattern. In addition, the symbol can have an optional outline, which is defined by a SimpleLineSymbol.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleFillSymbol.html">ArcGIS JS API</a> |
| [SimpleLineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol') | SimpleLineSymbol is used for rendering 2D polyline geometries in a 2D MapView. SimpleLineSymbol is also used for rendering outlines for marker symbols and fill symbols.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html">ArcGIS JS API</a> |
| [SimpleMarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol') | |
| [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') | |
| [TextSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol') | Text symbols are used to define the graphic for displaying labels on a FeatureLayer, CSVLayer, Sublayer, and StreamLayer in a 2D MapView. Text symbols can also be used to define the symbol property of Graphic if the geometry type is Point or Multipoint. With this class, you may alter the color, font, halo, and other properties of the label graphic.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-TextSymbol.html">ArcGIS JS API</a> |

| Enums | |
| :--- | :--- |
| [FillStyle](dymaptic.GeoBlazor.Core.Components.Symbols.FillStyle.html 'dymaptic.GeoBlazor.Core.Components.Symbols.FillStyle') | The possible fill style for the [SimpleFillSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleFillSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleFillSymbol') |
| [LineStyle](dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle.html 'dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle') | Possible line style values for [SimpleLineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol') |

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
| [BasemapGalleryWidget](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapGalleryWidget') | The BasemapGallery widget displays a collection images representing basemaps from ArcGIS.com or a user-defined set of map or image services. When a new basemap is selected from the BasemapGallery, the map's basemap layers are removed and replaced with the basemap layers of the associated basemap selected in the gallery.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapGallery.html">ArcGIS JS API</a> |
| [BasemapToggleWidget](dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.BasemapToggleWidget') | The BasemapToggle provides a widget which allows an end-user to switch between two basemaps. The toggled basemap is set inside the view's map object.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapToggle.html">ArcGIS JS API</a> |
| [CompassWidget](dymaptic.GeoBlazor.Core.Components.Widgets.CompassWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.CompassWidget') | The Compass widget indicates where north is in relation to the current view rotation or camera heading. Clicking the Compass widget rotates the view to face north (heading = 0). This widget is added to a SceneView by default. The icon for the Compass widget is determined based upon the view's spatial reference. If the view's spatial reference is not Web Mercator or WGS84 a dial icon will be used, however when the spatial reference is Web Mercator or WGS84 the icon will be a north arrow.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Compass.html">ArcGIS JS API</a> |
| [HomeWidget](dymaptic.GeoBlazor.Core.Components.Widgets.HomeWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.HomeWidget') | Provides a simple widget that switches the View to its initial Viewpoint or a previously defined viewpoint.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Home.html">ArcGIS JS API</a> |
| [LayerListWidget](dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerListWidget') | The LayerList widget provides a way to display a list of layers, and switch on/off their visibility. The ListItem API provides access to each layer's properties, allows the developer to configure actions related to the layer, and allows the developer to add content to the item related to the layer.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html">ArcGIS JS API</a> |
| [LegendWidget](dymaptic.GeoBlazor.Core.Components.Widgets.LegendWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LegendWidget') | The Legend widget describes the symbols used to represent layers in a map. All symbols and text used in this widget are configured in the Renderer of the layer. The legend will only display layers and sublayers that are visible in the view.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html">ArcGIS JS API</a> |
| [LocateWidget](dymaptic.GeoBlazor.Core.Components.Widgets.LocateWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LocateWidget') | Provides a simple widget that animates the View to the user's current location. The view rotates according to the direction where the tracked device is heading towards.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Locate.html">ArcGIS JS API</a> |
| [ScaleBarWidget](dymaptic.GeoBlazor.Core.Components.Widgets.ScaleBarWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.ScaleBarWidget') | The ScaleBar widget displays a scale bar on the map or in a specified HTML node. The widget respects various coordinate systems and displays units in metric or non-metric values. Metric values shows either kilometers or meters depending on the scale, and likewise non-metric values shows miles and feet depending on the scale.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-ScaleBar.html">ArcGIS JS API</a> |
| [SearchWidget](dymaptic.GeoBlazor.Core.Components.Widgets.SearchWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.SearchWidget') | The Search widget provides a way to perform search operations on locator service(s), map/feature service feature layer(s), SceneLayers with an associated feature layer, BuildingComponentSublayer with an associated feature layer, GeoJSONLayer, CSVLayer, OGCFeatureLayer, and/or table(s). If using a locator with a geocoding service, the findAddressCandidates operation is used, whereas queries are used on feature layers.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html">ArcGIS JS API</a> |
| [Widget](dymaptic.GeoBlazor.Core.Components.Widgets.Widget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.Widget') | The base class for widgets. Each widget's presentation is separate from its properties, methods, and data.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html">ArcGIS JS API</a> |

| Enums | |
| :--- | :--- |
| [ScaleUnit](dymaptic.GeoBlazor.Core.Components.Widgets.ScaleUnit.html 'dymaptic.GeoBlazor.Core.Components.Widgets.ScaleUnit') | Possible unit values for the [ScaleBarWidget](dymaptic.GeoBlazor.Core.Components.Widgets.ScaleBarWidget.html 'dymaptic.GeoBlazor.Core.Components.Widgets.ScaleBarWidget') |

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerList'></a>

## dymaptic.GeoBlazor.Core.Components.Widgets.LayerList Namespace

| Classes | |
| :--- | :--- |
| [ActionBase](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ActionBase') | Actions are customizable behavior which can be executed in certain widgets such as Popups, a BasemapLayerList, or a LayerList.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html">ArcGIS JS API</a> |
| [ListItem](dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem.html 'dymaptic.GeoBlazor.Core.Components.Widgets.LayerList.ListItem') | The ListItem class represents one of the operationalItems in the LayerListViewModel. In the LayerList widget UI, the list item represents a layer displayed in the view. It provides access to the associated layer's properties, allows the developer to configure actions related to the layer, and allows the developer to add content to the item related to the layer.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList-ListItem.html#actionsSections">ArcGIS JS API</a> |

<a name='dymaptic.GeoBlazor.Core.Exceptions'></a>

## dymaptic.GeoBlazor.Core.Exceptions Namespace

| Classes | |
| :--- | :--- |
| [InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException') | Exception thrown when a component is added to the wrong type of parent component. |
| [JavascriptException](dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptException') | Converts a JavaScript Error into a .NET Exception |
| [MissingMapException](dymaptic.GeoBlazor.Core.Exceptions.MissingMapException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingMapException') | Exception when a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is created with no [Map](dymaptic.GeoBlazor.Core.Components.Map.html 'dymaptic.GeoBlazor.Core.Components.Map') or [WebMap](dymaptic.GeoBlazor.Core.Components.WebMap.html 'dymaptic.GeoBlazor.Core.Components.WebMap') |
| [MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException') | An exception that specifies that a required child component was not added to the parent. |
| [MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException') | An exception that specifies that none of the choices of required child components were added. |

<a name='dymaptic.GeoBlazor.Core.Model'></a>

## dymaptic.GeoBlazor.Core.Model Namespace

| Classes | |
| :--- | :--- |
| [LogicComponent](dymaptic.GeoBlazor.Core.Model.LogicComponent.html 'dymaptic.GeoBlazor.Core.Model.LogicComponent') | A base class for non-map components, such as GeometryEngine, Projection, etc. |
| [Projection](dymaptic.GeoBlazor.Core.Model.Projection.html 'dymaptic.GeoBlazor.Core.Model.Projection') | A client-side projection engine for converting geometries from one SpatialReference to another. When projecting geometries the starting spatial reference must be specified on the input geometry. You can specify a specific geographic (datum) transformation for the project operation, or accept the default transformation if one is needed.<br/><a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-projection.html">ArcGIS JS API</a> |

<a name='dymaptic.GeoBlazor.Core.Objects'></a>

## dymaptic.GeoBlazor.Core.Objects Namespace

| Classes | |
| :--- | :--- |
| [AddressCandidate](dymaptic.GeoBlazor.Core.Objects.AddressCandidate.html 'dymaptic.GeoBlazor.Core.Objects.AddressCandidate') | <a target="_blank" href="">ArcGIS JS API</a> |
| [Direction](dymaptic.GeoBlazor.Core.Objects.Direction.html 'dymaptic.GeoBlazor.Core.Objects.Direction') | <a target="_blank" href="">ArcGIS JS API</a> |
| [Feature](dymaptic.GeoBlazor.Core.Objects.Feature.html 'dymaptic.GeoBlazor.Core.Objects.Feature') | <a target="_blank" href="">ArcGIS JS API</a> |
| [GeographicTransformation](dymaptic.GeoBlazor.Core.Objects.GeographicTransformation.html 'dymaptic.GeoBlazor.Core.Objects.GeographicTransformation') | <a target="_blank" href="">ArcGIS JS API</a> |
| [GeographicTransformationStep](dymaptic.GeoBlazor.Core.Objects.GeographicTransformationStep.html 'dymaptic.GeoBlazor.Core.Objects.GeographicTransformationStep') | <a target="_blank" href="">ArcGIS JS API</a> |
| [MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor') | <a target="_blank" href="">ArcGIS JS API</a> |
| [MapPath](dymaptic.GeoBlazor.Core.Objects.MapPath.html 'dymaptic.GeoBlazor.Core.Objects.MapPath') | <a target="_blank" href="">ArcGIS JS API</a> |
| [MapRing](dymaptic.GeoBlazor.Core.Objects.MapRing.html 'dymaptic.GeoBlazor.Core.Objects.MapRing') | <a target="_blank" href="">ArcGIS JS API</a> |
| [MapRings](dymaptic.GeoBlazor.Core.Objects.MapRings.html 'dymaptic.GeoBlazor.Core.Objects.MapRings') | <a target="_blank" href="">ArcGIS JS API</a> |
| [PopupOptions](dymaptic.GeoBlazor.Core.Objects.PopupOptions.html 'dymaptic.GeoBlazor.Core.Objects.PopupOptions') | <a target="_blank" href="">ArcGIS JS API</a> |
| [Query](dymaptic.GeoBlazor.Core.Objects.Query.html 'dymaptic.GeoBlazor.Core.Objects.Query') | <a target="_blank" href="">ArcGIS JS API</a> |
| [SelectResult](dymaptic.GeoBlazor.Core.Objects.SelectResult.html 'dymaptic.GeoBlazor.Core.Objects.SelectResult') | <a target="_blank" href="">ArcGIS JS API</a> |

| Enums | |
| :--- | :--- |
| [ArealUnit](dymaptic.GeoBlazor.Core.Objects.ArealUnit.html 'dymaptic.GeoBlazor.Core.Objects.ArealUnit') | <a target="_blank" href="">ArcGIS JS API</a> |
| [LinearUnit](dymaptic.GeoBlazor.Core.Objects.LinearUnit.html 'dymaptic.GeoBlazor.Core.Objects.LinearUnit') | <a target="_blank" href="">ArcGIS JS API</a> |
| [SpatialRelationship](dymaptic.GeoBlazor.Core.Objects.SpatialRelationship.html 'dymaptic.GeoBlazor.Core.Objects.SpatialRelationship') | <a target="_blank" href="">ArcGIS JS API</a> |

