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
import Measurement from "@arcgis/core/widgets/Measurement";
import Bookmarks from "@arcgis/core/widgets/Bookmarks";
import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import Layer from "@arcgis/core/layers/Layer";
import VectorTileLayer from "@arcgis/core/layers/VectorTileLayer";
import TileLayer from "@arcgis/core/layers/TileLayer";
import GeoJSONLayer from "@arcgis/core/layers/GeoJSONLayer";
import CSVLayer from "@arcgis/core/layers/CSVLayer";
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
import * as reactiveUtils from "@arcgis/core/core/reactiveUtils";
import BasemapLayerList from "@arcgis/core/widgets/BasemapLayerList";
import FeatureLayerWrapper from "./featureLayer";
import KMLLayer from "@arcgis/core/layers/KMLLayer";
import WCSLayer from "@arcgis/core/layers/WCSLayer";

import {
    buildDotNetExtent,
    buildDotNetFeature,
    buildDotNetGeometry,
    buildDotNetGraphic,
    buildDotNetHitTestResult,
    buildDotNetLayer,
    buildDotNetLayerView,
    buildDotNetPoint,
    buildDotNetPopupTemplate,
    buildDotNetSpatialReference,
    buildViewExtentUpdate,
    buildDotNetBookmark
} from "./dotNetBuilder";

import {
    buildJsAttributes,
    buildJsExtent,
    buildJsFields,
    buildJsFormTemplate,
    buildJsGeometry,
    buildJsGraphic,
    buildJsPoint,
    buildJsPopup,
    buildJsPopupOptions,
    buildJsPopupTemplate,
    buildJsPortalItem,
    buildJsRenderer,
    buildJsSpatialReference,
    buildJsSymbol,
    templateTriggerActionHandler,
    buildJsBookmark,
    buildJsDimensionalDefinition,
    buildJsColorRamp,
    buildJsAlgorithmicColorRamp,
    buildJsMultipartColorRamp,
    buildJsRasterStretchRenderer
} from "./jsBuilder";
import {
    DotNetExtent,
    DotNetGeometry,
    DotNetHitTestOptions,
    DotNetHitTestResult,
    DotNetListItem,
    DotNetPoint,
    DotNetPopupTemplate,
    DotNetSpatialReference,
    MapCollection
} from "./definitions";
import WebTileLayer from "@arcgis/core/layers/WebTileLayer";
import TileInfo from "@arcgis/core/layers/support/TileInfo";
import LOD from "@arcgis/core/layers/support/LOD";
import OpenStreetMapLayer from "@arcgis/core/layers/OpenStreetMapLayer";
import Camera from "@arcgis/core/Camera";
import ProjectionWrapper from "./projection";
import GeometryEngineWrapper from "./geometryEngine";
import FeatureLayerViewWrapper from "./featureLayerView";
import Popup from "@arcgis/core/widgets/Popup";
import ElevationLayer from "@arcgis/core/layers/ElevationLayer";
import PopupWidgetWrapper from "./popupWidgetWrapper";
import { load } from "protobufjs";
import AuthenticationManager from "./authenticationManager";
import HitTestResult = __esri.HitTestResult;
import MapViewHitTestOptions = __esri.MapViewHitTestOptions;
import LegendLayerInfos = __esri.LegendLayerInfos;
import ScreenPoint = __esri.ScreenPoint;
import RasterStretchRenderer from "@arcgis/core/renderers/RasterStretchRenderer";
import DimensionalDefinition from "@arcgis/core/layers/support/DimensionalDefinition";
import ColorRamp from "@arcgis/core/rest/support/ColorRamp";
import MultipartColorRamp from "@arcgis/core/rest/support/MultipartColorRamp";
import AlgorithmicColorRamp from "@arcgis/core/rest/support/AlgorithmicColorRamp";
import Renderer from "@arcgis/core/renderers/Renderer";

export let arcGisObjectRefs: Record<string, Accessor> = {};
export let graphicsRefs: Record<string, Graphic> = {};
export let dotNetRefs = {};
export let queryLayer: FeatureLayer;
export let blazorServer: boolean = false;
export { projection, geometryEngine, Graphic };
let notifyExtentChanged: boolean = true;
let uploadingLayers: Array<string> = [];

export function getProperty(obj, prop) {
    return obj[prop];
}

export function setProperty(obj, prop, value) {
    obj[prop] = value;
}

