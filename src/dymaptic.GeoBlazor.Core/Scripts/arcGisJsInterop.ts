// noinspection JSUnusedGlobalSymbols

// region imports
import {
    buildJsEffect,
    buildJsPopupOptions,
    buildJsSearchSource,
} from './jsBuilder';
import {
    DotNetExtent,
    DotNetGeometry,
    DotNetGraphic,
    DotNetGraphicHit,
    DotNetHitTestOptions,
    DotNetHitTestResult,
    DotNetListItem,
    DotNetPoint,
    DotNetPolygon,
    DotNetPolyline,
    DotNetPopupTemplate,
    DotNetSpatialReference,
    DotNetViewHit,
    MapCollection
} from './definitions';
import * as geometryEngine from "@arcgis/core/geometry/geometryEngine";
import * as locator from "@arcgis/core/rest/locator";
import * as projection from "@arcgis/core/geometry/projection";
import * as reactiveUtils from "@arcgis/core/core/reactiveUtils";
import * as route from "@arcgis/core/rest/route";
import * as serviceArea from "@arcgis/core/rest/serviceArea";
import Accessor from "@arcgis/core/core/Accessor";
import ArcGisSymbol from "@arcgis/core/symbols/Symbol";
import AreaMeasurement2D from "@arcgis/core/widgets/AreaMeasurement2D";
import AuthenticationManager from "./authenticationManager";
import Basemap from "@arcgis/core/Basemap";
import BasemapGallery from "@arcgis/core/widgets/BasemapGallery";
import BasemapLayerList from "@arcgis/core/widgets/BasemapLayerList";
import BasemapStyle from "@arcgis/core/support/BasemapStyle";
import BasemapToggle from "@arcgis/core/widgets/BasemapToggle";
import Bookmarks from "@arcgis/core/widgets/Bookmarks";
import Camera from "@arcgis/core/Camera";
import Color from "@arcgis/core/Color";
import Compass from "@arcgis/core/widgets/Compass";
import CSVLayer from "@arcgis/core/layers/CSVLayer";
import ElevationLayer from "@arcgis/core/layers/ElevationLayer";
import esriConfig from "@arcgis/core/config";
import Expand from "@arcgis/core/widgets/Expand";
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import FeatureSet from "@arcgis/core/rest/support/FeatureSet";
import GeoJSONLayer from "@arcgis/core/layers/GeoJSONLayer";
import GeometryEngineWrapper from "./geometryEngine";
import Graphic from "@arcgis/core/Graphic";
import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";
import Home from "@arcgis/core/widgets/Home";
import ImageryLayer from "@arcgis/core/layers/ImageryLayer.js";
import ImageryTileLayer from "@arcgis/core/layers/ImageryTileLayer.js";
import Layer from "@arcgis/core/layers/Layer";
import LayerList from "@arcgis/core/widgets/LayerList";
import Legend from "@arcgis/core/widgets/Legend";
import ListItem from "@arcgis/core/widgets/LayerList/ListItem";
import ListItemPanel from "@arcgis/core/widgets/LayerList/ListItemPanel";
import Locate from "@arcgis/core/widgets/Locate";
import LocatorWrapper from "./locator";
import LOD from "@arcgis/core/layers/support/LOD";
import Map from "@arcgis/core/Map";
import MapImageLayer from "@arcgis/core/layers/MapImageLayer";
import MapView from "@arcgis/core/views/MapView";
import Measurement from "@arcgis/core/widgets/Measurement";
import normalizeUtils = __esri.normalizeUtils;
import OpenStreetMapLayer from "@arcgis/core/layers/OpenStreetMapLayer";
import Point from "@arcgis/core/geometry/Point";
import Polygon from "@arcgis/core/geometry/Polygon";
import Polyline from "@arcgis/core/geometry/Polyline";
import Popup from "@arcgis/core/widgets/Popup";
import PopupTemplate from "@arcgis/core/PopupTemplate";
import Portal from "@arcgis/core/portal/Portal";
import PortalBasemapsSource from "@arcgis/core/widgets/BasemapGallery/support/PortalBasemapsSource";
import ProjectionWrapper from "./projection";
import Query from "@arcgis/core/rest/support/Query";
import RasterStretchRenderer from "@arcgis/core/renderers/RasterStretchRenderer";
import RouteParameters from "@arcgis/core/rest/support/RouteParameters";
import ScaleBar from "@arcgis/core/widgets/ScaleBar";
import SceneView from "@arcgis/core/views/SceneView";
import Search from "@arcgis/core/widgets/Search";
import SearchSource from "@arcgis/core/widgets/Search/SearchSource";
import ServiceAreaParameters from "@arcgis/core/rest/support/ServiceAreaParameters";
import SimpleRenderer from "@arcgis/core/renderers/SimpleRenderer";
import Slider from "@arcgis/core/widgets/Slider";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import TileInfo from "@arcgis/core/layers/support/TileInfo";
import TileLayer from "@arcgis/core/layers/TileLayer";
import View from "@arcgis/core/views/View";
import WebMap from "@arcgis/core/WebMap";
import WebScene from "@arcgis/core/WebScene";
import Widget from "@arcgis/core/widgets/Widget";
import {load} from "protobufjs";
import HitTestResult = __esri.HitTestResult;
import LegendLayerInfos = __esri.LegendLayerInfos;
import MapViewHitTestOptions = __esri.MapViewHitTestOptions;
import ScreenPoint = __esri.ScreenPoint;
import {buildDotNetExtent, buildJsExtent } from './extent';
import { buildJsPortalItem } from './portalItem';
import SearchWidgetWrapper from "./searchWidget";
import { buildJsGraphic } from './graphic';
import { buildDotNetLayer } from './layer';
import { buildDotNetPoint, buildJsPoint } from './point';
import { buildDotNetLayerView } from './layerView';
import { buildDotNetSpatialReference } from './spatialReference';
import { buildDotNetGeometry, buildJsGeometry } from './geometry';
import { buildDotNetSymbol, buildJsSymbol } from './symbol';
import { buildDotNetPopupTemplate } from './popupTemplate';
import {buildDotNetGoToOverrideParameters, buildDotNetHitTestResult, buildViewExtentUpdate } from './mapView';
import { buildJsRenderer } from './renderer';
import { buildJsLabel } from './label';

// region exports

// re-export imported types
export {
    esriConfig,
    projection,
    geometryEngine,
    Graphic,
    Color,
    Point,
    Polyline,
    Polygon,
    normalizeUtils,
    Portal,
    SimpleRenderer
};


export * from './jsBuilder';

export const arcGisObjectRefs: Record<string, any> = {};
// this could be either the arcGIS object or a "wrapper" class
export const jsObjectRefs: Record<string, any> = {};
export const popupTemplateRefs: Record<string, Accessor> = {};
export const graphicsRefs: Record<string, Record<string, Graphic>> = {};
export const graphicPopupLookupRefs: Record<string, string> = {};
export const dotNetRefs: Record<string, any> = {};
export let queryLayer: FeatureLayer;
export let blazorServer: boolean = false;

// region module variables

let notifyExtentChanged: boolean = true;
const uploadingLayers: Array<string> = [];
let userChangedViewExtent: boolean = false;
let pointerDown: boolean = false;
let Pro: any;

// region functions

export async function setPro(): Promise<void> {
    try {
        // @ts-ignore
        Pro = await import("./arcGisPro");
    } catch {
        // this catch tells esbuild to ignore
    }
}

// we have to wrap the JsObjectReference because a null will throw an error
// https://github.com/dotnet/aspnetcore/issues/52070
export async function getObjectRefForProperty(obj: any, prop: string): Promise<any> {
    const val = await getProperty(obj, prop);
    return {
        // @ts-ignore
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
        // @ts-ignore
        return DotNet.createJSObjectReference();
    }
    return null;
}

export async function setSublayerProperty(layerObj: any, sublayerId: number, prop: string, value: any) {
    const sublayer = (layerObj as TileLayer)?.sublayers.find(sl => sl.id === sublayerId);
    if (hasValue(sublayer)) {
        await setProperty(sublayer, prop, value);
    }
}

export async function setSublayerPopupTemplate(layerObj: any, sublayerId: number, popupTemplate: any, layerId: string | null, 
                                         viewId: string) {
    const sublayer = (layerObj as TileLayer)?.sublayers.find(sl => sl.id === sublayerId);
    if (hasValue(sublayer) && hasValue(popupTemplate)) {
        let { buildJsPopupTemplate } = await import('./popupTemplate');
        sublayer.popupTemplate = await buildJsPopupTemplate(popupTemplate, layerId, viewId) as PopupTemplate;
    }
}

export function setAssetsPath(path: string) {
    if (path !== undefined && path !== null && esriConfig.assetsPath !== path) {
        esriConfig.assetsPath = path;
    }
}

export async function getProjectionEngineWrapper(dotNetRef: any): Promise<ProjectionWrapper> {
    if (ProtoGraphicCollection === undefined) {
        await loadProtobuf();
    }
    return new ProjectionWrapper(dotNetRef);
}

export async function getGeometryEngineWrapper(dotNetRef: any): Promise<GeometryEngineWrapper> {
    if (ProtoGraphicCollection === undefined) {
        await loadProtobuf();
    }
    return new GeometryEngineWrapper(dotNetRef);
}

export async function getLocationServiceWrapper(): Promise<LocatorWrapper> {
    if (ProtoGraphicCollection === undefined) {
        await loadProtobuf();
    }

    return new LocatorWrapper();
}

