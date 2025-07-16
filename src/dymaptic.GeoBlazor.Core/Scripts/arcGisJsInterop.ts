// noinspection JSUnusedGlobalSymbols

// region imports
import {
    DotNetExtent,
    DotNetGeometry,
    DotNetGraphic,
    DotNetGraphicHit,
    DotNetHitTestOptions,
    DotNetHitTestResult,
    DotNetPoint,
    DotNetPolygon,
    DotNetPolyline,
    DotNetPopupTemplate,
    DotNetSpatialReference,
    DotNetViewHit,
    MapCollection
} from './definitions';
import * as esriNS from "@arcgis/core/kernel.js";
import * as locator from "@arcgis/core/rest/locator";
import * as reactiveUtils from "@arcgis/core/core/reactiveUtils";
import * as route from "@arcgis/core/rest/route";
import * as serviceArea from "@arcgis/core/rest/serviceArea";
import Accessor from "@arcgis/core/core/Accessor";
import ArcGisSymbol from "@arcgis/core/symbols/Symbol";
import AuthenticationManager from "./authenticationManager";
import Camera from "@arcgis/core/Camera";
import Color from "@arcgis/core/Color";
import esriConfig from "@arcgis/core/config";
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import FeatureSet from "@arcgis/core/rest/support/FeatureSet";
import GeometryEngineWrapper from "./geometryEngine";
import Graphic from "@arcgis/core/Graphic";
import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";
import Layer from "@arcgis/core/layers/Layer";
import LocatorWrapper from "./locationService";
import Map from "@arcgis/core/Map";
import MapView from "@arcgis/core/views/MapView";
import { ArcgisMap } from "@arcgis/map-components/components/arcgis-map";
import { ArcgisScene } from "@arcgis/map-components/components/arcgis-scene";
// @ts-ignore
import normalizeUtils from "@arcgis/core/geometry/support/normalizeUtils";
import Point from "@arcgis/core/geometry/Point";
import Polygon from "@arcgis/core/geometry/Polygon";
import Polyline from "@arcgis/core/geometry/Polyline";
import Popup from "@arcgis/core/widgets/Popup";
import PopupTemplate from "@arcgis/core/PopupTemplate";
import Portal from "@arcgis/core/portal/Portal";
import * as promiseUtils from "@arcgis/core/core/promiseUtils";
import ProjectionWrapper from "./projection";
import Query from "@arcgis/core/rest/support/Query";
import RasterStretchRenderer from "@arcgis/core/renderers/RasterStretchRenderer";
import RouteParameters from "@arcgis/core/rest/support/RouteParameters";
import SceneView from "@arcgis/core/views/SceneView";
import ServiceAreaParameters from "@arcgis/core/rest/support/ServiceAreaParameters";
import SimpleRenderer from "@arcgis/core/renderers/SimpleRenderer";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import TileLayer from "@arcgis/core/layers/TileLayer";
import View from "@arcgis/core/views/View";
import WebMap from "@arcgis/core/WebMap";
import Widget from "@arcgis/core/widgets/Widget";
import {load} from "protobufjs";
import {buildDotNetExtent, buildJsExtent} from './extent';
import {buildJsGraphic} from './graphic';
import {buildDotNetLayer, buildJsLayer, preloadLayerTypes} from './layer';
import {buildDotNetPoint, buildJsPoint} from './point';
import {buildDotNetLayerView} from './layerView';
import {buildDotNetSpatialReference} from './spatialReference';
import {buildDotNetGeometry, buildJsGeometry} from './geometry';
import {buildDotNetSymbol, buildJsSymbol} from './symbol';
import {buildDotNetPopupTemplate} from './popupTemplate';
import {buildDotNetHitTestResult, buildViewExtentUpdate} from './mapView';
import {buildJsAttributes} from './attributes';
import HitTestResult = __esri.HitTestResult;
import MapViewHitTestOptions = __esri.MapViewHitTestOptions;
import ScreenPoint = __esri.ScreenPoint;
import {buildJsWidget} from "./widget";
import ColorBackground from "@arcgis/core/webmap/background/ColorBackground";
import { buildJsColor } from './mapColor';
import {buildJsBasemap} from "./basemap";

// region exports

// re-export imported types
export {
    esriConfig,
    Graphic,
    Color,
    Point,
    Polyline,
    Polygon,
    normalizeUtils,
    Portal,
    SimpleRenderer,
    buildJsLayer,
    reactiveUtils
};

export const arcGisObjectRefs: Record<string, any> = {};
// this could be either the arcGIS object or a "wrapper" class
export const jsObjectRefs: Record<string, any> = {};
export const popupTemplateRefs: Record<string, Accessor> = {};
export const graphicsRefs: Record<string, Record<string, Graphic>> = {};
export const dotNetRefs: Record<string, any> = {};
export const actionHandlers: Record<string, any> = {};
export let queryLayer: FeatureLayer;
export let blazorServer: boolean = false;

export let geometryEngine: GeometryEngineWrapper = new GeometryEngineWrapper(false);
export let projectionEngine: ProjectionWrapper = new ProjectionWrapper(false);

// region module variables

let notifyExtentChanged: boolean = true;
const uploadingLayers: Array<string> = [];
let userChangedViewExtent: boolean = false;
let pointerDown: boolean = false;

export let Pro: any;

// region functions

export async function setPro(pro): Promise<void> {
    Pro = pro;
}

// we have to wrap the JsObjectReference because a null will throw an error
// https://github.com/dotnet/aspnetcore/issues/52070
export async function getObjectRefForProperty(obj: any, prop: string): Promise<any> {
    const val = await getProperty(obj, prop);
    return {
        value: hasValue(val) ? DotNet.createJSObjectReference(val) : null
    };
}

export async function getProperty(obj: any, prop: string): Promise<any> {
    let val: any;
    if ('getProperty' in obj) {
        val = obj.getProperty(prop);
    } else {
        val = obj[prop];
    }

    return val;
}

// nullable value types cannot be correctly deserialized directly with the current Blazor implementation, so we have to wrap them
export async function getNullableValueTypedProperty(obj: any, prop: string): Promise<any> {
    const val = await getProperty(obj, prop);
    return {
        value: val
    };
}

export async function setProperty(obj: any, prop: string, value: any): Promise<void> {
    if ('setProperty' in obj) {
        obj.setProperty(prop, value);
    } else {
        obj[prop] = value;
    }
}

export function addToProperty(obj, prop, value) {
    if ('addToProperty' in obj) {
        obj.addToProperty(prop, value);
    } else if (Array.isArray(value)) {
        obj[prop].addMany(value);
    } else {
        obj[prop].add(value);
    }
}

export function removeFromProperty(obj, prop, value) {
    if ('removeFromProperty' in obj) {
        obj.removeFromProperty(prop, value);
    } else if (Array.isArray(value)) {
        obj[prop].removeMany(value);
    } else {
        obj[prop].remove(value);
    }
}

export function getJsComponent(id: string) {
    const component = jsObjectRefs[id];

    if (hasValue(component)) {
        return component;
    }
    return null;
}

export async function setSublayerProperty(layerObj: any, sublayerId: number, prop: string, value: any) {
    const sublayer = (layerObj as TileLayer)?.sublayers?.find(sl => sl.id === sublayerId);
    if (hasValue(sublayer)) {
        await setProperty(sublayer, prop, value);
    }
}

export async function setSublayerPopupTemplate(layerObj: any, sublayerId: number, popupTemplate: any, layerId: string | null,
                                               viewId: string) {
    const sublayer = (layerObj as TileLayer)?.sublayers?.find(sl => sl.id === sublayerId);
    if (hasValue(sublayer) && hasValue(popupTemplate)) {
        let {buildJsPopupTemplate} = await import('./popupTemplate');
        sublayer!.popupTemplate = await buildJsPopupTemplate(popupTemplate, layerId, viewId) as PopupTemplate;
    }
}

export function setAssetsPath(path: string) {
    if (path !== undefined && path !== null && esriConfig.assetsPath !== path) {
        esriConfig.assetsPath = `${path}/${esriNS.fullVersion.replaceAll('.', '_')}`;
    }
}

export async function getProjectionEngineWrapper(): Promise<ProjectionWrapper> {
    if (ProtoGraphicCollection === undefined) {
        await loadProtobuf();
    }
    return new ProjectionWrapper();
}

export async function getGeometryEngineWrapper(): Promise<GeometryEngineWrapper> {
    if (ProtoGraphicCollection === undefined) {
        await loadProtobuf();
    }
    return new GeometryEngineWrapper();
}

export async function getLocationServiceWrapper(): Promise<LocatorWrapper> {
    if (ProtoGraphicCollection === undefined) {
        await loadProtobuf();
    }

    return new LocatorWrapper(locator);
}

