import esriConfig from "@arcgis/core/config";
import * as geometryEngine from "@arcgis/core/geometry/geometryEngine";
import * as projection from "@arcgis/core/geometry/projection";
import Basemap from "@arcgis/core/Basemap";
import Map from "@arcgis/core/Map";
import SceneView from "@arcgis/core/views/SceneView";
import MapView from "@arcgis/core/views/MapView";
import WebMap from "@arcgis/core/WebMap";
import WebScene from "@arcgis/core/WebScene";
import * as route from "@arcgis/core/rest/route";
import RouteParameters from "@arcgis/core/rest/support/RouteParameters";
import FeatureSet from "@arcgis/core/rest/support/FeatureSet";
import ServiceAreaParameters from "@arcgis/core/rest/support/ServiceAreaParameters";
import * as serviceArea from "@arcgis/core/rest/serviceArea";
import Graphic from "@arcgis/core/Graphic";
import Point from "@arcgis/core/geometry/Point";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import * as locator from "@arcgis/core/rest/locator";
import BasemapGallery from "@arcgis/core/widgets/BasemapGallery";
import ScaleBar from "@arcgis/core/widgets/ScaleBar";
import Legend from "@arcgis/core/widgets/Legend";
import PortalBasemapsSource from "@arcgis/core/widgets/BasemapGallery/support/PortalBasemapsSource";
import Portal from "@arcgis/core/portal/Portal";
import BasemapToggle from "@arcgis/core/widgets/BasemapToggle";
import Search from "@arcgis/core/widgets/Search";
import Locate from "@arcgis/core/widgets/Locate";
import Widget from "@arcgis/core/widgets/Widget";
import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import Layer from "@arcgis/core/layers/Layer";
import VectorTileLayer from "@arcgis/core/layers/VectorTileLayer";
import TileLayer from "@arcgis/core/layers/TileLayer";
import GeoJSONLayer from "@arcgis/core/layers/GeoJSONLayer";
import PopupTemplate from "@arcgis/core/PopupTemplate";
import Query from "@arcgis/core/rest/support/Query";
import View from "@arcgis/core/views/View";
import ArcGisSymbol from "@arcgis/core/symbols/Symbol";
import Accessor from "@arcgis/core/core/Accessor";

import Home from "@arcgis/core/widgets/Home";
import Compass from "@arcgis/core/widgets/Compass";
import {
    DotNetExtent, DotNetGeometry,
    DotNetGraphic,
    DotNetPoint, DotNetSpatialReference,
    MapCollection
} from "ArcGisDefinitions";
import {
    buildDotNetExtent,
    buildDotNetFeature,
    buildDotNetGraphic,
    buildDotNetPoint,
    buildDotNetGeometry, buildDotNetSpatialReference
} from "./dotNetBuilder";
import Extent from "@arcgis/core/geometry/Extent";
import {build} from "esbuild";
import Geometry from "@arcgis/core/geometry/Geometry";
import {buildJsSpatialReference} from "./jsBuilder";

export let arcGisObjectRefs: Record<string, Accessor> = {};
export let dotNetRefs = {};
export let queryLayer: FeatureLayer;
export { projection, geometryEngine };


