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
import * as MapComponents from '@arcgis/map-components';
import * as Calcite from "@esri/calcite-components";
import * as esriNS from "@arcgis/core/kernel.js";
import * as locator from "@arcgis/core/rest/locator";
import * as reactiveUtils from "@arcgis/core/core/reactiveUtils";
import * as route from "@arcgis/core/rest/route";
import * as serviceArea from "@arcgis/core/rest/serviceArea";
import Accessor from "@arcgis/core/core/Accessor";
import ArcGisSymbol from "@arcgis/core/symbols/Symbol";
import Camera from "@arcgis/core/Camera";
import Color from "@arcgis/core/Color";
import esriConfig from "@arcgis/core/config";
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import FeatureSet from "@arcgis/core/rest/support/FeatureSet";
import GeometryEngineWrapper from "./geometryEngine";
import Graphic from "@arcgis/core/Graphic";
import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";
import Layer from "@arcgis/core/layers/Layer";
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
import {buildDotNetGraphic, buildJsGraphic} from './graphic';
import {buildDotNetLayer, buildJsLayer, buildJsLayerWrapper} from './layer';
import {buildDotNetPoint, buildJsPoint} from './point';
import {buildDotNetLayerView, buildJsLayerViewWrapper} from './layerView';
import {buildDotNetSpatialReference} from './spatialReference';
import {buildDotNetGeometry, buildJsGeometry} from './geometry';
import {buildDotNetSymbol, buildJsSymbol} from './symbol';
import {buildDotNetPopupTemplate} from './popupTemplate';
import {buildJsAttributes} from './attributes';
import HitTestResult = __esri.HitTestResult;
import MapViewHitTestOptions = __esri.MapViewHitTestOptions;
import ScreenPoint = __esri.ScreenPoint;
import ViewHit = __esri.ViewHit;
import {buildJsWidget} from "./widget";
import ColorBackground from "@arcgis/core/webmap/background/ColorBackground";
import { buildJsColor } from './mapColor';
import {buildJsBasemap} from "./basemap";
import GeoJSONLayer from "@arcgis/core/layers/GeoJSONLayer";
import {
    arcGisObjectRefs,
    dotNetRefs,
    jsObjectRefs,
    buildJsStreamReference,
    generateSerializableJson,
    sanitize,
    setCursor,
    base64ToArrayBuffer,
    setProperty,
    addHeadLink,
    checkHeadLink,
    removeHeadLink,
    lookupGeoBlazorId,
    logUncaughtError,
    disposeMapComponent
} from "./geoBlazorCore";
// endregion

// region exports
globalThis.esriConfig = esriConfig;

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

export const popupTemplateRefs: Record<string, Accessor> = {};
export const graphicsRefs: Record<string, Record<string, Graphic>> = {};
export const actionHandlers: Record<string, any> = {};
export let queryLayer: FeatureLayer;
export let blazorServer: boolean = false;
export let ProtoGraphicCollection;
export let ProtoViewHitCollection;
export let geometryEngine: GeometryEngineWrapper = new GeometryEngineWrapper(false);
export let projectionEngine: ProjectionWrapper = new ProjectionWrapper(false);

// region module variables
let notifyExtentChanged: boolean = true;
const uploadingLayers: Array<string> = [];
let userChangedViewExtent: boolean = false;
let pointerDown: boolean = false;

// endregion

// region functions
export function getArcGISVersion() {
    return esriNS.version;
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
        esriConfig.assetsPath = path;
        MapComponents.setAssetPath(path);
        Calcite.setAssetPath(path);
    }
}