export async function buildMapView(id: string, dotNetReference: any, long: number | null, lat: number | null,
                                   rotation: number, mapObject: any, zoom: number | null, scale: number,
                                   mapType: string, widgets: any[], graphics: any,
                                   spatialReference: any, constraints: any, extent: any, backgroundColor: any,
                                   eventRateLimitInMilliseconds: number | null, activeEventHandlers: Array<string>,
                                   isServer: boolean, highlightOptions?: any | null, popupEnabled?: boolean | null, 
                                   zIndex?: number, tilt?: number)
    : Promise<void> {
    try {
        await setCursor('wait');
        notifyExtentChanged = false;
        userChangedViewExtent = false;
        blazorServer = isServer;
        const dotNetRef = dotNetReference;

        if (ProtoGraphicCollection === undefined) {
            await loadProtobuf();
        }

        checkConnectivity(id);
        // disposeView(id);
        dotNetRefs[id] = dotNetRef;
        let mapComponent: ArcgisMap | ArcgisScene = document.querySelector(`#map-container-${id}`) as ArcgisMap | ArcgisScene;
        if (!hasValue(mapComponent)) {
            // if the map component is not found, we cannot create a view
            throw new Error(`Map component with id ${id} not found.`);
        }
        let view: MapView | SceneView;
        
        // check that there is either a webmap, webscene, or basemap to load the map
        if (mapType !== 'webmap' && mapType !== 'webscene' && !hasValue(mapObject.basemap)
            && !hasValue(mapObject.arcGISDefaultBasemap)) {
            // set a default basemap if none is provided, so the map can be created
            if (mapType === 'scene') {
                
                mapObject.basemap = 'gray-3d';
            } else {
                mapObject.basemap = {
                    style : {
                        name: "arcgis/light-gray"
                    }
                }
            }
        }

        let basemap = hasValue(mapObject.basemap)
            ? await buildJsBasemap(mapObject.basemap, null, id)
            : hasValue(mapObject.arcGISDefaultBasemap)
                ? mapObject.arcGISDefaultBasemap
                : undefined;

        let spatialRef: SpatialReference | null = null;
        if (hasValue(spatialReference)) {
            let {buildJsSpatialReference} = await import('./spatialReference');
            spatialRef = buildJsSpatialReference(spatialReference) as SpatialReference;
            mapComponent.spatialReference = spatialRef;
        }
        
        if (mapComponent instanceof ArcgisMap) {
            if (mapType === 'webmap') {
                let {buildJsWebMap} = await import('./webMap');
                const webMap = await buildJsWebMap(mapObject, null, id);
                mapComponent.map = webMap;
            } else {
                const map = new Map({
                    basemap: basemap,
                    ground: mapObject.ground
                });
                mapComponent.map = map;
            }
            if (!mapComponent.ready) {
                await mapComponent.viewOnReady();
            }
            (mapComponent.view as MapView).rotation = rotation;
        } else // this check is required for ESBuild to not throw away the ArcgisScene import
            // noinspection SuspiciousTypeOfGuard
            if (mapComponent instanceof ArcgisScene) {
            if (mapType === 'webscene') {
                let {buildJsWebScene} = await import('./webScene');
                const webScene = await buildJsWebScene(mapObject, null, id);
                mapComponent.map = webScene;
            } else {
                const scene = new Map({
                    basemap: basemap,
                    ground: mapObject.ground
                });
                mapComponent.map = scene;
            }
            if (!mapComponent.ready) {
                await mapComponent.viewOnReady();
            }
            if (hasValue(lat) && hasValue(long)) {
                (mapComponent.view as SceneView).camera = {
                    position: {
                        x: long as number, //Longitude
                        y: lat as number, //Latitude
                        z: zIndex as number //Meters
                    } as Point,
                    tilt: tilt as number
                } as Camera
            }
        }
        
        view = mapComponent.view;

        if (!hasValue(view.container)) {
            // someone navigated away or rerendered the page, the view is no longer valid
            return;
        }

        if (hasValue(backgroundColor)) {
            (view as MapView).background = new ColorBackground({ color: await buildJsColor(backgroundColor) });
        }

        if (hasValue(popupEnabled)) {
            view.popupEnabled = popupEnabled as boolean;
        }

        if (hasValue(constraints)) {
            view.constraints = sanitize(constraints);
        }

        arcGisObjectRefs[id] = view;
        await dotNetRef.invokeMethodAsync('OnJsViewInitialized');
        waitForRender(id, dotNetRef);

        if (hasValue(highlightOptions)) {
            view.highlightOptions = highlightOptions;
        }

        await setEventListeners(view, dotNetRef, eventRateLimitInMilliseconds, activeEventHandlers, id);

        // popup widget needs to be registered before adding layers to not overwrite the popupTemplates
        const popupWidget = widgets.find(w => w.type === 'popup');
        if (hasValue(popupWidget)) {
            await addWidget(popupWidget, id);
        }

        if (hasValue(mapObject.layers)) {
            // add layers in reverse order to match the expected order in the map
            for (let i = mapObject.layers.length - 1; i >= 0; i--) {
                const layerObject = mapObject.layers[i];
                await addLayer(layerObject, id);
            }
        }

        for (const widget of widgets.filter(w => w.type !== 'popup')) {
            await addWidget(widget, id);
        }

        for (let i = 0; i < graphics.length; i++) {
            const graphicObject = graphics[i];
            await addGraphic(graphicObject, id, null);
        }

        if (view instanceof MapView) {
            // set the extent, center, zoom/scale after the spatial reference is set
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
        
    }
    catch (e) {
        throw e;
    } finally {
        await setCursor('unset');
    }
}

async function setEventListeners(view: MapView | SceneView, dotNetRef: any, eventRateLimit: number | null,
                                 activeEventHandlers: Array<string>, viewId: string): Promise<void> {
    if (activeEventHandlers.includes('OnClick')) {
        view.on('click', async (evt) => {
            try {
                await setCursor('wait', viewId);
                evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
                await dotNetRef.invokeMethodAsync('OnJavascriptClick', evt);
            } finally {
                await setCursor('unset', viewId);
            }
        });
    }

    // always listen for this to track extent changes
    view.on('double-click', async (evt) => {
        try {
            userChangedViewExtent = true;
            if (activeEventHandlers.includes('OnDoubleClick')) {
                // only set the cursor if there is user code to run
                await setCursor('wait', viewId);
            }
            evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
            await dotNetRef.invokeMethodAsync('OnJavascriptDoubleClick', evt);
        } finally {
            await setCursor('unset', viewId);
        }
    });

    if (activeEventHandlers.includes('OnHold')) {
        view.on('hold', async (evt) => {
            evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
            await dotNetRef.invokeMethodAsync('OnJavascriptHold', evt);
        });
    }

    if (activeEventHandlers.includes('ImmediateClick')) {
        view.on('immediate-click', async (evt) => {
            try {
                await setCursor('wait', viewId);
                evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
                await dotNetRef.invokeMethodAsync('OnJavascriptImmediateClick', evt);
            } finally {
                await setCursor('unset', viewId);
            }
        });
    }

    if (activeEventHandlers.includes('ImmediateDoubleClick')) {
        view.on('immediate-double-click', async (evt) => {
            try {
                await setCursor('wait', viewId);
                evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
                await dotNetRef.invokeMethodAsync('OnJavascriptImmediateDoubleClick', evt);
            } finally {
                await setCursor('unset', viewId);
            }
        });
    }

    if (activeEventHandlers.includes('OnBlur')) {
        view.on('blur', async (evt) => {
            await dotNetRef.invokeMethodAsync('OnJavascriptBlur', evt);
        });
    }

    if (activeEventHandlers.includes('OnFocus')) {
        view.on('focus', async (evt) => {
            await dotNetRef.invokeMethodAsync('OnJavascriptFocus', evt);
        });
    }

    // always listen for this to track extent changes
    view.on('drag', (evt) => {
        userChangedViewExtent = true;
        const dragCallback = async () => {
            await dotNetRef.invokeMethodAsync('OnJavascriptDrag', evt);
        }
        debounce(dragCallback, eventRateLimit, !hasValue(eventRateLimit))();
    });

    view.on('pointer-down', async (evt) => {
        pointerDown = true;
        await dotNetRef.invokeMethodAsync('OnJavascriptPointerDown', evt);
    });

    if (activeEventHandlers.includes('OnPointerEnter')) {
        view.on('pointer-enter', async (evt) => {
            await dotNetRef.invokeMethodAsync('OnJavascriptPointerEnter', evt);
        });
    }

    if (activeEventHandlers.includes('OnPointerLeave')) {
        view.on('pointer-leave', async (evt) => {
            pointerDown = false;
            await dotNetRef.invokeMethodAsync('OnJavascriptPointerLeave', evt);
        });
    }

    view.on('pointer-move', async (evt) => {
        if (pointerDown) {
            userChangedViewExtent = true;
        }
        const pointerMoveCallback = async () => {
            await dotNetRef.invokeMethodAsync('OnJavascriptPointerMove', evt);
        }
        debounce(pointerMoveCallback, eventRateLimit, !hasValue(eventRateLimit))();
    });

    view.on('pointer-up', async (evt) => {
        pointerDown = false;
        await dotNetRef.invokeMethodAsync('OnJavascriptPointerUp', evt);
    });

    if (activeEventHandlers.includes('OnKeyDown')) {
        view.on('key-down', async (evt) => {
            await dotNetRef.invokeMethodAsync('OnJavascriptKeyDown', evt);
        });
    }

    if (activeEventHandlers.includes('OnKeyUp')) {
        view.on('key-up', async (evt) => {
            await dotNetRef.invokeMethodAsync('OnJavascriptKeyUp', evt);
        });
    }

    view.on('layerview-create', async (evt) => {
        try {
            // find objectRef id by layer
            const layerGeoBlazorId = lookupGeoBlazorId(evt.layer);

            let isBasemapLayer = false;
            let isReferenceLayer = false;
            if (hasValue(view?.map?.basemap)) {
                if (view!.map!.basemap!.baseLayers?.includes(evt.layer)) {
                    isBasemapLayer = true;
                } else if (view!.map!.basemap!.referenceLayers?.includes(evt.layer)) {
                    isReferenceLayer = true;
                }
            }

            let jsLayer: any = evt.layer;
            let jsLayerView: any = evt.layerView;

            switch (jsLayer.type) {
                case 'feature':
                    const {default: FeatureLayerWrapper} = await import('./featureLayer');
                    jsLayer = new FeatureLayerWrapper(jsLayer);
                    const {default: FeatureLayerViewWrapper} = await import('./featureLayerView');
                    jsLayerView = new FeatureLayerViewWrapper(jsLayerView);
                    break;
                case 'geojson':
                    const {default: GeoJSONLayerWrapper} = await import('./geoJSONLayer');
                    jsLayer = new GeoJSONLayerWrapper(jsLayer);
                    const {default: GeoJSONLayerViewWrapper} = await import('./geoJSONLayerView');
                    jsLayerView = new GeoJSONLayerViewWrapper(jsLayerView);
                    break;
            }

            const layerRef = DotNet.createJSObjectReference(jsLayer);
            const layerViewRef = DotNet.createJSObjectReference(jsLayerView);

            const result = {
                layerObjectRef: layerRef,
                layerViewObjectRef: layerViewRef,
                layerView: await buildDotNetLayerView(evt.layerView),
                layer: await buildDotNetLayer(evt.layer),
                layerGeoBlazorId: layerGeoBlazorId,
                isBasemapLayer: isBasemapLayer,
                isReferenceLayer: isReferenceLayer
            }
            
            if (!hasValue(result.layer)) {
                // some layer types are only deserialized in GeoBlazor Pro, so we need to check if the layer is null
                // here and exit out if it is not supported.
                return;
            }

            const layerUid = evt.layer.id;
            if (uploadingLayers.includes(layerUid)) {
                return;
            }

            uploadingLayers.push(layerUid);

            let layerViewId: string | null;

            if (!blazorServer) {
                layerViewId = await dotNetRef.invokeMethodAsync('OnJavascriptLayerViewCreate', result);
                if (layerViewId !== null) {
                    arcGisObjectRefs[layerViewId] = evt.layerView;
                    jsObjectRefs[layerViewId] = jsLayerView;
                }
                uploadingLayers.splice(uploadingLayers.indexOf(layerUid), 1);
                return;
            }
            
            // for debugging issues below
            // findCircularReferences(result.layer);
            // findCircularReferences(result.layerView);

            // return dotNetResult in small chunks to avoid memory issues in Blazor Server
            // SignalR has a maximum message size of 32KB
            // https://github.com/dotnet/aspnetcore/issues/23179
            const jsonLayerResult = generateSerializableJson(result.layer);
            const jsonLayerViewResult = generateSerializableJson(result.layerView);
            
            if (!hasValue(jsonLayerResult) || !hasValue(jsonLayerViewResult)) {
                return;
            }
            
            const chunkSize = 1000;
            let chunks = Math.ceil(jsonLayerResult!.length / chunkSize);

            for (let i = 0; i < chunks; i++) {
                const chunk = jsonLayerResult!.slice(i * chunkSize, (i + 1) * chunkSize);
                await dotNetRef.invokeMethodAsync('OnJavascriptLayerCreateChunk', layerUid, chunk, i);
            }

            chunks = Math.ceil(jsonLayerViewResult!.length / chunkSize);
            for (let i = 0; i < chunks; i++) {
                const chunk = jsonLayerViewResult!.slice(i * chunkSize, (i + 1) * chunkSize);
                await dotNetRef.invokeMethodAsync('OnJavascriptLayerViewCreateChunk', layerUid, chunk, i);
            }

            layerViewId = await dotNetRef.invokeMethodAsync('OnJavascriptLayerViewCreateComplete', layerGeoBlazorId ?? null, layerUid,
                result.layerObjectRef, result.layerViewObjectRef, isBasemapLayer, isReferenceLayer);
            if (layerViewId !== null) {
                arcGisObjectRefs[layerViewId] = evt.layerView;
                jsObjectRefs[layerViewId] = jsLayerView;
            }
            uploadingLayers.splice(uploadingLayers.indexOf(layerUid), 1);
        } catch (e) {
            console.error(e);
        }
    });

    if (activeEventHandlers.includes('OnLayerViewCreateError')) {
        view.on('layerview-create-error', async (evt) => {
            const layerGeoBlazorId = lookupGeoBlazorId(evt.layer);
            let { buildDotNetViewLayerviewCreateErrorEvent } = await import('./viewLayerviewCreateErrorEvent');
            const dnEvent = await buildDotNetViewLayerviewCreateErrorEvent(evt, layerGeoBlazorId, viewId);
            await dotNetRef.invokeMethodAsync('OnJavascriptLayerViewCreateError', dnEvent);
        });
    }

    if (activeEventHandlers.includes('OnLayerViewDestroy')) {
        view.on('layerview-destroy', async (evt) => {
            const layerGeoBlazorId = lookupGeoBlazorId(evt.layer);
            let { buildDotNetViewLayerviewCreateErrorEvent } = await import('./viewLayerviewCreateErrorEvent');
            const dnEvent = await buildDotNetViewLayerviewCreateErrorEvent(evt, layerGeoBlazorId, viewId);
            await dotNetRef.invokeMethodAsync('OnJavascriptLayerViewDestroy', dnEvent);
        });
    }

    view.on('mouse-wheel', async (evt) => {
        userChangedViewExtent = true;
        const mouseWheelCallback = async () => {
            await setCursor('wait', viewId);
            await dotNetRef.invokeMethodAsync('OnJavascriptMouseWheel', evt);
            await setCursor('unset', viewId);
        }
        debounce(mouseWheelCallback, eventRateLimit, !hasValue(eventRateLimit))();
    });

    view.on('resize', async (evt) => {
        userChangedViewExtent = true;
        const resizeCallback = async () => {
            await setCursor('wait', viewId);
            await dotNetRef.invokeMethodAsync('OnJavascriptResize', evt);
            await setCursor('unset', viewId);
        }
        debounce(resizeCallback, eventRateLimit, !hasValue(eventRateLimit))();
    });

    reactiveUtils.watch(() => view.spatialReference, () => {
        dotNetRef.invokeMethodAsync('OnJavascriptSpatialReferenceChanged', buildDotNetSpatialReference(view.spatialReference));
    });

    reactiveUtils.watch(() => view.extent, () => {
        if (!notifyExtentChanged) return;
        userChangedViewExtent = true;
        const extentCallback = () => {
            if (!hasValue((view as MapView).extent)) {
                return;
            }
            if (view instanceof SceneView) {
                dotNetRef.invokeMethodAsync('OnJavascriptExtentChanged', buildDotNetExtent(view.extent),
                    buildDotNetPoint(view.camera.position), view.zoom, view.scale, null, view.camera.tilt);
                return;
            }
            dotNetRef.invokeMethodAsync('OnJavascriptExtentChanged', buildDotNetExtent((view as MapView).extent),
                buildDotNetPoint((view as MapView).center), (view as MapView).zoom, (view as MapView).scale,
                (view as MapView).rotation, null);
        }

        debounce(extentCallback, eventRateLimit, !hasValue(eventRateLimit))();
    });
}

function debounce(func: Function, wait: number | null, immediate: boolean) {

    // 'private' variable for instance
    // The returned function will be able to reference this due to closure.
    // Each call to the returned function will share this common timer.
    let timeout;

    // Calling debounce returns a new anonymous function
    return () => {
        // reference the context and args for the setTimeout function
        // @ts-ignore        
        const context: any = this,
        // eslint-disable-next-line prefer-rest-params
        args = arguments;

        // Should the function be called now? If immediate is true
        //   and not already in a timeout then the answer is: Yes
        if (!timeout) {
            func.apply(context, args);
            if (immediate) {
                return;
            }
        }

        // This is the basic debounce behaviour where you can call this
        //   function several times, but it will only execute once
        //   (before or after imposing a delay).
        //   Each time the returned function is called, the timer starts over.
        clearTimeout(timeout);

        // Set the new timeout
        timeout = setTimeout(function () {

            // Inside the timeout function, clear the timeout variable
            // which will let the next execution run when in 'immediate' mode
            timeout = null;

            // Check if the function already ran with the immediate flag
            if (!immediate) {
                // Call the original function with apply
                // apply lets you define the 'this' object as well as the arguments
                //    (both captured before setTimeout)
                func.apply(context, args);
            }
        }, wait ?? 300);
    }
}

export function registerGeoBlazorObject(jsObjectRef: any, geoBlazorId: string) {
    if (arcGisObjectRefs.hasOwnProperty(geoBlazorId)) {
        return;
    }
    jsObjectRefs[geoBlazorId] = jsObjectRef;
    arcGisObjectRefs[geoBlazorId] = typeof jsObjectRef.unwrap === 'function'
        ? jsObjectRef.unwrap()
        : jsObjectRef;
}

export async function registerGeoBlazorSublayer(layerId, sublayerId, sublayerGeoBlazorId) {
    const layer = arcGisObjectRefs[layerId] as TileLayer;
    let sublayer = layer?.allSublayers?.find(sl => sl.id === sublayerId);
    if (!hasValue(sublayer)) {
        return null;
    }
    arcGisObjectRefs[sublayerGeoBlazorId] = sublayer;
    let { default: SublayerWrapper } = await import('./sublayer');
    let wrapper = new SublayerWrapper(sublayer!);
    jsObjectRefs[sublayerGeoBlazorId] = wrapper;
    return wrapper;
}

export async function hitTest(screenPoint: any, viewId: string, options: DotNetHitTestOptions | null, hitTestId: string)
    : Promise<DotNetHitTestResult | void> {
    const view = arcGisObjectRefs[viewId] as MapView;
    let result: HitTestResult;

    if (options !== null) {
        const hitOptions = buildHitTestOptions(options, view);
        result = await view.hitTest(screenPoint, hitOptions);
    } else {
        result = await view.hitTest(screenPoint);
    }

    const dotNetResult = await buildDotNetHitTestResult(result, viewId);
    if (dotNetResult.results.length > 0) {
        const streamRef = getProtobufViewHitStream(dotNetResult.results);
        dotNetResult.results = [];
        const dotNetRef = dotNetRefs[viewId];
        await dotNetRef.invokeMethodAsync('OnHitTestStreamCallback', streamRef, hitTestId);
    }

    return dotNetResult;
}

export function toMap(screenPoint: any, viewId: string): DotNetPoint | null {
    const view = arcGisObjectRefs[viewId] as MapView;
    const mapPoint = view.toMap(screenPoint);
    return buildDotNetPoint(mapPoint);
}

export function toScreen(mapPoint: any, viewId: string): ScreenPoint {
    const view = arcGisObjectRefs[viewId] as MapView;
    return view.toScreen(buildJsPoint(mapPoint) as Point) as ScreenPoint;
}

export async function disposeMapComponent(componentId: string, viewId: string): Promise<void> {
    try {
        const component = arcGisObjectRefs[componentId];

        if (!hasValue(component)) {
            return;
        }

        switch (component?.declaredClass) {
            case 'esri.Graphic':
                await disposeGraphic(componentId);
                return;
        }

        if (arcGisObjectRefs.hasOwnProperty(componentId)) {
            delete arcGisObjectRefs[componentId];
        }
        if (dotNetRefs.hasOwnProperty(componentId)) {
            delete dotNetRefs[componentId];
        }
        if (jsObjectRefs.hasOwnProperty(componentId)) {
            delete jsObjectRefs[componentId];
        }
        if (popupTemplateRefs.hasOwnProperty(componentId)) {
            delete popupTemplateRefs[componentId];
        }
        if (actionHandlers.hasOwnProperty(componentId)) {
            actionHandlers[componentId].remove();
            delete actionHandlers[componentId];
        }
        const view = arcGisObjectRefs[viewId] as MapView;
        view?.ui?.remove(component as any);
        component.destroy();
    }
    catch {
        // ignore
    }
}

export async function disposeGraphic(graphicId: string) {
    for (const groupId in graphicsRefs) {
        const graphics = graphicsRefs[groupId];
        if (graphics.hasOwnProperty(graphicId)) {
            delete graphics[graphicId];
            return;
        }
    }
}

export function updateView(viewObject: any) {
    if (userChangedViewExtent) {
        return;
    }
    notifyExtentChanged = false;
    const view = arcGisObjectRefs[viewObject.id] as View;

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
    return buildViewExtentUpdate(view);
}

export async function setExtent(extentObject: any, viewId: string) {
    notifyExtentChanged = false;
    const view = arcGisObjectRefs[viewId] as MapView;
    if (!hasValue(view)) return;
    const extent = buildJsExtent(extentObject, view.spatialReference);
    if (extent !== null) {
        view.extent = extent;
    }
    return buildViewExtentUpdate(view);
}

export function setConstraints(constraintsObject: any, viewId: string) {
    const view = arcGisObjectRefs[viewId] as MapView;
    view.constraints = constraintsObject;
}

export function setHighlightOptions(highlightOptions: any, viewId: string) {
    const view = arcGisObjectRefs[viewId] as MapView;
    view.highlightOptions = highlightOptions;
}

export async function setSpatialReference(spatialReferenceObject: any, viewId: string) {
    const view = arcGisObjectRefs[viewId] as MapView;
    if (view !== undefined) {
        let {buildJsSpatialReference} = await import('./spatialReference');
        view.spatialReference = buildJsSpatialReference(spatialReferenceObject) as any;
    }
}

export async function queryFeatureLayer(queryObject: any, layerObject: any, symbol: any, popupTemplateObject: any,
                                        viewId: string): Promise<void> {
    const query = new Query({
        where: queryObject.where,
        outFields: queryObject.outFields,
        returnGeometry: queryObject.returnGeometry,
        spatialRelationship: queryObject.spatialRelationship,
    });
    const view = arcGisObjectRefs[viewId] as MapView;
    if (queryObject.useViewExtent) {
        query.geometry = view.extent;
    } else if (hasValue(queryObject.geometry)) {
        query.geometry = buildJsGeometry(queryObject.geometry)!;
    }
    let {buildJsPopupTemplate} = await import('./popupTemplate');
    const popupTemplate = await buildJsPopupTemplate(popupTemplateObject, layerObject.id, viewId) as PopupTemplate;
    await addLayer(layerObject, viewId, false, false, true, () => {
        displayQueryResults(query, symbol, popupTemplate, viewId);
    });
}

export async function removeGraphics(graphicWrapperIds: string[], viewId: string): Promise<void> {
    let view = arcGisObjectRefs[viewId] as MapView;
    
    if (!hasValue(view)) {
        return;
    }
    
    if (!graphicsRefs.hasOwnProperty(viewId)) {
        view.graphics.removeAll();
        return;
    }
    
    for (const id of graphicWrapperIds) {
        if (!graphicsRefs[viewId].hasOwnProperty(id)) {
            continue;
        }
        let graphic = graphicsRefs[viewId][id];
        if (hasValue(graphic)) {
            view.graphics.remove(graphic);
        }
        delete graphicsRefs[viewId][id];
    }
}

export async function removeGraphic(graphicId: string, viewId: string): Promise<void> {
    let view = arcGisObjectRefs[viewId] as MapView;
    if (!graphicsRefs.hasOwnProperty(viewId) || !hasValue(view)) {
        return;
    }
    
    if (!graphicsRefs[viewId].hasOwnProperty(graphicId)) {
        return;
    }
    
    let graphic = graphicsRefs[viewId][graphicId];
    if (hasValue(graphic)) {
        view.graphics.remove(graphic);
    }
    
    delete graphicsRefs[viewId][graphicId];
}

export function findPlaces(addressQueryParams: any, symbol: any, popupTemplateObject: any, viewId: string): void {
    const view = arcGisObjectRefs[viewId] as MapView;
    locator.addressToLocations(addressQueryParams.locatorUrl, {
        location: view.center,
        categories: addressQueryParams.categories,
        maxLocations: addressQueryParams.maxLocations,
        outFields: addressQueryParams.outFields,
        address: null
    })
        .then(async (results) => {
            view.popup?.close();
            view.graphics.removeAll();
            let {buildJsPopupTemplate} = await import('./popupTemplate');
            const popupTemplate = await buildJsPopupTemplate(popupTemplateObject, null, viewId) as PopupTemplate;
            results.forEach(function (result) {
                view.graphics.add(new Graphic({
                    attributes: result.attributes,
                    geometry: result.location,
                    symbol: symbol,
                    popupTemplate: popupTemplate
                }))
            });
        }).catch((error) => {
        throw error;
    });
}

export const triggerActionHandlers: Record<string, IHandle> = {};

export async function openPopup(viewId: string, options: any | null): Promise<void> {
    const view = arcGisObjectRefs[viewId] as MapView;
    if (options !== null) {
        const jsOptions = await buildJsPopupOptions(options);
        if (hasValue(options.widgetContent)) {
            const widgetContent = await buildJsWidget(options.widgetContent, options.widgetContent.layerId, viewId);
            if (hasValue(widgetContent)) {
                jsOptions.content = widgetContent as Widget;
            }
        }
        await view.openPopup(jsOptions);
    } else {
        await view.openPopup();
    }
}

export async function buildJsPopupOptions(dotNetPopupOptions: any): Promise<any> {
    let options: any = {};

    if (hasValue(dotNetPopupOptions.title)) {
        options.title = dotNetPopupOptions.title;
    }
    if (hasValue(dotNetPopupOptions.stringContent)) {
        options.content = dotNetPopupOptions.content;
    }
    if (hasValue(dotNetPopupOptions.fetchFeatures)) {
        options.fetchFeatures = dotNetPopupOptions.fetchFeatures;
    }

    if (hasValue(dotNetPopupOptions.featureMenuOpen)) {
        options.featureMenuOpen = dotNetPopupOptions.featureMenuOpen;
    }

    if (hasValue(dotNetPopupOptions.updateLocationEnabled)) {
        options.updateLocationEnabled = dotNetPopupOptions.updateLocationEnabled;
    }

    if (hasValue(dotNetPopupOptions.collapsed)) {
        options.collapsed = dotNetPopupOptions.collapsed;
    }

    if (hasValue(dotNetPopupOptions.shouldFocus)) {
        options.shouldFocus = dotNetPopupOptions.shouldFocus;
    }

    if (hasValue(dotNetPopupOptions.location)) {
        options.location = buildJsPoint(dotNetPopupOptions.location) as Point;
    }

    if (hasValue(dotNetPopupOptions.features)) {
        let features: Graphic[] = [];
        for (const f of dotNetPopupOptions.features) {
            let graphic = buildJsGraphic(f) as Graphic;
            graphic.layer = arcGisObjectRefs[f.layerId] as Layer;
            features.push(graphic);
        }
        options.features = features;
    }

    return options;
}

export function closePopup(viewId: string): void {
    const view = arcGisObjectRefs[viewId] as MapView;
    try {
        view.popup?.close();
    } catch {
        // ignore
    }
}

export async function showPopup(popupTemplateObject: any, location: DotNetPoint, viewId: string): Promise<void> {
    let {buildJsPopupTemplate} = await import('./popupTemplate');
    const popupTemplate = await buildJsPopupTemplate(popupTemplateObject, null, viewId) as PopupTemplate;
    let view = arcGisObjectRefs[viewId] as MapView;
    await view.openPopup({
        title: popupTemplate.title as string,
        content: popupTemplate.content as string,
        location: buildJsPoint(location)!
    });
}


export async function showPopupWithGraphic(graphicObject: any, options: any, viewId: string): Promise<void> {
    await addGraphic(graphicObject, viewId, null);
    const view = arcGisObjectRefs[viewId] as MapView;
    const graphic = arcGisObjectRefs[graphicObject.id] as Graphic;
    if (!hasValue(view.popup)) {
        return;
    }
    view.popup!.dockOptions = options.dockOptions;
    view.popup!.visibleElements = options.visibleElements;
    await view.openPopup({
        features: [graphic]
    });
}


export async function addGraphic(streamRefOrGraphicObject: any, viewId: string, layerId: string | null): Promise<void> {
    let graphic: Graphic;
    if (streamRefOrGraphicObject.hasOwnProperty("_streamPromise")) {
        const graphics = await getGraphicsFromProtobufStream(streamRefOrGraphicObject) as any[];
        graphic = buildJsGraphic(graphics[0]) as Graphic;
    } else {
        graphic = buildJsGraphic(streamRefOrGraphicObject) as Graphic;
    }
    const view = arcGisObjectRefs[viewId] as View;
    if (hasValue(layerId)) {
        const layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
        layer.add(graphic);
    } else {
        if (!hasValue(view?.graphics)) {
            return;
        }
        view.graphics?.add(graphic);
    }
}

export async function addGraphicsFromStream(streamRef: any, viewId: string, abortSignal: AbortSignal, layerId: string | null): Promise<void> {
    if (abortSignal.aborted) {
        return;
    }
    const graphics = await getGraphicsFromProtobufStream(streamRef) as any[];
    let jsGraphics: Graphic[] = [];
    const layer = hasValue(layerId) ? arcGisObjectRefs[layerId as string] as GraphicsLayer : null;
    const view = arcGisObjectRefs[viewId] as View;
    const existingGraphics = layer?.graphics || view.graphics;

    for (const g of graphics) {
        if (abortSignal.aborted) {
            return;
        }
        const jsGraphic = buildJsGraphic(g) as Graphic;
        jsGraphics.push(jsGraphic);
    }
    jsGraphics = jsGraphics.filter(g => !existingGraphics.includes(g));
    if (abortSignal.aborted) {
        return;
    }
    if (hasValue(layer)) {
        layer!.addMany(jsGraphics);
    } else {
        view.graphics?.addMany(jsGraphics);
    }
}

export function addGraphicsSynchronously(graphicsArray: Uint8Array, viewId: string, layerId: string | null): void {
    const graphics = decodeProtobufGraphics(graphicsArray);
    let jsGraphics: Graphic[] = [];
    const view = arcGisObjectRefs[viewId] as View;
    const layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
    const existingGraphics = layer?.graphics || view.graphics;

    for (const g of graphics) {
        const jsGraphic = buildJsGraphic(g) as Graphic;
        jsGraphics.push(jsGraphic);
    }
    jsGraphics = jsGraphics.filter(g => !existingGraphics.includes(g));
    if (hasValue(layerId)) {
        layer.graphics?.addMany(jsGraphics);
    } else {
        view.graphics?.addMany(jsGraphics);
    }
}

export function setGraphicGeometry(id: string, layerId: string | null, viewId: string | null, geometry: DotNetGeometry): void {
    const jsGeometry = buildJsGeometry(geometry);
    const graphic = lookupJsGraphicById(id, layerId, viewId);
    if (graphic !== null && jsGeometry !== null && graphic.geometry !== jsGeometry) {
        graphic.geometry = jsGeometry;
    }
}

export function getGraphicGeometry(id: string, layerId: string | null, viewId: string | null): DotNetGeometry | null {
    const graphic = lookupJsGraphicById(id, layerId, viewId);
    if (graphic !== null) {
        return buildDotNetGeometry(graphic.geometry);
    }

    return null;
}

export function setGraphicSymbol(id: string, symbol: any, layerId: string | null, viewId: string | null): void {
    const graphic = lookupJsGraphicById(id, layerId, viewId);
    const jsSymbol = buildJsSymbol(symbol);
    if (graphic !== null && hasValue(symbol) && graphic.symbol !== jsSymbol) {
        graphic.symbol = jsSymbol as any;
    }
}

export function getGraphicSymbol(id: string, layerId: string | null, viewId: string | null): any {
    const graphic = lookupJsGraphicById(id, layerId, viewId);
    if (hasValue(graphic?.symbol)) {
        return buildDotNetSymbol(graphic!.symbol!);
    }

    return null;
}

export async function setGraphicPopupTemplate(id: string, popupTemplate: DotNetPopupTemplate, dotNetRef: any,
                                              layerId: string | null, viewId: string): Promise<void> {
    const graphic = lookupJsGraphicById(id, layerId, viewId);
    popupTemplate.dotNetPopupTemplateReference = dotNetRef;
    dotNetRefs[popupTemplate.id] = dotNetRef;
    let {buildJsPopupTemplate} = await import('./popupTemplate');
    const jsPopupTemplate = await buildJsPopupTemplate(popupTemplate, layerId, viewId) as PopupTemplate;
    if (graphic !== null && hasValue(popupTemplate) && graphic.popupTemplate !== jsPopupTemplate) {
        
        graphic.popupTemplate = jsPopupTemplate;
    }
}

export async function getGraphicPopupTemplate(id: string, layerId: string | null, viewId: string): Promise<DotNetPopupTemplate | null> {
    const graphic = lookupJsGraphicById(id, layerId, viewId);
    if (graphic === null) return null;
    return await buildDotNetPopupTemplate(graphic.popupTemplate);
}

export function setGraphicAttributes(id: string, attributes: any, layerId: string | null, viewId: string | null): void {
    const graphic = lookupJsGraphicById(id, layerId, viewId);
    if (graphic !== null) {
        graphic.attributes = buildJsAttributes(attributes);
    }
}

export function getGraphicAttributes(id: string, layerId: string | null, viewId: string | null): any {
    const graphic = lookupJsGraphicById(id, layerId, viewId);
    if (graphic !== null) {
        return graphic.attributes;
    }

    return null;
}

export function getObjectIdForGraphic(id: string, layerId: string | null, viewId: string | null): string | number | null {
    const graphic = lookupJsGraphicById(id, layerId, viewId);
    if (graphic !== null) {
        return graphic.getObjectId() ?? null;
    }

    return null;
}

export async function getEffectivePopupTemplate(graphic: any, defaultPopupTemplateEnabled: any): Promise<any> {
    let jsGraphic = buildJsGraphic(graphic);
    let result = jsGraphic?.getEffectivePopupTemplate(defaultPopupTemplateEnabled);
    return await buildDotNetPopupTemplate(result);
}

export function lookupJsGraphicById(graphicId: string, layerId: string | null, viewId: string | null): Graphic | null {
    const graphicsCollectionId = layerId ?? viewId;
    if (graphicsCollectionId !== null && graphicsRefs.hasOwnProperty(graphicsCollectionId)
        && graphicsRefs[graphicsCollectionId].hasOwnProperty(graphicId)) {
        return graphicsRefs[graphicsCollectionId][graphicId] ?? null;
    }

    for (const graphicsCollection of Object.values(graphicsRefs)) {
        if (graphicsCollection.hasOwnProperty(graphicId)) {
            return graphicsCollection[graphicId];
        }
    }

    return null;
}

export function lookupGeoBlazorId(jsObject: any): string | null {
    for (const key in arcGisObjectRefs) {
        if (key === 'undefined') {
            delete arcGisObjectRefs[key];
            continue;
        }
        let item = arcGisObjectRefs[key];
        if (!hasValue(item)) {
            delete arcGisObjectRefs[key];
            continue;
        }
        if (item === jsObject
            || (hasValue(jsObject.uid) && item.uid === jsObject.uid)) {
            return key;
        }
    }

    return null;
}

export function lookupGeoBlazorGraphicId(jsObject: any): string | null {
    for (const key in graphicsRefs) {
        let group = graphicsRefs[key];
        if (!hasValue(group)) {
            continue;
        }
        for (const k2 in group) {
            let item = group[k2];
            if (!hasValue(item)) {
                delete group[k2];
                continue;
            }
            
            if (item === jsObject
                // @ts-ignore
                || (hasValue(jsObject.uid) && item.uid === jsObject.uid)) {
                return k2;
            }
        }
    }

    return null;
}

export function setGraphicOrigin(id: string, origin: any, layerId: string | null, viewId: string | null): void {
    const graphic = lookupJsGraphicById(id, layerId, viewId);
    if (hasValue(origin) && hasValue(graphic)) {
        let layer: any | undefined = undefined;
        if (arcGisObjectRefs.hasOwnProperty(origin.layerId)) {
            layer = arcGisObjectRefs[origin.layerId] as any;
        }
        graphic!.origin = {
            type: 'vector-tile',
            layer: layer,
            layerId: origin.arcGISLayerId,
            layerIndex: origin.layerIndex
        }
    }
}

export function getGraphicOrigin(id: string, layerId: string | null, viewId: string | null): any {
    const graphic = lookupJsGraphicById(id, layerId, viewId);
    if (hasValue(graphic?.origin)) {
        let layerId: any = lookupGeoBlazorId(graphic!.origin!.layer);

        return {
            layerId: layerId,
            arcGISLayerId: graphic!.origin!.layerId,
            layerIndex: graphic!.origin!.layerIndex
        };
    }

    return null;
}

export function clearGraphics(viewId: string, layerId?: string | null): void {
    const view = arcGisObjectRefs[viewId] as View;
    if (hasValue(layerId)) {
        const layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
        layer.graphics.removeAll();
        graphicsRefs[layerId as string] = {};
    } else {
        view.graphics.removeAll();
        graphicsRefs[viewId] = {};
    }
}

export async function drawRouteAndGetDirections(routeUrl: string, routeSymbol: any, viewId: string): Promise<any[]> {
    const view = arcGisObjectRefs[viewId] as View;
    const routeParams = new RouteParameters({
        stops: new FeatureSet({
            features: view.graphics.toArray()
        }),
        returnDirections: true
    });

    const data = await route.solve(routeUrl, routeParams);
    data.routeResults.forEach(function (result) {
        result.route!.symbol = routeSymbol
        view.graphics.add(result.route!);
    });
    const directions: any[] = [];
    if (data.routeResults.length > 0) {
        data.routeResults[0].directions?.features.forEach(function (result) {
            const direction = {
                text: result.attributes.text,
                length: result.attributes.length,
                time: result.attributes.time,
                ETA: result.attributes.ETA,
                maneuverType: result.attributes.maneuverType
            };
            directions.push(direction);
        });
    }

    return [];
}

export function solveServiceArea(url: string, driveTimeCutoffs: number[], serviceAreaSymbol: any, viewId: string): void {
    let jsServiceAreaSymbol = buildJsSymbol(serviceAreaSymbol);
    const view = arcGisObjectRefs[viewId] as View;
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
            if (result.serviceAreaPolygons!.features.length) {
                result.serviceAreaPolygons!.features.forEach(function (graphic) {
                    graphic.symbol = jsServiceAreaSymbol;
                    view.graphics.add(graphic, 0);
                })
            }
        }, function (error) {
            throw error
        });
}