export async function buildMapView(id: string, dotNetReference: any, long: number | null, lat: number | null,
    rotation: number, mapObject: any, zoom: number | null, scale: number,
    mapType: string, widgets: any[], graphics: any,
    spatialReference: any, constraints: any, extent: any,
    eventRateLimitInMilliseconds: number | null, activeEventHandlers: Array<string>,
    isServer: boolean, highlightOptions?: any | null, popupEnabled?: boolean | null, zIndex?: number, tilt?: number)
    : Promise<void> {
    console.debug("render map");
    try {
        setWaitCursor(id);
        notifyExtentChanged = false;
        userChangedViewExtent = false;
        blazorServer = isServer;
        const dotNetRef = dotNetReference;
        if (!projection.isLoaded()) {
            await projection.load();
        }

        if (ProtoGraphicCollection === undefined) {
            await loadProtobuf();
        }

        checkConnectivity(id);
        disposeView(id);
        dotNetRefs[id] = dotNetRef;
        let view: View;

        let basemap: Basemap | undefined = undefined;
        const basemapBaseLayers: any[] = [];
        const basemapReferenceLayers: any[] = [];
        if (!mapType.startsWith('web')) {
            if (mapObject.arcGISDefaultBasemap !== undefined &&
                mapObject.arcGISDefaultBasemap !== null) {
                basemap = mapObject.arcGISDefaultBasemap;
            } else if (hasValue(mapObject.basemap?.style)) {
                const style = new BasemapStyle({
                    id: mapObject.basemap.style.name
                });
                if (hasValue(mapObject.basemap.style.language)) {
                    style.language = mapObject.basemap.style.language
                }
                if (hasValue(mapObject.basemap.style.serviceUrl)) {
                    style.serviceUrl = mapObject.basemap.style.serviceUrl;
                }
                basemap = new Basemap({ style: style })
            } else if (hasValue(mapObject.basemap?.portalItem?.id)) {
                const portalItem = await buildJsPortalItem(mapObject.basemap.portalItem, mapObject.basemap.id, id);
                basemap = new Basemap({ portalItem: portalItem });
            } else if (mapObject.basemap?.baseLayers?.length > 0 || mapObject.basemap?.referenceLayers?.length > 0) {
                if (hasValue(mapObject.basemap.baseLayers)) {
                    for (let i = 0; i < mapObject.basemap.baseLayers.length; i++) {
                        const layerObject = mapObject.basemap.baseLayers[i];
                        if (layerObject.isReferenceLayer) {
                            basemapReferenceLayers.push(layerObject);
                        } else {
                            basemapBaseLayers.push(layerObject);
                        }
                    }
                }
                if (hasValue(mapObject.basemap.referenceLayers)) {
                    for (let j = 0; j < mapObject.basemap.referenceLayers.length; j++) {
                        const layerObject = mapObject.basemap.referenceLayers[j];
                        basemapReferenceLayers.push(layerObject);
                    }
                }
                basemap = new Basemap({
                    baseLayers: []
                });
            }
        }

        switch (mapType) {
            case 'webmap':
                let webMap: WebMap;
                const portalItem = await buildJsPortalItem(mapObject.portalItem, null, id);
                webMap = new WebMap({ portalItem: portalItem });
                view = new MapView({
                    container: `map-container-${id}`,
                    map: webMap
                });
                break;
            case 'webscene':
                let webScene: WebScene;
                const scenePortalItem = await buildJsPortalItem(mapObject.portalItem, null, id);
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
        
        if (hasValue(popupEnabled)) {
            view.popupEnabled = popupEnabled as boolean;
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

        await setEventListeners(view, dotNetRef, eventRateLimitInMilliseconds, activeEventHandlers);

        // popup widget needs to be registered before adding layers to not overwrite the popupTemplates
        const popupWidget = widgets.find(w => w.type === 'popup');
        if (hasValue(popupWidget)) {
            await addWidget(popupWidget, id);
        } else {
            await setPopupHandler(id, null);
        }

        if (hasValue(mapObject.layers)) {
            // add layers in reverse order to match the expected order in the map
            for (let i = mapObject.layers.length - 1; i >= 0; i--) {
                const layerObject = mapObject.layers[i];
                await addLayer(layerObject, id);
            }
        }

        for (let i = basemapBaseLayers.length - 1; i >= 0; i--) {
            const layerObject = basemapBaseLayers[i];
            await addLayer(layerObject, id, true);
        }
        
        for (let i = basemapReferenceLayers.length - 1; i >= 0; i--) {
            const layerObject = basemapReferenceLayers[i];
            await addLayer(layerObject, id, false, true);
        }

        for (const widget of widgets.filter(w => w.type !== 'popup')) {
            await addWidget(widget, id);
        }

        for (let i = 0; i < graphics.length; i++) {
            const graphicObject = graphics[i];
            await addGraphic(graphicObject, id, null);
        }

        let spatialRef: SpatialReference | null = null;
        if (hasValue(spatialReference)) {
            let { buildJsSpatialReference } = await import('./spatialReference');
            spatialRef = await buildJsSpatialReference(spatialReference, null, id);
            view.spatialReference = spatialRef!;
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

async function setEventListeners(view: __esri.View, dotNetRef: any, eventRateLimit: number | null,
    activeEventHandlers: Array<string>): Promise<void> {
    view.on('click', async (evt) => {
        evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
        await dotNetRef.invokeMethodAsync('OnJavascriptClick', evt);
    });

    view.on('double-click', (evt) => {
        userChangedViewExtent = true;
        evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
        dotNetRef.invokeMethodAsync('OnJavascriptDoubleClick', evt);
    });

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

    view.on('drag', (evt) => {
        userChangedViewExtent = true;
        const dragCallback = () => dotNetRef.invokeMethodAsync('OnJavascriptDrag', evt);
        debounce(dragCallback, eventRateLimit, !hasValue(eventRateLimit))();
    });

    view.on('pointer-down', (evt) => {
        pointerDown = true;
        dotNetRef.invokeMethodAsync('OnJavascriptPointerDown', evt);
    });

    if (activeEventHandlers.includes('OnPointerEnter')) {
        view.on('pointer-enter', (evt) => {
            dotNetRef.invokeMethodAsync('OnJavascriptPointerEnter', evt);
        });
    }

    view.on('pointer-leave', (evt) => {
        pointerDown = false;
        dotNetRef.invokeMethodAsync('OnJavascriptPointerLeave', evt);
    });

    view.on('pointer-move', (evt) => {
        if (pointerDown) {
            userChangedViewExtent = true;
        }
        const pointerMoveCallback = () => dotNetRef.invokeMethodAsync('OnJavascriptPointerMove', evt);
        debounce(pointerMoveCallback, eventRateLimit, !hasValue(eventRateLimit))();
    });

    view.on('pointer-up', (evt) => {
        pointerDown = false;
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
        try {
            // find objectRef id by layer
            const layerGeoBlazorId = Object.keys(arcGisObjectRefs).find(key => arcGisObjectRefs[key] === evt.layer);

            let isBasemapLayer = false;
            let isReferenceLayer = false;
            if (hasValue(view.map.basemap)) {
                if (view.map.basemap.baseLayers?.includes(evt.layer)) {
                    isBasemapLayer = true;
                } else if (view.map.basemap.referenceLayers?.includes(evt.layer)) {
                    isReferenceLayer = true;
                }
            }

            let jsLayer: any = evt.layer;
            let jsLayerView: any = evt.layerView;

            if (jsLayer.type == 'feature') {
                const { default: FeatureLayerWrapper } = await import('./featureLayer');
                jsLayer = new FeatureLayerWrapper(jsLayer);
                const { default: FeatureLayerViewWrapper } = await import('./featureLayerView');
                jsLayerView = new FeatureLayerViewWrapper(jsLayerView);
            }

            // @ts-ignore
            const layerRef = DotNet.createJSObjectReference(jsLayer);
            // @ts-ignore
            const layerViewRef = DotNet.createJSObjectReference(jsLayerView);

            const result = {
                layerObjectRef: layerRef,
                layerViewObjectRef: layerViewRef,
                layerView: buildDotNetLayerView(evt.layerView),
                layer: await buildDotNetLayer(evt.layer),
                layerGeoBlazorId: layerGeoBlazorId,
                isBasemapLayer: isBasemapLayer,
                isReferenceLayer: isReferenceLayer
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

            // return dotNetResult in small chunks to avoid memory issues in Blazor Server
            // SignalR has a maximum message size of 32KB
            // https://github.com/dotnet/aspnetcore/issues/23179
            const jsonLayerResult = JSON.stringify(result.layer);
            const jsonLayerViewResult = JSON.stringify(result.layerView);
            const chunkSize = 1000;
            let chunks = Math.ceil(jsonLayerResult.length / chunkSize);

            for (let i = 0; i < chunks; i++) {
                const chunk = jsonLayerResult.slice(i * chunkSize, (i + 1) * chunkSize);
                await dotNetRef.invokeMethodAsync('OnJavascriptLayerCreateChunk', layerUid, chunk, i);
            }

            chunks = Math.ceil(jsonLayerViewResult.length / chunkSize);
            for (let i = 0; i < chunks; i++) {
                const chunk = jsonLayerViewResult.slice(i * chunkSize, (i + 1) * chunkSize);
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
            throw e;
        }
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
    
    view.on('mouse-wheel', (evt) => {
        userChangedViewExtent = true;
        const mouseWheelCallback = () => dotNetRef.invokeMethodAsync('OnJavascriptMouseWheel', evt);
        debounce(mouseWheelCallback, eventRateLimit, !hasValue(eventRateLimit))();
    });

    view.on('resize', (evt) => {
        userChangedViewExtent = true;
        const resizeCallback = () => dotNetRef.invokeMethodAsync('OnJavascriptResize', evt);
        debounce(resizeCallback, eventRateLimit, !hasValue(eventRateLimit))();
    });

    view.watch('spatialReference', () => {
        dotNetRef.invokeMethodAsync('OnJavascriptSpatialReferenceChanged', buildDotNetSpatialReference(view.spatialReference));
    });

    view.watch('extent', () => {
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
        timeout = setTimeout(function() {

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

export async function registerGeoBlazorObject(jsObjectRef: any, geoBlazorId: string) {
    if (arcGisObjectRefs.hasOwnProperty(geoBlazorId)) {
        return;
    }
    arcGisObjectRefs[geoBlazorId] = jsObjectRef;
    jsObjectRefs[geoBlazorId] = jsObjectRef.hasOwnProperty('unwrap') 
        ? jsObjectRef.unwrap() 
        : jsObjectRef;
}

export function registerGeoBlazorSublayer(layerId, sublayerId, sublayerGeoBlazorId) {
    const layer = arcGisObjectRefs[layerId] as TileLayer;
    arcGisObjectRefs[sublayerGeoBlazorId] = layer.allSublayers.find(sl => sl.id === sublayerId);
}

export async function hitTest(screenPoint: any, viewId: string, options: DotNetHitTestOptions | null, hitTestId: string)
    : Promise<DotNetHitTestResult | void> {
    try {
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
    } catch (e) {
        logError(e, viewId);
    }
}

export function toMap(screenPoint: any, viewId: string): DotNetPoint | null {
    const view = arcGisObjectRefs[viewId] as MapView;
    const mapPoint = view.toMap(screenPoint);
    return buildDotNetPoint(mapPoint);
}

export function toScreen(mapPoint: any, viewId: string): ScreenPoint {
    const view = arcGisObjectRefs[viewId] as MapView;
    return view.toScreen(buildJsPoint(mapPoint) as Point);
}

export function disposeView(viewId: string): void {
    try {
        const view = arcGisObjectRefs[viewId] as MapView;
        view?.destroy();
        delete arcGisObjectRefs[viewId];
        delete dotNetRefs[viewId];
        if (triggerActionHandlers.hasOwnProperty(viewId)) {
            triggerActionHandlers[viewId].remove();
            delete triggerActionHandlers[viewId];
        }
    } catch (error) {
        logError(error, viewId);
    }
}

export function disposeMapComponent(componentId: string, viewId: string): void {
    try {
        const component = arcGisObjectRefs[componentId];
        switch (component?.declaredClass) {
            case 'esri.Graphic':
                const graphic = component as Graphic;
                (graphic?.layer as GraphicsLayer)?.graphics.remove(graphic);
                break;
        }
        component?.destroy();
        if (arcGisObjectRefs.hasOwnProperty(componentId)) {
            delete arcGisObjectRefs[componentId];
        }
        if (dotNetRefs.hasOwnProperty(componentId)) {
            delete dotNetRefs[componentId];
        }
        if (jsObjectRefs.hasOwnProperty(componentId)) {
            delete jsObjectRefs[componentId];
        }
        const view = arcGisObjectRefs[viewId] as View;
        view?.ui?.remove(component as any);
        disposeGraphic(componentId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function disposeGraphic(graphicId: string) {
    try {
        for (const layerId in graphicsRefs) {
            const layerGraphics = graphicsRefs[layerId];
            if (layerGraphics.hasOwnProperty(graphicId)) {
                layerGraphics[graphicId]?.destroy();
                delete layerGraphics[graphicId];
                return;
            }
        }
    } catch (error) {
        logError(error, graphicId);
    }
}

export function updateView(viewObject: any) {
    try {
        if (userChangedViewExtent) {
            return;
        }
        setWaitCursor(viewObject.id);
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
        unsetWaitCursor(viewObject.id);
        return buildViewExtentUpdate(view);
    } catch (error) {
        logError(error, viewObject.id);
    }
}

export async function setExtent(extentObject: any, viewId: string) {
    try {
        notifyExtentChanged = false;
        const view = arcGisObjectRefs[viewId] as MapView;
        if (!hasValue(view)) return;
        const extent = buildJsExtent(extentObject, view.spatialReference);
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
        const view = arcGisObjectRefs[viewId] as MapView;
        view.constraints = constraintsObject;
    } catch (error) {
        logError(error, viewId);
    }
}

export function setHighlightOptions(highlightOptions: any, viewId: string) {
    try {
        const view = arcGisObjectRefs[viewId] as MapView;
        view.highlightOptions = highlightOptions;
    } catch (error) {
        logError(error, viewId);
    }
}

export async function setSpatialReference(spatialReferenceObject: any, viewId: string) {
    try {
        const view = arcGisObjectRefs[viewId] as MapView;
        if (view !== undefined) {
            let { buildJsSpatialReference } = await import('./spatialReference');
            view.spatialReference = await buildJsSpatialReference(spatialReferenceObject, null, viewId);
        }
    } catch (error) {
        logError(error, viewId);
    }
}

export async function queryFeatureLayer(queryObject: any, layerObject: any, symbol: any, popupTemplateObject: any,
    layerId: string | null, viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
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
        let { buildJsPopupTemplate } = await import('./popupTemplate');
        const popupTemplate = await buildJsPopupTemplate(popupTemplateObject, layerObject.id, viewId) as PopupTemplate;
        await addLayer(layerObject, viewId, false, false, true, () => {
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
        const view = arcGisObjectRefs[viewId] as View;
        const graphicsToRemove: Graphic[] = [];
        
        for (const id of graphicWrapperIds) {
            disposeGraphic(id);
        }
        
        if (hasValue(layerId)) {
            const layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
            layer.removeMany(graphicsToRemove);
        } else {
            view.graphics.removeMany(graphicsToRemove);
        }
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export function removeGraphic(graphicId: string, viewId: string, layerId?: string | null): void {
    try {
        setWaitCursor(viewId);
        const view = arcGisObjectRefs[viewId] as View;
        const graphic = graphicsRefs[layerId ?? viewId][graphicId];
        disposeGraphic(graphicId);
        if (hasValue(layerId)) {
            const layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
            layer.remove(graphic);
        } else if (hasValue(view)) {
            view.graphics.remove(graphic);
        }

        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export async function updateLayer(layerObject: any, viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
        const currentLayer = arcGisObjectRefs[layerObject.id] as Layer;
        
        if (currentLayer === undefined) {
            unsetWaitCursor(viewId);
            return;
        }

        switch (layerObject.type) {
            case 'feature':
                const featureLayer = currentLayer as FeatureLayer;

                if (hasValue(layerObject.popupTemplate)) {
                    let { buildJsPopupTemplate } = await import('./popupTemplate');
                    featureLayer.popupTemplate = await buildJsPopupTemplate(layerObject.popupTemplate, layerObject.id, viewId) as PopupTemplate;
                }
                // on first pass the renderer is often left blank, but it fills in when the round trip happens to the server
                if (hasValue(layerObject.renderer) && layerObject.renderer.type !== featureLayer.renderer.type) {
                    const renderer = await buildJsRenderer(layerObject.renderer, layerObject.id, viewId);
                    if (renderer !== null && featureLayer.renderer !== renderer) {
                        featureLayer.renderer = renderer;
                    }
                }
                if (hasValue(layerObject.fields) && layerObject.fields.length > 0) {
                    let { buildJsField } = await import('./field');
                    featureLayer.fields = await Promise.all(layerObject.fields.map(async f => await buildJsField(f, layerObject.id, viewId)));
                }

                if (hasValue(layerObject.labelingInfo)) {
                    featureLayer.labelingInfo = layerObject.labelingInfo.map(buildJsLabel);
                }

                if (hasValue(layerObject.proProperties?.FeatureReduction) && hasValue(Pro)) {
                    await Pro.addFeatureReduction(featureLayer, layerObject.proProperties.FeatureReduction, viewId);
                }

                copyValuesIfExists(layerObject, featureLayer, 'minScale', 'maxScale', 'orderBy', 'objectIdField',
                    'definitionExpression', 'outFields');

                break;
            case 'geojson':
                const geoJsonLayer = currentLayer as GeoJSONLayer;
                if (hasValue(layerObject.renderer)) {
                    const renderer = await buildJsRenderer(layerObject.renderer, layerObject.id, viewId);
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
                if (hasValue(layerObject.popupTemplate)) {
                    let { buildJsPopupTemplate } = await import('./popupTemplate');
                    geoJsonLayer.popupTemplate = await buildJsPopupTemplate(layerObject.popupTemplate, layerObject.id, viewId ?? null) as PopupTemplate;
                }
                if (hasValue(layerObject.proProperties?.FeatureReduction) && hasValue(Pro)) {
                    await Pro.addFeatureReduction(geoJsonLayer, layerObject.proProperties.FeatureReduction, viewId);
                } else {
                    // @ts-ignore
                    geoJsonLayer.featureReduction = null;
                }
                break;
            case 'web-tile':
                const webTileLayer = currentLayer as __esri.WebTileLayer;
                copyValuesIfExists(layerObject, webTileLayer,
                    'subDomains', 'blendMode', 'copyright', 'maxScale', 'minScale', 'refreshInterval');

                if (hasValue(layerObject.tileInfo)) {
                    webTileLayer.tileInfo = new TileInfo();
                    copyValuesIfExists(layerObject.tileInfo, webTileLayer.tileInfo,
                        'dpi', 'format', 'isWrappable', 'size');

                    if (hasValue(layerObject.tileInfo.lods)) {
                        webTileLayer.tileInfo.lods = layerObject.tileInfo.lods.map(l => {
                            const lod = new LOD();
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
                        let { buildJsSpatialReference } = await import('./spatialReference');
                        webTileLayer.tileInfo.spatialReference = 
                            await buildJsSpatialReference(layerObject.tileInfo.spatialReference, layerObject.id, viewId);
                    }
                }

                break;
            case 'open-street-map':
                const openStreetMapLayer = currentLayer as OpenStreetMapLayer;
                copyValuesIfExists(layerObject, openStreetMapLayer,
                    'subDomains', 'blendMode', 'copyright', 'maxScale', 'minScale', 'refreshInterval')

                if (hasValue(layerObject.tileInfo)) {
                    openStreetMapLayer.tileInfo = new TileInfo();
                    copyValuesIfExists(layerObject.tileInfo, openStreetMapLayer.tileInfo,
                        'dpi', 'format', 'isWrappable', 'size');

                    if (hasValue(layerObject.tileInfo.lods)) {
                        openStreetMapLayer.tileInfo.lods = layerObject.tileInfo.lods.map(l => {
                            const lod = new LOD();
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
                        let { buildJsSpatialReference } = await import('./spatialReference');
                        openStreetMapLayer.tileInfo.spatialReference = 
                            await buildJsSpatialReference(layerObject.tileInfo.spatialReference, layerObject.id, viewId);
                    }
                }

                break;
            case 'csv':
                if (hasValue(layerObject.proProperties?.FeatureReduction) && hasValue(Pro)) {
                    await Pro.addFeatureReduction(currentLayer, layerObject.proProperties.FeatureReduction, viewId);
                } else {
                    // @ts-ignore
                    (currentLayer as CSVLayer).featureReduction = null;
                }
                break;
            case 'map-image':
                copyValuesIfExists(layerObject, currentLayer, 'blendMode', 'customParameters', 'dpi',
                    'gdbVersion', 'imageFormat', 'imageMaxHeight', 'imageMaxWidth', 'imageTransparency', 'legendEnabled',
                    'maxScale', 'minScale', 'refreshInterval', 'timeExtent', 'timeInfo',
                    'useViewTime');

                let { buildJsSublayer } = await import('./sublayer');
                if (hasValue(layerObject.sublayers) && layerObject.sublayers.length > 0 &&
                    (currentLayer as MapImageLayer).capabilities?.exportMap.supportsDynamicLayers &&
                    (currentLayer as MapImageLayer).capabilities?.exportMap.supportsSublayersChanges) {
                    (currentLayer as MapImageLayer).sublayers = layerObject.sublayers.map(buildJsSublayer);
                }
                break;
                
            case 'imagery':
                copyValuesIfExists(layerObject, currentLayer, 'blendMode', 'maxScale', 'minScale', 'bandIds',
                    'compressionQuality', 'compressionTolerance', 'copyright', 'definitionExpression', 'format',
                    'hasMultidimensions', 'imageMaxHeight', 'imageMaxWidth', 'interpolation', 'legendEnabled',
                    'noData', 'noDataInterpretation', 'objectIdField', 'pixelType', 
                    'popupEnabled', 'rasterFields', 'refreshInterval', 'useViewTime', 'tileInfo', 'timeExtent',
                    'timeInfo', 'timeOffset', 'customParameters');
                if (hasValue(layerObject.effect)) {
                    (currentLayer as ImageryLayer).effect = buildJsEffect(layerObject.effect);
                }
                if (hasValue(layerObject.multidimensionalSubset)) {
                    let { buildJsMultidimensionalSubset } = await import('./multidimensionalSubset');
                    (currentLayer as ImageryLayer).multidimensionalSubset = 
                        await buildJsMultidimensionalSubset(layerObject.multidimensionalSubset, layerObject.id, viewId);
                }
                break;
                
            case 'imagery-tile':
                copyValuesIfExists(layerObject, currentLayer, 'blendMode', 'maxScale', 'minScale', 'bandIds',
                    'copyright', 'interpolation', 'legendEnabled', 'useViewTime', 
                    'customParameters');
                if (hasValue(layerObject.effect)) {
                    (currentLayer as ImageryTileLayer).effect = buildJsEffect(layerObject.effect);
                }
                if (hasValue(layerObject.multidimensionalDefinition) && layerObject.multidimensionalDefinition.length > 0) {
                    let { buildJsDimensionalDefinition } = await import('./dimensionalDefinition');
                    (currentLayer as ImageryTileLayer).multidimensionalDefinition = layerObject.multidimensionalDefinition.map(buildJsDimensionalDefinition);
                }
                if (hasValue(layerObject.multidimensionalSubset)) {
                    let { buildJsMultidimensionalSubset } = await import('./multidimensionalSubset');
                    (currentLayer as ImageryTileLayer).multidimensionalSubset = 
                        await buildJsMultidimensionalSubset(layerObject.multidimensionalSubset, layerObject.id, viewId);
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
        const currentWidget = arcGisObjectRefs[widgetObject.id] as Widget;

        if (currentWidget === undefined) {
            unsetWaitCursor(viewId);
            return;
        }

        switch (widgetObject.type) {
            case 'bookmarks':
                const bookmarks = currentWidget as Bookmarks;
                if (hasValue(widgetObject.bookmarks)) {
                    let { buildJsBookmark } = await import('./bookmark');
                    bookmarks.bookmarks = widgetObject.bookmarks.map(buildJsBookmark);
                }
                break;
            case 'search':
                const search = currentWidget as Search;
                if (hasValue(widgetObject.sources)) {
                    const sources: SearchSource[] = [];
                    for (const source of widgetObject.sources) {
                        const jsSource = await buildJsSearchSource(source, viewId);
                        sources.push(jsSource);
                    }
                    search.sources.removeAll();
                    search.sources.addMany(sources);
                }

                if (hasValue(widgetObject.popupTemplate)) {
                    let { buildJsPopupTemplate } = await import('./popupTemplate');
                    search.popupTemplate = await buildJsPopupTemplate(widgetObject.popupTemplate, null, viewId) as PopupTemplate;
                }

                if (hasValue(widgetObject.portal)) {
                    search.portal = new Portal({
                        url: widgetObject.portal.url
                    });
                }
                break;
            case 'basemap-layer-list':
                const basemapLayerList = currentWidget as BasemapLayerList;
                if (hasValue(widgetObject.visibleElements)) {
                    basemapLayerList.visibleElements = {
                        statusIndicators: widgetObject.visibleElements.statusIndicators,
                        baseLayers: widgetObject.visibleElements.baseLayers,
                        referenceLayers: widgetObject.visibleElements.referenceLayers,
                        errors: widgetObject.errors
                    };
                }
                copyValuesIfExists(widgetObject, basemapLayerList, 'basemapTitle', 'editingEnabled', 'headingLevel',
                    'multipleSelectionEnabled');
                break;
        }

        if (hasValue(widgetObject.widgetId)) {
            currentWidget.id = widgetObject.widgetId;
        }
        copyValuesIfExists(widgetObject, currentWidget, 'icon', 'label');
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}
export function findPlaces(addressQueryParams: any, symbol: any, popupTemplateObject: any, viewId: string): void {
    try {
        setWaitCursor(viewId);
        const view = arcGisObjectRefs[viewId] as MapView;
        locator.addressToLocations(addressQueryParams.locatorUrl, {
            location: view.center,
            categories: addressQueryParams.categories,
            maxLocations: addressQueryParams.maxLocations,
            outFields: addressQueryParams.outFields,
            address: null
        })
            .then(async (results) => {
                view.popup.close();
                view.graphics.removeAll();
                let { buildJsPopupTemplate } = await import('./popupTemplate');
                const popupTemplate = await buildJsPopupTemplate(popupTemplateObject, null, viewId) as PopupTemplate;
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

export async function setPopup(dotNetPopup: any, viewId: string): Promise<Popup | null> {
    try {
        const view = arcGisObjectRefs[viewId] as View;
        let { buildJsPopupWidget } = await import('./popupWidget');
        const jsPopup = await buildJsPopupWidget(dotNetPopup, viewId);
        if (hasValue(dotNetPopup.widgetContent)) {
            const widgetContent = await createWidget(dotNetPopup.widgetContent, dotNetPopup.viewId);
            if (hasValue(widgetContent)) {
                jsPopup.content = widgetContent as Widget;
            }
        }

        view.popup = jsPopup;

        await setPopupHandler(viewId, dotNetPopup);

        return jsPopup;
    } catch (error) {
        logError(error, dotNetPopup.viewId);
        return null;
    }
}

async function setPopupHandler(viewId: string, dotNetPopup: any | null) {
    try {
        const view = arcGisObjectRefs[viewId] as View;

        if (hasValue(triggerActionHandlers[viewId])) {
            triggerActionHandlers[viewId].remove();
        }

        if (!hasValue(view.popup.on)) {
            reactiveUtils.once(() => view.popup.on !== undefined)
                .then(() => {
                    triggerActionHandlers[viewId] = view.popup.on("trigger-action", 
                            event => triggerActionCallback(event, viewId, dotNetPopup));
                })
        } else {
            triggerActionHandlers[viewId] = view.popup.on("trigger-action", 
                    event => triggerActionCallback(event, viewId, dotNetPopup));
        }
    }
    catch (error) {
        logError(error, viewId);
    }
}

async function triggerActionCallback(event, viewId, dotNetPopup) {
    if (!arcGisObjectRefs.hasOwnProperty(viewId)) {
        return;
    }
    if (hasValue(dotNetPopup)) {
        await dotNetPopup.dotNetComponentReference.invokeMethodAsync("OnTriggerAction", event.action.id);
    }
    const viewRef = dotNetRefs[viewId];
    for (const k of Object.keys(popupTemplateRefs)) {
        let popupRef = dotNetRefs[k];
        if (!hasValue(popupRef)) {
            popupRef = await viewRef.invokeMethodAsync('GetDotNetPopupTemplateObjectReference', k);
            if (hasValue(popupRef)) {
                dotNetRefs[k] = popupRef;
            }
        }
        
        if (hasValue(popupRef)) {
            await popupRef.invokeMethodAsync("OnTriggerAction", event.action.id);
        }
    }
}

export const triggerActionHandlers: Record<string, IHandle> = {};

export async function openPopup(viewId: string, options: any | null): Promise<void> {
    try {
        const view = arcGisObjectRefs[viewId] as View;
        if (options !== null) {
            const jsOptions = await buildJsPopupOptions(options);
            if (hasValue(options.widgetContent)) {
                const widgetContent = await createWidget(options.widgetContent, viewId);
                if (hasValue(widgetContent)) {
                    jsOptions.content = widgetContent as Widget;
                }
            }
            await view.openPopup(jsOptions);
        } else {
            await view.openPopup();
        }
    } catch (error) {
        logError(error, options.viewId);
    }
}

export function closePopup(viewId: string): void {
    try {
        const view = arcGisObjectRefs[viewId] as View;
        view.popup.close();
    } catch (error) {
        logError(error, viewId);
    }
}

export async function showPopup(popupTemplateObject: any, location: DotNetPoint, viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
        let { buildJsPopupTemplate } = await import('./popupTemplate');
        const popupTemplate = await buildJsPopupTemplate(popupTemplateObject, null, viewId) as PopupTemplate;

        await (arcGisObjectRefs[viewId] as View).openPopup({
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
        await addGraphic(graphicObject, viewId, null);
        const view = arcGisObjectRefs[viewId] as View;
        const graphic = arcGisObjectRefs[graphicObject.id] as Graphic;
        view.popup.dockOptions = options.dockOptions;
        view.popup.visibleElements = options.visibleElements;
        await view.openPopup({
            features: [graphic]
        });
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}


export async function addGraphic(streamRefOrGraphicObject: any, viewId: string, layerId: string | null): Promise<void> {
    try {
        setWaitCursor(viewId);
        let graphic: Graphic;
        const { buildJsGraphic } = await import('./graphic');
        if (streamRefOrGraphicObject.hasOwnProperty("_streamPromise")) {
            const graphics = await getGraphicsFromProtobufStream(streamRefOrGraphicObject) as any[];
            graphic = buildJsGraphic(graphics[0], layerId, viewId) as Graphic;
        } else {
            graphic = buildJsGraphic(streamRefOrGraphicObject, layerId, viewId) as Graphic;
        }
        const view = arcGisObjectRefs[viewId] as View;
        if (hasValue(layerId)) {
            const layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
            layer.add(graphic);
        } else {
            if (!hasValue(view?.graphics)) {
                unsetWaitCursor(viewId);
                return;
            }
            view.graphics?.add(graphic);
        }
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export async function addGraphicsFromStream(streamRef: any, viewId: string, abortSignal: AbortSignal, layerId: string | null): Promise<void> {
    try {
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
            const jsGraphic = buildJsGraphic(g, layerId, viewId) as Graphic;
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
    } catch (error) {
        logError(error, viewId);
    }
}

export function addGraphicsSynchronously(graphicsArray: Uint8Array, viewId: string, layerId: string | null): void {
    try {
        const graphics = decodeProtobufGraphics(graphicsArray);
        let jsGraphics: Graphic[] = [];
        const view = arcGisObjectRefs[viewId] as View;
        const layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
        const existingGraphics = layer?.graphics || view.graphics;

        for (const g of graphics) {
            const jsGraphic = buildJsGraphic(g, layerId, viewId) as Graphic;
            jsGraphics.push(jsGraphic);
        }
        jsGraphics = jsGraphics.filter(g => !existingGraphics.includes(g));
        if (hasValue(layerId)) {
            layer.graphics?.addMany(jsGraphics);
        } else {
            view.graphics?.addMany(jsGraphics);
        }
    } catch (error) {
        logError(error, viewId);
    }
}

export function setGraphicGeometry(id: string, layerId: string | null, viewId: string | null, geometry: DotNetGeometry): void {
    const jsGeometry = buildJsGeometry(geometry);
    const graphic = lookupGraphicById(id, layerId, viewId);
    if (graphic !== null && jsGeometry !== null && graphic.geometry !== jsGeometry) {
        graphic.geometry = jsGeometry;
    }
}

export function getGraphicGeometry(id: string, layerId: string | null, viewId: string | null): DotNetGeometry | null {
    const graphic = lookupGraphicById(id, layerId, viewId);
    if (graphic !== null) {
        return buildDotNetGeometry(graphic.geometry);
    }

    return null;
}

export async function setGraphicSymbol(id: string, symbol: any, layerId: string | null, viewId: string | null): Promise<void> {
    const graphic = lookupGraphicById(id, layerId, viewId);
    const jsSymbol = await buildJsSymbol(symbol, layerId, viewId);
    if (graphic !== null && hasValue(symbol) && graphic.symbol !== jsSymbol) {
        graphic.symbol = jsSymbol as any;
    }
}

export function getGraphicSymbol(id: string, layerId: string | null, viewId: string | null): any {
    const graphic = lookupGraphicById(id, layerId, viewId);
    if (graphic !== null) {
        return buildDotNetSymbol(graphic.symbol);
    }
    
    return null;
}

export async function setGraphicPopupTemplate(id: string, popupTemplate: DotNetPopupTemplate, dotNetRef: any, 
                                        layerId: string | null, viewId: string): Promise<void> {
    const graphic = lookupGraphicById(id, layerId, viewId);
    popupTemplate.dotNetPopupTemplateReference = dotNetRef;
    graphicPopupLookupRefs[id] = popupTemplate.id;
    dotNetRefs[popupTemplate.id] = dotNetRef;
    let { buildJsPopupTemplate } = await import('./popupTemplate');
    const jsPopupTemplate = await buildJsPopupTemplate(popupTemplate, layerId, viewId) as PopupTemplate;
    if (graphic !== null && hasValue(popupTemplate) && graphic.popupTemplate !== jsPopupTemplate) {
        graphic.popupTemplate = jsPopupTemplate;
    }
}

export function removeGraphicPopupTemplate(graphicId: string): void {
    if (graphicPopupLookupRefs.hasOwnProperty(graphicId)) {
        const popupTemplateId = graphicPopupLookupRefs[graphicId];
        delete graphicPopupLookupRefs[graphicId];
        if (dotNetRefs.hasOwnProperty(popupTemplateId)) {
            delete dotNetRefs[popupTemplateId];
        }
    }
}

export async function getGraphicPopupTemplate(id: string, layerId: string | null, viewId: string): Promise<DotNetPopupTemplate | null> {
    const graphic = lookupGraphicById(id, layerId, viewId);
    if (graphic === null) return null;
    return await buildDotNetPopupTemplate(graphic.popupTemplate);
}

export async function setGraphicAttributes(id: string, attributes: any, layerId: string | null, viewId: string | null): Promise<void> {
    const graphic = lookupGraphicById(id, layerId, viewId);
    if (graphic !== null) {
        let { buildJsAttributes } = await import('./attributes');
        graphic.attributes = buildJsAttributes(attributes);
    }
}

export function lookupGraphicById(graphicId: string, layerId: string | null, viewId: string | null): Graphic | null {
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

export function clearGraphics(viewId: string, layerId?: string | null): void {
    try {
        setWaitCursor(viewId);
        const view = arcGisObjectRefs[viewId] as View;
        if (hasValue(layerId)) {
            const layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
            layer.graphics.removeAll();
            graphicsRefs[layerId as string] = {};
        } else {
            view.graphics.removeAll();
            graphicsRefs[viewId] = {};
        }
        unsetWaitCursor(viewId);
    } catch (error) {
        logError(error, viewId);
    }
}

export async function drawRouteAndGetDirections(routeUrl: string, routeSymbol: any, viewId: string): Promise<any[]> {
    try {
        setWaitCursor(viewId);
        const view = arcGisObjectRefs[viewId] as View;
        const routeParams = new RouteParameters({
            stops: new FeatureSet({
                features: view.graphics.toArray()
            }),
            returnDirections: true
        });

        const data = await route.solve(routeUrl, routeParams);
        data.routeResults.forEach(function (result) {
            result.route.symbol = routeSymbol
            view.graphics.add(result.route);
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

export function getExtent(viewId: string): DotNetExtent | null {
    return buildDotNetExtent((arcGisObjectRefs[viewId] as MapView).extent);
}

export async function goToExtent(extentObject: any, viewId: string) {
    try {
        notifyExtentChanged = false;
        const view = arcGisObjectRefs[viewId] as MapView;
        if (!hasValue(view)) return;
        const extent = buildJsExtent(extentObject, view.spatialReference);
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
    const view = arcGisObjectRefs[viewId] as MapView;
    const jsGraphics: Graphic[] = [];
    for (const graphic of graphics) {
        delete graphic.dotNetGraphicReference;
        delete graphic.layerId;
        const jsGraphic = buildJsGraphic(graphic, null, viewId);
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
    setWaitCursor(viewId);
    queryLayer.queryFeatures(query)
        .then((results) => {
            results.features.map((feature) => {
                feature.symbol = symbol;
                feature.popupTemplate = popupTemplate;
                return feature;
            });
            const view = arcGisObjectRefs[viewId] as View;

            view.popup.close();
            view.graphics.removeAll();
            view.graphics.addMany(results.features);
            unsetWaitCursor(viewId);
        }).catch((error) => {
            logError(error, viewId);
        });
}

export async function addWidget(widget: any, viewId: string, setInContainerByDefault: boolean = false)
    : Promise<void> {
    try {
        const view = arcGisObjectRefs[viewId] as MapView;
        if (view === undefined || view === null) return;
        const newWidget = await createWidget(widget, viewId);
        if (newWidget === null || newWidget instanceof Popup) return;

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
            const inMapWidget = view.container?.querySelector(`#widget-container-${widget.id}`);
            const widgetContainer: HTMLElement = document.getElementById(`widget-container-${widget.id}`)!;
            if ((hasValue(inMapWidget) || !hasValue(widgetContainer)) && !setInContainerByDefault) {
                view.ui.add(newWidget, widget.position);
            } else {
                // default to using the pre-defined widget container
                widgetContainer.innerHTML = '';
                newWidget.container = widgetContainer;
            }
        }
    } catch (error) {
        logError(error, viewId);
    }
}

async function createWidget(dotNetWidget: any, viewId: string): Promise<Widget | null> {
    const view = arcGisObjectRefs[viewId] as MapView;

    let newWidget: Widget;
    let wrapper: any;
    switch (dotNetWidget.type) {
        case 'locate':
            const locate = new Locate({
                view: view,
                rotationEnabled: dotNetWidget.rotationEnabled ?? undefined,
                scale: dotNetWidget.scale ?? undefined
            });
            newWidget = locate;

            if (dotNetWidget.hasGoToOverride) {
                locate.goToOverride = async (_, parameters) => {
                    const dnParams = buildDotNetGoToOverrideParameters(parameters, viewId);
                    await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJavaScriptGoToOverride', dnParams);
                }
            }

            break;
        case 'search':
            const search = new Search({
                view: view
            });
            newWidget = search;

            if (hasValue(dotNetWidget.sources)) {
                const sources: SearchSource[] = [];
                for (const source of dotNetWidget.sources) {
                    const jsSource = await buildJsSearchSource(source, viewId);
                    sources.push(jsSource);
                }
                search.sources.addMany(sources);
            }

            if (hasValue(dotNetWidget.popupTemplate)) {
                let { buildJsPopupTemplate } = await import('./popupTemplate');
                search.popupTemplate = await buildJsPopupTemplate(dotNetWidget.popupTemplate, null, viewId) as PopupTemplate;
            }

            if (hasValue(dotNetWidget.portal)) {
                search.portal = new Portal({
                    url: dotNetWidget.portal.url
                });
            }

            if (dotNetWidget.hasGoToOverride) {
                search.goToOverride = async (view, parameters) => {
                    const dnParams = buildDotNetGoToOverrideParameters(parameters, viewId);
                    await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJavaScriptGoToOverride', dnParams);
                }
            }

            search.on('select-result', async (evt) => {
                const { buildDotNetGraphic } = await import('./graphic');
                dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJavaScriptSearchSelectResult', {
                    extent: buildDotNetExtent(evt.result.extent),
                    feature: buildDotNetGraphic(evt.result.feature, null, viewId),
                    name: evt.result.name
                });
            });

            copyValuesIfExists(dotNetWidget, search, 'activeMenu', 'activeSourceIndex', 'allPlaceholder',
                'autoSelect', 'disabled', 'includeDefaultSources', 'locationEnabled', 'maxResults',
                'maxSuggestions', 'minSuggestCharacters', 'popupEnabled', 'resultGraphicEnabled', 'searchAllEnabled',
                'searchTerm', 'suggestionsEnabled');
            
            wrapper = new SearchWidgetWrapper(search);
            jsObjectRefs[dotNetWidget.id] = wrapper;
            break;
        case 'basemap-toggle':
            // the esri definition file is missing basemapToggle.nextBasemap, but it is in the docs.
            const basemapToggle = new BasemapToggle({
                view: view
            });
            newWidget = basemapToggle;
            if (hasValue(dotNetWidget.nextBasemapStyle)) {
                basemapToggle.nextBasemap = dotNetWidget.nextBasemapStyle;
            }
            else if (hasValue(dotNetWidget.nextBasemapName)) {
                // @ts-ignore
                basemapToggle.nextBasemap = dotNetWidget.nextBasemapName;
            } else {
                // @ts-ignore
                basemapToggle.nextBasemap = dotNetWidget.nextBasemap;
            }
            break;
        case 'basemap-gallery':
            let source = new PortalBasemapsSource();
            if (hasValue(dotNetWidget.portalBasemapsSource)) {
                const portal = new Portal();
                if (dotNetWidget.portalBasemapsSource.portal?.url !== undefined &&
                    dotNetWidget.portalBasemapsSource.portal?.url !== null) {
                    portal.url = dotNetWidget.portalBasemapsSource.portal.url;
                }
                source = new PortalBasemapsSource({
                    portal
                });
                if (dotNetWidget.portalBasemapsSource.queryParams !== undefined &&
                    dotNetWidget.portalBasemapsSource.queryParams !== null) {
                    source.query = dotNetWidget.portalBasemapsSource.queryParams;
                } else if (dotNetWidget.portalBasemapsSource.queryString !== undefined &&
                    dotNetWidget.portalBasemapsSource.queryString !== null) {
                    source.query = dotNetWidget.portalBasemapsSource.queryString;
                }
            } else if (hasValue(dotNetWidget.title)) {
                source.query = {
                    title: dotNetWidget.title
                };
            }
            newWidget = new BasemapGallery({
                view: view,
                source: source
            });
            break;
        case 'scale-bar':
            const scaleBar = new ScaleBar({
                view: view
            });
            newWidget = scaleBar;
            if (hasValue(dotNetWidget.unit)) {
                scaleBar.unit = dotNetWidget.unit;
            }
            break;
        case 'legend':
            const legend = new Legend({
                view: view
            });
            newWidget = legend;

            if (hasValue(dotNetWidget.layerInfos) && dotNetWidget.layerInfos.length > 0) {
                view.when(() => {
                    legend.layerInfos = dotNetWidget.layerInfos.map(li => {
                        const jsLayerInfo = {
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
                });
            }
            if (hasValue(dotNetWidget.style)) {
                if (hasValue(dotNetWidget.style.layout)) {
                    legend.style = {
                        type: dotNetWidget.style.type,
                        layout: dotNetWidget.style.layout
                    };
                }
                else {
                    legend.style = dotNetWidget.style.type;
                }
            }
            break;
        case 'home':
            const homeBtn = new Home({
                view: view,
            });
            newWidget = homeBtn;
            break;
        case 'compass':
            const compassWidget = new Compass({
                view: view
            });
            newWidget = compassWidget;
            break;
        case 'layer-list':
            const layerListWidget = new LayerList({
                view: view
            });
            newWidget = layerListWidget;

            if (hasValue(dotNetWidget.hasCustomHandler) && dotNetWidget.hasCustomHandler) {
                layerListWidget.listItemCreatedFunction = async (evt) => {
                    const dotNetListItem = buildDotNetListItem(evt.item);
                    const returnItem = await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnListItemCreated', dotNetListItem) as DotNetListItem;
                    if (hasValue(returnItem) && hasValue(evt.item)) {
                        await updateListItem(evt.item, returnItem, dotNetListItem?.layerId, viewId);
                    }
                };
            }

            break;
        case 'basemap-layer-list':
            const basemapLayerListWidget = new BasemapLayerList({
                view: view
            });
            newWidget = basemapLayerListWidget;

            if (hasValue(dotNetWidget.hasCustomBaseListHandler) && dotNetWidget.hasCustomBaseListHandler) {
                basemapLayerListWidget.baseListItemCreatedFunction = async (evt) => {
                    const dotNetBaseListItem = buildDotNetListItem(evt.item);
                    const returnItem = await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnBaseListItemCreated', dotNetBaseListItem) as DotNetListItem;
                    if (hasValue(returnItem) && hasValue(evt.item)) {
                        await updateListItem(evt.item, returnItem, dotNetBaseListItem?.layerId, viewId);
                    }
                };
            }
            if (hasValue(dotNetWidget.hasCustomReferenceListHandler) && dotNetWidget.hasCustomReferenceListHandler) {
                basemapLayerListWidget.referenceListItemCreatedFunction = async (evt) => {
                    const dotNetReferenceListItem = buildDotNetListItem(evt.item);
                    const returnItem = await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnReferenceListItemCreated', dotNetReferenceListItem) as DotNetListItem;
                    if (hasValue(returnItem) && hasValue(evt.item)) {
                        await updateListItem(evt.item, returnItem, dotNetReferenceListItem?.layerId, viewId);
                    }
                };
            }
            
            if (hasValue(dotNetWidget.visibleElements)) {
                basemapLayerListWidget.visibleElements = {
                    statusIndicators: dotNetWidget.visibleElements.statusIndicators,
                    baseLayers: dotNetWidget.visibleElements.baseLayers,
                    referenceLayers: dotNetWidget.visibleElements.referenceLayers,
                    errors: dotNetWidget.visibleElements.errors
                };
            }
            
            copyValuesIfExists(dotNetWidget, basemapLayerListWidget, 'basemapTitle', 'editingEnabled', 'headingLevel',
                'multipleSelectionEnabled');
            
            break;
        case 'expand':
            const expandWidgetDiv = 
                document.getElementById(`widget-container-${dotNetWidget.id}`) as HTMLElement;
            if (expandWidgetDiv === null) {
                return null;
            }
            
            // remove comment nodes
            for (let i = 0; i < expandWidgetDiv.childNodes.length; i++) {
                const childNode = expandWidgetDiv.childNodes[i];
                if (childNode.nodeType === 8) {
                    expandWidgetDiv.removeChild(childNode);
                    i --;
                }
            }
            expandWidgetDiv.hidden = false;
            if (hasValue(dotNetWidget.htmlContent)) {
                const templatedContent = document.createElement('template');
                templatedContent.innerHTML = dotNetWidget.htmlContent;
                expandWidgetDiv.appendChild(templatedContent.content.firstChild!);
            }
            
            if (hasValue(dotNetWidget.widgetContent)) {
                await addWidget(dotNetWidget.widgetContent, viewId, true);
            }
            const expand = new Expand({
                view,
                content: expandWidgetDiv,
                expanded: dotNetWidget.expanded,
                mode: dotNetWidget.mode,
            });

            if (hasValue(dotNetWidget.autoCollapse)) {
                expand.autoCollapse = dotNetWidget.autoCollapse;
            }

            if (hasValue(dotNetWidget.closeOnEsc)) {
                expand.closeOnEsc = dotNetWidget.closeOnEsc;
            }

            if (hasValue(dotNetWidget.expandIcon)) {
                expand.expandIcon = dotNetWidget.expandIcon;
            }

            if (hasValue(dotNetWidget.collapseIcon)) {
                expand.collapseIcon = dotNetWidget.collapseIcon;
            }

            if (hasValue(dotNetWidget.expandTooltip)) {
                expand.expandTooltip = dotNetWidget.expandTooltip;
            }

            if (hasValue(dotNetWidget.collapseTooltip)) {
                expand.collapseTooltip = dotNetWidget.collapseTooltip;
            }

            newWidget = expand;
            break;
        case 'popup':
            newWidget = await setPopup(dotNetWidget, viewId) as Popup;
            const { default: PopupWidgetWrapper } = await import('./popupWidget');
            wrapper = new PopupWidgetWrapper(newWidget as Popup);
            break;
        case 'measurement':
            newWidget = new Measurement({
                view: view,
                activeTool: dotNetWidget.activeTool ?? undefined,
                areaUnit: dotNetWidget.areaUnit ?? undefined,
                linearUnit: dotNetWidget.linearUnit ?? undefined,
                icon: dotNetWidget.icon ?? undefined,
            });
            break;
        case 'areaMeasurement2D':
            newWidget = new AreaMeasurement2D({
                view: view,
                viewModel: dotNetWidget.AreaMeasurement2DViewModel ?? undefined,
                unit: dotNetWidget.unit ?? undefined,
                unitOptions: dotNetWidget.unitOptions ?? undefined
            });
            break;
        case 'bookmarks':
            const bookmarkWidget = new Bookmarks({
                view: view,
                editingEnabled: dotNetWidget.editingEnabled,
                disabled: dotNetWidget.disabled,
                icon: dotNetWidget.icon
            });
            if (dotNetWidget.bookmarks != null) {
                let { buildJsBookmark } = await import('./bookmark');
                bookmarkWidget.bookmarks = dotNetWidget.bookmarks.map(buildJsBookmark);
            }

            bookmarkWidget.on('bookmark-select', async (event) => {
                const { buildDotNetBookmark } = await import('./bookmark');
                const bookmark = await buildDotNetBookmark(event.bookmark);
                await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJavascriptBookmarkSelect', {
                    bookmark: bookmark
                });
            });

            newWidget = bookmarkWidget;
            break;
        case 'slider':
            const slider = new Slider({
                container: dotNetWidget.containerId
            });
            newWidget = slider;
            copyValuesIfExists(dotNetWidget, slider, 'disabled', 'draggableSegmentsEnabled', 'effectiveMax',
                'effectiveMin', 'labelInputsEnabled', 'layout', 'max', 'min', 'precision', 
                'rangeLabelInputsEnabled', 'snapOnClickEnabled', 'syncedSegmentsEnabled', 'thumbsConstrained',
                'values');
            
            if (hasValue(dotNetWidget.steps)) {
                slider.steps = dotNetWidget.steps;
            } else if (hasValue(dotNetWidget.stepInterval)) {
                slider.steps = dotNetWidget.stepInterval;
            }
            
            if (hasValue(dotNetWidget.inputCreatedFunction)) {
                slider.inputCreatedFunction = (inputElement, type, thumbIndex) => {
                    return new Function('inputElement', 'type', 'thumbIndex', dotNetWidget.inputCreatedFunction)(inputElement, type, thumbIndex);
                };
            }
            
            if (hasValue(dotNetWidget.inputFormatFunction)) {
                slider.inputFormatFunction = (value, type, index) => {
                    return new Function('value', 'type', 'index', dotNetWidget.inputFormatFunction)(value, type, index);
                };
            }
            if (hasValue(dotNetWidget.inputParseFunction)) {
                slider.inputParseFunction = (value, type, index) => {
                    return new Function('value', 'type', 'index', dotNetWidget.inputParseFunction)(value, type, index);
                };
            }
            if (hasValue(dotNetWidget.labelFormatFunction)) {
                slider.labelFormatFunction = (value, type, index) => {
                    return new Function('value', 'type', 'index', dotNetWidget.labelFormatFunction)(value, type, index);
                }
            }
            if (hasValue(dotNetWidget.thumbCreatedFunction)) {
                slider.thumbCreatedFunction = (index, value, thumbElement, labelElement) => {
                    return new Function ('index', 'value', 'thumbElement', 'labelElement', dotNetWidget.thumbCreatedFunction)(index, value, thumbElement, labelElement);
                };
            }
            
            if (hasValue(dotNetWidget.tickConfigs) && dotNetWidget.tickConfigs.length > 0) {
                let { buildJsTickConfig } = await import('./tickConfig');
                slider.tickConfigs = dotNetWidget.tickConfigs.map(buildJsTickConfig);
            }
            if (hasValue(dotNetWidget.visibleElements)) {
                slider.visibleElements = {
                    labels: dotNetWidget.visibleElements.labels ?? false,
                    rangeLabels: dotNetWidget.visibleElements.rangeLabels ?? false
                };
            }
            
            slider.on('max-change', async (event) => {
                await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJsMaxChange', {
                    value: event.value,
                    oldValue: event.oldValue
                });
            });
            slider.on('max-click', async (event) => {
                await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJsMaxClick', {
                    value: event.value
                });                
            });
            slider.on('min-change', async (event) => {
                await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJsMinChange', {
                    value: event.value,
                    oldValue: event.oldValue
                });
            });
            slider.on('min-click', async (event) => {
                await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJsMinClick', {
                    value: event.value
                });
            });
            slider.on('segment-click', async (event) => {
                await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJsSegmentClick', {
                    index: event.index,
                    thumbIndices: event.thumbIndices,
                    value: event.value
                });
            });
            slider.on('segment-drag', async (event) => {
                await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJsSegmentDrag', {
                    index: event.index,
                    state: event.state,
                    thumbIndices: event.thumbIndices
                });
            });
            slider.on('thumb-change', async (event) => {
                await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJsThumbChange', {
                    index: event.index,
                    value: event.value,
                    oldValue: event.oldValue
                });
            });
            slider.on('thumb-click', async (event) => {
                await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJsThumbClick', {
                    index: event.index,
                    value: event.value
                });
            });
            slider.on('thumb-drag', async (event) => {
                await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJsThumbDrag', {
                    index: event.index,
                    state: event.state,
                    value: event.value
                });
            });
            slider.on('tick-click', async (event) => {
                await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJsTickClick', {
                    value: event.value,
                    configIndex: event.configIndex,
                    groupIndex: event.groupIndex
                });
            });
            slider.on('track-click', async (event) => {
                await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJsTrackClick', {
                    value: event.value
                });
            });

            reactiveUtils.watch(
                () => slider.values,
                async () => {
                    await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJsValueChanged', slider.values);
                }
            );
            
            const { default: SliderWidgetWrapper } = await import('./sliderWidget');
            wrapper = new SliderWidgetWrapper(slider);
            break;
        case 'area-measurement2-d':
            let { buildJsAreaMeasurement2DWidget } = await import('./areaMeasurement2DWidget');
            newWidget = await buildJsAreaMeasurement2DWidget(dotNetWidget, dotNetWidget.id, viewId);

            break;
        case 'feature':
            let { buildJsFeatureWidget } = await import('./featureWidget');
            newWidget = await buildJsFeatureWidget(dotNetWidget, dotNetWidget.id, viewId);

            break;
        case 'list-item-panel':
            let { buildJsListItemPanelWidget } = await import('./listItemPanelWidget');
            newWidget = await buildJsListItemPanelWidget(dotNetWidget, dotNetWidget.id, viewId);

            break;
        default:
            return null;
    }

    if (hasValue(dotNetWidget.widgetId)) {
        newWidget.id = dotNetWidget.widgetId;
    }

    copyValuesIfExists(dotNetWidget, newWidget, 'icon', 'label', 'visible');
    wrapper ??= newWidget;
    arcGisObjectRefs[dotNetWidget.id] = newWidget;
    dotNetRefs[dotNetWidget.id] = dotNetWidget.dotNetComponentReference;
    jsObjectRefs[dotNetWidget.id] = wrapper;
    
    // @ts-ignore
    const jsRef = DotNet.createJSObjectReference(wrapper);
    
    // register, to be removed when we finish code generation of all widgets
    await dotNetWidget.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsRef);
    
    return newWidget;
}

async function updateListItem(jsItem: ListItem, dnItem: DotNetListItem, layerId, viewId) {
    copyValuesIfExists(dnItem, jsItem, 'title', 'visible', 'childrenSortable', 'hidden',
        'open', 'sortable');
    
    if (hasValue(dnItem.children)) {
        for (let i = 0; i < dnItem.children.length; i++) {
            const child = dnItem.children[i];
            const jsChild = jsItem.children[i];
            if (hasValue(child) && hasValue(jsChild)) {
                await updateListItem(jsChild, child, layerId, viewId);
            }
        }
    }
    if (hasValue(dnItem.actionsSections)) {
        const actionsSections: any[] = [];
        let { buildJsActionBase } = await import('./actionBase');
        for (let i = 0; i < dnItem.actionsSections.length; i++) {
            const section: any[] = [];
            actionsSections.push(section);
            const dnSection = dnItem.actionsSections[i];
            for (let j = 0; j < dnSection.length; j++) {
                const dnAction = dnSection[j];
                const action = await buildJsActionBase(dnAction, layerId, viewId);
                section.push(action);
            }
        }
        jsItem.actionsSections = actionsSections as any;
    }
    
    if (hasValue(dnItem.layerId)) {
        jsItem.layer = arcGisObjectRefs[dnItem.layerId] as Layer;
    }
    
    if (hasValue(dnItem.panel)) {
        if (hasValue(dnItem.panel.contentDivId)) {
            const contentDiv = document.getElementById(dnItem.panel.contentDivId);
            if (contentDiv !== null) {
                jsItem.panel = {
                    content: contentDiv,
                    visible: dnItem.panel.visible,
                    className: dnItem.panel.className,
                    disabled: dnItem.panel.disabled,
                    flowEnabled: dnItem.panel.flowEnabled,
                    open: dnItem.panel.open,
                    image: dnItem.panel.image,
                    icon: dnItem.panel.icon,
                    label: dnItem.panel.label
                } as ListItemPanel;
            }
        } else if (hasValue(dnItem.panel.contentWidgetId)) {
            const contentWidget = arcGisObjectRefs[dnItem.panel.contentWidgetId] as Widget;
            jsItem.panel = {
                content: contentWidget,
                visible: dnItem.panel.visible,
                className: dnItem.panel.className,
                disabled: dnItem.panel.disabled,
                flowEnabled: dnItem.panel.flowEnabled,
                open: dnItem.panel.open,
                image: dnItem.panel.image,
                icon: dnItem.panel.icon,
                label: dnItem.panel.label
            } as ListItemPanel;
        } else if (hasValue(dnItem.panel.stringContent)) {
            jsItem.panel = {
                content: dnItem.panel.stringContent,
                visible: dnItem.panel.visible,
                className: dnItem.panel.className,
                disabled: dnItem.panel.disabled,
                flowEnabled: dnItem.panel.flowEnabled,
                open: dnItem.panel.open,
                image: dnItem.panel.image,
                icon: dnItem.panel.icon,
                label: dnItem.panel.label
            } as ListItemPanel;
        } else if (hasValue(dnItem.panel.showLegendContent) && dnItem.panel.showLegendContent) {
            jsItem.panel = {
                content: 'legend',
                visible: dnItem.panel.visible,
                className: dnItem.panel.className,
                disabled: dnItem.panel.disabled,
                flowEnabled: dnItem.panel.flowEnabled,
                open: dnItem.panel.open,
                image: dnItem.panel.image,
                icon: dnItem.panel.icon,
                label: dnItem.panel.label
            } as ListItemPanel;
        }
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

export async function addLayer(layerObject: any, viewId: string, isBasemapLayer?: boolean, isReferenceLayer?: boolean, 
                               isQueryLayer?: boolean, callback?: Function): Promise<void> {
    try {
        const view = arcGisObjectRefs[viewId] as View;
        if (!hasValue(view?.map)) return;

        const newLayer = await createLayer(layerObject, null, viewId);

        if (newLayer === null) return;

        if (isBasemapLayer) {
            if (layerObject.isBasemapReferenceLayer) {
                view.map?.basemap.referenceLayers.push(newLayer);
            } else {
                view.map?.basemap.baseLayers.push(newLayer);
            }
        } else if (isReferenceLayer) {
            view.map?.basemap.referenceLayers.push(newLayer);
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

export async function createLayer(dotNetLayer: any, wrap: boolean | null, viewId: string | null): Promise<Layer | null> {
    if (arcGisObjectRefs.hasOwnProperty(dotNetLayer.id)) {
        const existingLayer = jsObjectRefs[dotNetLayer.id] as any;
        if (hasValue(existingLayer) && !existingLayer.layer.destroyed) {
            return jsObjectRefs[dotNetLayer.id] as Layer;
        }
    }
    let newLayer: Layer;
    switch (dotNetLayer.type) {
        case 'graphics':
            newLayer = new GraphicsLayer();
            const graphicsLayer = newLayer as GraphicsLayer;
            const jsGraphics: Graphic[] = [];
            const groupId = dotNetLayer.id;
            if (!graphicsRefs.hasOwnProperty(groupId)) {
                graphicsRefs[groupId] = {};
            }
            for (const g of dotNetLayer.graphics) {
                const jsGraphic = buildJsGraphic(g, dotNetLayer.id, viewId ?? null) as Graphic;
                jsGraphics.push(jsGraphic);
            }
            graphicsLayer.addMany(jsGraphics);
            
            copyValuesIfExists(dotNetLayer, graphicsLayer, 'blendMode',
                'maxScale', 'minScale', 'screenSizePerspectiveEnabled');

            if (hasValue(dotNetLayer.effect)) {
                graphicsLayer.effect = buildJsEffect(dotNetLayer.effect);
            }
            break;
        case 'map-image':
            if (hasValue(dotNetLayer.portalItem)) {
                const portalItem = await buildJsPortalItem(dotNetLayer.portalItem, dotNetLayer.id, viewId);
                newLayer = new MapImageLayer({ portalItem: portalItem });
            } else {
                newLayer = new MapImageLayer({
                    url: dotNetLayer.url
                });
            }
            
            copyValuesIfExists(dotNetLayer, newLayer, 'blendMode', 'customParameters', 'dpi',
                'gdbVersion', 'imageFormat', 'imageMaxHeight', 'imageMaxWidth', 'imageTransparency', 'legendEnabled',
                'maxScale', 'minScale', 'refreshInterval', 'timeExtent', 'timeInfo',
                'useViewTime');
            
            if (hasValue(dotNetLayer.sublayers) && dotNetLayer.sublayers.length > 0) {
                let { buildJsSublayer } = await import('./sublayer');
                (newLayer as MapImageLayer).sublayers = dotNetLayer.sublayers.map(buildJsSublayer);
            }
            break;
        case 'tile':
            if (hasValue(dotNetLayer.portalItem)) {
                const portalItem = await buildJsPortalItem(dotNetLayer.portalItem, dotNetLayer.id, viewId);

                newLayer = new TileLayer({ portalItem: portalItem });
            } else {
                newLayer = new TileLayer({
                    url: dotNetLayer.url
                });
            }
            const tileLayer = newLayer as TileLayer;
            copyValuesIfExists(dotNetLayer, newLayer, 'minScale', 'maxScale', 'opacity', 'apiKey',
                'blendMode', 'copyright', 'customParameters', 'legendEnabled', 'listMode', 
                'refreshInterval', 'resampling', 'tileInfo', 'tileServers', 'title', 'version');

            if (hasValue(dotNetLayer.effect)) {
                tileLayer.effect = buildJsEffect(dotNetLayer.effect);
            }
            
            break;
        case 'elevation':
            if (hasValue(dotNetLayer.portalItem)) {
                const portalItem = await buildJsPortalItem(dotNetLayer.portalItem, dotNetLayer.id, viewId);
                newLayer = new ElevationLayer({ portalItem: portalItem });
            } else {
                newLayer = new ElevationLayer({
                    url: dotNetLayer.url
                });
            }
            break;
        case 'open-street-map':
            let openStreetMapLayer: OpenStreetMapLayer;
            if (hasValue(dotNetLayer.urlTemplate)) {
                openStreetMapLayer = new OpenStreetMapLayer({
                    urlTemplate: dotNetLayer.urlTemplate
                });
            } else if (hasValue(dotNetLayer.portalItem)) {
                const portalItem = await buildJsPortalItem(dotNetLayer.portalItem, dotNetLayer.id, viewId);
                openStreetMapLayer = new OpenStreetMapLayer({ portalItem: portalItem });
            } else {
                openStreetMapLayer = new OpenStreetMapLayer();
            }
            newLayer = openStreetMapLayer;

            copyValuesIfExists(dotNetLayer, openStreetMapLayer,
                'subDomains', 'blendMode', 'copyright', 'maxScale', 'minScale', 'refreshInterval')

            if (hasValue(dotNetLayer.tileInfo)) {
                openStreetMapLayer.tileInfo = new TileInfo();
                copyValuesIfExists(dotNetLayer.tileInfo, openStreetMapLayer.tileInfo,
                    'dpi', 'format', 'isWrappable', 'size');

                if (hasValue(dotNetLayer.tileInfo.lods)) {
                    openStreetMapLayer.tileInfo.lods = dotNetLayer.tileInfo.lods.map(l => {
                        const lod = new LOD();
                        copyValuesIfExists(l, lod, 'level', 'levelValue', 'resolution', 'scale');
                        return lod;
                    });
                }

                if (hasValue(dotNetLayer.tileInfo.origin)) {
                    openStreetMapLayer.tileInfo.origin = buildJsPoint(dotNetLayer.tileInfo.origin) as Point;
                }

                if (hasValue(dotNetLayer.tileInfo.spatialReference)) {
                    let { buildJsSpatialReference } = await import('./spatialReference');
                    openStreetMapLayer.tileInfo.spatialReference = 
                        await buildJsSpatialReference(dotNetLayer.tileInfo.spatialReference, dotNetLayer.id, viewId);
                }
            }

            break;
        case 'imagery':
            if (hasValue(dotNetLayer.url)) {
                newLayer = new ImageryLayer({
                    url: dotNetLayer.url
                });
            } else {
                const portalItem = await buildJsPortalItem(dotNetLayer.portalItem, dotNetLayer.id, viewId);
                newLayer = new ImageryLayer({ portalItem: portalItem });
            }

            const imageryLayer = newLayer as ImageryLayer;

            if (hasValue(dotNetLayer.renderer)) {
                let { buildJsImageryRenderer } = await import('./imageryRenderer');
                imageryLayer.renderer = await buildJsImageryRenderer(dotNetLayer.renderer, dotNetLayer.id, viewId) as any;
            }
            
            if (hasValue(dotNetLayer.effect)) {
                imageryLayer.effect = buildJsEffect(dotNetLayer.effect);
            }
            if (hasValue(dotNetLayer.fields && dotNetLayer.fields.length > 0)) {
                imageryLayer.fields = buildJsFields(dotNetLayer.fields);
            }
            if (hasValue(dotNetLayer.multidimensionsionalSubset)) {
                let { buildJsMultidimensionalSubset } = await import('./multidimensionalSubset');
                imageryLayer.multidimensionalSubset = 
                    await buildJsMultidimensionalSubset(dotNetLayer.multidimensionsionalSubset, dotNetLayer.id, viewId);
            }
            if (hasValue(dotNetLayer.noData)) {
                imageryLayer.noData = dotNetLayer.noData;
            }
            
            if (hasValue(dotNetLayer.popupTemplate)) {
                let { buildJsPopupTemplate } = await import('./popupTemplate');
                imageryLayer.popupTemplate = await buildJsPopupTemplate(dotNetLayer.popupTemplate, dotNetLayer.id, viewId ?? null) as PopupTemplate;
            }

            copyValuesIfExists('bandIds', 'blendMode', 'compressionQuality', 'compressionTolerance',
                'copyright', 'definitionExpression', 'format', 'hasMultidimensions', 'imageMaxHeight', 'imageMaxWidth',
                'interpolation', 'legendEnabled', 'maxScale', 'minScale', 'multidimensionalInfo', 'noDataInterpretation',
                'objectIdField', 'pixelType', 'popupEnabled', 'refreshInterval', 
                'serviceRasterInfo', 'useViewTime', 'version', 'capabilities', 'customParameters', 'timeExtent',
                'timeInfo', 'timeOffset');

            newLayer = imageryLayer;
            break;
        case 'base-tile':
            const { buildJsBaseTileLayer } = await import('./baseTileLayer');
            newLayer = await buildJsBaseTileLayer(dotNetLayer, dotNetLayer.Id, viewId);

            break;
        case 'feature':
            const { buildJsFeatureLayer } = await import('./featureLayer');
            newLayer = await buildJsFeatureLayer(dotNetLayer, dotNetLayer.id, viewId);

            break;
        case 'imagery-tile':
            const { buildJsImageryTileLayer } = await import('./imageryTileLayer');
            newLayer = await buildJsImageryTileLayer(dotNetLayer, dotNetLayer.id, viewId);

            break;
        case 'vector-tile':
            const { buildJsVectorTileLayer } = await import('./vectorTileLayer');
            newLayer = await buildJsVectorTileLayer(dotNetLayer, dotNetLayer.Id, viewId);

            break;
        case 'web-tile':
            const { buildJsWebTileLayer } = await import('./webTileLayer');
            newLayer = await buildJsWebTileLayer(dotNetLayer, dotNetLayer.Id, viewId);

            break;
        case 'bing-maps':
            const { buildJsBingMapsLayer } = await import('./bingMapsLayer');
            newLayer = await buildJsBingMapsLayer(dotNetLayer, dotNetLayer.id, viewId);

            break;
        case 'csv':
            const { buildJsCSVLayer } = await import('./cSVLayer');
            newLayer = await buildJsCSVLayer(dotNetLayer, dotNetLayer.id, viewId);

            break;
        case 'geojson':
            const { buildJsGeoJSONLayer } = await import('./geoJSONLayer');
            newLayer = await buildJsGeoJSONLayer(dotNetLayer, dotNetLayer.id, viewId);

            break;
        case 'geo-rss':
            const { buildJsGeoRSSLayer } = await import('./geoRSSLayer');
            newLayer = await buildJsGeoRSSLayer(dotNetLayer, dotNetLayer.id, viewId);

            break;
        case 'kml':
            const { buildJsKMLLayer } = await import('./kMLLayer');
            newLayer = await buildJsKMLLayer(dotNetLayer, dotNetLayer.id, viewId);

            break;
        case 'wcs':
            const { buildJsWCSLayer } = await import('./wCSLayer');
            newLayer = await buildJsWCSLayer(dotNetLayer, dotNetLayer.id, viewId);

            break;
        default:
            return null;
    }
    
    copyValuesIfExists(dotNetLayer, newLayer, 'title', 'opacity', 'listMode', 'visible',
        'persistenceEnabled');

    if (hasValue(dotNetLayer.fullExtent) && dotNetLayer.type !== 'open-street-map') {
        newLayer.fullExtent = buildJsExtent(dotNetLayer.fullExtent, null);
    }

    arcGisObjectRefs[dotNetLayer.id] = newLayer;
    
    if (wrap) {
        return jsObjectRefs[dotNetLayer.id];
    }

    return newLayer;
}

export function removeLayer(layerId: string, viewId: string, isBasemapLayer: boolean, isReferenceLayer): void {
    try {
        const layer = arcGisObjectRefs[layerId] as Layer;
        const view = arcGisObjectRefs[viewId] as MapView;
        if (isBasemapLayer) {
            view.map?.basemap.baseLayers.remove(layer);
        } else if (isReferenceLayer) {
            view.map?.basemap.referenceLayers.remove(layer);
        } else {
            view.map?.remove(layer);
        }
        layer.destroy();
        delete arcGisObjectRefs[layerId];
    } catch (error) {
        logError(error, viewId);
    }
}

async function resetCenterToSpatialReference(center: Point, spatialReference: SpatialReference): Promise<Point> {
    return await projection.project(center, spatialReference) as Point;
}

export function logError(error, viewId: string | null) {
    unsetWaitCursor(viewId);
    throw error;
}


function setWaitCursor(viewId: string): void {
    const viewContainer = document.getElementById(`map-container-${viewId}`);
    if (viewContainer !== null) {
        document.body.style.cursor = 'wait';
    }
}

function unsetWaitCursor(viewId: string | null): void {
    const viewContainer = document.getElementById(`map-container-${viewId}`);
    if (viewContainer !== null) {
        document.body.style.cursor = 'unset';
    }
}

function waitForRender(viewId: string, dotNetRef: any): void {
    const view = arcGisObjectRefs[viewId] as View;
    // eslint-disable-next-line @typescript-eslint/no-unused-vars
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
                if (!zoomWidgetListenerAdded) {
                    const zoomWidgetButtons =  document.querySelectorAll('[title="Zoom in"], [title="Zoom out"]');
                    for (let i = 0; i < zoomWidgetButtons.length; i++) {
                        zoomWidgetButtons[i].removeEventListener('click', setUserChangedViewExtent);
                        zoomWidgetButtons[i].addEventListener('click', setUserChangedViewExtent);
                    }
                    zoomWidgetListenerAdded = true;
                }
                
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

let zoomWidgetListenerAdded = false;

function setUserChangedViewExtent() {
    userChangedViewExtent = true;
}

export function hasValue(prop: any): boolean {
    return prop !== undefined && prop !== null;
}

function buildDotNetListItem(item: ListItem): DotNetListItem | null {
    if (!hasValue(item)) return null;
    const children: Array<DotNetListItem> = [];
    item.children.forEach(c => {
        const child = buildDotNetListItem(c);
        if (child !== null) {
            children.push(child);
        }
    });
    
    let layerId: string | null = null;
    // iterate through arcGisObjectRefs and find the value that equals the layer
    for (const key in arcGisObjectRefs) {
        if (arcGisObjectRefs[key] === item.layer) {
            layerId = key;
            break;
        }
    }

    return {
        title: item.title,
        visible: item.visible,
        children: children,
        actionSections: item.actionsSections as any,
        layerId: layerId
    } as any as DotNetListItem;
}

// this function should only be used for simple types that are guaranteed to succeed in serialization and conversion
export function copyValuesIfExists(originalObject: any, newObject: any, ...params: Array<string>) {
    params.forEach(p => {
        if (hasValue(originalObject[p]) && originalObject[p] !== newObject[p]) {
            newObject[p] = originalObject[p];
        }
    });
}

export async function createGeoBlazorObject(arcGisObject: any, newGeoBlazorObject: any = {}): Promise<any> {
    try {
        if ('items' in arcGisObject) {
            const items = arcGisObject.items;
            for (let i = 0; i < items.length; i++) {
                const item = items[i];
                const newItem = {};
                await createGeoBlazorObject(item, newItem);
                newGeoBlazorObject.items.push(newItem);
            }
            return newGeoBlazorObject;
        }
        if ('toJSON' in arcGisObject) {
            try {
                newGeoBlazorObject = arcGisObject.toJSON();
                return newGeoBlazorObject;
            } catch (error) {
                logError(error, null);
            }
        }

        await copyValuesToGeoBlazor(arcGisObject, newGeoBlazorObject);
        return newGeoBlazorObject;
    } catch (error) {
        logError(error, null);
        return null;
    }
}

export async function copyValuesToGeoBlazor(originalObject: any, newObject: any) {
    for (const key in originalObject) {
        if (typeof originalObject[key] === 'function') {
            continue;
        }
        const value = originalObject[key];
        if (!hasValue(value)) {
            continue;
        }
        if (typeof value === 'object') {
            const newValue = Array.isArray(value) ? [] : {};
            await createGeoBlazorObject(value, newValue);
            newObject[key] = newValue;
        } else {
            newObject[key] = value;
        }
    }
}

function checkConnectivity(viewId) {
    const connectError = new Error('Cannot load ArcGIS Assets!');
    const message = '<div><h1>Cannot retrieve ArcGIS asset files.</h1><p><a target="_blank" href="https://docs/geoblazor.com/assetFiles"</p></div>';
    const mapContainer = document.getElementById(`map-container-${viewId}`)!;
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
            .catch(() => {
                // The resource could not be reached
                mapContainer.innerHTML = message;
                logError(connectError, viewId)
            });
    } catch {
        mapContainer.innerHTML = message;
        logError(connectError, viewId);
    }
}


export function addReactiveWatcher(targetId: string, targetName: string, watchExpression: string, once: boolean,
    initial: boolean, dotNetRef: any): any {
    const target = arcGisObjectRefs[targetId];
    console.debug(`Adding watch: "${watchExpression}"`);
    const watcherFunc = new Function(targetName, 'reactiveUtils', 'dotNetRef',
        `return reactiveUtils.watch(() => ${watchExpression},
        (value) => dotNetRef.invokeMethodAsync('OnReactiveWatcherUpdate', '${watchExpression}', value),
        {once: ${once}, initial: ${initial}});`);
    return watcherFunc(target, reactiveUtils, dotNetRef);
}

export function addReactiveListener(targetId: string, eventName: string, once: boolean, dotNetRef: any): any {
    const target = arcGisObjectRefs[targetId];
    console.debug(`Adding listener: "${eventName}"`);
    const listenerFunc = new Function('target', 'reactiveUtils', 'dotNetRef',
        `return reactiveUtils.on(() => target, '${eventName}',
        (value) => dotNetRef.invokeMethodAsync('OnReactiveListenerTriggered', '${eventName}', value),
        {once: ${once}, onListenerRemove: () => console.debug('Removing listener: ${eventName}')});`);
    return listenerFunc(target, reactiveUtils, dotNetRef);
}

export async function awaitReactiveSingleWatchUpdate(targetId: string, targetName: string, watchExpression: string): Promise<any> {
    const target = arcGisObjectRefs[targetId];
    console.debug(`Adding once watcher: "${watchExpression}"`);
    const AsyncFunction = async function () {}.constructor;
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
    const graphic = lookupGraphicById(componentId, null, null);
    if (graphic !== null) {
        graphic.visible = visible;
        return;
    }
}

function buildHitTestOptions(options: DotNetHitTestOptions, view: MapView): MapViewHitTestOptions {
    const hitOptions: MapViewHitTestOptions = {};
    let hitIncludeOptions: Array<any> = [];
    let hitExcludeOptions: Array<any> = [];
    const layers = (view.map.layers as MapCollection).items as Array<Layer>;
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
        try {
            if (err) {
                logError(err, null);
                return;
            }
            ProtoGraphicCollection = root?.lookupType("ProtoGraphicCollection");
            ProtoViewHitCollection = root?.lookupType("ProtoViewHitCollection");
            console.debug('Protobuf graphics json loaded');
        } catch (error) {
            logError(error, null);
        }    
    });
}

export async function getGraphicsFromProtobufStream(streamRef): Promise<any[] | null> {
    try {
        const buffer = await streamRef.arrayBuffer();
        return decodeProtobufGraphics(new Uint8Array(buffer));
    } catch (error) {
        logError(error, null);
        return null;
    }
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
    // @ts-ignore
    return DotNet.createJSStreamReference(encoded);
}

function getProtobufViewHitStream(viewHits: DotNetViewHit[]): any{
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
    // @ts-ignore
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
    return view.container.style.cursor;
}

export function setCursor(cursorType: string, viewId: string) {
    const view = arcGisObjectRefs[viewId] as MapView;
    view.container.style.cursor = cursorType;
}

export async function getWebMapBookmarks(viewId: string) {
    const view = arcGisObjectRefs[viewId] as MapView;
    if (view != null) {
        const webMap = view.map as WebMap;
        if (webMap != null) {
            const arr = webMap.bookmarks.toArray();
            const { buildDotNetBookmark } = await import('./bookmark');
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
        // @ts-ignore
        abortControllerRef: DotNet.createJSObjectReference(controller),
        // @ts-ignore
        abortSignalRef: DotNet.createJSObjectReference(signal)
    }
}

export async function takeScreenshot(viewId, options): Promise<any> {
    const view = arcGisObjectRefs[viewId] as MapView;
    let screenshot : __esri.Screenshot;
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
    
    // @ts-ignore
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