export function setTheme(theme: string | null, viewId): string | null {
    if (hasValue(theme)) {
        if (theme === 'dark') {
            removeHeadLink('/esri/themes/light/main.css');
            addHeadLink(`${esriConfig.assetsPath}/esri/themes/dark/main.css`);
        } else {
            removeHeadLink('/esri/themes/dark/main.css');
            addHeadLink(`${esriConfig.assetsPath}/esri/themes/light/main.css`);
        }
    } else if (checkHeadLink(`${esriConfig.assetsPath}/esri/themes/dark/main.css`)) {
        theme = 'dark';
    } else {
        theme = 'light';
        addHeadLink(`${esriConfig.assetsPath}/esri/themes/light/main.css`);
    }
    
    setViewTheme(theme, viewId);
    
    return theme;
}

function setViewTheme(theme, viewId: string): void {
    if (arcGisObjectRefs.hasOwnProperty(viewId)) {
        let view = arcGisObjectRefs[viewId] as MapView | SceneView | null;
        if (hasValue(view)) {
            view!.container!.style.colorScheme = theme as string;
            if (theme === 'dark' && !view!.ui.container!.classList.contains('calcite-mode-dark')) {
                // if the view was already rendered, this class is missed and needs adding
                view!.ui.container!.classList.add('calcite-mode-dark');
            }
        }
    }
}