export function getCenter(viewId: string): DotNetPoint | null {
    return buildDotNetPoint((arcGisObjectRefs[viewId] as MapView).center);
}

export function setZoom(zoom: number, viewId: string) {
    notifyExtentChanged = false;
    const view = arcGisObjectRefs[viewId] as MapView;
    view.zoom = zoom;
    return buildViewExtentUpdate(view);
}

export function getZoom(viewId: string): number {
    return (arcGisObjectRefs[viewId] as MapView).zoom;
}

export function setScale(scale: number, viewId: string) {
    notifyExtentChanged = false;
    const view = arcGisObjectRefs[viewId] as MapView;
    view.scale = scale;
    return buildViewExtentUpdate(view);
}

export function getScale(viewId: string): number {
    return (arcGisObjectRefs[viewId] as MapView).scale;
}

export function setRotation(rotation: number, viewId: string) {
    notifyExtentChanged = false;
    const view = arcGisObjectRefs[viewId] as MapView;
    view.rotation = rotation;
    return buildViewExtentUpdate(view);
}

export function getRotation(viewId: string): number {
    return (arcGisObjectRefs[viewId] as MapView).rotation;
}

export function setCenter(center: any, viewId: string): any {
    notifyExtentChanged = false;
    const view = arcGisObjectRefs[viewId] as MapView;
    view.center = buildJsPoint(center) as Point;
    return buildViewExtentUpdate(view);
}

