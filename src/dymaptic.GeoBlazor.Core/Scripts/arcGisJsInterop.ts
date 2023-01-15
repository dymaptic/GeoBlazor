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
import Expand from "@arcgis/core/widgets/Expand";
import Search from "@arcgis/core/widgets/Search";
import Locate from "@arcgis/core/widgets/Locate";
import Widget from "@arcgis/core/widgets/Widget";
import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import Layer from "@arcgis/core/layers/Layer";
import VectorTileLayer from "@arcgis/core/layers/VectorTileLayer";
import TileLayer from "@arcgis/core/layers/TileLayer";
import GeoJSONLayer from "@arcgis/core/layers/GeoJSONLayer";
import GeoRSSLayer from "@arcgis/core/layers/GeoRSSLayer";
import PopupTemplate from "@arcgis/core/PopupTemplate";
import Query from "@arcgis/core/rest/support/Query";
import View from "@arcgis/core/views/View";
import ArcGisSymbol from "@arcgis/core/symbols/Symbol";
import Accessor from "@arcgis/core/core/Accessor";

import Home from "@arcgis/core/widgets/Home";
import Compass from "@arcgis/core/widgets/Compass";
import LayerList from "@arcgis/core/widgets/LayerList";
import ListItem from "@arcgis/core/widgets/LayerList/ListItem";
import Extent from "@arcgis/core/geometry/Extent";
import * as reactiveUtils from "@arcgis/core/core/reactiveUtils";
import Geometry from "@arcgis/core/geometry/Geometry";
import BasemapLayerList from "@arcgis/core/widgets/BasemapLayerList";
import FeatureLayerWrapper from "./featureLayer";

import {
    buildDotNetExtent,
    buildDotNetFeature,
    buildDotNetGraphic,
    buildDotNetPoint,
    buildDotNetGeometry,
    buildDotNetSpatialReference,
    buildDotNetLayerView,
    buildDotNetHitTestResult, buildDotNetLayer
} from "./dotNetBuilder";

import {
    buildJsFields,
    buildJsRenderer,
    buildJsSpatialReference,
    buildJsPopupTemplate,
    buildJsGraphic, 
    buildJsViewClickEvent,
    buildJsGeometry, 
    buildJsPoint, 
    buildJsExtent,
    buildJsPopup,
    buildJsPopupOptions
} from "./jsBuilder";
import {
    DotNetExtent,
    DotNetGeometry,
    DotNetGraphic, DotNetHitTestOptions,
    DotNetHitTestResult,
    DotNetListItem,
    DotNetPoint,
    DotNetSpatialReference,
    MapCollection
} from "./definitions";

import HitTestResult = __esri.HitTestResult;
import MapViewHitTestOptions = __esri.MapViewHitTestOptions;
import WebTileLayer from "@arcgis/core/layers/WebTileLayer";
import TileInfo from "@arcgis/core/layers/support/TileInfo";
import LOD from "@arcgis/core/layers/support/LOD";
import OpenStreetMapLayer from "@arcgis/core/layers/OpenStreetMapLayer";
import Camera from "@arcgis/core/Camera";
import LegendLayerInfos = __esri.LegendLayerInfos;
import ProjectionWrapper from "./projection";
import GeometryEngineWrapper from "./geometryEngine";

export let arcGisObjectRefs: Record<string, Accessor> = {};
export let dotNetRefs = {};
export let queryLayer: FeatureLayer;
export { projection, geometryEngine };

export function setAssetsPath (path: string) {
    if (path !== undefined && path !== null && esriConfig.assetsPath !== path) {
        esriConfig.assetsPath = path;
    }
}

export function getObjectReference(id: string): any {
    let objectRef = arcGisObjectRefs[id];
    if (objectRef instanceof Layer) {
        if (objectRef instanceof FeatureLayer) {
            return new FeatureLayerWrapper(objectRef);
        }

        return buildDotNetLayer(objectRef);
    }
    if (objectRef instanceof Graphic) {
        return buildDotNetGraphic(objectRef);
    }
    return objectRef;
}

export function getSerializedDotNetObject(id: string): any {
    let objectRef = arcGisObjectRefs[id];
    if (objectRef instanceof Layer) {
        return buildDotNetLayer(objectRef);
    }
    if (objectRef instanceof Graphic) {
        return buildDotNetGraphic(objectRef);
    }
    return objectRef;
}

export function getFeatureLayerWrapper(layer: FeatureLayer): FeatureLayerWrapper {
    let wrapper = new FeatureLayerWrapper(layer);
    return wrapper;
}

export function getProjectionWrapper(dotNetRef: any, apiKey: string): ProjectionWrapper {
    let wrapper = new ProjectionWrapper(dotNetRef, apiKey);
    return wrapper;
}

export function getGeometryEngineWrapper(dotNetRef: any, apiKey: string): GeometryEngineWrapper {
    let wrapper = new GeometryEngineWrapper(dotNetRef, apiKey);
    return wrapper;
}