export async function buildMapView(id: string, dotNetReference: any, long: number, lat: number,
                                   rotation: number, mapObject: any, zoom: number, scale: number, 
                                   apiKey: string, mapType: string, widgets: any, graphics: any, 
                                   spatialReference: any, zIndex?: number, tilt?: number): Promise<void> {
    console.log("render map");
    try {
        setWaitCursor(id);
        let dotNetRef = dotNetReference;
        dotNetRefs[id] = dotNetRef;
        if (esriConfig.apiKey === undefined) {
            esriConfig.apiKey = apiKey;
        }
        disposeView(id);
        let view: View;

        let basemap: Basemap;
        let basemapLayers: any[] = [];
        if (!mapType.startsWith('web')) {
            if (mapObject.arcGISDefaultBasemap !== undefined &&
                mapObject.arcGISDefaultBasemap !== null) {
                basemap = mapObject.arcGISDefaultBasemap;
            } else if (mapObject.basemap?.portalItem?.id !== undefined &&
                mapObject.basemap?.portalItem?.id !== null) {
                basemap = new Basemap({
                    portalItem: {
                        id: mapObject.basemap.portalItem.id
                    }
                });
            } else {
                if (mapObject.basemap?.layers.length > 0) {
                    for (let i = 0; i < mapObject.basemap.layers.length; i++) {
                        const layerObject = mapObject.basemap.layers[i];
                        basemapLayers.push(layerObject);
                    }
                }
                basemap = new Basemap({
                    baseLayers: []
                });
            }
        }

        switch (mapType) {
            case 'webmap':
                const webMap = new WebMap({
                    portalItem: {
                        id: mapObject.portalItem.id
                    }
                });
                view = new MapView({
                    container: `map-container-${id}`,
                    map: webMap
                });
                break;
            case 'webscene':
                const webScene = new WebScene({
                    portalItem: {
                        id: mapObject.portalItem.id
                    }
                });
                view = new SceneView({
                    container: `map-container-${id}`,
                    map: webScene
                });
                break;
            case 'scene':
                const scene = new Map({
                    basemap: basemap!,
                    ground: mapObject.ground
                });
                view = new SceneView({
                    container: `map-container-${id}`,
                    map: scene,
                    camera: {
                        position: {
                            x: long, //Longitude
                            y: lat, //Latitude
                            z: zIndex //Meters
                        },
                        tilt: tilt
                    }
                });
                break;
            default:
                const map = new Map({
                    basemap: basemap!,
                    ground: mapObject.ground
                });
                let center;
                let spatialRef;
                if (spatialReference !== undefined && spatialReference !== null) {
                    spatialRef = buildJsSpatialReference(spatialReference);
                    center = new Point({
                        latitude: lat,
                        longitude: long,
                        spatialReference: spatialRef
                    });
                    center = await resetCenterToSpatialReference(center, spatialRef);
                } else {
                    center = [long, lat];
                }
                view = new MapView({
                    map: map,
                    center: center,
                    container: `map-container-${id}`,
                    rotation: rotation
                });
                if (scale !== undefined && scale !== null) {
                    (view as MapView).scale = scale;
                } else {
                    (view as MapView).zoom = zoom;
                }

                if (spatialRef !== undefined && spatialRef !== null) {
                    view.spatialReference = spatialRef;
                }
                break;
        }

        arcGisObjectRefs[id] = view;
        waitForRender(id, dotNetRef);

        if (mapObject.layers !== undefined && mapObject.layers !== null) {
            for (const layerObject of mapObject.layers) {
                await addLayer(layerObject, id);
            }
        }

        for (const l of basemapLayers) {
            await addLayer(l, id, true);
        }

        for (const widget of widgets) {
            await addWidget(widget, id);
        }

        graphics.forEach(graphicObject => {
            addGraphic(graphicObject, id);
        })

        view.on('click', (evt) => {
            dotNetRef.invokeMethodAsync('OnJavascriptClick', buildDotNetPoint(evt.mapPoint));
        });

        view.on('pointer-move', (evt) => {
            let point = (view as MapView).toMap({
                x: evt.x,
                y: evt.y
            });
            dotNetRef.invokeMethodAsync('OnJavascriptPointerMove', buildDotNetPoint(point));
        });

        view.watch('spatialReference', () => {
            dotNetRef.invokeMethodAsync('OnSpatialReferenceChanged', buildDotNetSpatialReference(view.spatialReference));
        });
        
        unsetWaitCursor(id);
    } catch (error) {
        logError(error, id);
    }
}

export function disposeView(viewId: string): void {
    try {
        let view = arcGisObjectRefs[viewId];
        view?.destroy();
        delete arcGisObjectRefs.viewId;
    } catch (error) {
        logError(error, viewId);
    }
}

export function disposeMapComponent(componentId: string, viewId: string): void {
    try {
        let component = arcGisObjectRefs[componentId];
        switch (component?.declaredClass) {
            case 'esri.Graphic':
                let graphic = component as Graphic;
                (graphic.layer as GraphicsLayer).graphics.remove(graphic);
                break;
        }
        component?.destroy();
        delete arcGisObjectRefs[componentId];
        let view = arcGisObjectRefs[viewId] as View;
        view?.ui?.remove(component as any);
    } catch (error) {
        logError(error, viewId);
    }
}