export async function setBackgroundColor(viewId: string, color: string) {
    const view = arcGisObjectRefs[viewId] as MapView;
    if (view === undefined || view === null) return;
    view.background = new ColorBackground({
        color: await buildJsColor(color)
    });
}

export function getExtent(viewId: string): DotNetExtent | null {
    return buildDotNetExtent((arcGisObjectRefs[viewId] as MapView).extent);
}

export async function goToExtent(extentObject: any, viewId: string) {
    notifyExtentChanged = false;
    const view = arcGisObjectRefs[viewId] as MapView;
    if (!hasValue(view)) return;
    const extent = buildJsExtent(extentObject, view.spatialReference);
    if (extent !== null) {
        await view.goTo(extent);
    }
    notifyExtentChanged = true;
    return buildViewExtentUpdate(view);
}

export async function goToGraphics(graphics, viewId: string): Promise<void> {
    notifyExtentChanged = false;
    const view = arcGisObjectRefs[viewId] as MapView;
    const jsGraphics: Graphic[] = [];
    for (const graphic of graphics) {
        const jsGraphic = buildJsGraphic(graphic);
        if (jsGraphic !== null) {
            jsGraphics.push(jsGraphic);
        }
    }
    await view.goTo(jsGraphics);
    notifyExtentChanged = true;
    return buildViewExtentUpdate(view);
}