export async function buildMapView(id: string, dotNetReference: any, long: number | null, lat: number | null,
                                   rotation: number, mapObject: any, zoom: number | null, scale: number, 
                                   apiKey: string, mapType: string, widgets: any, graphics: any, 
                                   spatialReference: any, constraints: any, extent: any, 
                                   eventRateLimitInMilliseconds: number | null, activeEventHandlers: Array<string>,
                                   highlightOptions?: any | null, zIndex?: number, tilt?: number)
    : Promise<void> {
    console.debug("render map");
    try {
        setWaitCursor(id);
        let dotNetRef = dotNetReference;

        checkConnectivity(id);
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
                    map: scene
                });
                if (hasValue(lat) && hasValue(long)) {
                    (view as SceneView).camera = {
                        position: {
                            x: long as number, //Longitude
                            y: lat as number, //Latitude
                            z: zIndex as number //Meters
                        } as Point,
                        tilt: tilt as number
                    } as Camera
                }
                break;
            default:
                const map = new Map({
                    basemap: basemap!,
                    ground: mapObject.ground
                });
                
                view = new MapView({
                    map: map,
                    container: `map-container-${id}`,
                    rotation: rotation
                });
                break;
        }

        let spatialRef;
        if (hasValue(spatialReference)) {
            spatialRef = buildJsSpatialReference(spatialReference);
            view.spatialReference = spatialRef;
        }

        if (hasValue(extent)) {
            (view as MapView).extent = buildJsExtent(extent);
        } else {
            let center;
            
            if (hasValue(lat) && hasValue(long)) {
                if (hasValue(spatialRef)) {
                    center = new Point({
                        latitude: lat as number,
                        longitude: long as number,
                        spatialReference: spatialRef
                    });
                    center = await resetCenterToSpatialReference(center, spatialRef);
                } else {
                    center = [long, lat];
                }
            }

            if (hasValue(center)) {
                (view as MapView).center = center;
            }

            if (hasValue(scale)) {
                (view as MapView).scale = scale;
            } else if (hasValue(zoom)) {
                (view as MapView).zoom = zoom as number;
            }
        }

        if (hasValue(constraints)) {
            (view as MapView).constraints = constraints;
        }

        arcGisObjectRefs[id] = view;
        await dotNetRef.invokeMethodAsync('OnJsViewInitialized');
        waitForRender(id, dotNetRef);

        if (hasValue(highlightOptions)) {
            (view as MapView).highlightOptions = highlightOptions;
        }
        
        if (hasValue(mapObject.layers)) {
            for (const layerObject of mapObject.layers) {
                await addLayer(layerObject, id);
            }
        }

        for (const l of basemapLayers) {
            await addLayer(l, id, true);
        }

        for (const widget of widgets) {
            addWidget(widget, id);
        }

        graphics.forEach(graphicObject => {
            addGraphic(graphicObject, id);
        })

        setEventListeners(view, dotNetRef, eventRateLimitInMilliseconds, activeEventHandlers);
        
        unsetWaitCursor(id);
    } catch (error) {
        logError(error, id);
    }
}

function setEventListeners(view: __esri.View, dotNetRef: any, eventRateLimit: number | null, 
                           activeEventHandlers: Array<string>) : void {
    if (activeEventHandlers.includes('OnClick') || activeEventHandlers.includes('OnClickAsyncHandler')) {
        view.on('click', (evt) => {
            evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
            dotNetRef.invokeMethodAsync('OnJavascriptClick', evt);
        });
    }

    if (activeEventHandlers.includes('OnDoubleClick')) {
        view.on('double-click', (evt) => {
            evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
            dotNetRef.invokeMethodAsync('OnJavascriptDoubleClick', evt);
        });
    }

    if (activeEventHandlers.includes('OnHold')) {
        view.on('hold', (evt) => {
            evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
            dotNetRef.invokeMethodAsync('OnJavascriptHold', evt);
        });
    }

    if (activeEventHandlers.includes('ImmediateClick')) {
        view.on('immediate-click', (evt) => {
            evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
            dotNetRef.invokeMethodAsync('OnJavascriptImmediateClick', evt);
        });
    }

    if (activeEventHandlers.includes('ImmediateDoubleClick')) {
        view.on('immediate-double-click', (evt) => {
            evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
            dotNetRef.invokeMethodAsync('OnJavascriptImmediateDoubleClick', evt);
        });
    }

    if (activeEventHandlers.includes('OnBlur')) {
        view.on('blur', (evt) => {
            dotNetRef.invokeMethodAsync('OnJavascriptBlur', evt);
        });
    }

    if (activeEventHandlers.includes('OnFocus')) {
        view.on('focus', (evt) => {
            dotNetRef.invokeMethodAsync('OnJavascriptFocus', evt);
        });
    }

    if (activeEventHandlers.includes('OnDrag')) {
        let lastDragCall: number = 0;
        view.on('drag', (evt) => {
            let now = Date.now();
            if (eventRateLimit !== undefined && eventRateLimit !== null &&
                lastDragCall + eventRateLimit > now) {
                return;
            }
            lastDragCall = now;
            dotNetRef.invokeMethodAsync('OnJavascriptDrag', evt);
        });
    }

    if (activeEventHandlers.includes('OnPointerDown')) {
        view.on('pointer-down', (evt) => {
            dotNetRef.invokeMethodAsync('OnJavascriptPointerDown', evt);
        });
    }

    if (activeEventHandlers.includes('OnPointerEnter')) {
        view.on('pointer-enter', (evt) => {
            dotNetRef.invokeMethodAsync('OnJavascriptPointerEnter', evt);
        });
    }

    if (activeEventHandlers.includes('OnPointerLeave')) {
        view.on('pointer-leave', (evt) => {
            dotNetRef.invokeMethodAsync('OnJavascriptPointerLeave', evt);
        });
    }

    if (activeEventHandlers.includes('OnPointerMove') || activeEventHandlers.includes('OnPointerMoveHandler')) {
        let lastPointerMoveCall : number = 0;
        view.on('pointer-move', (evt) => {
            let now = Date.now();
            if (eventRateLimit !== undefined && eventRateLimit !== null &&
                lastPointerMoveCall + eventRateLimit > now) {
                return;
            }
            lastPointerMoveCall = now;
            dotNetRef.invokeMethodAsync('OnJavascriptPointerMove', evt);
        });
    }

    if (activeEventHandlers.includes('OnPointerUp')) {
        view.on('pointer-up', (evt) => {
            dotNetRef.invokeMethodAsync('OnJavascriptPointerUp', evt);
        });
    }

    if (activeEventHandlers.includes('OnKeyDown')) {
        view.on('key-down', (evt) => {
            dotNetRef.invokeMethodAsync('OnJavascriptKeyDown', evt);
        });
    }

    if (activeEventHandlers.includes('OnKeyUp')) {
        view.on('key-up', (evt) => {
            dotNetRef.invokeMethodAsync('OnJavascriptKeyUp', evt);
        });
    }

    view.on('layerview-create', (evt) => {
        // find objectRef id by layer
        let layerGeoBlazorId = Object.keys(arcGisObjectRefs).find(key => arcGisObjectRefs[key] === evt.layer);
        // @ts-ignore
        let layerRef;
        if (evt.layer instanceof FeatureLayer) {
            // @ts-ignore
            layerRef = DotNet.createJSObjectReference(getFeatureLayerWrapper(evt.layer));
        } else {
            // @ts-ignore
            layerRef = DotNet.createJSObjectReference(evt.layer)
        }
        
        let result = {
            layerObjectRef: layerRef,
            // @ts-ignore
            layerViewObjectRef: DotNet.createJSObjectReference(evt.layerView),
            layerView: buildDotNetLayerView(evt.layerView),
            layer: buildDotNetLayer(evt.layer),
            layerGeoBlazorId: layerGeoBlazorId
        }
        dotNetRef.invokeMethodAsync('OnJavascriptLayerViewCreate', result);
    });

    if (activeEventHandlers.includes('OnLayerViewCreateError')) {
        view.on('layerview-create-error', (evt) => {
            dotNetRef.invokeMethodAsync('OnJavascriptLayerViewCreateError', evt);
        });
    }

    if (activeEventHandlers.includes('OnLayerViewDestroy')) {
        view.on('layerview-destroy', (evt) => {
            dotNetRef.invokeMethodAsync('OnJavascriptLayerViewDestroy', evt);
        });
    }
    
    if (activeEventHandlers.includes('OnMouseWheel')) {
        let lastMouseWheelCall = 0;
        view.on('mouse-wheel', (evt) => {
            let now = Date.now();
            if (eventRateLimit !== undefined && eventRateLimit !== null &&
                lastMouseWheelCall + eventRateLimit > now) {
                return;
            }
            lastMouseWheelCall = now;
            dotNetRef.invokeMethodAsync('OnJavascriptMouseWheel', evt);
        });
    }
    
    if (activeEventHandlers.includes('OnResize')) {
        let lastResizeCall = 0;
        view.on('resize', (evt) => {
            let now = Date.now();
            if (eventRateLimit !== undefined && eventRateLimit !== null &&
                lastResizeCall + eventRateLimit > now) {
                return;
            }
            lastResizeCall = now;
            dotNetRef.invokeMethodAsync('OnJavascriptResize', evt);
        });
    }

    view.watch('spatialReference', () => {
        dotNetRef.invokeMethodAsync('OnJavascriptSpatialReferenceChanged', buildDotNetSpatialReference(view.spatialReference));
    });

    let lastExtentChangeCall = 0;
    view.watch('extent', () => {
        let now = Date.now();
        if (eventRateLimit !== undefined && eventRateLimit !== null &&
            lastExtentChangeCall + eventRateLimit > now) {
            return;
        }
        lastExtentChangeCall = now;
        dotNetRef.invokeMethodAsync('OnJavascriptExtentChanged', buildDotNetExtent((view as MapView).extent));
    });
}