export async function buildArcGisMapView(abortSignal: AbortSignal, id: string, dotNetReference: any, 
                                   long: number | null, lat: number | null, rotation: number | null, mapObject: any, 
                                   zoom: number | null, scale: number, mapType: string, widgets: any[], graphics: any,
                                   spatialReference: any, constraints: any, extent: any, backgroundColor: any,
                                   eventRateLimitInMilliseconds: number | null, activeEventHandlers: Array<string>,
                                   isServer: boolean, highlightOptions?: any | null, 
                                   popupEnabled?: boolean | null, theme?: string | null, zIndex?: number, tilt?: number,
                                   retry: boolean = false)
    : Promise<void> {
    // Order of operations in this function is very important
    // do not change without significant testing.

    notifyExtentChanged = false;
    userChangedViewExtent = false;
    blazorServer = isServer;
    const dotNetRef = dotNetReference;
    
    let interceptorName = `mapViewInterceptor_${id.replace(/-/g, '_')}`;
    let existingInterceptor = esriConfig.log.interceptors
        .find(i => i.name === interceptorName);
    let index = esriConfig.log.interceptors.indexOf(existingInterceptor!);
    if (index >= 0) {
        esriConfig.log.interceptors.splice(index, 1);
    }

    let newInterceptor = new Function('logUncaughtError',
        `return function ${interceptorName}(level, module, ...args) {
            return logUncaughtError(level, module, '${id}', ...args);
        }`);
    esriConfig.log.interceptors.unshift((newInterceptor(logUncaughtError) as __esri.LogInterceptor));

    if (ProtoGraphicCollection === undefined) {
        await loadProtobuf();
    }

    await projectionEngine.load();

    checkConnectivity(id);

    if (abortSignal.aborted) {
        return;
    }

    dotNetRefs[id] = dotNetRef;

    // 1. Find the <arcgis-map> or <arcgis-scene> component in the DOM
    let mapComponent: ArcgisMap | ArcgisScene = document.querySelector(`#map-container-${id}`) as ArcgisMap | ArcgisScene;

    if (!hasValue(mapComponent)) {
        // if the map component is not found, we cannot create a view
        throw new Error(`Map component with id ${id} not found.`);
    }

    // 2. Set the spatial reference
    let spatialRef: SpatialReference | null = null;
    if (hasValue(spatialReference)) {
        let {buildJsSpatialReference} = await import('./spatialReference');
        spatialRef = buildJsSpatialReference(spatialReference) as SpatialReference;
        mapComponent.spatialReference = spatialRef;
    }

    if (abortSignal.aborted) {
        return;
    }

    // 3. Create the basemap
    let basemap = hasValue(mapObject.basemap)
        ? await buildJsBasemap(mapObject.basemap, null, id)
        : hasValue(mapObject.arcGISDefaultBasemap)
            ? mapObject.arcGISDefaultBasemap
            : undefined;

    // 4. Create the map object
    let map: Map | WebMap | null = null;

    if (mapComponent instanceof ArcgisMap) {
        if (mapType === 'webmap') {
            let {buildJsWebMap} = await import('./webMap');
            map = await buildJsWebMap(mapObject, null, id);
        } else {
            map = new Map({
                basemap: basemap,
                ground: mapObject.ground
            });
        }

        if (hasValue(rotation)) {
            mapComponent.rotation = rotation!;
        }
    } else // this check is required for ESBuild to not throw away the ArcgisScene import
        // noinspection SuspiciousTypeOfGuard
    if (mapComponent instanceof ArcgisScene) {
        if (mapType === 'webscene') {
            let {buildJsWebScene} = await import('./webScene');
            map = await buildJsWebScene(mapObject, null, id);
        } else {
            map = new Map({
                basemap: basemap,
                // a ground is required for a SceneView, so we set a default one if none is provided
                // TODO: Make Ground an object in GeoBlazor, give it a default value for Scenes
                ground: mapObject.ground ?? 'world-elevation'
            });
        }

        if (hasValue(lat) && hasValue(long)) {
            mapComponent.camera = {
                position: {
                    x: long as number, //Longitude
                    y: lat as number, //Latitude
                    z: zIndex as number //Meters
                } as Point,
                tilt: tilt as number
            } as Camera
        }
    }

    // store for lookup
    arcGisObjectRefs[mapObject.id] = map;

    if (abortSignal.aborted) {
        return;
    }

    // 5. set the web component's map object
    mapComponent.map = map;

    // the web component should now also have a view property that is constructed but not loaded
    // 6. Copy the web component's view locally and into the arcGisObjectRefs for lookups
    let view: MapView | SceneView = mapComponent.view;
    arcGisObjectRefs[id] = view;

    if (abortSignal.aborted) {
        return;
    }

    // 7. Set view properties
    await setupView(abortSignal, view, id, dotNetRef, long, lat, zoom, scale, spatialRef, constraints, extent,
        backgroundColor, eventRateLimitInMilliseconds, activeEventHandlers, highlightOptions, popupEnabled, theme);

    if (abortSignal.aborted) {
        return;
    }

    // 8. Register popup widget first before adding layers to not overwrite the popupTemplates
    const popupWidget = widgets.find(w => w.type === 'popup');
    if (hasValue(popupWidget)) {
        await addWidget(popupWidget, id);
    }

    if (abortSignal.aborted) {
        return;
    }

    // 9. Add layers to the map
    if (hasValue(mapObject.layers)) {
        // add layers in reverse order to match the expected order in the map
        for (let i = mapObject.layers.length - 1; i >= 0; i--) {
            const layerObject = mapObject.layers[i];
            await addArcGisLayer(layerObject, mapObject.id, id);
            if (abortSignal.aborted) {
                return;
            }
        }
    }

    // 10. Wait for the map to render
    if (!mapComponent.ready) {
        await mapComponent.viewOnReady();
    }

    if (!view.ui.view) {
        // this state happens after an internal ArcGIS error, we need to reload everything
        await resetMapComponent(id);
        if (retry) {
            throw new Error(`Map component view is in an invalid state. This often occurs after an error on navigation. We suggest catching this exception and re-rendering the MapView.`);
        } else {
            await buildArcGisMapView(abortSignal, id, dotNetReference, long, lat, rotation, mapObject, zoom, scale, 
                mapType, widgets, graphics, spatialReference, constraints, extent, backgroundColor, 
                eventRateLimitInMilliseconds, activeEventHandlers, isServer, highlightOptions, popupEnabled, theme, 
                zIndex, tilt, true);
        }
    }

    if (!hasValue(view.container) || abortSignal.aborted) {
        // someone navigated away or rerendered the page, the view is no longer valid
        return;
    }

    if (abortSignal.aborted) {
        return;
    }

    // 11. Add graphics directly to the view
    for (let i = 0; i < graphics.length; i++) {
        const graphicObject = graphics[i];
        await addGraphic(graphicObject, id, null);
    }

    if (abortSignal.aborted) {
        return;
    }

    // 12. Group widgets by position to ensure consistent stacking order
    const filteredWidgets = widgets.filter(w => w.type !== 'popup');
    const widgetsByPosition = new window.Map<string, any[]>();

    for (const widget of filteredWidgets) {
        const position = widget.position || 'default';
        if (!widgetsByPosition.has(position)) {
            widgetsByPosition.set(position, []);
        }
        widgetsByPosition.get(position)!.push(widget);
    }

    // 13. Process each position group in parallel, but widgets within each group sequentially
    const positionPromises = Array.from(widgetsByPosition.entries()).map(async ([position, positionWidgets]) => {
        for (const widget of positionWidgets) {
            if (abortSignal.aborted) {
                return;
            }
            try {
                // Process widgets in the same position sequentially to maintain stacking order
                await addWidget(widget, id);
            } catch (e) {
                console.error(`Error adding widget ${widget.type} at position ${position}: ${e}`);
            }
        }
    });

    // Wait for all position groups to complete
    await Promise.all(positionPromises);

    if (abortSignal.aborted) {
        return;
    }
}