export function getSpatialReference(viewId: string): DotNetSpatialReference | null {
    const view = arcGisObjectRefs[viewId] as MapView;
    return buildDotNetSpatialReference(view?.spatialReference);
}

export function getGeometry(graphicId: string): DotNetGeometry | null {
    const graphic = arcGisObjectRefs[graphicId] as Graphic;
    return buildDotNetGeometry(graphic.geometry);
}

export function displayQueryResults(query: Query, symbol: ArcGisSymbol, popupTemplate: PopupTemplate, viewId: string):
    void {
    queryLayer.queryFeatures(query)
        .then((results) => {
            results.features.map((feature) => {
                feature.symbol = symbol as any;
                feature.popupTemplate = popupTemplate;
                return feature;
            });
            const view = arcGisObjectRefs[viewId] as MapView | SceneView;

            view.popup?.close();
            view.graphics.removeAll();
            view.graphics.addMany(results.features);
        }).catch((error) => {
        throw error;
    });
}

export async function addWidget(widget: any, viewId: string, setInContainerByDefault: boolean = false)
    : Promise<void> {
    try {
        await setCursor('wait', viewId);
        const view = arcGisObjectRefs[viewId] as MapView;
        if (view === undefined || view === null) return;
        const newWidget = await buildJsWidget(widget, widget?.layerId, viewId);
        if (!hasValue(newWidget)) {
            return;
        }
        if (newWidget instanceof Popup) {
            view.popup = newWidget;
            return;
        }

        if (hasValue(widget.containerId) && !hasValue(newWidget.container)) {
            const container = document.getElementById(widget.containerId);
            const innerContainer = document.createElement('div');
            innerContainer.className = `widget-${widget.type}`;
            const existingWidget = container?.getElementsByClassName(`widget-${widget.type}`);
            if (hasValue(existingWidget) && existingWidget!.length > 0) {
                container?.removeChild((existingWidget as HTMLCollectionOf<Element>)[0]);
            }
            container?.appendChild(innerContainer);
            newWidget.container = innerContainer;
        } else {
            // check if widget is defined inside mapview
            const inMapWidget = view.container?.parentElement?.querySelector(`#widget-container-${widget.id}`);
            const widgetContainer: HTMLElement = document.getElementById(`widget-container-${widget.id}`)!;
            if ((hasValue(inMapWidget) || !hasValue(widgetContainer)) && !setInContainerByDefault) {
                view.ui.add(newWidget, widget.position);
            } else {
                // default to using the pre-defined widget container
                widgetContainer.innerHTML = '';
                newWidget.container = widgetContainer;
            }
        }
    } finally {
        await setCursor('unset', viewId);
    }
}