export async function hitTest(pointObject: any, eventId: string | null, viewId: string, returnValue: boolean,
    isEvent: boolean, options: DotNetHitTestOptions | null) : Promise<DotNetHitTestResult | void> {
    let view = arcGisObjectRefs[viewId] as MapView;
    let result: HitTestResult;
    let screenPoint = isEvent ? pointObject : { x: pointObject.x, y: pointObject.y };
    
    if (options !== null) {
        let hitOptions = buildHitTestOptions(options, view);
        result = await view.hitTest(screenPoint, hitOptions);
    }
    else {
        result = await view.hitTest(screenPoint);
    }
    
    let dotNetResult = buildDotNetHitTestResult(result);
    if (returnValue) {
        return dotNetResult;
    }

    let dotNetRef = dotNetRefs[viewId];
    let jsonResult = JSON.stringify(dotNetResult);
    // return dotNetResult in small chunks to avoid memory issues in Blazor Server
    // SignalR has a maximum message size of 32KB
    // https://github.com/dotnet/aspnetcore/issues/23179
    let chunkSize = 100;
    let chunks = Math.ceil(jsonResult.length / chunkSize);
    for (let i = 0; i < chunks; i++) {
        let chunk = jsonResult.slice(i * chunkSize, (i + 1) * chunkSize);
        await dotNetRef.invokeMethodAsync('OnJavascriptHitTestResult', eventId, chunk);
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
                (graphic?.layer as GraphicsLayer)?.graphics.remove(graphic);
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
        } else if (hasValue(queryObject.geometry)) {
            query.geometry = buildJsGeometry(queryObject.geometry)!;
        }
        let popupTemplate = buildJsPopupTemplate(popupTemplateObject);
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
        console.debug('update graphics layer');
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
        console.debug('remove graphics layer');
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
            if (hasValue(oldGraphic)) {
                view.graphics.remove(oldGraphic);
            } else {
                view.graphics.removeAt(graphicObject.graphicIndex);
            }
        } else {
            gLayer = (view.map.layers as MapCollection).items.filter(l => l.type === "graphics")[layerIndex] as GraphicsLayer;
            if (hasValue(gLayer)) {
                if (hasValue(oldGraphic)) {
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
        let currentLayer = arcGisObjectRefs[layerObject.id] as FeatureLayer;
        
        if (currentLayer === undefined) {
            await addLayer(layerObject, viewId);
            return;
        }
        
        if (hasValue(layerObject.portalItem) && layerObject.portalItem.id !== currentLayer.portalItem.id) {
            currentLayer.portalItem.id = layerObject.portalItem.id;
        }
        if (hasValue(layerObject.url) && layerObject.url !== currentLayer.url) {
            currentLayer.url = layerObject.url;
        }
        if (hasValue(layerObject.source)) {
            let source: Array<Graphic> = [];
            layerObject.source?.forEach(graphicObject => {
                let graphic = buildJsGraphic(graphicObject);
                if (graphic !== null) {
                    source.push(graphic);
                }
            });
            
            currentLayer.source = source as any;
        }
        
        if (hasValue(layerObject.opacity) && layerObject.opacity !== currentLayer.opacity && 
            layerObject.opacity >= 0 && layerObject.opacity <= 1) {
            currentLayer.opacity = layerObject.opacity;
        }
        if (hasValue(layerObject.definitionExpression) && 
            layerObject.definitionExpression !== currentLayer.definitionExpression) {
            currentLayer.definitionExpression = layerObject.definitionExpression;
        }

        if (layerObject.labelingInfo !== undefined && layerObject.labelingInfo?.length > 0 &&
            layerObject.labelingInfo !== currentLayer.labelingInfo) {
            currentLayer.labelingInfo = layerObject.labelingInfo;
        }

        if (layerObject.outFields !== undefined && layerObject.outFields?.length > 0 && 
            layerObject.outFields !== currentLayer.outFields) {
            currentLayer.outFields = layerObject.outFields;
        }

        if (hasValue(layerObject.popupTemplate) && layerObject.popupTemplate !== currentLayer.popupTemplate) {
            currentLayer.popupTemplate = buildJsPopupTemplate(layerObject.popupTemplate);
        }
        if (hasValue(layerObject.title) && layerObject.title !== currentLayer.title) {
            currentLayer.title = layerObject.title;
        }
        if (hasValue(layerObject.minScale) && layerObject.minScale !== currentLayer.minScale) {
            currentLayer.minScale = layerObject.minScale;
        }
        if (hasValue(layerObject.maxScale) && layerObject.maxScale !== currentLayer.maxScale) {
            currentLayer.maxScale = layerObject.maxScale;
        }
        if (hasValue(layerObject.orderBy) && layerObject.orderBy !== currentLayer.orderBy) {
            currentLayer.orderBy = layerObject.orderBy;
        }
        if (hasValue(layerObject.objectIdField) && layerObject.objectIdField !== currentLayer.objectIdField) {
            currentLayer.objectIdField = layerObject.objectIdField;
        }
        if (hasValue(layerObject.renderer) && layerObject.renderer !== currentLayer.renderer) {
            let renderer = buildJsRenderer(layerObject.renderer);
            if (renderer !== null) {
                currentLayer.renderer = renderer;
            }
        }
        if (hasValue(layerObject.fields) && layerObject.fields !== currentLayer.fields) {
            currentLayer.fields = buildJsFields(layerObject.fields);
        }
        if (hasValue(layerObject.spatialReference) && 
            layerObject.spatialReference.wkid !== currentLayer.spatialReference.wkid) {
            currentLayer.spatialReference = buildJsSpatialReference(layerObject.spatialReference);
        }
        if (hasValue(layerObject.fullExtent) && layerObject.fullExtent !== currentLayer.fullExtent) {
            currentLayer.fullExtent = buildJsExtent(layerObject.fullExtent);
        }
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
                let popupTemplate = buildJsPopupTemplate(popupTemplateObject);
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

export function setPopup(popup: any, viewId: string): void {
    try {
        let view = arcGisObjectRefs[viewId] as View;
        let jsPopup = buildJsPopup(popup);
        if (hasValue(popup.widgetContent)) {
            let widgetContent = createWidget(popup.widgetContent, popup.viewId);
            if (hasValue(widgetContent)) {
                jsPopup.content = widgetContent as Widget;
            }
        }
        view.popup = jsPopup;
    } catch (error) {
        logError(error, popup.viewId);
    }
}

export function openPopup(viewId: string, options: any | null): void {
    try {
        let view = arcGisObjectRefs[viewId] as View;
        if (options !== null) {
            let jsOptions = buildJsPopupOptions(options);
            if (hasValue(options.widgetContent)) {
                let widgetContent = createWidget(options.widgetContent, viewId);
                if (hasValue(widgetContent)) {
                    jsOptions.content = widgetContent as Widget;
                }
            }
            view.popup.open(jsOptions);
        } else {
            view.popup.open();
        }
    } catch (error) {
        logError(error, options.viewId);
    }
}

export async function showPopup(popupTemplateObject: any, location: DotNetPoint, viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
        let popupTemplate = buildJsPopupTemplate(popupTemplateObject);
        (arcGisObjectRefs[viewId] as View).popup.open({
            title: popupTemplate.title as string,
            content: popupTemplate.content as string,
            location: buildJsPoint(location)!
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


export function addGraphic(graphicObject: DotNetGraphic, viewId: string, graphicsLayer?: any): void {
    try {
        setWaitCursor(viewId);
        let graphic = buildJsGraphic(graphicObject);
        let view = arcGisObjectRefs[viewId] as View;
        if (graphicsLayer === undefined || graphicsLayer === null) {
            if (!hasValue(view?.graphics)) return;
            view.graphics?.add(graphic as Graphic);
        } else if (typeof (graphicsLayer) === 'object') {
            graphicsLayer.add(graphic as Graphic);
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

export function addWidget(widget: any, viewId: string): void {
    try {
        let newWidget = createWidget(widget, viewId);
        if (newWidget === null) return;

        if (hasValue(widget.containerId)) {
            let container = document.getElementById(widget.containerId);
            let innerContainer = document.createElement('div');
            container?.appendChild(innerContainer);
            newWidget.container = innerContainer;
        } else {
            let view = arcGisObjectRefs[viewId] as MapView;
            view.ui.add(newWidget, widget.position);
        }
    } catch (error) {
        logError(error, viewId);
    }
}

function createWidget(widget: any, viewId: string): Widget | null {
    let view = arcGisObjectRefs[viewId] as MapView;
    if (arcGisObjectRefs.hasOwnProperty(widget.id)) {
        // for now just skip if it already exists
        // later we may want to replace it with a remove and add
        // if new values are added
        return null;
    }
    let newWidget: Widget;
    switch (widget.type) {
        case 'locate':
            newWidget = new Locate({
                view: view,
                useHeadingEnabled: widget.useHeadingEnabled,
                goToOverride: function (view, options) {
                    options.target.scale = widget.scale;
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
            // the esri definition file is missing basemapToggle.nextBasemap, but it is in the docs.
            let basemapToggle = new BasemapToggle({
                view: view
            });
            newWidget = basemapToggle;
            if (hasValue(widget.nextBasemapName)) {
                // @ts-ignore
                basemapToggle.nextBasemap = widget.nextBasemapName;
            } else {
                // @ts-ignore
                basemapToggle.nextBasemap = widget.nextBasemap;
            }
            break;
        case 'basemapGallery':
            let source = new PortalBasemapsSource();
            if (hasValue(widget.portalBasemapsSource)) {
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
            } else if (hasValue(widget.title)) {
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
            if (hasValue(widget.unit)) {
                scaleBar.unit = widget.unit;
            }
            break;
        case 'legend':
            const legend = new Legend({
                view: view
            });
            newWidget = legend;
            
            if (hasValue(widget.layerInfos)) {
                legend.layerInfos = widget.layerInfos.forEach(li => {
                    let jsLayerInfo = {
                        layer: arcGisObjectRefs[li.layerId]
                    } as LegendLayerInfos;
                    if (hasValue(li.title)) {
                        jsLayerInfo.title = li.title;
                    }
                    if (hasValue(li.sublayerIds)) {
                        jsLayerInfo.sublayerIds = li.sublayerIds;
                    }
                    
                    return jsLayerInfo;
                });
            }
            break;
        case 'home':
            const homeBtn = new Home({
                view: view,
            });
            newWidget = homeBtn;
            if (hasValue(widget.label)) {
                homeBtn.label = widget.label;
            }
            if (hasValue(widget.iconClass)) {
                homeBtn.iconClass = widget.iconClass;
            }
            break;
        case 'compass':
            const compassWidget = new Compass({
                view: view
            });
            newWidget = compassWidget;
            if (hasValue(widget.iconClass)) {
                compassWidget.iconClass = widget.iconClass;
            }
            if (hasValue(widget.label)) {
                compassWidget.label = widget.label;
            }
            break;
        case 'layerList':
            const layerListWidget = new LayerList({
                view: view
            });
            newWidget = layerListWidget;

            if (hasValue(widget.hasCustomHandler)) {
                layerListWidget.listItemCreatedFunction = async (evt) => {
                    let dotNetListItem = buildDotNetListItem(evt.item);
                    let returnItem = await widget.layerListWidgetObjectReference.invokeMethodAsync('OnListItemCreated', dotNetListItem) as DotNetListItem;
                    evt.item.title = returnItem.title;
                    evt.item.visible = returnItem.visible;
                    //evt.item.layer = returnItem.layer; //--> needs implementation
                    //evt.item.children = returnItem.children; //--> needs implementation
                    /// <summary>
                    ///     The Action Sections property and corresponding functionality will be fully implemented
                    ///     in a future iteration.  Currently, a user can view available layers in the layer list widget
                    ///     and toggle the selected layer's visiblity. More capabilities will be available after full
                    ///     implementation of ActionSection.
                    /// </summary>
                    //evt.item.actionSections = returnItem.actionSections as any;
                };
            }

            if (hasValue(widget.iconClass)) {
                layerListWidget.iconClass = widget.iconClass;
            }
            if (hasValue(widget.label)) {
                layerListWidget.label = widget.label;
            }
            break;
        case 'basemapLayerList':
            const basemapLayerListWidget = new BasemapLayerList({
                view: view
            });
            newWidget = basemapLayerListWidget;

            if (hasValue(widget.HasCustomBaseListHandler)) {
                basemapLayerListWidget.baseListItemCreatedFunction = async (evt) => {
                    let dotNetBaseListItem = buildDotNetListItem(evt.item);
                    let returnItem = await widget.layerListWidgetObjectReference.invokeMethodAsync('OnBaseListItemCreated', dotNetBaseListItem) as DotNetListItem;
                    evt.item.title = returnItem.title;
                    evt.item.visible = returnItem.visible;
                    // basemap will require additional implementation (similar to layerlist above) to activate additional layer and action sections.
                    //evt.item.layer = returnItem.layer; //--> needs implementation
                   // evt.item.children = returnItem.children; //--> needs implementation
                   // evt.item.actionSections = returnItem.actionSections as any;
                };
            }
            if (hasValue(widget.HasCustomReferenceListHandler)) {
                basemapLayerListWidget.baseListItemCreatedFunction = async (evt) => {
                    let dotNetReferenceListItem = buildDotNetListItem(evt.item);
                    let returnItem = await widget.layerListWidgetObjectReference.invokeMethodAsync('OnReferenceListItemCreated', dotNetReferenceListItem) as DotNetListItem;
                    evt.item.title = returnItem.title;
                    evt.item.visible = returnItem.visible;
                    // basemap will require additional implementation (similar to layerlist above) to activate additional layer and action sections.
                    // evt.item.layer = returnItem.layer; //--> needs implementation
                    // evt.item.children = returnItem.children; //--> needs implementation
                    // evt.item.actionSections = returnItem.actionSections as any;
                };
            }

            if (widget.iconClass !== undefined && widget.iconClass !== null) {
                basemapLayerListWidget.iconClass = widget.iconClass;
            }
            if (widget.label !== undefined && widget.label !== null) {
                basemapLayerListWidget.label = widget.label;
            }
            break;
        case 'expand':
            createWidget(widget.content, viewId);
            let content = arcGisObjectRefs[widget.content.id] as Widget;
            view.ui.remove(content);
            const expand = new Expand({
                view,
                content: content
            });

            if (hasValue(widget.autoCollapse)) {
                expand.autoCollapse = widget.autoCollapse;
            }

            if (hasValue(widget.closeOnEsc)) {
                expand.closeOnEsc = widget.closeOnEsc;
            }

            if (hasValue(widget.expandIconClass)) {
                expand.expandIconClass = widget.expandIconClass;
            }

            if (hasValue(widget.collapseIconClass)) {
                expand.collapseIconClass = widget.collapseIconClass;
            }

            if (hasValue(widget.expandTooltip)) {
                expand.expandTooltip = widget.expandTooltip;
            }

            if (hasValue(widget.collapseTooltip)) {
                expand.collapseTooltip = widget.collapseTooltip;
            }

            newWidget = expand;
            break;
        case 'popup':
            setPopup(widget, viewId);
            return null;
        default:
            return null;
    }
    
    arcGisObjectRefs[widget.id] = newWidget;
    dotNetRefs[widget.id] = widget.dotNetComponentReference;
    return newWidget;
}

export function removeWidget(widgetId: string, viewId: string) : void {
    let view = arcGisObjectRefs[viewId] as MapView;
    let widget = arcGisObjectRefs[widgetId] as Widget;
    try {
        view.ui.remove(widget);
    }
    catch{
        //ignore
    }
    delete arcGisObjectRefs.widgetId;
}

export function addLayer(layerObject: any, viewId: string, isBasemapLayer?: boolean, isQueryLayer?: boolean, 
                         callback?: Function): void {
    try {
        let view = arcGisObjectRefs[viewId] as View;
        if (!hasValue(view?.map)) return;
        
        let newLayer: Layer | null;
        if (arcGisObjectRefs.hasOwnProperty(layerObject.id)) {
            newLayer = arcGisObjectRefs[layerObject.id] as Layer;
            if (newLayer.destroyed) {
                newLayer = createLayer(layerObject);
            }
        } else {
            newLayer = createLayer(layerObject);
        }
        
        if (newLayer === null) return;
        
        if (layerObject.type === 'graphics') {
            layerObject.graphics?.forEach(graphicObject => {
                addGraphic(graphicObject, viewId, newLayer);
            });
        }
        
        if (isBasemapLayer) {
            view.map?.basemap.baseLayers.push(newLayer);
        } else if (isQueryLayer) {
            queryLayer = newLayer as FeatureLayer;
            if (callback !== undefined) {
                callback();
            }
        } else {
            view.map?.add(newLayer);
        }
    } catch (error) {
        logError(error, viewId);
    }
}

export function createLayer(layerObject: any, wrap?: boolean | null): Layer | null {
    let newLayer: Layer;
    switch (layerObject.type) {
        case 'graphics':
            newLayer = new GraphicsLayer();
            break;
        case 'feature':
            if (hasValue(layerObject.portalItem)) {
                newLayer = new FeatureLayer({
                    portalItem: {
                        id: layerObject.portalItem.id
                    }
                });
            } else if (hasValue(layerObject.url)) {
                newLayer = new FeatureLayer({
                    url: layerObject.url
                });
            } else {
                let source: Array<Graphic> = [];
                layerObject.source?.forEach(graphicObject => {
                    let graphic = buildJsGraphic(graphicObject);
                    if (graphic !== null) {
                        source.push(graphic);
                    }
                });
                newLayer = new FeatureLayer({
                    source: source
                });
            }
            let featureLayer = newLayer as FeatureLayer;

            copyValuesIfExists(layerObject, featureLayer, 'minScale', 'maxScale', 'orderBy', 'objectIdField',
                'definitionExpression', 'labelingInfo', 'outFields');


                if (hasValue(layerObject.popupTemplate)) {
                    featureLayer.popupTemplate = buildJsPopupTemplate(layerObject.popupTemplate);
                }
                if (hasValue(layerObject.renderer)) {
                    let renderer = buildJsRenderer(layerObject.renderer);
                    if (renderer !== null) {
                        featureLayer.renderer = renderer;
                    }
                }
                if (hasValue(layerObject.fields)) {
                    featureLayer.fields = buildJsFields(layerObject.fields);
                }
                if (hasValue(layerObject.spatialReference)) {
                    featureLayer.spatialReference = buildJsSpatialReference(layerObject.spatialReference);
                }
                break;
            case 'vector-tile':
                if (hasValue(layerObject.portalItem)) {
                    newLayer = new VectorTileLayer({
                        portalItem: layerObject.portalItem
                    });
                } else {
                    newLayer = new VectorTileLayer({
                        url: layerObject.url
                    });
                }
                if (hasValue(layerObject.opacity)) {
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
                if (hasValue(layerObject.renderer)) {
                    gjLayer.renderer = layerObject.renderer;
                }
                if (hasValue(layerObject.spatialReference)) {
                    gjLayer.spatialReference = new SpatialReference({
                        wkid: layerObject.spatialReference.wkid
                    });
                }
                break;
            case 'geo-rss':
                newLayer = new GeoRSSLayer({ url: layerObject.url });
                break;
            case 'web-tile':
                let webTileLayer: WebTileLayer;
                if (hasValue(layerObject.urlTemplate)) {
                    webTileLayer = new WebTileLayer({
                        urlTemplate: layerObject.urlTemplate
                    });
                } else {
                    webTileLayer = new WebTileLayer({
                        portalItem: layerObject.portalItem
                    });
                }
                newLayer = webTileLayer;
    
                copyValuesIfExists(layerObject, webTileLayer,
                    'subDomains', 'blendMode', 'copyright', 'maxScale', 'minScale', 'refreshInterval')
    
                if (hasValue(layerObject.tileInfo)) {
                    webTileLayer.tileInfo = new TileInfo();
                    copyValuesIfExists(layerObject.tileInfo, webTileLayer.tileInfo,
                        'dpi', 'format', 'isWrappable', 'size');
    
                    if (hasValue(layerObject.tileInfo.lods)) {
                        webTileLayer.tileInfo.lods = layerObject.tileInfo.lods.map(l => {
                            let lod = new LOD();
                            copyValuesIfExists(l, lod, 'level', 'levelValue', 'resolution', 'scale');
                            return lod;
                        });
                    }
    
                    if (hasValue(layerObject.tileInfo.origin)) {
                        webTileLayer.tileInfo.origin = buildJsPoint(layerObject.tileInfo.origin) as Point;
                    }
    
                    if (hasValue(layerObject.tileInfo.spatialReference)) {
                        webTileLayer.tileInfo.spatialReference = buildJsSpatialReference(layerObject.tileInfo.spatialReference);
                    }
                }
    
                break;
            case 'open-street-map':
                let openStreetMapLayer: OpenStreetMapLayer;
                if (hasValue(layerObject.urlTemplate)) {
                    openStreetMapLayer = new OpenStreetMapLayer({
                        urlTemplate: layerObject.urlTemplate
                    });
                } else {
                    openStreetMapLayer = new OpenStreetMapLayer({
                        portalItem: layerObject.portalItem
                    });
                }
                newLayer = openStreetMapLayer;
    
                copyValuesIfExists(layerObject, openStreetMapLayer,
                    'subDomains', 'blendMode', 'copyright', 'maxScale', 'minScale', 'refreshInterval')
    
                if (hasValue(layerObject.tileInfo)) {
                    openStreetMapLayer.tileInfo = new TileInfo();
                    copyValuesIfExists(layerObject.tileInfo, openStreetMapLayer.tileInfo,
                        'dpi', 'format', 'isWrappable', 'size');
    
                    if (hasValue(layerObject.tileInfo.lods)) {
                        openStreetMapLayer.tileInfo.lods = layerObject.tileInfo.lods.map(l => {
                            let lod = new LOD();
                            copyValuesIfExists(l, lod, 'level', 'levelValue', 'resolution', 'scale');
                            return lod;
                        });
                    }
    
                    if (hasValue(layerObject.tileInfo.origin)) {
                        openStreetMapLayer.tileInfo.origin = buildJsPoint(layerObject.tileInfo.origin) as Point;
                    }
    
                    if (hasValue(layerObject.tileInfo.spatialReference)) {
                        openStreetMapLayer.tileInfo.spatialReference = buildJsSpatialReference(layerObject.tileInfo.spatialReference);
                    }
                }
    
                break;
            default:
                return null;
        }

    if (hasValue(layerObject.title)) {
        newLayer.title = layerObject.title;
    }

    if (hasValue(layerObject.opacity)) {
        newLayer.opacity = layerObject.opacity;
    }

    if (hasValue(layerObject.listMode)) {
        newLayer.listMode = layerObject.listMode;
    }
    if (hasValue(layerObject.visible)) {
        newLayer.visible = layerObject.visible;
    }
        
    if (hasValue(layerObject.fullExtent)) {
        newLayer.fullExtent = buildJsExtent(layerObject.fullExtent);
    }

    arcGisObjectRefs[layerObject.id] = newLayer;
    
    if (wrap) {
        return getObjectReference(layerObject.id);
    }
    
    return newLayer;
}

async function resetCenterToSpatialReference(center: Point, spatialReference: SpatialReference): Promise<Point> {
    return await projection.project(center, spatialReference) as Point;
}

export function logError(error, viewId: string) {
    error.message ??= error.toString();
    console.debug(error);
    try {
        dotNetRefs[viewId].invokeMethodAsync('OnJavascriptError', {
            message: error.message, name: error.name, stack: error.stack
        });
    } catch {
        // ignore, we've already logged to the console
    }
    unsetWaitCursor(viewId);
}


function setWaitCursor(viewId: string): void {
    let viewContainer = document.getElementById(`map-container-${viewId}`);
    if (viewContainer !== null) {
        document.body.style.cursor = 'wait';
    }
}

function unsetWaitCursor(viewId: string): void {
    let viewContainer = document.getElementById(`map-container-${viewId}`);
    if (viewContainer !== null) {
        document.body.style.cursor = 'unset';
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
                console.debug("View Render Complete");
                try {
                    dotNetRef.invokeMethodAsync('OnViewRendered');    
                }
                catch
                {
                    // we must be disconnected
                }
                isRendered = true;
            } else if (isRendered && view.updating) {
                isRendered = false;
            }
        }, 100);
    })
}

function hasValue(prop: any): boolean {
    return prop !== undefined && prop !== null;
}

function buildDotNetListItem(item: ListItem): DotNetListItem | null {
    if (item === undefined || item === null) return null;
    let children: Array<DotNetListItem> = [];
    item.children.forEach(c => {
        let child = buildDotNetListItem(c);
        if (child !== null) {
            children.push(child);
        }
    });

    return {
        title: item.title,
        layer: item.layer,
        visible: item.visible,
        children: children,
        actionSections: item.actionsSections as any
    } as DotNetListItem;
}

function copyValuesIfExists(originalObject: any, newObject: any, ...params: Array<string>) {
    params.forEach(p => {
        if (hasValue(originalObject[p])) {
            newObject[p] = originalObject[p];
        }
    });
}

function checkConnectivity(viewId) {
    let connectError = new Error('Cannot load ArcGIS Assets!');
    let message = '<div><h1>Cannot retrieve ArcGIS asset files.</h1><p><a target="_blank" href="https://docs/geoblazor.com/assetFiles"</p></div>';
    let mapContainer = document.getElementById(`map-container-${viewId}`)!; 
    try {
        //if (esriConfig.assetsPath.includes('js.arcgis.com')) return;
        let assetsUrl = esriConfig.assetsPath;
        if (!assetsUrl.endsWith('/')) {
            assetsUrl += '/';
        }
        assetsUrl += 'esri/core/libs/libtess/libtess.wasm';
        fetch(assetsUrl)
            .then(response => {
                // Check if the response is successful
                if (!response.ok){
                    mapContainer.innerHTML = message; 
                    throw connectError;
                }
            })
            .catch(error => {
                // The resource could not be reached
                mapContainer.innerHTML = message;
                logError(connectError, viewId)
            });
    } catch (err) {
        mapContainer.innerHTML = message;
        logError(connectError, viewId);
    }
}


export function addReactiveWatcher(targetId: string, targetName: string, watchExpression: string, once: boolean, 
                                   initial: boolean, dotNetRef: any) : any {
    let target = arcGisObjectRefs[targetId];
    console.debug(`Adding watch: "${watchExpression}"`);
    const watcherFunc = new Function(targetName, 'reactiveUtils', 'dotNetRef',
        `return reactiveUtils.watch(() => ${watchExpression},
        (value) => dotNetRef.invokeMethodAsync('OnReactiveWatcherUpdate', '${watchExpression}', value),
        {once: ${once}, initial: ${initial}});`);
    return watcherFunc(target, reactiveUtils, dotNetRef);
}

export function addReactiveListener(targetId: string, eventName: string, once: boolean, dotNetRef: any) : any {
    let target = arcGisObjectRefs[targetId];
    console.debug(`Adding listener: "${eventName}"`);
    const listenerFunc = new Function('target', 'reactiveUtils', 'dotNetRef',
        `return reactiveUtils.on(() => target, '${eventName}',
        (value) => dotNetRef.invokeMethodAsync('OnReactiveListenerTriggered', '${eventName}', value),
        {once: ${once}, onListenerRemove: () => console.debug('Removing listener: ${eventName}')});`);
    return listenerFunc(target, reactiveUtils, dotNetRef);
}

export async function awaitReactiveSingleWatchUpdate(targetId: string, targetName: string, watchExpression: string,
                                                     dotNetRef: any) : Promise<any> {
    let target = arcGisObjectRefs[targetId];
    console.debug(`Adding once watcher: "${watchExpression}"`);
    const AsyncFunction = (async function () {}).constructor;
    // @ts-ignore
    const onceFunc = new AsyncFunction(targetName, 'reactiveUtils', 'dotNetRef',
        `return await reactiveUtils.once(() => ${watchExpression});`);
    return await onceFunc(target, reactiveUtils, dotNetRef);
}

export function addReactiveWaiter(targetId: string, targetName: string, watchExpression: string, once: boolean, 
                                  initial: boolean, dotNetRef: any) : any {
    let target = arcGisObjectRefs[targetId];
    console.debug(`Adding when waiter: "${watchExpression}"`);
    const whenFunc = new Function(targetName, 'reactiveUtils', 'dotNetRef',
        `return reactiveUtils.when(() => ${watchExpression},
        () => { 
            console.debug('waiter == true'); 
            dotNetRef.invokeMethodAsync('OnReactiveWaiterTrue', '${watchExpression}')
        },
        {once: ${once}, initial: ${initial}});`);
    return whenFunc(target, reactiveUtils, dotNetRef);
}


export function setVisibility(componentId: string, visible: boolean) : void {
    let component : any = arcGisObjectRefs[componentId];
    component.visible = visible;
}

function buildHitTestOptions(options: DotNetHitTestOptions, view: MapView) : MapViewHitTestOptions {
    let hitOptions: MapViewHitTestOptions = {};
    let hitIncludeOptions: Array<any> = [];
    let hitExcludeOptions: Array<any> = [];
    let layers = (view.map.layers as MapCollection).items as Array<Layer>;
    let graphicsLayers = layers.filter(l => l.type === "graphics") as Array<GraphicsLayer>;
    
    if (options.includeByGeoBlazorId !== null) {
        let gbInclude = options.includeByGeoBlazorId.map(i => arcGisObjectRefs[i]);
        hitIncludeOptions = hitIncludeOptions.concat(gbInclude);
    }
    if (options.excludeByGeoBlazorId !== null) {
        let gbExclude = options.excludeByGeoBlazorId.map(i => arcGisObjectRefs[i]);
        hitExcludeOptions = hitExcludeOptions.concat(gbExclude);
    }
    if (options.includeLayersByArcGISId !== null) {
        let layerInclude = layers.filter(l => options.includeLayersByArcGISId!.includes(l.id));
        hitIncludeOptions = hitIncludeOptions.concat(layerInclude);
    }
    if (options.excludeLayersByArcGISId !== null) {
        let layerExclude = layers.filter(l => options.excludeLayersByArcGISId!.includes(l.id));
        hitExcludeOptions = hitExcludeOptions.concat(layerExclude);
    }
    if (options.includeGraphicsByArcGISId !== null) {
        let graphicInclude = options.includeGraphicsByArcGISId.map(i => 
            view.graphics.find(g => g.attributes['OBJECTID'] == i) ||
            graphicsLayers.map(l => l.graphics.find(g => g.attributes['OBJECTID'] == i)));
        hitIncludeOptions = hitIncludeOptions.concat(graphicInclude);
    }
    if (options.excludeGraphicsByArcGISId !== null) {
        let graphicExclude = options.excludeGraphicsByArcGISId.map(i =>
            view.graphics.find(g => g.attributes['OBJECTID'] == i) ||
            graphicsLayers.map(l => l.graphics.find(g => g.attributes['OBJECTID'] == i)));
        hitExcludeOptions = hitExcludeOptions.concat(graphicExclude);
    }
    
    if (hitIncludeOptions.length > 0) {
        hitOptions.include = hitIncludeOptions;
    }
    if (hitExcludeOptions.length > 0) {
        hitOptions.exclude = hitExcludeOptions;
    }
    
    return hitOptions;
}