export async function resetMapComponent(id: string): Promise<void> {
    let mapComponent: ArcgisMap | ArcgisScene = document.querySelector(`#map-container-${id}`) as ArcgisMap | ArcgisScene;
    if (!hasValue(mapComponent)) {
        return;
    }
    let parentContainer = mapComponent.parentElement;
    let newComponent = document.createElement(mapComponent.tagName);
    newComponent.className = 'map-container';
    newComponent.id = `map-container-${id}`;
    let knownAttributes = ['id', 'class', 'style', 'hydrated'];
    let blazorAttr = mapComponent.getAttributeNames()
        .find(a => !knownAttributes.includes(a));
    
    if (blazorAttr) {
        newComponent.setAttribute(blazorAttr, '');
    }
    
    parentContainer!.replaceChild(newComponent, mapComponent);
    mapComponent.destroy();
}

async function setupView(abortSignal: AbortSignal, view: MapView | SceneView, id: string, dotNetRef: any, 
                         long: number | null, lat: number | null, zoom: number | null, scale: number | null,
                         spatialRef: SpatialReference | null, constraints: any, extent: any, backgroundColor: any,
                         eventRateLimitInMilliseconds: number | null, activeEventHandlers: Array<string>,
                         highlightOptions?: any | null, popupEnabled?: boolean | null, theme?: string | null): Promise<void> {
    if (abortSignal.aborted) {
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

    if (abortSignal.aborted) {
        return;
    }

    await dotNetRef.invokeMethodAsync('OnJsViewInitialized');

    if (abortSignal.aborted) {
        return;
    }

    waitForRender(id, theme, dotNetRef, abortSignal);

    if (hasValue(highlightOptions)) {
        view.highlightOptions = highlightOptions;
    }

    if (abortSignal.aborted) {
        return;
    }

    await setEventListeners(view, dotNetRef, eventRateLimitInMilliseconds, activeEventHandlers, id);

    if (abortSignal.aborted) {
        return;
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
                (view as MapView).scale = scale!;
            } else if (hasValue(zoom)) {
                (view as MapView).zoom = zoom as number;
            }
        }

        if (abortSignal.aborted) {
            return;
        }
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
        if (activeEventHandlers.includes('OnDoubleClick')) {
            // only set the cursor if there is user code to run
            await setCursor('wait', viewId);
        }
        // but always hook up listener for internal events in GeoBlazor
        try {
            userChangedViewExtent = true;
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
            await setCursor('wait', viewId);
            try {
                evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
                await dotNetRef.invokeMethodAsync('OnJavascriptImmediateClick', evt);
            } finally {
                await setCursor('unset', viewId);
            }
        });
    }

    if (activeEventHandlers.includes('ImmediateDoubleClick')) {
        view.on('immediate-double-click', async (evt) => {
            await setCursor('wait', viewId);
            try {
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
    let dragTimeoutId: number | undefined;
    view.on('drag', (evt) => {
        userChangedViewExtent = true;
        clearTimeout(dragTimeoutId);
        dragTimeoutId = setTimeout(() => {
            requestAnimationFrame(async () => {
                await dotNetRef.invokeMethodAsync('OnJavascriptDrag', evt);
            });
        }, eventRateLimit ?? 0);
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

    let pointerMoveTimeoutId: number | undefined;
    view.on('pointer-move', async (evt) => {
        clearTimeout(pointerMoveTimeoutId);
        if (pointerDown) {
            userChangedViewExtent = true;
        }
        
        pointerMoveTimeoutId = setTimeout(() => {
            requestAnimationFrame(async () => {
                await dotNetRef.invokeMethodAsync('OnJavascriptPointerMove', evt);
            });
        }, eventRateLimit ?? 0);
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

            let jsLayer: any = await buildJsLayerWrapper(evt.layer);
            let jsLayerView: any = await buildJsLayerViewWrapper(evt.layerView);

            const layerRef = DotNet.createJSObjectReference(jsLayer);
            const layerViewRef = DotNet.createJSObjectReference(jsLayerView);

            const result = {
                layerObjectRef: layerRef,
                layerViewObjectRef: layerViewRef,
                layerView: await buildDotNetLayerView(evt.layerView, viewId),
                layer: await buildDotNetLayer(evt.layer, viewId),
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
            
            requestAnimationFrame(async () => {
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
            });
        } catch (e) {
            console.error(e);
        }
    });

    view.on('layerview-create-error', (evt) => {
        requestAnimationFrame(async () => {
            const layerGeoBlazorId = lookupGeoBlazorId(evt.layer);
            let { buildDotNetViewLayerviewCreateErrorEvent } = await import('./viewLayerviewCreateErrorEvent');
            const dnEvent = await buildDotNetViewLayerviewCreateErrorEvent(evt, layerGeoBlazorId, viewId);
            await dotNetRef.invokeMethodAsync('OnJavascriptLayerViewCreateError', dnEvent);
        });
    });

    if (activeEventHandlers.includes('OnLayerViewDestroy')) {
        view.on('layerview-destroy', (evt) => {
            requestAnimationFrame(async () => {
                const layerGeoBlazorId = lookupGeoBlazorId(evt.layer);
                let { buildDotNetViewLayerviewDestroyEvent } = await import('./viewLayerviewDestroyEvent');
                const dnEvent = await buildDotNetViewLayerviewDestroyEvent(evt, layerGeoBlazorId, viewId);
                await dotNetRef.invokeMethodAsync('OnJavascriptLayerViewDestroy', dnEvent);
            });
        });
    }

    let mouseWheelTimeoutId: number | undefined;
    view.on('mouse-wheel', async (evt) => {
        clearTimeout(mouseWheelTimeoutId);
        userChangedViewExtent = true;
        await setCursor('wait', viewId);
        mouseWheelTimeoutId = setTimeout(() => {
            requestAnimationFrame(async () => {
                await dotNetRef.invokeMethodAsync('OnJavascriptMouseWheel', evt);
                await setCursor('unset', viewId);
            });
        }, eventRateLimit ?? 0);
    });

    let resizeTimeoutId: number | undefined;
    view.on('resize', async (evt) => {
        clearTimeout(resizeTimeoutId);
        userChangedViewExtent = true;
        await setCursor('wait', viewId);
        resizeTimeoutId = setTimeout(() => {
            requestAnimationFrame(async () => {
                await dotNetRef.invokeMethodAsync('OnJavascriptResize', evt);
                await setCursor('unset', viewId);
            });
        }, eventRateLimit ?? 0);
    });

    reactiveUtils.watch(() => view.spatialReference, () => {
        requestAnimationFrame(async () => {
            await dotNetRef.invokeMethodAsync('OnJavascriptSpatialReferenceChanged', 
                buildDotNetSpatialReference(view.spatialReference));
        });
    });

    let watchExtentTimeoutId: number | undefined;
    reactiveUtils.watch(() => view.extent, () => {
        if (!notifyExtentChanged) return;
        clearTimeout(watchExtentTimeoutId);
        if (!hasValue((view as MapView)?.extent)) {
            return;
        }
        userChangedViewExtent = true;
        watchExtentTimeoutId = setTimeout(() => {
            requestAnimationFrame(async () => {
                if (view instanceof SceneView) {
                    await dotNetRef.invokeMethodAsync('OnJavascriptExtentChanged', buildDotNetExtent(view.extent),
                        buildDotNetPoint(view.camera?.position), view.zoom, view.scale, null, view.camera.tilt);
                    return;
                }
                await dotNetRef.invokeMethodAsync('OnJavascriptExtentChanged', buildDotNetExtent((view as MapView).extent),
                    buildDotNetPoint((view as MapView).center), (view as MapView).zoom, (view as MapView).scale,
                    (view as MapView).rotation, null);
            });
        }, eventRateLimit ?? 0);
    });
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
    await addArcGisLayer(layerObject, null, viewId, false, false, true, () => {
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
    const jsSymbol = buildJsSymbol(symbol, layerId, viewId);
    if (graphic !== null && hasValue(symbol) && graphic.symbol !== jsSymbol) {
        graphic.symbol = jsSymbol as any;
    }
}

export function getGraphicSymbol(id: string, layerId: string | null, viewId: string | null): any {
    const graphic = lookupJsGraphicById(id, layerId, viewId);
    if (hasValue(graphic?.symbol)) {
        return buildDotNetSymbol(graphic!.symbol!, viewId);
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
    let jsServiceAreaSymbol = buildJsSymbol(serviceAreaSymbol, null, viewId);
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

export function getGraphicGlobalId(graphicId: string): string | null | undefined {
    const graphic = arcGisObjectRefs[graphicId] as Graphic;
    if (hasValue(graphic)) {
        return graphic.getGlobalId();
    }
    
    return null;
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
        let mapComponent: ArcgisMap | ArcgisScene = document.querySelector(`#map-container-${viewId}`) as ArcgisMap | ArcgisScene;
        const view = arcGisObjectRefs[viewId] as MapView | SceneView;
        if (!hasValue(view)) {
            return;
        }
        const newWidget = await buildJsWidget(widget, widget?.layerId, viewId);
        if (!hasValue(newWidget)) {
            return;
        }
        if (newWidget instanceof Popup) {
            mapComponent.popup = newWidget;
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
            const inMapWidget = mapComponent?.querySelector(`#widget-container-${widget.id}`);
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

export async function addArcGisLayer(layerObject: any, mapId: string | null, viewId: string, isBasemapLayer?: boolean, isReferenceLayer?: boolean,
                                     isQueryLayer?: boolean, callback?: Function): Promise<void> {
    try {
        await setCursor('wait', viewId);
        const view = arcGisObjectRefs[viewId] as View;
        const map = hasValue(mapId) ? arcGisObjectRefs[mapId!] as Map : view?.map as Map;
        if (!hasValue(map)) {
            throw new Error(`View with id ${viewId} does not have a map.`);
        }

        const newLayer = await buildJsLayer(layerObject, layerObject.id, viewId);

        if (!hasValue(newLayer)) return;

        if (isBasemapLayer) {
            if (layerObject.isBasemapReferenceLayer) {
                map?.basemap?.referenceLayers.push(newLayer);
            } else {
                map?.basemap?.baseLayers.push(newLayer);
            }
        } else if (isReferenceLayer) {
            map?.basemap?.referenceLayers.push(newLayer);
        } else if (isQueryLayer) {
            queryLayer = newLayer as FeatureLayer;
            if (callback !== undefined) {
                callback();
            }
        } else {
            map?.add(newLayer);
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

function waitForRender(viewId: string, theme: string | null | undefined, dotNetRef: any, abortSignal: AbortSignal): void {
    const view = arcGisObjectRefs[viewId] as View;

    try {
        view.when().then(_ => {
            if (hasValue(theme)) {
                setViewTheme(theme, viewId);
            }
            let isRendered = false;
            let rendering = false;
            const interval = setInterval(async () => {
                if (view === undefined || view === null || abortSignal.aborted) {
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
                        requestAnimationFrame(async () => {
                            await dotNetRef.invokeMethodAsync('OnJsViewRendered')
                        });
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
        if (!promiseUtils.isAbortError(error) && !abortSignal.aborted) {
            console.error(error);
        }
    }
}

let widgetListenerAdded = false;

function setUserChangedViewExtent() {
    userChangedViewExtent = true;
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
            requestAnimationFrame(async () => {
                let jsonValue = generateSerializableJson(value);
                let jsStreamRef = buildJsStreamReference(jsonValue);
                await dotNetRef.invokeMethodAsync('OnReactiveWatcherUpdate', '${watchExpression}', jsStreamRef);
            });
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
            requestAnimationFrame(async () => {
                await dotNetRef.invokeMethodAsync('OnReactiveListenerTriggered', '${fullEventName}', jsStreamRef);
            });
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
            requestAnimationFrame(async () => {
                await dotNetRef.invokeMethodAsync('OnReactiveWaiterTrue', '${watchExpression}')
            });
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

export async function buildDotNetHitTestResult(hitTestResult: HitTestResult, viewId: string): Promise<DotNetHitTestResult> {
    let results = await Promise.all(hitTestResult.results.map(async r => await buildDotNetViewHit(r as ViewHit, viewId)))
        .then(res => res.filter(r => r !== null)) as Array<DotNetViewHit>;
    return {
        results: results,
        screenPoint: hitTestResult.screenPoint
    }
}

async function buildDotNetViewHit(viewHit: ViewHit, viewId: string): Promise<any> {
    switch (viewHit.type) {
        case "graphic":
            let layerId: string | null = null;
            if (Object.values(arcGisObjectRefs).includes(viewHit.layer)) {
                for (const k of Object.keys(arcGisObjectRefs)) {
                    if (arcGisObjectRefs[k] === viewHit.layer) {
                        layerId = k;
                        break;
                    }
                }
            }
            let {buildDotNetPoint} = await import('./point');
            return {
                type: "graphic",
                graphic: buildDotNetGraphic(viewHit.graphic, layerId, viewId),
                layerId: layerId,
                mapPoint: buildDotNetPoint(viewHit.mapPoint)
            };
    }

    return null;
}

export function buildViewExtentUpdate(view: View): any {
    if (view instanceof MapView) {
        return {
            extent: buildDotNetExtent(view.extent),
            center: view.center !== null ? buildDotNetPoint(view.center) : null,
            scale: view.scale,
            zoom: view.zoom,
            rotation: view.rotation
        }
    } else if (view instanceof SceneView) {
        return {
            extent: buildDotNetExtent(view.extent),
            center: view.center !== null ? buildDotNetPoint(view.center) : null,
            scale: view.scale,
            zoom: view.zoom,
            tilt: view.camera?.tilt
        }
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

export async function loadProtobuf() {
    if (ProtoGraphicCollection && ProtoViewHitCollection) {
        // already loaded
        return;
    }
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

export function getProtobufGraphicStream(graphics: DotNetGraphic[], layer: FeatureLayer | GeoJSONLayer | null): any {
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

function updateGraphicForProtobuf(graphic: DotNetGraphic, layer: FeatureLayer | GeoJSONLayer | null) {
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
        if (hasValue(symbol.portal)) {
            symbol.portalUrl = symbol.portal.url;
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

export function hasValue(prop: any): boolean {
    return prop !== undefined && prop !== null;
}

// endregion