export function removeWidget(widgetId: string, viewId: string): void {
    const view = arcGisObjectRefs[viewId] as MapView;
    const widget = arcGisObjectRefs[widgetId] as Widget;
    try {
        view.ui.remove(widget);
    } catch {
        //ignore
    }
    delete arcGisObjectRefs.widgetId;
}

export function setWidgetPosition(viewId: string, widgetId: string, position: string) {
    const view = arcGisObjectRefs[viewId] as MapView;
    const widget = arcGisObjectRefs[widgetId] as Widget;
    view.ui.move(widget, position);
}

export async function addLayer(layerObject: any, viewId: string, isBasemapLayer?: boolean, isReferenceLayer?: boolean,
                               isQueryLayer?: boolean, callback?: Function): Promise<void> {
    try {
        await setCursor('wait', viewId);
        const view = arcGisObjectRefs[viewId] as View;
        if (!hasValue(view?.map)) return;

        const newLayer = await buildJsLayer(layerObject, layerObject.id, viewId);

        if (!hasValue(newLayer)) return;

        if (isBasemapLayer) {
            if (layerObject.isBasemapReferenceLayer) {
                view.map?.basemap?.referenceLayers.push(newLayer);
            } else {
                view.map?.basemap?.baseLayers.push(newLayer);
            }
        } else if (isReferenceLayer) {
            view.map?.basemap?.referenceLayers.push(newLayer);
        } else if (isQueryLayer) {
            queryLayer = newLayer as FeatureLayer;
            if (callback !== undefined) {
                callback();
            }
        } else {
            view.map?.add(newLayer);
        }
    } finally {
        await setCursor('unset', viewId);
    }
}