export function updateView(property: string, value: number, viewId: string): void {
    try {
        setWaitCursor(viewId);
        let view = arcGisObjectRefs[viewId] as MapView;
        switch (property) {
            case 'Longitude':
                view.center = new Point({ longitude: value, latitude: view.center.latitude });
                break;
            case 'Latitude':
                view.center = new Point({ longitude: view.center.longitude, latitude: value });
                break;
            case 'Zoom':
                view.zoom = value;
                break;
            case 'Rotation':
                view.rotation = value;
        }
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}


export async function queryFeatureLayer(queryObject: any, layerObject: any, symbol: any, popupTemplateObject: any, 
                                  viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
        let query = new Query ({
            where: queryObject.where,
            outFields: queryObject.outFields,
            returnGeometry: queryObject.returnGeometry,
            spatialRelationship: queryObject.spatialRelationship,
        });
        if (queryObject.useViewExtent) {
            let view = arcGisObjectRefs[viewId] as MapView;
            query.geometry = view.extent;
        } else if (queryObject.geometry !== undefined && queryObject.geometry !== null) {
            query.geometry = queryObject.geometry;
        }
        let popupTemplate = buildPopupTemplate(popupTemplateObject);
        await addLayer(layerObject, viewId, false, true, () => {
            displayQueryResults(query, symbol, popupTemplate, viewId);
        });
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}


export async function updateGraphicsLayer(layerObject: any, layerId: string, viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
        console.log('update graphics layer');
        removeGraphicsLayer(viewId, layerId);
        await addLayer(layerObject, viewId);
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function removeGraphicsLayer(viewId: string, layerId: string): void {
    try {
        setWaitCursor(viewId);
        console.log('remove graphics layer');
        let view = arcGisObjectRefs[viewId] as View;
        let layer = arcGisObjectRefs[layerId!] as Layer;
        view?.map?.remove(layer);
        layer?.destroy();        
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function updateGraphic(graphicObject: any, layerIndex: number, viewId: string): void {
    try {
        setWaitCursor(viewId);
        let oldGraphic = arcGisObjectRefs[graphicObject.id] as Graphic;
        let gLayer: GraphicsLayer | null = null;
        let view = arcGisObjectRefs[viewId] as View;
        if (layerIndex === undefined || layerIndex === null) {
            if (oldGraphic !== undefined && oldGraphic !== null) {
                view.graphics.remove(oldGraphic);
            } else {
                view.graphics.removeAt(graphicObject.graphicIndex);
            }
        } else {
            gLayer = (view.map.layers as MapCollection).items.filter(l => l.type === "graphics")[layerIndex] as GraphicsLayer;
            if (gLayer !== undefined && gLayer !== null) {
                if (oldGraphic !== undefined && oldGraphic !== null) {
                    gLayer.graphics.remove(oldGraphic);
                } else {
                    gLayer.graphics.removeAt(graphicObject.graphicIndex);
                }
            }
        }
        addGraphic(graphicObject, viewId, gLayer);
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function removeGraphicAtIndex(index: number, layerIndex: number, viewId: string): void {
    try {
        setWaitCursor(viewId);
        let view = arcGisObjectRefs[viewId] as View;
        if (layerIndex === undefined || layerIndex === null) {
            view.graphics.removeAt(index);
        } else {
            let gLayer = (view?.map?.layers as MapCollection).items.filter(l => l.type === "graphics")[layerIndex];
            gLayer?.graphics?.removeAt(index);
        }
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export async function updateFeatureLayer(layerObject: any, viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
        removeFeatureLayer(layerObject, viewId);
        await addLayer(layerObject, viewId);
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function removeFeatureLayer(layerObject: any, viewId: string): void {
    try {
        setWaitCursor(viewId);
        let featureLayer = arcGisObjectRefs[layerObject.id] as Layer;
        let view = arcGisObjectRefs[viewId] as View;
        view?.map?.remove(featureLayer);
        featureLayer?.destroy();
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function findPlaces(addressQueryParams: any, symbol: any, popupTemplateObject: any, viewId: string): void {
    try {
        setWaitCursor(viewId);
        let view = arcGisObjectRefs[viewId] as MapView;
        locator.addressToLocations(addressQueryParams.locatorUrl, {
            location: view.center,
            categories: addressQueryParams.categories,
            maxLocations: addressQueryParams.maxLocations,
            outFields: addressQueryParams.outFields,
            address: null
        })
            .then(function (results) {
                view.popup.close();
                view.graphics.removeAll();
                let popupTemplate = buildPopupTemplate(popupTemplateObject);
                results.forEach(function (result) {
                    view.graphics.add(new Graphic({
                        attributes: result.attributes,
                        geometry: result.location,
                        symbol: symbol,
                        popupTemplate: popupTemplate
                    }))
                });
                unsetWaitCursor(viewId);
            }).catch((error) => {
            logError(error, viewId)
        });
    } catch (error) {
        logError(error, viewId);
    }
}


export async function showPopup(popupTemplateObject: any, location: any, viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
        let popupTemplate = buildPopupTemplate(popupTemplateObject);
        (arcGisObjectRefs[viewId] as View).popup.open({
            title: popupTemplate.title as string,
            content: popupTemplate.content as string,
            location: location
        });
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}


export async function showPopupWithGraphic(graphicObject: any, options: any, viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
        addGraphic(graphicObject, viewId);
        let view = arcGisObjectRefs[viewId] as View;
        let graphic = arcGisObjectRefs[graphicObject.id] as Graphic;
        view.popup.dockOptions = options.dockOptions;
        view.popup.visibleElements = options.visibleElements;
        view.popup.open({
            features: [graphic]
        });
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}


export function addGraphic(graphicObject: any, viewId: string, graphicsLayer?: any): void {
    try {
        setWaitCursor(viewId);
        let graphic = createGraphic(graphicObject);
        let view = arcGisObjectRefs[viewId] as View;
        if (graphicsLayer === undefined || graphicsLayer === null) {
            view.graphics.add(graphic);
        } else if (typeof (graphicsLayer) === 'object') {
            graphicsLayer.add(graphic);
        } else {
            (view?.map?.layers as MapCollection).items.filter(l => l.type === "graphics")[graphicsLayer].add(graphic);
        }
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}


export function clearViewGraphics(viewId: string): void {
    try {
        setWaitCursor(viewId);
        (arcGisObjectRefs[viewId] as View).graphics.removeAll();
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}


export async function drawRouteAndGetDirections(routeUrl: string, routeSymbol: any, viewId: string): Promise<any[]> {
    try {
        setWaitCursor(viewId);
        let view = arcGisObjectRefs[viewId] as View;
        const routeParams = new RouteParameters({
            stops: new FeatureSet({
                features: view.graphics.toArray()
            }),
            returnDirections: true
        });

        let data = await route.solve(routeUrl, routeParams);
        data.routeResults.forEach(function (result) {
            result.route.symbol = routeSymbol
            view.graphics.add(result.route);
        });
        const directions: any[] = [];
        if (data.routeResults.length > 0) {
            data.routeResults[0].directions?.features.forEach(function (result, i) {
                let direction = {
                    text: result.attributes.text,
                    length: result.attributes.length,
                    time: result.attributes.time,
                    ETA: result.attributes.ETA,
                    maneuverType: result.attributes.maneuverType
                };
                directions.push(direction);
            });
        }
        unsetWaitCursor(viewId);
        return directions;
    } catch (error) {
        logError(error, viewId);
    }
    
    return [];
}

export function solveServiceArea(url: string, driveTimeCutoffs: number[], serviceAreaSymbol: any, viewId: string): void {
    try {
        setWaitCursor(viewId);
        let view = arcGisObjectRefs[viewId] as View;
        const featureSet = new FeatureSet({
            features: [(view.graphics as MapCollection).items[0]]
        });
        const taskParameters = new ServiceAreaParameters({
            facilities: featureSet,
            defaultBreaks: driveTimeCutoffs,
            trimOuterPolygon: true,
            outSpatialReference: view.spatialReference
        });

        serviceArea.solve(url, taskParameters)
            .then(function (result) {
                if (result.serviceAreaPolygons.length) {
                    result.serviceAreaPolygons.forEach(function (graphic) {
                        graphic.symbol = serviceAreaSymbol;
                        view.graphics.add(graphic, 0);
                    })
                }
                unsetWaitCursor(viewId);
            }, function (error) {
                logError(error, viewId);
            });
    } catch (error) {
        logError(error, viewId);
    }
}


export function getAllGraphics(layerIndex: number, viewId: string): DotNetGraphic[] {
    try {
        let dotNetGraphics: DotNetGraphic[] = [];
        let view = arcGisObjectRefs[viewId] as View;
        (view?.map?.layers as MapCollection).items.filter(l => l.type === "graphics")[layerIndex].graphics?.items.forEach(g => {
            let dotNetGraphic = buildDotNetGraphic(g);
            dotNetGraphics.push(dotNetGraphic);
        });
        return dotNetGraphics;
    } catch (error) {
        logError(error, viewId);
    }
    
    return [];
}

export function getCenter(viewId: string): DotNetPoint {
    return buildDotNetPoint((arcGisObjectRefs[viewId] as MapView).center);
}

export function getExtent(viewId: string): DotNetExtent | null {
    return buildDotNetExtent((arcGisObjectRefs[viewId] as MapView).extent);
}

export function queryExtent(layerId: string): DotNetExtent | null {
    let layer = arcGisObjectRefs[layerId] as any;
    if (layer === undefined || layer === null) return null;
    let extent = layer.queryExtent ?? layer.fullExtent as Extent;
    return buildDotNetExtent(extent);
}

export async function goToExtent(extent, viewId: string): Promise<void> {
    let view = arcGisObjectRefs[viewId] as MapView;
    await view.goTo(extent);
}

export function getSpatialReference(viewId: string): DotNetSpatialReference | null {
    let view = arcGisObjectRefs[viewId] as MapView;
    return buildDotNetSpatialReference(view?.spatialReference);
}

export function getGeometry(graphicId: string): DotNetGeometry | null {
    let graphic = arcGisObjectRefs[graphicId] as Graphic;
    return buildDotNetGeometry(graphic.geometry);
}

export function displayQueryResults(query: Query, symbol: ArcGisSymbol, popupTemplate: PopupTemplate, viewId: string): 
    void {
    setWaitCursor(viewId);
    queryLayer.queryFeatures(query)
        .then((results) => {
            results.features.map((feature) => {
                feature.symbol = symbol;
                feature.popupTemplate = popupTemplate;
                return feature;
            });
            let view = arcGisObjectRefs[viewId] as View;

            view.popup.close();
            view.graphics.removeAll();
            view.graphics.addMany(results.features);
            unsetWaitCursor(viewId);
        }).catch((error) => {
        logError(error, viewId);
    });
}

export async function addWidget(widget: any, viewId: string): Promise<void> {
    try {
        let view = arcGisObjectRefs[viewId] as MapView;
        if (arcGisObjectRefs.hasOwnProperty(widget.id)) {
            // for now just skip if it already exists
            // later we may want to replace it with a remove and add
            // if new values are added
            return;
        }
        let newWidget: Widget;
        switch (widget.type) {
            case 'locate':
                newWidget = new Locate({
                    view: view,
                    useHeadingEnabled: widget.useHeadingEnabled,
                    goToOverride: function (view, options) {
                        options.target.scale = widget.zoomTo;
                        return view.goTo(options.target);
                    }
                });
                
                break;
            case 'search':
                const search = new Search({
                    view: view
                });
                newWidget = search;
                
                search.on('select-result', (evt) => {
                    widget.searchWidgetObjectReference.invokeMethodAsync('OnSearchSelectResult', {
                        extent: buildDotNetExtent(evt.result.extent),
                        feature: buildDotNetFeature(evt.result.feature),
                        name: evt.result.name
                    });
                });
                break;
            case 'basemapToggle':
                newWidget = new BasemapToggle({
                    view: view,
                    nextBasemap: widget.nextBasemap
                });
                break;
            case 'basemapGallery':
                let source = new PortalBasemapsSource();
                if (widget.portalBasemapsSource !== undefined && widget.portalBasemapsSource !== null) {
                    const portal = new Portal();
                    if (widget.portalBasemapsSource.portal?.url !== undefined &&
                        widget.portalBasemapsSource.portal?.url !== null) {
                        portal.url = widget.portalBasemapsSource.portal.url;
                    }
                    source = new PortalBasemapsSource({
                        portal
                    });
                    if (widget.portalBasemapsSource.queryParams !== undefined &&
                        widget.portalBasemapsSource.queryParams !== null) {
                        source.query = widget.portalBasemapsSource.queryParams;
                    } else if (widget.portalBasemapsSource.queryString !== undefined &&
                        widget.portalBasemapsSource.queryString !== null) {
                        source.query = widget.portalBasemapsSource.queryString;
                    }
                } else if (widget.title !== undefined && widget.title !== null) {
                    source.query = {
                        title: widget.title
                    };
                }
                newWidget = new BasemapGallery({
                    view: view,
                    source: source
                });
                break;
            case 'scaleBar':
                const scaleBar = new ScaleBar({
                    view: view
                });
                newWidget = scaleBar;
                if (widget.unit !== undefined && widget.unit !== null) {
                    scaleBar.unit = widget.unit;
                }
                break;
            case 'legend':
                const legend = new Legend({
                    view: view
                });
                newWidget = legend;
                break;
            case 'home':
                const homeBtn = new Home({
                    view: view,
                });
                newWidget = homeBtn;
                if (widget.label !== undefined && widget.label !== null) {
                    homeBtn.label = widget.label;
                }
                if (widget.iconClass !== undefined && widget.iconClass !== null) {
                    homeBtn.iconClass = widget.iconClass;
                }                
                break;
            case 'compass':
                const compassWidget = new Compass({
                    view: view
                });
                newWidget = compassWidget;
                if (widget.iconClass !== undefined && widget.iconClass !== null) {
                    compassWidget.iconClass = widget.iconClass;
                }
                if (widget.label !== undefined && widget.label !== null) {
                    compassWidget.label = widget.label;
                }
                break;
            default:
                return;
        }

        if (widget.containerId !== undefined && widget.containerId !== null) {
            let container = document.getElementById(widget.containerId);
            let innerContainer = document.createElement('div');
            container?.appendChild(innerContainer);
            newWidget.container = innerContainer;
        } else {
            view.ui.add(newWidget, widget.position);
        }
        arcGisObjectRefs[widget.id] = newWidget;
    } catch (error) {
        logError(error, viewId);
    }
}

export function createGraphic(graphicObject: any): Graphic {
    let popupTemplate: PopupTemplate | undefined = undefined;
    if (graphicObject.popupTemplate !== undefined && graphicObject.popupTemplate !== null) {
        popupTemplate = buildPopupTemplate(graphicObject.popupTemplate);
    }

    const graphic = new Graphic({
        geometry: graphicObject.geometry,
        symbol: graphicObject.symbol,
        attributes: graphicObject.attributes,
        popupTemplate: popupTemplate
    });

    arcGisObjectRefs[graphicObject.id] = graphic;
    return graphic;
}

export async function addLayer(layerObject: any, viewId: string, isBasemapLayer?: boolean, isQueryLayer?: boolean, 
                         callback?: Function): Promise<void> {
    try {
        let view = arcGisObjectRefs[viewId] as View;
        let newLayer: Layer;
        switch (layerObject.type) {
            case 'graphics':
                newLayer = new GraphicsLayer();
                layerObject.graphics?.forEach(graphicObject => {
                    addGraphic(graphicObject, viewId, newLayer);
                });
                break;
            case 'feature':
                if (layerObject.portalItem !== undefined && layerObject.portalItem?.id !== null) {
                    newLayer = new FeatureLayer({
                        portalItem: {
                            id: layerObject.portalItem.id
                        },
                        opacity: layerObject.opacity,
                        definitionExpression: layerObject.definitionExpression
                    });
                } else {
                    newLayer = new FeatureLayer({
                        url: layerObject.url,
                        opacity: layerObject.opacity,
                        definitionExpression: layerObject.definitionExpression
                    });
                }
                let featureLayer = newLayer as FeatureLayer;
                if (layerObject.opacity !== undefined && layerObject.opacity !== null) {
                    newLayer.opacity = layerObject.opacity;
                }
                if (layerObject.definitionExpression !== undefined && layerObject.definitionExpression !== null) {
                    featureLayer.definitionExpression = layerObject.definitionExpression;
                }
                if (layerObject.renderer !== undefined && layerObject.renderer !== null) {
                    featureLayer.renderer = layerObject.renderer;
                }

                if (layerObject.labelingInfo !== undefined && layerObject.labelingInfo?.length > 0) {
                    featureLayer.labelingInfo = layerObject.labelingInfo;
                }

                if (layerObject.outFields !== undefined && layerObject.outFields?.length > 0) {
                    featureLayer.outFields = layerObject.outFields;
                }

                if (layerObject.popupTemplate !== undefined && layerObject.popupTemplate !== null) {
                    featureLayer.popupTemplate = buildPopupTemplate(layerObject.popupTemplate);
                }
                break;
            case 'vectorTile':
                if (layerObject.portalItem !== undefined && layerObject.portalItem !== null) {
                    newLayer = new VectorTileLayer({
                        portalItem: layerObject.portalItem
                    });
                } else {
                    newLayer = new VectorTileLayer({
                        url: layerObject.url
                    });
                }
                if (layerObject.opacity !== undefined && layerObject.opacity !== null) {
                    newLayer.opacity = layerObject.opacity;
                }
                break;
            case 'tile':
                newLayer = new TileLayer({
                    portalItem: {
                        id: layerObject.portalItem.id
                    }
                });
                break;
            case 'geo-json':
                newLayer = new GeoJSONLayer({
                    url: layerObject.url,
                    copyright: layerObject.copyright
                });
                let gjLayer = newLayer as GeoJSONLayer;
                if (layerObject.renderer !== undefined && layerObject.renderer !== null) {
                    gjLayer.renderer = layerObject.renderer;
                }
                if (layerObject.spatialReference !== undefined && layerObject.spatialReference !== null) {
                    gjLayer.spatialReference = new SpatialReference({
                        wkid: layerObject.spatialReference.wkid
                    });
                }
                break;
            default:
                return;
        }

        
        if (isBasemapLayer) {
            view.map.basemap.baseLayers.push(newLayer);
        } else if (isQueryLayer) {
            queryLayer = newLayer as FeatureLayer;
            if (callback !== undefined) {
                callback();
            }
        } else {
            view.map.add(newLayer);
        }
        arcGisObjectRefs[layerObject.id] = newLayer;
    } catch (error) {
        logError(error, viewId);
    }
}


export function buildPopupTemplate(popupTemplateObject: any): PopupTemplate {
    let content;
    if (popupTemplateObject.stringContent !== undefined && popupTemplateObject.stringContent !== null) {
        content = popupTemplateObject.stringContent;
    } else {
        content = popupTemplateObject.content;
    }
    return new PopupTemplate({
        title: popupTemplateObject.title,
        content: content
    });
}

async function resetCenterToSpatialReference(center: Point, spatialReference: SpatialReference): Promise<Point> {
    return await projection.project(center, spatialReference) as Point;
}

export function logError(error, viewId) {
    if (error.stack !== undefined && error.stack !== null) {
        console.log(error.stack);
        dotNetRefs[viewId].invokeMethodAsync('OnJavascriptError', error.stack);
    } else {
        console.log(error.message);
        dotNetRefs[viewId].invokeMethodAsync('OnJavascriptError', error.message);
    }
    unsetWaitCursor(viewId);
}


function setWaitCursor(viewId: string): void {
    let viewContainer = document.getElementById(`map-container-${viewId}`);
    if (viewContainer !== null) {
        viewContainer.style.cursor = 'wait';
    }
}

function unsetWaitCursor(viewId: string): void {
    let viewContainer = document.getElementById(`map-container-${viewId}`);
    if (viewContainer !== null) {
        viewContainer.style.cursor = 'unset';
    }
}

function waitForRender(viewId: string, dotNetRef: any): void {
    let view = arcGisObjectRefs[viewId] as View;
    view.when().then(_ => {
        let isRendered = false;
        let interval = setInterval(() => {
            if (view === undefined || view === null) {
                clearInterval(interval);
                return;
            }
            if (!view.updating && !isRendered) {
                console.log("View Render Complete");
                dotNetRef.invokeMethodAsync('OnViewRendered');
                isRendered = true;
            } else if (isRendered && view.updating) {
                isRendered = false;
            }
        }, 100);
    })
}