export function setAssetsPath(path: string) {
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
    if (objectRef instanceof Popup) {
        return new PopupWidgetWrapper(objectRef);
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

export function getProjectionWrapper(dotNetRef: any): ProjectionWrapper {
    let wrapper = new ProjectionWrapper(dotNetRef);
    return wrapper;
}

export function getGeometryEngineWrapper(dotNetRef: any): GeometryEngineWrapper {
    let wrapper = new GeometryEngineWrapper(dotNetRef);
    return wrapper;
}

export async function buildMapView(id: string, dotNetReference: any, long: number | null, lat: number | null,
    rotation: number, mapObject: any, zoom: number | null, scale: number,
    mapType: string, widgets: any[], graphics: any,
    spatialReference: any, constraints: any, extent: any,
    eventRateLimitInMilliseconds: number | null, activeEventHandlers: Array<string>,
    isServer: boolean, highlightOptions?: any | null, zIndex?: number, tilt?: number)
    : Promise<void> {
    console.debug("render map");
    try {
        setWaitCursor(id);
        blazorServer = isServer;
        let dotNetRef = dotNetReference;
        if (!projection.isLoaded()) {
            await projection.load();
        }

        if (ProtoGraphicCollection === undefined) {
            await loadProtobuf();
        }

        checkConnectivity(id);
        dotNetRefs[id] = dotNetRef;

        disposeView(id);
        let view: View;

        let basemap: Basemap | undefined = undefined;
        let basemapLayers: any[] = [];
        if (!mapType.startsWith('web')) {
            if (mapObject.arcGISDefaultBasemap !== undefined &&
                mapObject.arcGISDefaultBasemap !== null) {
                basemap = mapObject.arcGISDefaultBasemap;
            } else if (hasValue(mapObject.basemap?.portalItem?.id)) {
                let portalItem = buildJsPortalItem(mapObject.basemap.portalItem);
                basemap = new Basemap({ portalItem: portalItem });
            } else if (mapObject.basemap?.layers.length > 0) {
                for (let i = 0; i < mapObject.basemap.layers.length; i++) {
                    const layerObject = mapObject.basemap.layers[i];
                    basemapLayers.push(layerObject);
                }
                basemap = new Basemap({
                    baseLayers: []
                });
            }
        }

        switch (mapType) {
            case 'webmap':
                let webMap: WebMap;
                let portalItem = buildJsPortalItem(mapObject.portalItem);
                webMap = new WebMap({ portalItem: portalItem });
                view = new MapView({
                    container: `map-container-${id}`,
                    map: webMap
                });
                break;
            case 'webscene':
                let webScene: WebScene;
                let scenePortalItem = buildJsPortalItem(mapObject.portalItem);
                webScene = new WebScene({ portalItem: scenePortalItem });
                view = new SceneView({
                    container: `map-container-${id}`,
                    map: webScene
                });
                break;
            case 'scene':
                const scene = new Map({
                    basemap: basemap,
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
                    basemap: basemap,
                    ground: mapObject.ground
                });

                view = new MapView({
                    map: map,
                    container: `map-container-${id}`,
                    rotation: rotation
                });
                break;
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

        setEventListeners(view, dotNetRef, eventRateLimitInMilliseconds, activeEventHandlers);

        // popup widget needs to be registered before adding layers to not overwrite the popupTemplates
        let popupWidget = widgets.find(w => w.type === 'popup');
        if (hasValue(popupWidget)) {
            await addWidget(popupWidget, id);
        }

        if (hasValue(mapObject.layers)) {
            for (const layerObject of mapObject.layers) {
                await addLayer(layerObject, id);
            }
        }

        for (const l of basemapLayers) {
            await addLayer(l, id, true);
        }

        for (const widget of widgets.filter(w => w.type !== 'popup')) {
            await addWidget(widget, id);
        }

        for (let i = 0; i < graphics.length; i++) {
            const graphicObject = graphics[i];
            await addGraphic(graphicObject, id);
        }

        let spatialRef: SpatialReference | null = null;
        if (hasValue(spatialReference)) {
            spatialRef = buildJsSpatialReference(spatialReference);
            view.spatialReference = spatialRef;
        }

        if (view instanceof MapView) {
            if (hasValue(extent) && (hasValue(extent.spatialReference) || hasValue(spatialRef))) {
                (view as MapView).extent = buildJsExtent(extent, spatialRef);
            } else {
                let center;

                if (hasValue(lat) && hasValue(long)) {
                    if (hasValue(spatialRef)) {
                        center = new Point({
                            latitude: lat as number,
                            longitude: long as number,
                            spatialReference: spatialRef as SpatialReference
                        });
                        center = await resetCenterToSpatialReference(center, spatialRef as SpatialReference);
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
        }

        unsetWaitCursor(id);
    } catch (error) {
        logError(error, id);
    }
}

function setEventListeners(view: __esri.View, dotNetRef: any, eventRateLimit: number | null,
    activeEventHandlers: Array<string>): void {
    if (activeEventHandlers.includes('OnClick')) {
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

    view.on('pointer-down', (evt) => {
        dotNetRef.invokeMethodAsync('OnJavascriptPointerDown', evt);
    });

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

    if (activeEventHandlers.includes('OnPointerMove')) {
        let lastPointerMoveCall: number = 0;
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

    view.on('pointer-up', (evt) => {
        dotNetRef.invokeMethodAsync('OnJavascriptPointerUp', evt);
    });

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

    view.on('layerview-create', async (evt) => {
        // find objectRef id by layer
        let layerGeoBlazorId = Object.keys(arcGisObjectRefs).find(key => arcGisObjectRefs[key] === evt.layer);
        let isBasemapLayer = false;
        if (view.map.basemap.baseLayers.includes(evt.layer) || view.map.basemap.referenceLayers.includes(evt.layer)) {
            isBasemapLayer = true;
        }
        let layerRef;
        let layerViewRef;
        if (evt.layer instanceof FeatureLayer) {
            // @ts-ignore
            layerRef = DotNet.createJSObjectReference(new FeatureLayerWrapper(evt.layer));
            // @ts-ignore
            layerViewRef = DotNet.createJSObjectReference(new FeatureLayerViewWrapper(evt.layerView));
        } else {
            // @ts-ignore
            layerRef = DotNet.createJSObjectReference(evt.layer);
            // @ts-ignore
            layerViewRef = DotNet.createJSObjectReference(evt.layerView);
        }

        let result = {
            layerObjectRef: layerRef,
            layerViewObjectRef: layerViewRef,
            layerView: buildDotNetLayerView(evt.layerView),
            layer: buildDotNetLayer(evt.layer),
            layerGeoBlazorId: layerGeoBlazorId,
            isBasemapLayer: isBasemapLayer
        }

        let layerUid = evt.layer.id;
        if (uploadingLayers.includes(layerUid)) {
            return;
        }

        uploadingLayers.push(layerUid);

        if (!blazorServer) {
            await dotNetRef.invokeMethodAsync('OnJavascriptLayerViewCreate', result);
            uploadingLayers.splice(uploadingLayers.indexOf(layerUid), 1);
            return;
        }

        // return dotNetResult in small chunks to avoid memory issues in Blazor Server
        // SignalR has a maximum message size of 32KB
        // https://github.com/dotnet/aspnetcore/issues/23179
        let jsonLayerResult = JSON.stringify(result.layer);
        let jsonLayerViewResult = JSON.stringify(result.layerView);
        let chunkSize = 1000;
        let chunks = Math.ceil(jsonLayerResult.length / chunkSize);

        for (let i = 0; i < chunks; i++) {
            let chunk = jsonLayerResult.slice(i * chunkSize, (i + 1) * chunkSize);
            await dotNetRef.invokeMethodAsync('OnJavascriptLayerCreateChunk', layerUid, chunk, i);
        }

        chunks = Math.ceil(jsonLayerViewResult.length / chunkSize);
        for (let i = 0; i < chunks; i++) {
            let chunk = jsonLayerViewResult.slice(i * chunkSize, (i + 1) * chunkSize);
            await dotNetRef.invokeMethodAsync('OnJavascriptLayerViewCreateChunk', layerUid, chunk, i);
        }

        await dotNetRef.invokeMethodAsync('OnJavascriptLayerViewCreateComplete', layerGeoBlazorId ?? null, layerUid,
            result.layerObjectRef, result.layerViewObjectRef, isBasemapLayer);
        uploadingLayers.splice(uploadingLayers.indexOf(layerUid), 1);
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
        if (!notifyExtentChanged) return;
        let now = Date.now();
        if (eventRateLimit !== undefined && eventRateLimit !== null &&
            lastExtentChangeCall + eventRateLimit > now) {
            return;
        }
        lastExtentChangeCall = now;
        if (view instanceof SceneView) {
            dotNetRef.invokeMethodAsync('OnJavascriptExtentChanged', buildDotNetExtent(view.extent),
                buildDotNetPoint(view.camera.position), view.zoom, view.scale, null, view.camera.tilt);
            return;
        }
        dotNetRef.invokeMethodAsync('OnJavascriptExtentChanged', buildDotNetExtent((view as MapView).extent),
            buildDotNetPoint((view as MapView).center), (view as MapView).zoom, (view as MapView).scale,
            (view as MapView).rotation, null);
    });
}

export async function hitTest(pointObject: any, eventId: string | null, viewId: string,
    isEvent: boolean, options: DotNetHitTestOptions | null): Promise<DotNetHitTestResult | void> {
    let view = arcGisObjectRefs[viewId] as MapView;
    let result: HitTestResult;
    let screenPoint = isEvent ? pointObject : { x: pointObject.x, y: pointObject.y };

    if (options !== null) {
        let hitOptions = buildHitTestOptions(options, view);
        result = await view.hitTest(screenPoint, hitOptions);
    } else {
        result = await view.hitTest(screenPoint);
    }

    let dotNetResult = buildDotNetHitTestResult(result);
    if (!blazorServer) {
        return dotNetResult;
    }

    let dotNetRef = dotNetRefs[viewId];
    let jsonResult = JSON.stringify(dotNetResult);
    // return dotNetResult in small chunks to avoid memory issues in Blazor Server
    // SignalR has a maximum message size of 32KB
    // https://github.com/dotnet/aspnetcore/issues/23179
    let chunkSize = 1000;
    let chunks = Math.ceil(jsonResult.length / chunkSize);
    for (let i = 0; i < chunks; i++) {
        let chunk = jsonResult.slice(i * chunkSize, (i + 1) * chunkSize);
        await dotNetRef.invokeMethodAsync('OnJavascriptHitTestResult', eventId, chunk);
    }
}

export function toMap(screenPoint: any, viewId: string): DotNetPoint | null {
    let view = arcGisObjectRefs[viewId] as MapView;
    let mapPoint = view.toMap(screenPoint);
    return buildDotNetPoint(mapPoint);
}

export function toScreen(mapPoint: any, viewId: string): ScreenPoint {
    let view = arcGisObjectRefs[viewId] as MapView;
    return view.toScreen(mapPoint);
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
        disposeGraphic(componentId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function disposeGraphic(graphicId: string) {
    try {
        let graphic = graphicsRefs[graphicId];
        graphic?.destroy();
        delete graphicsRefs[graphicId];
    } catch (error) {
        logError(error, graphicId);
    }
}

export function updateView(viewObject: any) {
    try {
        setWaitCursor(viewObject.id);
        notifyExtentChanged = false;
        let view = arcGisObjectRefs[viewObject.id] as View;

        if (view instanceof MapView) {
            if (hasValue(viewObject.latitude) && hasValue(viewObject.longitude) &&
                (viewObject.latitude?.toFixed(2) !== view.center?.latitude?.toFixed(2) ||
                    viewObject.longitude?.toFixed(2) !== view.center?.longitude?.toFixed(2))) {
                view.center = new Point({
                    latitude: viewObject.latitude,
                    longitude: viewObject.longitude
                });
            } else if (hasValue(viewObject.zoom) && viewObject.zoom !== view.zoom) {
                view.zoom = viewObject.zoom;
            }

            if (hasValue(viewObject.rotation) && viewObject.rotation !== view.rotation) {
                view.rotation = viewObject.rotation;
            }
        } else if (view instanceof SceneView && hasValue(viewObject.tilt)) {
            if (hasValue(viewObject.latitude) && hasValue(viewObject.longitude) &&
                (viewObject.latitude?.toFixed(2) !== view.center?.latitude?.toFixed(2) ||
                    viewObject.longitude?.toFixed(2) !== view.center?.longitude?.toFixed(2) ||
                    viewObject.tilt !== view.camera.tilt || viewObject.zIndex !== view.camera.position.z)) {
                view.camera = new Camera({
                    position: {
                        latitude: viewObject.latitude,
                        longitude: viewObject.longitude,
                        z: viewObject.zIndex
                    },
                    tilt: viewObject.tilt
                });
            }
        }
        unsetWaitCursor(viewObject.id);
        return buildViewExtentUpdate(view);
    } catch (error) {
        logError(error, viewObject.id);
    }
}

export async function setExtent(extentObject: any, viewId: string) {
    try {
        notifyExtentChanged = false;
        let view = arcGisObjectRefs[viewId] as MapView;
        if (!hasValue(view)) return;
        let extent = buildJsExtent(extentObject, view.spatialReference);
        if (extent !== null) {
            view.extent = extent;
        }
        return buildViewExtentUpdate(view);
    } catch (error) {
        logError(error, viewId);
    }
}

export function setConstraints(constraintsObject: any, viewId: string) {
    try {
        let view = arcGisObjectRefs[viewId] as MapView;
        view.constraints = constraintsObject;
    } catch (error) {
        logError(error, viewId);
    }
}

export function setHighlightOptions(highlightOptions: any, viewId: string) {
    try {
        let view = arcGisObjectRefs[viewId] as MapView;
        view.highlightOptions = highlightOptions;
    } catch (error) {
        logError(error, viewId);
    }
}

export function setSpatialReference(spatialReferenceObject: any, viewId: string) {
    try {
        let view = arcGisObjectRefs[viewId] as MapView;
        if (view !== undefined) {
            view.spatialReference = buildJsSpatialReference(spatialReferenceObject);
        }
    } catch (error) {
        logError(error, viewId);
    }
}

export async function queryFeatureLayer(queryObject: any, layerObject: any, symbol: any, popupTemplateObject: any,
    viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
        let query = new Query({
            where: queryObject.where,
            outFields: queryObject.outFields,
            returnGeometry: queryObject.returnGeometry,
            spatialRelationship: queryObject.spatialRelationship,
        });
        let view = arcGisObjectRefs[viewId] as MapView;
        if (queryObject.useViewExtent) {
            query.geometry = view.extent;
        } else if (hasValue(queryObject.geometry)) {
            query.geometry = buildJsGeometry(queryObject.geometry)!;
        }
        let popupTemplate = buildJsPopupTemplate(popupTemplateObject, viewId);
        await addLayer(layerObject, viewId, false, true, () => {
            displayQueryResults(query, symbol, popupTemplate, viewId);
        });
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function removeGraphics(graphicWrapperIds: string[], viewId: string, layerId?: string | null): void {
    try {
        setWaitCursor(viewId);
        let view = arcGisObjectRefs[viewId] as View;
        let graphicsToRemove: Graphic[] = [];
        if (hasValue(layerId)) {
            let layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
            layer.removeMany(graphicsToRemove);
        } else {
            view.graphics.removeMany(graphicsToRemove);
        }
        (async () => {
            for (const id of graphicWrapperIds) {
                graphicsToRemove.push(graphicsRefs[id]);
                delete graphicsRefs[id];
            }
        })();
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function removeGraphic(graphicId: string, viewId: string, layerId?: string | null): void {
    try {
        setWaitCursor(viewId);
        let view = arcGisObjectRefs[viewId] as View;
        let graphic = graphicsRefs[graphicId];
        if (hasValue(layerId)) {
            let layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
            layer.remove(graphic);
        } else {
            view.graphics.remove(graphic);
        }
        delete graphicsRefs[graphicId];

        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export async function updateLayer(layerObject: any, viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
        let currentLayer = arcGisObjectRefs[layerObject.id] as Layer;
        let view = arcGisObjectRefs[viewId] as View;

        if (currentLayer === undefined) {
            unsetWaitCursor(viewId);
            return;
        }

        switch (layerObject.type) {
            case 'feature':
                let featureLayer = currentLayer as FeatureLayer;
                if (hasValue(layerObject.portalItem)) {
                    if (layerObject.portalItem.id !== featureLayer.portalItem.id) {
                        featureLayer.portalItem.id = layerObject.portalItem.id;
                        if (hasValue(layerObject.portalItem?.portal.url) &&
                            layerObject.portalItem.portal.url !== featureLayer.portalItem.portal?.url) {
                            featureLayer.portalItem.portal.url = layerObject.portalItem.portal.url;
                        }
                        if (hasValue(layerObject.portalItem?.apiKey) &&
                            layerObject.portalItem.apiKey !== featureLayer.portalItem.apiKey) {
                            featureLayer.portalItem.apiKey = layerObject.portalItem.apiKey;
                        }
                    }
                } else if (hasValue(layerObject.url) && layerObject.url !== featureLayer.url) {
                    featureLayer.url = layerObject.url;
                } else {
                    if (hasValue(layerObject.spatialReference) &&
                        layerObject.spatialReference.wkid !== featureLayer.spatialReference.wkid) {
                        featureLayer.spatialReference = buildJsSpatialReference(layerObject.spatialReference);
                    }
                }

                if (hasValue(layerObject.fullExtent) && layerObject.fullExtent !== currentLayer.fullExtent) {
                    currentLayer.fullExtent = buildJsExtent(layerObject.fullExtent, view.spatialReference);
                }
                if (hasValue(layerObject.popupTemplate)) {
                    featureLayer.popupTemplate = buildJsPopupTemplate(layerObject.popupTemplate, viewId);
                }
                // on first pass the renderer is often left blank, but it fills in when the round trip happens to the server
                if (hasValue(layerObject.renderer) && layerObject.renderer.type !== featureLayer.renderer.type) {
                    let renderer = buildJsRenderer(layerObject.renderer);
                    if (renderer !== null && featureLayer.renderer !== renderer) {
                        featureLayer.renderer = renderer;
                    }
                }
                if (hasValue(layerObject.fields) && layerObject.fields.length > 0) {
                    featureLayer.fields = buildJsFields(layerObject.fields);
                }

                copyValuesIfExists(layerObject, featureLayer, 'minScale', 'maxScale', 'orderBy', 'objectIdField',
                    'definitionExpression', 'labelingInfo', 'outFields');

                break;
            case 'geo-json':
                let geoJsonLayer = currentLayer as GeoJSONLayer;
                if (hasValue(layerObject.renderer)) {
                    let renderer = buildJsRenderer(layerObject.renderer);
                    if (renderer !== null) {
                        geoJsonLayer.renderer = renderer;
                    }
                }
                if (hasValue(layerObject.spatialReference) &&
                    layerObject.spatialReference.wkid !== geoJsonLayer.spatialReference.wkid) {
                    geoJsonLayer.spatialReference = new SpatialReference({
                        wkid: layerObject.spatialReference.wkid
                    });
                }
                if (hasValue(layerObject.fullExtent) && layerObject.fullExtent !== currentLayer.fullExtent) {
                    currentLayer.fullExtent = buildJsExtent(layerObject.fullExtent, view.spatialReference);
                }
                break;
            case 'web-tile':
                let webTileLayer = currentLayer as WebTileLayer;
                copyValuesIfExists(layerObject, webTileLayer,
                    'subDomains', 'blendMode', 'copyright', 'maxScale', 'minScale', 'refreshInterval');

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

                    if (hasValue(layerObject.tileInfo.origin) &&
                        (layerObject.tileInfo.origin.x !== webTileLayer.tileInfo.origin.x ||
                            layerObject.tileInfo.origin.y !== webTileLayer.tileInfo.origin.y)) {
                        webTileLayer.tileInfo.origin = buildJsPoint(layerObject.tileInfo.origin) as Point;
                    }

                    if (hasValue(layerObject.tileInfo.spatialReference) &&
                        layerObject.tileInfo.spatialReference.wkid !== webTileLayer.tileInfo.spatialReference.wkid) {
                        webTileLayer.tileInfo.spatialReference = buildJsSpatialReference(layerObject.tileInfo.spatialReference);
                    }
                }

                if (hasValue(layerObject.fullExtent) && layerObject.fullExtent !== currentLayer.fullExtent) {
                    currentLayer.fullExtent = buildJsExtent(layerObject.fullExtent, view.spatialReference);
                }
                break;
            case 'open-street-map':
                let openStreetMapLayer = currentLayer as OpenStreetMapLayer;
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

                    if (hasValue(layerObject.tileInfo.origin) &&
                        (layerObject.tileInfo.origin.x !== openStreetMapLayer.tileInfo.origin.x ||
                            layerObject.tileInfo.origin.y !== openStreetMapLayer.tileInfo.origin.y)) {
                        openStreetMapLayer.tileInfo.origin = buildJsPoint(layerObject.tileInfo.origin) as Point;
                    }

                    if (hasValue(layerObject.tileInfo.spatialReference) &&
                        layerObject.tileInfo.spatialReference.wkid !== openStreetMapLayer.tileInfo.spatialReference.wkid) {
                        openStreetMapLayer.tileInfo.spatialReference = buildJsSpatialReference(layerObject.tileInfo.spatialReference);
                    }
                }

                break;
        }

        if (hasValue(layerObject.opacity) && layerObject.opacity !== currentLayer.opacity &&
            layerObject.opacity >= 0 && layerObject.opacity <= 1) {
            currentLayer.opacity = layerObject.opacity;
        }

        if (hasValue(layerObject.title) && layerObject.title !== currentLayer.title) {
            currentLayer.title = layerObject.title;
        }

        if (hasValue(layerObject.listMode) && layerObject.listMode !== currentLayer.listMode) {
            currentLayer.listMode = layerObject.listMode;
        }
        if (hasValue(layerObject.visible) && layerObject.visible !== currentLayer.visible) {
            currentLayer.visible = layerObject.visible;
        }

        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export async function updateWidget(widgetObject: any, viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
        let currentWidget = arcGisObjectRefs[widgetObject.id] as Widget;
        let view = arcGisObjectRefs[viewId] as View;

        if (currentWidget === undefined) {
            unsetWaitCursor(viewId);
            return;
        }

        switch (widgetObject.type) {
            case 'bookmarks':
                let bookmarks = currentWidget as Bookmarks;
                bookmarks.bookmarks = widgetObject.bookmarks.map(buildJsBookmark)
                break;
        }
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
                let popupTemplate = buildJsPopupTemplate(popupTemplateObject, viewId);
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

export async function setPopup(popup: any, viewId: string): Promise<Popup | null> {
    try {
        let view = arcGisObjectRefs[viewId] as View;

        let jsPopup = await buildJsPopup(popup, viewId);
        if (hasValue(popup.widgetContent)) {
            let widgetContent = await createWidget(popup.widgetContent, popup.viewId);
            if (hasValue(widgetContent)) {
                jsPopup.content = widgetContent as Widget;
            }
        }

        view.popup = jsPopup;
        if (hasValue(triggerActionHandler)) {
            triggerActionHandler.remove();
        }
        if (hasValue(templateTriggerActionHandler)) {
            templateTriggerActionHandler.remove();
        }
        triggerActionHandler = view.popup.on("trigger-action", async (event) => {
            await popup.dotNetWidgetReference.invokeMethodAsync("OnTriggerAction", event.action.id);
        });
        return jsPopup;
    } catch (error) {
        logError(error, popup.viewId);
        return null;
    }
}

export let triggerActionHandler: IHandle;

export async function openPopup(viewId: string, options: any | null): Promise<void> {
    try {
        let view = arcGisObjectRefs[viewId] as View;
        if (options !== null) {
            let jsOptions = await buildJsPopupOptions(options);
            if (hasValue(options.widgetContent)) {
                let widgetContent = await createWidget(options.widgetContent, viewId);
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

export function closePopup(viewId: string): void {
    try {
        let view = arcGisObjectRefs[viewId] as View;
        view.popup.close();
    } catch (error) {
        logError(error, viewId);
    }
}

export async function showPopup(popupTemplateObject: any, location: DotNetPoint, viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
        let popupTemplate = buildJsPopupTemplate(popupTemplateObject, viewId);
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
        await addGraphic(graphicObject, viewId);
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


export async function addGraphic(streamRefOrGraphicObject: any, viewId: string, layerId?: string | null): Promise<void> {
    try {
        setWaitCursor(viewId);
        let graphic: Graphic;
        let graphicId: string;
        if (streamRefOrGraphicObject.hasOwnProperty("_streamPromise")) {
            let graphics = await getGraphicsFromProtobufStream(streamRefOrGraphicObject) as any[];
            graphic = buildJsGraphic(graphics[0], viewId) as Graphic;
            graphicId = graphics[0].id;
        } else {
            graphic = buildJsGraphic(streamRefOrGraphicObject, viewId) as Graphic;
            graphicId = streamRefOrGraphicObject.id;
        }
        let view = arcGisObjectRefs[viewId] as View;
        if (hasValue(layerId)) {
            let layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
            layer.add(graphic);
        } else {
            if (!hasValue(view?.graphics)) {
                unsetWaitCursor(viewId);
                return;
            }
            view.graphics?.add(graphic);
        }
        graphicsRefs[graphicId] = graphic;
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export async function addGraphicsFromStream(streamRef: any, viewId: string, abortSignal: AbortSignal, layerId?: string | null): Promise<void> {
    try {
        if (abortSignal.aborted) {
            return;
        }
        let graphics = await getGraphicsFromProtobufStream(streamRef) as any[];
        let jsGraphics: Graphic[] = [];
        let view = arcGisObjectRefs[viewId] as View;
        for (const g of graphics) {
            if (abortSignal.aborted) {
                return;
            }
            let jsGraphic = buildJsGraphic(g, viewId) as Graphic;
            jsGraphics.push(jsGraphic);
        }
        if (abortSignal.aborted) {
            return;
        }
        if (hasValue(layerId)) {
            let layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
            layer.addMany(jsGraphics);
        } else {
            view.graphics?.addMany(jsGraphics);
        }
        (async () => {
            for (let i = 0; i < jsGraphics.length; i++) {
                if (abortSignal.aborted) {
                    return;
                }
                let graphic = jsGraphics[i];
                let graphicObject = graphics[i];
                graphicsRefs[graphicObject.id] = graphic;
            }
        })();
    } catch (error) {
        logError(error, viewId);
    }
}

export function addGraphicsSyncInterop(graphicsArray: Uint8Array, viewId: string, layerId?: string | null): void {
    try {
        let graphics = decodeProtobufGraphics(graphicsArray);
        let jsGraphics: Graphic[] = [];
        let view = arcGisObjectRefs[viewId] as View;
        for (const g of graphics) {
            let jsGraphic = buildJsGraphic(g, viewId) as Graphic;
            jsGraphics.push(jsGraphic);
        }
        if (hasValue(layerId)) {
            let layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
            layer.graphics?.addMany(jsGraphics);
        } else {
            view.graphics?.addMany(jsGraphics);
        }
        (async () => {
            for (let i = 0; i < jsGraphics.length; i++) {
                let graphic = jsGraphics[i];
                let graphicObject = graphics[i];
                graphicsRefs[graphicObject.id] = graphic;
            }
        })();
    } catch (error) {
        logError(error, viewId);
    }
}

export function setGraphicGeometry(id: string, geometry: DotNetGeometry): void {
    let jsGeometry = buildJsGeometry(geometry);
    let graphic = graphicsRefs[id];
    if (hasValue(graphic) && jsGeometry !== null && graphic.geometry !== jsGeometry) {
        graphic.geometry = jsGeometry;
    }
}

export function getGraphicGeometry(id: string): DotNetGeometry | null {
    let graphic = graphicsRefs[id];
    if (hasValue(graphic)) {
        return buildDotNetGeometry(graphic.geometry);
    }

    return null;
}

export function setGraphicSymbol(id: string, symbol: any): void {
    let graphic = graphicsRefs[id];
    let jsSymbol = buildJsSymbol(symbol);
    if (hasValue(graphic) && hasValue(symbol) && graphic.symbol !== jsSymbol) {
        graphic.symbol = jsSymbol as any;
    }
}

export function getGraphicSymbol(id: string): any {
    return graphicsRefs[id]?.symbol;
}

export function setGraphicVisibility(id: string, visible: boolean): void {
    let graphic = graphicsRefs[id];
    if (hasValue(graphic)) {
        graphic.visible = visible;
    }
}

export function getGraphicVisibility(id: string): boolean {
    return graphicsRefs[id]?.visible;
}

export function setGraphicPopupTemplate(id: string, popupTemplate: DotNetPopupTemplate, dotNetRef: any, viewId: string): void {
    let graphic = graphicsRefs[id];
    popupTemplate.dotNetPopupTemplateReference = dotNetRef;
    let jsPopupTemplate = buildJsPopupTemplate(popupTemplate, viewId);
    if (hasValue(graphic) && hasValue(popupTemplate) && graphic.popupTemplate !== jsPopupTemplate) {
        graphic.popupTemplate = jsPopupTemplate;
    }
}

export function getGraphicPopupTemplate(id: string): DotNetPopupTemplate | null {
    let graphic = graphicsRefs[id];
    if (!hasValue(graphic)) return null;
    return buildDotNetPopupTemplate(graphic.popupTemplate);
}

export function setGraphicAttributes(Id: string, attributes: any): void {
    let graphic = graphicsRefs[Id];
    if (hasValue(graphic)) {
        graphic.attributes = buildJsAttributes(attributes);
    }
}


export function clearGraphics(viewId: string, layerId?: string | null): void {
    try {
        setWaitCursor(viewId);
        let view = arcGisObjectRefs[viewId] as View;
        if (hasValue(layerId)) {
            let layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
            layer.graphics?.removeAll();
            (async () => {
                for (const key in graphicsRefs) {
                    if (graphicsRefs.hasOwnProperty(key)) {
                        const graphic = graphicsRefs[key];
                        if (graphic.layer == layer) {
                            delete graphicsRefs[key];
                        }
                    }
                }
            })();
        } else {
            view.graphics.removeAll();
            (async () => {
                for (const key in graphicsRefs) {
                    if (graphicsRefs.hasOwnProperty(key)) {
                        const graphic = graphicsRefs[key];
                        if (!hasValue(graphic.layer)) {
                            delete graphicsRefs[key];
                        }
                    }
                }
            })();
        }
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
                if (result.serviceAreaPolygons.features.length) {
                    result.serviceAreaPolygons.features.forEach(function (graphic) {
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

export function getCenter(viewId: string): DotNetPoint | null {
    return buildDotNetPoint((arcGisObjectRefs[viewId] as MapView).center);
}

export function setZoom(zoom: number, viewId: string) {
    notifyExtentChanged = false;
    let view = arcGisObjectRefs[viewId] as MapView;
    view.zoom = zoom;
    return buildViewExtentUpdate(view);
}

export function getZoom(viewId: string): number {
    return (arcGisObjectRefs[viewId] as MapView).zoom;
}

export function setScale(scale: number, viewId: string) {
    notifyExtentChanged = false;
    let view = arcGisObjectRefs[viewId] as MapView;
    view.scale = scale;
    return buildViewExtentUpdate(view);
}

export function getScale(viewId: string): number {
    return (arcGisObjectRefs[viewId] as MapView).scale;
}

export function setRotation(rotation: number, viewId: string) {
    notifyExtentChanged = false;
    let view = arcGisObjectRefs[viewId] as MapView;
    view.rotation = rotation;
    return buildViewExtentUpdate(view);
}

export function getRotation(viewId: string): number {
    return (arcGisObjectRefs[viewId] as MapView).rotation;
}

export function setCenter(center: any, viewId: string): any {
    notifyExtentChanged = false;
    let view = arcGisObjectRefs[viewId] as MapView;
    view.center = buildJsPoint(center) as Point;
    return buildViewExtentUpdate(view);
}

export function getExtent(viewId: string): DotNetExtent | null {
    return buildDotNetExtent((arcGisObjectRefs[viewId] as MapView).extent);
}

export async function goToExtent(extentObject: any, viewId: string) {
    try {
        notifyExtentChanged = false;
        let view = arcGisObjectRefs[viewId] as MapView;
        if (!hasValue(view)) return;
        let extent = buildJsExtent(extentObject, view.spatialReference);
        if (extent !== null) {
            await view.goTo(extent);
        }
        notifyExtentChanged = true;
        return buildViewExtentUpdate(view);
    } catch (error) {
        logError(error, viewId);
    }
}

export async function goToGraphics(graphics, viewId: string): Promise<void> {
    notifyExtentChanged = false;
    let view = arcGisObjectRefs[viewId] as MapView;
    let jsGraphics: Graphic[] = [];
    for (const graphic of graphics) {
        delete graphic.dotNetGraphicReference;
        delete graphic.layerId;
        let jsGraphic = buildJsGraphic(graphic, viewId);
        if (jsGraphic !== null) {
            jsGraphics.push(jsGraphic);
        }
    }
    await view.goTo(jsGraphics);
    notifyExtentChanged = true;
    return buildViewExtentUpdate(view);
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
        if (view === undefined || view === null) return;
        let newWidget = await createWidget(widget, viewId);
        if (newWidget === null || newWidget instanceof Popup) return;

        if (hasValue(widget.containerId)) {
            let container = document.getElementById(widget.containerId);
            let innerContainer = document.createElement('div');
            innerContainer.id = `widget-${widget.type}`;
            let existingWidget = document.getElementById(`widget-${widget.type}`);
            if (existingWidget !== null) {
                container?.removeChild(existingWidget);
            }
            container?.appendChild(innerContainer);
            newWidget.container = innerContainer;
        } else {
            view.ui.add(newWidget, widget.position);
        }
    } catch (error) {
        logError(error, viewId);
    }
}

async function createWidget(widget: any, viewId: string): Promise<Widget | null> {
    let view = arcGisObjectRefs[viewId] as MapView;

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
                widget.searchWidgetObjectReference.invokeMethodAsync('OnJavaScriptSearchSelectResult', {
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
                    if (hasValue(returnItem)) {
                        evt.item.title = returnItem.title;
                        evt.item.visible = returnItem.visible;
                        //evt.item.layer = returnItem.layer; //--> needs implementation
                        //evt.item.children = returnItem.children; //--> needs implementation
                        /// <summary>
                        ///     The Action Sections property and corresponding functionality will be fully implemented
                        ///     in a future iteration.  Currently, a user can view available layers in the layer list widget
                        ///     and toggle the selected layer's visiblity. More capabilities will be available after full
                        ///     implementation of ActionSection.
                        //evt.item.actionSections = returnItem.actionSections as any;
                    }
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

            if (hasValue(widget.hasCustomBaseListHandler)) {
                basemapLayerListWidget.baseListItemCreatedFunction = async (evt) => {
                    let dotNetBaseListItem = buildDotNetListItem(evt.item);
                    let returnItem = await widget.baseLayerListWidgetObjectReference.invokeMethodAsync('OnBaseListItemCreated', dotNetBaseListItem) as DotNetListItem;
                    if (hasValue(returnItem)) {
                        evt.item.title = returnItem.title;
                        evt.item.visible = returnItem.visible;
                        // basemap will require additional implementation (similar to layerlist above) to activate additional layer and action sections.
                        //evt.item.layer = returnItem.layer; //--> needs implementation
                        // evt.item.children = returnItem.children; //--> needs implementation
                        // evt.item.actionSections = returnItem.actionSections as any;
                    }
                };
            }
            if (hasValue(widget.hasCustomReferenceListHandler)) {
                basemapLayerListWidget.baseListItemCreatedFunction = async (evt) => {
                    let dotNetReferenceListItem = buildDotNetListItem(evt.item);
                    let returnItem = await widget.baseLayerListWidgetObjectReference.invokeMethodAsync('OnReferenceListItemCreated', dotNetReferenceListItem) as DotNetListItem;
                    if (hasValue(returnItem)) {
                        evt.item.title = returnItem.title;
                        evt.item.visible = returnItem.visible;
                        // basemap will require additional implementation (similar to layerlist above) to activate additional layer and action sections.
                        // evt.item.layer = returnItem.layer; //--> needs implementation
                        // evt.item.children = returnItem.children; //--> needs implementation
                        // evt.item.actionSections = returnItem.actionSections as any;
                    }
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
            let content: any;
            if (hasValue(widget.widgetContent)) {
                await createWidget(widget.widgetContent, viewId);
                content = arcGisObjectRefs[widget.widgetContent.id] as Widget;
            } else {
                content = widget.htmlContent;
            }
            view.ui.remove(content);
            const expand = new Expand({
                view,
                content: content,
                expanded: widget.expanded,
                mode: widget.mode,
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

            if (hasValue(widget.expandIcon)) {
                expand.expandIcon = widget.expandIcon;
            }

            if (hasValue(widget.collapseIcon)) {
                expand.collapseIcon = widget.collapseIcon;
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
            newWidget = await setPopup(widget, viewId) as Popup;
            break;
        case 'measurement':
            newWidget = new Measurement({
                view: view,
                activeTool: widget.activeTool ?? undefined,
                areaUnit: widget.areaUnit ?? undefined,
                linearUnit: widget.linearUnit ?? undefined,
                label: widget.label ?? undefined,
                icon: widget.icon ?? undefined,
            });
            break;
        case 'bookmarks':
            const bookmarkWidget = new Bookmarks({
                view: view,
                editingEnabled: widget.editingEnabled,
                disabled: widget.disabled,
                icon: widget.icon,
                label: widget.label
            });
            if (widget.bookmarks != null) {
                bookmarkWidget.bookmarks = widget.bookmarks.map(buildJsBookmark);
            }

            bookmarkWidget.on('bookmark-select', (event) => {
                widget.dotNetWidgetReference.invokeMethodAsync('OnJavascriptBookmarkSelect', {
                    bookmark: buildDotNetBookmark(event.bookmark)
                });
            });

            newWidget = bookmarkWidget;
            break;
        default:
            return null;
    }

    if (hasValue(widget.icon)) {
        newWidget.icon = widget.icon;
    }

    if (hasValue(widget.widgetId)) {
        newWidget.id = widget.widgetId;
    }

    arcGisObjectRefs[widget.id] = newWidget;
    dotNetRefs[widget.id] = widget.dotNetComponentReference;
    // @ts-ignore
    let jsRef = DotNet.createJSObjectReference(getObjectReference(widget.id));
    await widget.dotNetWidgetReference.invokeMethodAsync('OnWidgetCreated', jsRef);
    return newWidget;
}

export function removeWidget(widgetId: string, viewId: string): void {
    let view = arcGisObjectRefs[viewId] as MapView;
    let widget = arcGisObjectRefs[widgetId] as Widget;
    try {
        view.ui.remove(widget);
    } catch {
        //ignore
    }
    delete arcGisObjectRefs.widgetId;
}

export async function addLayer(layerObject: any, viewId: string, isBasemapLayer?: boolean, isQueryLayer?: boolean,
    callback?: Function): Promise<void> {
    try {
        let view = arcGisObjectRefs[viewId] as View;
        if (!hasValue(view?.map)) return;

        let newLayer: Layer | null;
        if (arcGisObjectRefs.hasOwnProperty(layerObject.id)) {
            newLayer = arcGisObjectRefs[layerObject.id] as Layer;
            if (newLayer.destroyed) {
                newLayer = await createLayer(layerObject, null, viewId);
            }
        } else {
            newLayer = await createLayer(layerObject, null, viewId);
        }

        if (newLayer === null) return;

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

export async function createLayer(layerObject: any, wrap?: boolean | null, viewId?: string | null): Promise<Layer | null> {
    let newLayer: Layer;
    switch (layerObject.type) {
        case 'graphics':
            newLayer = new GraphicsLayer();
            let graphicsLayer = newLayer as GraphicsLayer;
            let jsGraphics: Graphic[] = [];
            for (const g of layerObject.graphics) {
                let jsGraphic = buildJsGraphic(g, viewId ?? null) as Graphic;
                jsGraphics.push(jsGraphic);
            }
            graphicsLayer.addMany(jsGraphics);
            for (let i = 0; i < jsGraphics.length; i++) {
                let graphic = jsGraphics[i];
                let graphicObject = layerObject.graphics[i];
                graphicsRefs[graphicObject.id] = graphic;
            }
            break;
        case 'feature':
            if (hasValue(layerObject.portalItem)) {
                let portalItem = buildJsPortalItem(layerObject.portalItem);

                newLayer = new FeatureLayer({ portalItem: portalItem });
            } else if (hasValue(layerObject.url)) {
                newLayer = new FeatureLayer({
                    url: layerObject.url
                });
            } else {
                let source: Array<Graphic> = [];
                if (hasValue(layerObject.source)) {
                    for (let i = 0; i < layerObject.source.length; i++) {
                        const graphicObject = layerObject.source[i];
                        let graphic = buildJsGraphic(graphicObject, viewId ?? null);
                        if (graphic !== null) {
                            source.push(graphic);
                        }
                    }
                }

                newLayer = new FeatureLayer({
                    source: source
                });
            }
            let featureLayer = newLayer as FeatureLayer;

            copyValuesIfExists(layerObject, featureLayer, 'minScale', 'maxScale', 'orderBy', 'objectIdField',
                'definitionExpression', 'labelingInfo', 'outFields');

            if (hasValue(layerObject.formTemplate)) {
                featureLayer.formTemplate = buildJsFormTemplate(layerObject.formTemplate);
            }

            if (hasValue(layerObject.popupTemplate)) {
                featureLayer.popupTemplate = buildJsPopupTemplate(layerObject.popupTemplate, viewId ?? null);
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
                let portalItem = buildJsPortalItem(layerObject.portalItem);
                newLayer = new VectorTileLayer({ portalItem: portalItem });
            } else {
                newLayer = new VectorTileLayer({
                    url: layerObject.url
                });
            }
            break;
        case 'tile':
            if (hasValue(layerObject.portalItem)) {
                let portalItem = buildJsPortalItem(layerObject.portalItem);

                newLayer = new TileLayer({ portalItem: portalItem });
            } else {
                newLayer = new TileLayer({
                    url: layerObject.url
                });
            }
            copyValuesIfExists(layerObject, newLayer, 'minScale', 'maxScale', 'opacity');
            break;
        case 'elevation':
            if (hasValue(layerObject.portalItem)) {
                let portalItem = buildJsPortalItem(layerObject.portalItem);
                newLayer = new ElevationLayer({ portalItem: portalItem });
            } else {
                newLayer = new ElevationLayer({
                    url: layerObject.url
                });
            }
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
                let portalItem = buildJsPortalItem(layerObject.portalItem);
                webTileLayer = new WebTileLayer({ portalItem: portalItem });
            }
            newLayer = webTileLayer;

            copyValuesIfExists(layerObject, webTileLayer,
                'subDomains', 'blendMode', 'copyright', 'maxScale', 'minScale', 'refreshInterval');

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
            } else if (hasValue(layerObject.portalItem)) {
                let portalItem = buildJsPortalItem(layerObject.portalItem);
                openStreetMapLayer = new OpenStreetMapLayer({ portalItem: portalItem });
            } else {
                openStreetMapLayer = new OpenStreetMapLayer();
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
        case 'csv':
            newLayer = new CSVLayer({
                url: layerObject.url,
                copyright: layerObject.copyright
            });
            let csvLayer = newLayer as CSVLayer;
            if (hasValue(layerObject.renderer)) {
                csvLayer.renderer = buildJsRenderer(layerObject.renderer) as Renderer;
            }
            if (hasValue(layerObject.spatialReference)) {
                csvLayer.spatialReference = new SpatialReference({
                    wkid: layerObject.spatialReference.wkid
                });
            }
            if (hasValue(layerObject.popupTemplate)) {
                csvLayer.popupTemplate = buildJsPopupTemplate(layerObject.popupTemplate, viewId ?? null);
            }
            
            copyValuesIfExists(layerObject, csvLayer, 'blendMode', 'copyright', 'delimiter', 'displayField');
            break;
        case 'kml':
            let kmlLayer: KMLLayer;
            if (hasValue(layerObject.url)) {
                kmlLayer = new KMLLayer({
                    url: layerObject.url
                });
            } else {
                let portalItem = buildJsPortalItem(layerObject.portalItem);
                kmlLayer = new KMLLayer({ portalItem: portalItem });
            }
            newLayer = kmlLayer;
            copyValuesIfExists(layerObject, kmlLayer, 'sublayers', 'blendMode', 'maxScale', 'minScale', 'title', 'visible');
            break;
        case 'wcs':
            newLayer = new WCSLayer({
                url: layerObject.url,
                title: layerObject.title
            });
            let wcsLayer = newLayer as WCSLayer;
            
            if (hasValue(layerObject.renderer) && (layerObject.renderer.type == 'raster-stretch')) {
                wcsLayer.renderer = buildJsRasterStretchRenderer(layerObject.renderer) as RasterStretchRenderer;

                if (hasValue(layerObject.renderer.stretchType)) {
                    wcsLayer.renderer.stretchType = layerObject.renderer.stretchType;
                }
                if (hasValue(layerObject.renderer.statistics)) {
                    wcsLayer.renderer.statistics = layerObject.renderer.statistics;
                }
            }
            if (hasValue(layerObject.multidimensionalDefinition) && layerObject.multidimensionalDefinition.length > 0) {
                wcsLayer.multidimensionalDefinition = [];
                for (let i = 0; i < layerObject.multidimensionalDefinition.length; i++) {

                    let wcsMDD = new DimensionalDefinition;
                    if (hasValue(layerObject.multidimensionalDefinition.VariableName)) {
                        wcsMDD.variableName = layerObject.multidimensionalDefinition.VariableName;
                    }
                    if (hasValue(layerObject.multidimensionalDefinition.DimensionName)) {
                        wcsMDD.dimensionName = layerObject.multidimensionalDefinition.DimensionName;
                    }
                    if (hasValue(layerObject.multidimensionalDefinition.Values)) {
                        wcsMDD.values = layerObject.multidimensionalDefinition.Values;
                    }
                    if (hasValue(layerObject.multidimensionalDefinition.isSlice)) {
                        wcsMDD.isSlice = layerObject.multidimensionalDefinition.isSlice;
                    }
                    wcsLayer.multidimensionalDefinition.push(wcsMDD);
                }
            }
            copyValuesIfExists(layerObject, 'bandIds', 'copyright', 'coverageId', 'coverageInfo', 'customParameters', 'fields', 'interpolation', 'maxScale', 'minscale', 'rasterInfo');

            newLayer = wcsLayer;
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

    if (hasValue(layerObject.fullExtent) && layerObject.type !== 'open-street-map') {
        newLayer.fullExtent = buildJsExtent(layerObject.fullExtent, null);
    }

    arcGisObjectRefs[layerObject.id] = newLayer;

    if (wrap) {
        return getObjectReference(layerObject.id);
    }

    return newLayer;
}

export function removeLayer(layerId: string, viewId: string, isBasemapLayer: boolean): void {
    try {
        let layer = arcGisObjectRefs[layerId] as Layer;
        let view = arcGisObjectRefs[viewId] as MapView;
        if (isBasemapLayer) {
            view.map?.basemap.baseLayers.remove(layer);
        } else {
            view.map?.remove(layer);
        }
        layer.destroy();
        delete arcGisObjectRefs.layerId;
    } catch (error) {
        logError(error, viewId);
    }
}

async function resetCenterToSpatialReference(center: Point, spatialReference: SpatialReference): Promise<Point> {
    return await projection.project(center, spatialReference) as Point;
}

export function logError(error, viewId: string | null) {
    error.message ??= error.toString();
    console.debug(error);
    if (viewId !== null) {
        try {
            dotNetRefs[viewId].invokeMethodAsync('OnJavascriptError', {
                message: error.message, name: error.name, stack: error.stack
            });
        } catch {
            // ignore, we've already logged to the console
        }
        unsetWaitCursor(viewId);
    }
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
        let rendering = false;
        let interval = setInterval(async () => {
            if (view === undefined || view === null) {
                clearInterval(interval);
                return;
            }
            if (!view.updating && !isRendered && !rendering) {
                notifyExtentChanged = true;
                console.debug(new Date() + " - View Render Complete");
                try {
                    rendering = true;
                    await dotNetRef.invokeMethodAsync('OnJsViewRendered');
                } catch {
                    // we must be disconnected
                }
                rendering = false;
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
        if (hasValue(originalObject[p]) && originalObject[p] !== newObject[p]) {
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
                if (!response.ok) {
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
    initial: boolean, dotNetRef: any): any {
    let target = arcGisObjectRefs[targetId];
    console.debug(`Adding watch: "${watchExpression}"`);
    const watcherFunc = new Function(targetName, 'reactiveUtils', 'dotNetRef',
        `return reactiveUtils.watch(() => ${watchExpression},
        (value) => dotNetRef.invokeMethodAsync('OnReactiveWatcherUpdate', '${watchExpression}', value),
        {once: ${once}, initial: ${initial}});`);
    return watcherFunc(target, reactiveUtils, dotNetRef);
}

export function addReactiveListener(targetId: string, eventName: string, once: boolean, dotNetRef: any): any {
    let target = arcGisObjectRefs[targetId];
    console.debug(`Adding listener: "${eventName}"`);
    const listenerFunc = new Function('target', 'reactiveUtils', 'dotNetRef',
        `return reactiveUtils.on(() => target, '${eventName}',
        (value) => dotNetRef.invokeMethodAsync('OnReactiveListenerTriggered', '${eventName}', value),
        {once: ${once}, onListenerRemove: () => console.debug('Removing listener: ${eventName}')});`);
    return listenerFunc(target, reactiveUtils, dotNetRef);
}

export async function awaitReactiveSingleWatchUpdate(targetId: string, targetName: string, watchExpression: string,
    dotNetRef: any): Promise<any> {
    let target = arcGisObjectRefs[targetId];
    console.debug(`Adding once watcher: "${watchExpression}"`);
    const AsyncFunction = (async function () {
    }).constructor;
    // @ts-ignore
    const onceFunc = new AsyncFunction(targetName, 'reactiveUtils', 'dotNetRef',
        `return await reactiveUtils.once(() => ${watchExpression});`);
    return await onceFunc(target, reactiveUtils, dotNetRef);
}

export function addReactiveWaiter(targetId: string, targetName: string, watchExpression: string, once: boolean,
    initial: boolean, dotNetRef: any): any {
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


export function setVisibility(componentId: string, visible: boolean): void {
    let component: any | undefined = arcGisObjectRefs[componentId];
    if (component !== undefined) {
        component.visible = visible;
    }
}

function buildHitTestOptions(options: DotNetHitTestOptions, view: MapView): MapViewHitTestOptions {
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

let ProtoGraphicCollection;

export async function loadProtobuf() {
    load("_content/dymaptic.GeoBlazor.Core/graphic.json", function (err, root) {
        if (err) throw err;
        ProtoGraphicCollection = root?.lookupType("ProtoGraphicCollection");
    });
}

export async function getGraphicsFromProtobufStream(streamRef): Promise<any[] | null> {
    try {
        const buffer = await streamRef.arrayBuffer();
        console.debug(new Date() + " - " + buffer.byteLength + " bytes received from server.");
        return decodeProtobufGraphics(new Uint8Array(buffer));
    } catch (error) {
        logError(error, null);
        return null;
    }
}

export function decodeProtobufGraphics(uintArray: Uint8Array): any[] {
    let decoded = ProtoGraphicCollection.decode(uintArray);
    let array = ProtoGraphicCollection.toObject(decoded, {
        defaults: false,
        enums: String,
        longs: String,
        arrays: false,
        objects: false
    });
    console.debug(new Date() + " - " + array.graphics.length + " graphics decoded from protobuf.");
    return array.graphics;
}

export function encodeProtobufGraphics(graphics: any[]): Uint8Array {
    let obj = {
        graphics: graphics
    };
    let collection = ProtoGraphicCollection.fromObject(obj);
    let encoded = ProtoGraphicCollection.encode(collection).finish();
    return encoded;
}

let _authenticationManager: AuthenticationManager | null = null;

export function getAuthenticationManager(dotNetRef: any, apiKey: string | null, appId: string | null,
    portalUrl: string | null): AuthenticationManager {
    if (_authenticationManager === null) {
        _authenticationManager = new AuthenticationManager(dotNetRef, apiKey, appId, portalUrl);
    }
    return _authenticationManager;
}

export function getCursor(viewId: string): string {
    let view = arcGisObjectRefs[viewId] as MapView;
    return view.container.style.cursor;
}

export function setCursor(cursorType: string, viewId: string) {
    let view = arcGisObjectRefs[viewId] as MapView;
    view.container.style.cursor = cursorType;
}

export function getWebMapBookmarks(viewId: string) {
    let view = arcGisObjectRefs[viewId] as MapView;
    if (view != null) {
        let webMap = view.map as WebMap;
        if (webMap != null) {
            let arr = webMap.bookmarks.toArray();
            if (arr instanceof Array) {
                let abc = arr.map(buildDotNetBookmark);
                return abc;
            }
        }
    }
    return null;
}