export function removeLayer(layerId: string, viewId: string, isBasemapLayer: boolean, isReferenceLayer): void {
    const layer = arcGisObjectRefs[layerId] as Layer;
    const view = arcGisObjectRefs[viewId] as MapView;
    if (isBasemapLayer) {
        view.map?.basemap?.baseLayers.remove(layer);
    } else if (isReferenceLayer) {
        view.map?.basemap?.referenceLayers.remove(layer);
    } else {
        view.map?.remove(layer);
    }
    
    delete arcGisObjectRefs[layerId];
}

async function resetCenterToSpatialReference(center: Point, spatialReference: SpatialReference): Promise<Point> {
    let projectOperator = await import('@arcgis/core/geometry/operators/projectOperator');
    if (!projectOperator.isLoaded()) {
        await projectOperator.load();
    }
    return projectOperator.execute(center, spatialReference) as Point;
}

function waitForRender(viewId: string, dotNetRef: any): void {
    const view = arcGisObjectRefs[viewId] as View;

    try {
        view.when().then(_ => {
            let isRendered = false;
            let rendering = false;
            const interval = setInterval(async () => {
                if (view === undefined || view === null) {
                    clearInterval(interval);
                    return;
                }
                if (!view.updating && !isRendered && !rendering) {
                    notifyExtentChanged = true;
                    // listen for click on zoom widget
                    if (!widgetListenerAdded) {
                        let widgetQuery = '[title="Zoom in"], [title="Zoom out"], [title="Find my location"], [class="esri-bookmarks__list"], [title="Default map view"], [title="Reset map orientation"]';
                        let widgetButtons = document.querySelectorAll(widgetQuery);
                        for (let i = 0; i < widgetButtons.length; i++) {
                            widgetButtons[i].removeEventListener('click', setUserChangedViewExtent);
                            widgetButtons[i].addEventListener('click', setUserChangedViewExtent);
                        }
                        widgetListenerAdded = true;
                    }

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
        }).catch((error) => !promiseUtils.isAbortError(error) && console.error(error));
    } catch (error: any) {
        if (!promiseUtils.isAbortError(error)) {
            console.error(error);
        }
    }
}

let widgetListenerAdded = false;

function setUserChangedViewExtent() {
    userChangedViewExtent = true;
}

export function hasValue(prop: any): boolean {
    return prop !== undefined && prop !== null;
}

// this function should only be used for simple types that are guaranteed to succeed in serialization and conversion
export function copyValuesIfExists(originalObject: any, newObject: any, ...params: Array<string>) {
    if (hasValue(originalObject)) {
        params.forEach(p => {
            if (hasValue(originalObject[p]) && originalObject[p] !== newObject[p]) {
                newObject[p] = originalObject[p];
            }
        });
    }
}

function checkConnectivity(viewId) {
    const connectError = new Error('Cannot load ArcGIS Assets!');
    const message = '<div><h1>Cannot retrieve ArcGIS asset files.</h1><p><a target="_blank" href="https://docs/geoblazor.com/assetFiles"</p></div>';
    const mapContainer = document.getElementById(`map-container-${viewId}`)!;
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
        .catch(() => {
            // The resource could not be reached
            mapContainer.innerHTML = message;
            throw connectError;
        });
}


export function addReactiveWatcher(targetId: string, targetName: string, watchExpression: string, once: boolean,
                                   initial: boolean, dotNetRef: any): any {
    const target = arcGisObjectRefs[targetId];
    console.debug(`Adding watch: "${watchExpression}"`);
    const watcherFunc = new Function(targetName, 'reactiveUtils', 'dotNetRef', 'generateSerializableJson', 'buildJsStreamReference',
        `return reactiveUtils.watch(() => ${watchExpression},
        (value) => { 
            let jsonValue = generateSerializableJson(value);
            let jsStreamRef = buildJsStreamReference(jsonValue);
            dotNetRef.invokeMethodAsync('OnReactiveWatcherUpdate', '${watchExpression}', jsStreamRef);
        },
        {once: ${once}, initial: ${initial}});`);
    return watcherFunc(target, reactiveUtils, dotNetRef, generateSerializableJson, buildJsStreamReference);
}

export function addReactiveListener(targetId: string, eventName: string, once: boolean, dotNetRef: any): any {
    const target = arcGisObjectRefs[targetId];
    let targetName = 'target';
    let fullEventName = eventName;
    if (eventName.includes('.')) {
        let lastIndexOfDot = eventName.lastIndexOf('.');
        // split the event name into the target and the event name
        targetName = 'target.' + eventName.substring(0, lastIndexOfDot);
        eventName = eventName.substring(lastIndexOfDot + 1);
    }
    
    console.debug(`Adding listener: "${eventName}" to target: "${targetName}"`);
    const listenerFunc = new Function('target', 'reactiveUtils', 'dotNetRef', 'generateSerializableJson', 'buildJsStreamReference',
        `return reactiveUtils.on(() => ${targetName}, '${eventName}',
        (value) => {
            let jsonValue = generateSerializableJson(value);
            let jsStreamRef = buildJsStreamReference(jsonValue);
            dotNetRef.invokeMethodAsync('OnReactiveListenerTriggered', '${fullEventName}', jsStreamRef);
        },
        {once: ${once}, onListenerRemove: () => console.debug('Removing listener: ${eventName}')});`);
    return listenerFunc(target, reactiveUtils, dotNetRef, generateSerializableJson, buildJsStreamReference);
}

export async function awaitReactiveSingleWatchUpdate(targetId: string, targetName: string, watchExpression: string): Promise<any> {
    const target = arcGisObjectRefs[targetId];
    console.debug(`Adding once watcher: "${watchExpression}"`);
    const AsyncFunction = async function () {
    }.constructor;
    // @ts-ignore
    const onceFunc = new AsyncFunction(targetName, 'reactiveUtils',
        `return reactiveUtils.once(() => ${watchExpression});`);
    return await onceFunc(target, reactiveUtils);
}

export function addReactiveWaiter(targetId: string, targetName: string, watchExpression: string, once: boolean,
                                  initial: boolean, dotNetRef: any): any {
    const target = arcGisObjectRefs[targetId];
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
    const component: any | undefined = arcGisObjectRefs[componentId];
    if (component !== undefined) {
        component.visible = visible;
        return;
    }
    // check graphics too
    const graphic = lookupJsGraphicById(componentId, null, null);
    if (graphic !== null) {
        graphic.visible = visible;
        return;
    }
}

function buildHitTestOptions(options: DotNetHitTestOptions, view: MapView): MapViewHitTestOptions {
    const hitOptions: MapViewHitTestOptions = {};
    let hitIncludeOptions: Array<any> = [];
    let hitExcludeOptions: Array<any> = [];
    const layers = (view.map!.layers as MapCollection).items as Array<Layer>;
    const graphicsLayers = layers.filter(l => l.type === "graphics") as Array<GraphicsLayer>;

    if (options.includeByGeoBlazorId !== null) {
        const gbInclude = options.includeByGeoBlazorId.map(i => arcGisObjectRefs[i]);
        hitIncludeOptions = hitIncludeOptions.concat(gbInclude);
    }
    if (options.excludeByGeoBlazorId !== null) {
        const gbExclude = options.excludeByGeoBlazorId.map(i => arcGisObjectRefs[i]);
        hitExcludeOptions = hitExcludeOptions.concat(gbExclude);
    }
    if (options.includeLayersByArcGISId !== null) {
        const layerInclude = layers.filter(l => options.includeLayersByArcGISId!.includes(l.id));
        hitIncludeOptions = hitIncludeOptions.concat(layerInclude);
    }
    if (options.excludeLayersByArcGISId !== null) {
        const layerExclude = layers.filter(l => options.excludeLayersByArcGISId!.includes(l.id));
        hitExcludeOptions = hitExcludeOptions.concat(layerExclude);
    }
    if (options.includeGraphicsByArcGISId !== null) {
        const graphicInclude = options.includeGraphicsByArcGISId.map(i =>
            view.graphics.find(g => g.attributes['OBJECTID'] == i) ||
            graphicsLayers.map(l => l.graphics.find(g => g.attributes['OBJECTID'] == i)));
        hitIncludeOptions = hitIncludeOptions.concat(graphicInclude);
    }
    if (options.excludeGraphicsByArcGISId !== null) {
        const graphicExclude = options.excludeGraphicsByArcGISId.map(i =>
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

export let ProtoGraphicCollection;
export let ProtoViewHitCollection;

export async function loadProtobuf() {
    load("_content/dymaptic.GeoBlazor.Core/graphic.json", function (err, root) {
        if (err) {
            throw err;
        }
        ProtoGraphicCollection = root?.lookupType("ProtoGraphicCollection");
        ProtoViewHitCollection = root?.lookupType("ProtoViewHitCollection");
        console.debug('Protobuf graphics json loaded');
    });
}

export async function getGraphicsFromProtobufStream(streamRef): Promise<any[] | null> {
    const buffer = await streamRef.arrayBuffer();
    return decodeProtobufGraphics(new Uint8Array(buffer));
}

export function decodeProtobufGraphics(uintArray: Uint8Array): any[] {
    const decoded = ProtoGraphicCollection.decode(uintArray);
    const array = ProtoGraphicCollection.toObject(decoded, {
        defaults: false,
        enums: String,
        longs: String,
        arrays: false,
        objects: false
    });
    return array.graphics;
}

export function getProtobufGraphicStream(graphics: DotNetGraphic[], layer: FeatureLayer | null): any {
    for (let i = 0; i < graphics.length; i++) {
        updateGraphicForProtobuf(graphics[i], layer);
    }
    const obj = {
        graphics: graphics
    };
    const collection = ProtoGraphicCollection.fromObject(obj);
    const encoded = ProtoGraphicCollection.encode(collection).finish();
        return DotNet.createJSStreamReference(encoded);
}

function getProtobufViewHitStream(viewHits: DotNetViewHit[]): any {
    for (let i = 0; i < viewHits.length; i++) {
        const viewHit = viewHits[i];
        if (viewHit.type === "graphic") {
            const graphic = (viewHit as DotNetGraphicHit).graphic;
            const layer = arcGisObjectRefs[(viewHit as DotNetGraphicHit).layerId] as FeatureLayer;
            updateGraphicForProtobuf(graphic, layer);
        }
    }

    const obj = {
        viewHits: viewHits
    };
    const collection = ProtoViewHitCollection.fromObject(obj);
    const encoded = ProtoViewHitCollection.encode(collection).finish();
        return DotNet.createJSStreamReference(encoded);
}

function updateGraphicForProtobuf(graphic: DotNetGraphic, layer: FeatureLayer | null) {
    if (hasValue(graphic.attributes)) {
        const fields = layer?.fields;
        graphic.attributes = Object.keys(graphic.attributes).map(attr => {
            const typedValue = graphic.attributes[attr];
            let valueType: string | undefined = undefined;
            if (hasValue(fields)) {
                const field = fields!.find(f => f.name === attr);
                if (hasValue(field)) {
                    valueType = field!.type;
                }
            }
            valueType ??= Object.prototype.toString.call(typedValue);
            return {
                key: attr,
                value: typedValue?.toString(),
                valueType: valueType
            }
        });
    }
    if (hasValue(graphic.geometry)) {
        updateGeometryForProtobuf(graphic.geometry);
    }
    const symbol: any = graphic.symbol;
    if (hasValue(symbol)) {
        if (hasValue(symbol.color)) {
            symbol.color = {
                hexOrNameValue: symbol.color
            }
        }
        if (hasValue(symbol.haloColor)) {
            symbol.haloColor = {
                hexOrNameValue: symbol.haloColor
            }
        }
        if (hasValue(symbol.backgroundColor)) {
            symbol.backgroundColor = {
                hexOrNameValue: symbol.backgroundColor
            }
        }
        if (hasValue(symbol.borderLineColor)) {
            symbol.borderLineColor = {
                hexOrNameValue: symbol.borderLineColor
            }
        }
        if (hasValue(symbol.outline?.color)) {
            symbol.outline.color = {
                hexOrNameValue: symbol.outline.color
            }
        }
    }
}

function updateGeometryForProtobuf(geometry) {
    if (hasValue(geometry.paths)) {
        geometry.paths = (geometry as DotNetPolyline).paths.map(p => {
            return {
                points: p.map(pt => {
                    return {
                        coordinates: pt
                    }
                })
            }
        });
    } else {
        geometry.paths = [];
    }
    if (hasValue(geometry.rings)) {
        geometry.rings = (geometry as DotNetPolygon).rings.map(r => {
            return {
                points: r.map(pt => {
                    return {
                        coordinates: pt
                    }
                })
            }
        });
    } else {
        geometry.rings = [];
    }
    if (hasValue(geometry.points)) {
        geometry.points = geometry.points.map(pt => {
            return {
                coordinates: pt
            }
        });
    } else {
        geometry.points = [];
    }
}

let _authenticationManager: AuthenticationManager | null = null;

export function getAuthenticationManager(dotNetRef: any, apiKey: string | null, appId: string | null,
                                         portalUrl: string | null, trustedServers: string[] | null, fontsUrl: string | null): AuthenticationManager {
    if (_authenticationManager === null) {
        _authenticationManager = new AuthenticationManager(dotNetRef, apiKey, appId, portalUrl, trustedServers, fontsUrl);
    }
    return _authenticationManager;
}

export function getCursor(viewId: string): string {
    const view = arcGisObjectRefs[viewId] as MapView;
    return view.container!.style.cursor;
}

export async function setCursor(cursorType: string, viewId: string | null = null) {
    const view = hasValue(viewId) ? arcGisObjectRefs[viewId!] : undefined;
    if (hasValue(view)) {
        view.container.style.cursor = cursorType;
    } else {
        document.body.style.cursor = cursorType;
    }
    await delayTask();
}

export async function getWebMapBookmarks(viewId: string) {
    const view = arcGisObjectRefs[viewId] as MapView;
    if (view != null) {
        const webMap = view.map as WebMap;
        if (webMap != null) {
            const arr = webMap.bookmarks.toArray();
            const {buildDotNetBookmark} = await import('./bookmark');
            return arr.map(buildDotNetBookmark);
        }
    }
    return null;
}

export function setStretchTypeForRenderer(rendererId, stretchType) {
    const renderer = arcGisObjectRefs[rendererId] as RasterStretchRenderer;
    renderer.stretchType = stretchType;
}

export function getBrowserLanguage(): string {
    return navigator.language;
}

export function createAbortControllerAndSignal() {
    const controller = new AbortController();
    const signal = controller.signal;
    return {
                abortControllerRef: DotNet.createJSObjectReference(controller),
                abortSignalRef: DotNet.createJSObjectReference(signal)
    }
}

export async function takeScreenshot(viewId, options): Promise<any> {
    const view = arcGisObjectRefs[viewId] as MapView;
    let screenshot: __esri.Screenshot;
    if (hasValue(options)) {
        if (hasValue(options.layerIds) && options.layerIds.length > 0) {
            options.layers = options.layerIds.map(id => arcGisObjectRefs[id]);
            delete options.layerIds;
        }
        screenshot = await view.takeScreenshot(options);
    } else {
        screenshot = await view.takeScreenshot();
    }

    const buffer = base64ToArrayBuffer(screenshot.dataUrl.split(",")[1]);

        const jsStreamRef = DotNet.createJSStreamReference(buffer);

    return {
        width: screenshot.data.width,
        height: screenshot.data.height,
        colorSpace: screenshot.data.colorSpace,
        stream: jsStreamRef
    };
}

// Converts a base64 string to an ArrayBuffer
function base64ToArrayBuffer(base64): Uint8Array {
    const binaryString = atob(base64);
    const bytes = new Uint8Array(binaryString.length);
    for (let i = 0; i < binaryString.length; i++) {
        bytes[i] = binaryString.charCodeAt(i);
    }
    return bytes;
}

export function toUpperFirstChar(str: string): string {
    return str.charAt(0).toUpperCase() + str.slice(1);
}

export function toLowerFirstChar(str: string): string {
    return str.charAt(0).toLowerCase() + str.slice(1);
}


export function sanitize(dotNetObject: any): any {
    let {id, dotNetComponentReference, layerId, viewId, ...sanitizedDotNetObject} = dotNetObject;
    
    for (const key in sanitizedDotNetObject) {
        if (typeof sanitizedDotNetObject[key] === 'object' && sanitizedDotNetObject[key] !== null) {
            sanitizedDotNetObject[key] = sanitize(sanitizedDotNetObject[key]);
        }
    }
    
    return sanitizedDotNetObject;
}

export function generateSerializableJson(object: any): string | null {
    if (!hasValue(object)) {
        return null;
    }
    
    if (typeof object !== 'object') {
        return object.toString();
    }
    
    // Create a path-based tracking for circular references
    const ancestors: any[] = [];
    let json = JSON.stringify(object, function(key, value) {
        if (key.startsWith('_') || key === 'jsComponentReference') {
            return undefined;
        }

        // If value is an object (and not null or empty array), check for circularity
        if (typeof value === 'object' && value !== null &&
            !(Array.isArray(value) && value.length === 0)) {

            // `this` is the object that value is contained in,
            // i.e., its direct parent.
            while (ancestors.length > 0 && ancestors.at(-1) !== this) {
                // this pops us back up one level in the tree to find the actual parent
                ancestors.pop();
            }

            if (ancestors.includes(value)) {
                return undefined;
            }
            ancestors.push(value);
            return value;
        }

        return value;
    });
    
    return json;
}

export function removeCircularReferences(jsObject: any) {
    if (typeof jsObject !== 'object') {
        return jsObject;
    }
    let json = generateSerializableJson(jsObject);
    if (!hasValue(json)) {
        return null;
    }
    return JSON.parse(json!);
}

export function buildJsStreamReference(dnObject: any) {
    let json = generateSerializableJson(dnObject);
    if (!hasValue(json)) {
        return null;
    }
    let encoder = new TextEncoder();
    let encodedArray = encoder.encode(json!);
    return DotNet.createJSStreamReference(encodedArray);
}

export function buildEncodedJson(object: any) {
    let json = generateSerializableJson(object);
    if (!hasValue(json)) {
        return null;
    }
    let encoder = new TextEncoder();
    let encodedArray = encoder.encode(json!);
    return encodedArray;
}

export function delayTask(milliseconds: number = 0) {
    return new Promise(resolve => setTimeout(resolve, milliseconds));
}
