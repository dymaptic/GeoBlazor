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
import MapImageLayer from "@arcgis/core/layers/MapImageLayer";
import Layer from "@arcgis/core/layers/Layer";
import VectorTileLayer from "@arcgis/core/layers/VectorTileLayer";
import TileLayer from "@arcgis/core/layers/TileLayer";
import GeoJSONLayer from "@arcgis/core/layers/GeoJSONLayer";
import CSVLayer from "@arcgis/core/layers/CSVLayer";
import GeoRSSLayer from "@arcgis/core/layers/GeoRSSLayer";
import BingMapsLayer from "@arcgis/core/layers/BingMapsLayer";
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
import ImageryLayer from "@arcgis/core/layers/ImageryLayer.js";
import ImageryTileLayer from "@arcgis/core/layers/ImageryTileLayer.js";

import {
    buildDotNetBookmark,
    buildDotNetExtent,
    buildDotNetFeature,
    buildDotNetGeometry,
    buildDotNetGoToOverrideParameters,
    buildDotNetGraphic,
    buildDotNetHitTestResult,
    buildDotNetLayer,
    buildDotNetLayerView,
    buildDotNetPoint,
    buildDotNetPopupTemplate,
    buildDotNetSpatialReference,
    buildViewExtentUpdate
} from "./dotNetBuilder";

import {
    buildJsAction,
    buildJsAttributes,
    buildJsBookmark,
    buildJsDimensionalDefinition,
    buildJsEffect,
    buildJsExtent,
    buildJsFeatureReduction,
    buildJsFields,
    buildJsFormTemplate,
    buildJsGeometry,
    buildJsGraphic,
    buildJsImageryRenderer,
    buildJsLabelClass,
    buildJsMultidimensionalSubset,
    buildJsPoint,
    buildJsPopup,
    buildJsPopupOptions,
    buildJsPopupTemplate,
    buildJsPortalItem,
    buildJsRasterStretchRenderer,
    buildJsRenderer,
    buildJsSearchSource,
    buildJsSpatialReference,
    buildJsSublayer,
    buildJsSymbol,
    buildJsTickConfig
} from "./jsBuilder";
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
} from "./definitions";
import WebTileLayer from "@arcgis/core/layers/WebTileLayer";
import TileInfo from "@arcgis/core/layers/support/TileInfo";
import LOD from "@arcgis/core/layers/support/LOD";
import OpenStreetMapLayer from "@arcgis/core/layers/OpenStreetMapLayer";
import Camera from "@arcgis/core/Camera";
import ProjectionWrapper from "./projection";
import GeometryEngineWrapper from "./geometryEngine";
import LocatorWrapper from "./locator";
import FeatureLayerViewWrapper from "./featureLayerView";
import Popup from "@arcgis/core/widgets/Popup";
import ElevationLayer from "@arcgis/core/layers/ElevationLayer";
import PopupWidgetWrapper from "./popupWidgetWrapper";
import {load} from "protobufjs";
import AuthenticationManager from "./authenticationManager";
import RasterStretchRenderer from "@arcgis/core/renderers/RasterStretchRenderer";
import DimensionalDefinition from "@arcgis/core/layers/support/DimensionalDefinition";
import Renderer from "@arcgis/core/renderers/Renderer";
import Color from "@arcgis/core/Color";
import BingMapsLayerWrapper from "./bingMapsLayer";
import SearchWidgetWrapper from "./searchWidgetWrapper";
import SearchSource from "@arcgis/core/widgets/Search/SearchSource";
import BasemapStyle from "@arcgis/core/support/BasemapStyle";
import Slider from "@arcgis/core/widgets/Slider";
import SliderWidgetWrapper from "./sliderWidgetWrapper";
import ListItemPanel from "@arcgis/core/widgets/LayerList/ListItemPanel";
import ImageryTileLayerWrapper from "./imageryTileLayer";
import HitTestResult = __esri.HitTestResult;
import MapViewHitTestOptions = __esri.MapViewHitTestOptions;
import LegendLayerInfos = __esri.LegendLayerInfos;
import ScreenPoint = __esri.ScreenPoint;
import Polyline from "@arcgis/core/geometry/Polyline";
import Polygon from "@arcgis/core/geometry/Polygon";


export let arcGisObjectRefs: Record<string, Accessor> = {};

export let popupTemplateRefs: Record<string, Accessor> = {};
export let graphicsRefs: Record<string, Graphic> = {};
export let dotNetRefs = {};
export let queryLayer: FeatureLayer;
export let blazorServer: boolean = false;
import normalizeUtils from "@arcgis/core/geometry/support/normalizeUtils";
export { projection, geometryEngine, Graphic, Color, Point, Polyline, Polygon, normalizeUtils };
let notifyExtentChanged: boolean = true;
let uploadingLayers: Array<string> = [];
let userChangedViewExtent: boolean = false;
let pointerDown: boolean = false;

export function getProperty(obj, prop) {
    return obj[prop];
}

export function setProperty(obj, prop, value) {
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

export function setSublayerProperty(layerObj: any, sublayerId: number, prop: string, value: any) {
    let sublayer = (layerObj as TileLayer)?.sublayers.find(sl => sl.id === sublayerId);
    if (hasValue(sublayer)) {
        setProperty(sublayer, prop, value);
    }
}

export function setSublayerPopupTemplate(layerObj: any, sublayerId: number, popupTemplate: any, viewId: string) {
    let sublayer = (layerObj as TileLayer)?.sublayers.find(sl => sl.id === sublayerId);
    if (hasValue(sublayer) && hasValue(popupTemplate)) {
        sublayer.popupTemplate = buildJsPopupTemplate(popupTemplate, viewId) as PopupTemplate;
    }
}

export function setAssetsPath(path: string) {
    if (path !== undefined && path !== null && esriConfig.assetsPath !== path) {
        esriConfig.assetsPath = path;
    }
}

export function getObjectReference(objectRef: any) {
    if (!hasValue(objectRef)) return objectRef;
    try {
        // check the class name first, as some esri types fail the `instanceof` check
        switch (objectRef?.__proto__.declaredClass) {
            case 'esri.views.2d.layers.FeatureLayerView2D':
            case 'esri.views.3d.layers.FeatureLayerView3D':
                return new FeatureLayerViewWrapper(objectRef);
        }
        
        if (objectRef instanceof Layer) {
            if (objectRef instanceof FeatureLayer) {
                return new FeatureLayerWrapper(objectRef);
            }
            if (objectRef instanceof BingMapsLayer) {
                return new BingMapsLayerWrapper(objectRef);
            }
            if (objectRef instanceof ImageryTileLayer) {
                return new ImageryTileLayerWrapper(objectRef);
            }
        }
        if (objectRef instanceof Graphic) {
            return buildDotNetGraphic(objectRef);
        }
        if (objectRef instanceof Popup) {
            return new PopupWidgetWrapper(objectRef);
        }
        if (objectRef instanceof Search) {
            return new SearchWidgetWrapper(objectRef);
        }
        if (objectRef instanceof Slider) {
            return new SliderWidgetWrapper(objectRef);
        }
        return objectRef;
    }
    catch {
        // do nothing
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

export async function getProjectionWrapper(dotNetRef: any): Promise<ProjectionWrapper> {
    if (ProtoGraphicCollection === undefined) {
        await loadProtobuf();
    }
    let wrapper = new ProjectionWrapper(dotNetRef);
    return wrapper;
}

export async function getGeometryEngineWrapper(dotNetRef: any): Promise<GeometryEngineWrapper> {
    if (ProtoGraphicCollection === undefined) {
        await loadProtobuf();
    }
    let wrapper = new GeometryEngineWrapper(dotNetRef);
    return wrapper;
}

export async function getLocatorWrapper(dotNetRef: any): Promise<LocatorWrapper> {
    if (ProtoGraphicCollection === undefined) {
        await loadProtobuf();
    }
    
    let wrapper = new LocatorWrapper(dotNetRef);
    return wrapper;
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
        let dotNetRef = dotNetReference;
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
        let basemapLayers: any[] = [];
        if (!mapType.startsWith('web')) {
            if (mapObject.arcGISDefaultBasemap !== undefined &&
                mapObject.arcGISDefaultBasemap !== null) {
                basemap = mapObject.arcGISDefaultBasemap;
            } else if (hasValue(mapObject.basemap?.style)) {
                let style = new BasemapStyle({
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

        setEventListeners(view, dotNetRef, eventRateLimitInMilliseconds, activeEventHandlers);

        // popup widget needs to be registered before adding layers to not overwrite the popupTemplates
        let popupWidget = widgets.find(w => w.type === 'popup');
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

        for (let i = basemapLayers.length - 1; i >= 0; i--) {
            const layerObject = basemapLayers[i];
            await addLayer(layerObject, id, true);
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
    view.on('click', (evt) => {
        evt.mapPoint = buildDotNetPoint(evt.mapPoint) as any;
        dotNetRef.invokeMethodAsync('OnJavascriptClick', evt);
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
        let dragCallback = () => dotNetRef.invokeMethodAsync('OnJavascriptDrag', evt);
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
        let pointerMoveCallback = () => dotNetRef.invokeMethodAsync('OnJavascriptPointerMove', evt);
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
        // find objectRef id by layer
        let layerGeoBlazorId = Object.keys(arcGisObjectRefs).find(key => arcGisObjectRefs[key] === evt.layer);

        let isBasemapLayer = false;
        if (hasValue(view.map.basemap) &&
            (view.map.basemap.baseLayers?.includes(evt.layer) || view.map.basemap.referenceLayers?.includes(evt.layer))) {
            isBasemapLayer = true;
        }
        
        let layerRef;
        let layerViewRef;
        // @ts-ignore
        layerRef = DotNet.createJSObjectReference(getObjectReference(evt.layer));
        // @ts-ignore
        layerViewRef = DotNet.createJSObjectReference(getObjectReference(evt.layerView));

        let result = {
            layerObjectRef: layerRef,
            layerViewObjectRef: layerViewRef,
            layerView: buildDotNetLayerView(evt.layerView),
            layer: buildDotNetLayer(evt.layer, false),
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
    
    view.on('mouse-wheel', (evt) => {
        userChangedViewExtent = true;
        let mouseWheelCallback = () => dotNetRef.invokeMethodAsync('OnJavascriptMouseWheel', evt);
        debounce(mouseWheelCallback, eventRateLimit, !hasValue(eventRateLimit))();
    });

    view.on('resize', (evt) => {
        userChangedViewExtent = true;
        let resizeCallback = () => dotNetRef.invokeMethodAsync('OnJavascriptResize', evt);
        debounce(resizeCallback, eventRateLimit, !hasValue(eventRateLimit))();
    });

    view.watch('spatialReference', () => {
        dotNetRef.invokeMethodAsync('OnJavascriptSpatialReferenceChanged', buildDotNetSpatialReference(view.spatialReference));
    });

    view.watch('extent', () => {
        if (!notifyExtentChanged) return;
        userChangedViewExtent = true;
        let extentCallback = () => {
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

export function registerGeoBlazorObject(jsObjectRef: any, geoBlazorId: string) {
    if ('unwrap' in jsObjectRef) {
        arcGisObjectRefs[geoBlazorId] = jsObjectRef.unwrap();
    } else {
        arcGisObjectRefs[geoBlazorId] = jsObjectRef;
    }
}

export function registerGeoBlazorSublayer(layerId, sublayerId, sublayerGeoBlazorId) {
    let layer = arcGisObjectRefs[layerId] as TileLayer;
    arcGisObjectRefs[sublayerGeoBlazorId] = layer.allSublayers.find(sl => sl.id === sublayerId);
}

export async function hitTest(screenPoint: any, viewId: string, options: DotNetHitTestOptions | null, hitTestId: string)
    : Promise<DotNetHitTestResult | void> {
    try {
        let view = arcGisObjectRefs[viewId] as MapView;
        let result: HitTestResult;

        if (options !== null) {
            let hitOptions = buildHitTestOptions(options, view);
            result = await view.hitTest(screenPoint, hitOptions);
        } else {
            result = await view.hitTest(screenPoint);
        }

        let dotNetResult = buildDotNetHitTestResult(result);
        if (dotNetResult.results.length > 0) {
            let streamRef = getProtobufViewHitStream(dotNetResult.results);
            dotNetResult.results = [];
            let dotNetRef = dotNetRefs[viewId];
            await dotNetRef.invokeMethodAsync('OnHitTestStreamCallback', streamRef, hitTestId);    
        }
        
        return dotNetResult;
    } catch (e) {
        logError(e, viewId);
    }
}

export function toMap(screenPoint: any, viewId: string): DotNetPoint | null {
    let view = arcGisObjectRefs[viewId] as MapView;
    let mapPoint = view.toMap(screenPoint);
    return buildDotNetPoint(mapPoint);
}

export function toScreen(mapPoint: any, viewId: string): ScreenPoint {
    let view = arcGisObjectRefs[viewId] as MapView;
    return view.toScreen(buildJsPoint(mapPoint) as Point);
}

export function disposeView(viewId: string): void {
    try {
        let view = arcGisObjectRefs[viewId] as MapView;
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
        let component = arcGisObjectRefs[componentId];
        switch (component?.declaredClass) {
            case 'esri.Graphic':
                let graphic = component as Graphic;
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
        removeGraphicPopupTemplate(graphic);
        graphic?.destroy();
        delete graphicsRefs[graphicId];
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
        let popupTemplate = buildJsPopupTemplate(popupTemplateObject, viewId) as PopupTemplate;
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
        for (const id of graphicWrapperIds) {
            graphicsToRemove.push(graphicsRefs[id]);
            removeGraphicPopupTemplate(graphicsRefs[id]);
            delete graphicsRefs[id];
        }
        if (hasValue(layerId)) {
            let layer = arcGisObjectRefs[layerId as string] as GraphicsLayer;
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
        let view = arcGisObjectRefs[viewId] as View;
        let graphic = graphicsRefs[graphicId];
        removeGraphicPopupTemplate(graphic);
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

                if (hasValue(layerObject.popupTemplate)) {
                    featureLayer.popupTemplate = buildJsPopupTemplate(layerObject.popupTemplate, viewId) as PopupTemplate;
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

                if (hasValue(layerObject.labelingInfo)) {
                    featureLayer.labelingInfo = layerObject.labelingInfo.map(buildJsLabelClass);
                }

                if (hasValue(layerObject.proProperties?.FeatureReduction)) {
                    featureLayer.featureReduction = buildJsFeatureReduction(layerObject.proProperties.FeatureReduction, viewId);
                }

                copyValuesIfExists(layerObject, featureLayer, 'minScale', 'maxScale', 'orderBy', 'objectIdField',
                    'definitionExpression', 'outFields');

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
                if (hasValue(layerObject.popupTemplate)) {
                    geoJsonLayer.popupTemplate = buildJsPopupTemplate(layerObject.popupTemplate, viewId ?? null) as PopupTemplate;
                }
                if (hasValue(layerObject.proProperties?.FeatureReduction)) {
                    geoJsonLayer.featureReduction = buildJsFeatureReduction(layerObject.proProperties.FeatureReduction, viewId);
                } else {
                    // @ts-ignore
                    geoJsonLayer.featureReduction = null;
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
            case 'csv':
                if (hasValue(layerObject.proProperties?.FeatureReduction)) {
                    (currentLayer as CSVLayer).featureReduction = buildJsFeatureReduction(layerObject.proProperties.FeatureReduction, viewId);
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
                    (currentLayer as ImageryLayer).multidimensionalSubset = buildJsMultidimensionalSubset(layerObject.multidimensionalSubset);
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
                    (currentLayer as ImageryTileLayer).multidimensionalDefinition = layerObject.multidimensionalDefinition.map(buildJsDimensionalDefinition);
                }
                if (hasValue(layerObject.multidimensionalSubset)) {
                    (currentLayer as ImageryTileLayer).multidimensionalSubset = buildJsMultidimensionalSubset(layerObject.multidimensionalSubset);
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

        if (currentWidget === undefined) {
            unsetWaitCursor(viewId);
            return;
        }

        switch (widgetObject.type) {
            case 'bookmarks':
                let bookmarks = currentWidget as Bookmarks;
                if (hasValue(widgetObject.bookmarks)) {
                    bookmarks.bookmarks = widgetObject.bookmarks.map(buildJsBookmark);
                }
                break;
            case 'search':
                let search = currentWidget as Search;
                if (hasValue(widgetObject.sources)) {
                    let sources: SearchSource[] = [];
                    for (const source of widgetObject.sources) {
                        let jsSource = await buildJsSearchSource(source, viewId);
                        sources.push(jsSource);
                    }
                    search.sources.removeAll();
                    search.sources.addMany(sources);
                }

                if (hasValue(widgetObject.popupTemplate)) {
                    search.popupTemplate = buildJsPopupTemplate(widgetObject.popupTemplate, viewId) as PopupTemplate;
                }

                if (hasValue(widgetObject.portal)) {
                    search.portal = new Portal({
                        url: widgetObject.portal.url
                    });
                }
                break;
            case 'basemapLayerList':
                let basemapLayerList = currentWidget as BasemapLayerList;
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
                let popupTemplate = buildJsPopupTemplate(popupTemplateObject, viewId) as PopupTemplate;
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
        let view = arcGisObjectRefs[viewId] as View;

        let jsPopup = await buildJsPopup(dotNetPopup, viewId);
        if (hasValue(dotNetPopup.widgetContent)) {
            let widgetContent = await createWidget(dotNetPopup.widgetContent, dotNetPopup.viewId);
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
        let view = arcGisObjectRefs[viewId] as View;

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
        await dotNetPopup.dotNetWidgetReference.invokeMethodAsync("OnTriggerAction", event.action.id);
    }
    let viewRef = dotNetRefs[viewId];
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

export let triggerActionHandlers: Record<string, IHandle> = {};

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
        let view = arcGisObjectRefs[viewId] as View;
        view.popup.close();
    } catch (error) {
        logError(error, viewId);
    }
}

export async function showPopup(popupTemplateObject: any, location: DotNetPoint, viewId: string): Promise<void> {
    try {
        setWaitCursor(viewId);
        let popupTemplate = buildJsPopupTemplate(popupTemplateObject, viewId) as PopupTemplate;

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
        await addGraphic(graphicObject, viewId);
        let view = arcGisObjectRefs[viewId] as View;
        let graphic = arcGisObjectRefs[graphicObject.id] as Graphic;
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

export function addGraphicsSynchronously(graphicsArray: Uint8Array, viewId: string, layerId?: string | null): void {
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
    let jsPopupTemplate = buildJsPopupTemplate(popupTemplate, viewId) as PopupTemplate;
    if (hasValue(graphic) && hasValue(popupTemplate) && graphic.popupTemplate !== jsPopupTemplate) {
        graphic.popupTemplate = jsPopupTemplate;
    }
}

export function removeGraphicPopupTemplate(graphic: Graphic): void {
    let id = Object.keys(popupTemplateRefs).find(k => popupTemplateRefs[k] === graphic);
    if (id !== undefined) {
        delete popupTemplateRefs[id];
        if (dotNetRefs.hasOwnProperty(id)) {
            delete dotNetRefs[id];
        }
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
                        removeGraphicPopupTemplate(graphic);
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
                        removeGraphicPopupTemplate(graphic);
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

export async function addWidget(widget: any, viewId: string, setInContainerByDefault: boolean = false)
    : Promise<void> {
    try {
        let view = arcGisObjectRefs[viewId] as MapView;
        if (view === undefined || view === null) return;
        let newWidget = await createWidget(widget, viewId);
        if (newWidget === null || newWidget instanceof Popup) return;

        if (hasValue(widget.containerId) && !hasValue(newWidget.container)) {
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
            // check if widget is defined inside mapview
            let inMapWidget = view.container?.querySelector(`#widget-container-${widget.id}`);
            let widgetContainer: HTMLElement = document.getElementById(`widget-container-${widget.id}`)!;
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

async function createWidget(widget: any, viewId: string): Promise<Widget | null> {
    let view = arcGisObjectRefs[viewId] as MapView;

    let newWidget: Widget;
    switch (widget.type) {
        case 'locate':
            const locate = new Locate({
                view: view,
                rotationEnabled: widget.rotationEnabled ?? undefined,
                scale: widget.scale ?? undefined
            });
            newWidget = locate;

            if (widget.hasGoToOverride) {
                locate.goToOverride = async (view, parameters) => {
                    let dnParams = buildDotNetGoToOverrideParameters(parameters, viewId);
                    await widget.locateWidgetObjectReference.invokeMethodAsync('OnJavaScriptGoToOverride', dnParams);
                }
            }

            break;
        case 'search':
            const search = new Search({
                view: view
            });
            newWidget = search;

            if (hasValue(widget.sources)) {
                let sources: SearchSource[] = [];
                for (const source of widget.sources) {
                    let jsSource = await buildJsSearchSource(source, viewId);
                    sources.push(jsSource);
                }
                search.sources.addMany(sources);
            }

            if (hasValue(widget.popupTemplate)) {
                search.popupTemplate = buildJsPopupTemplate(widget.popupTemplate, viewId) as PopupTemplate;
            }

            if (hasValue(widget.portal)) {
                search.portal = new Portal({
                    url: widget.portal.url
                });
            }

            if (widget.hasGoToOverride) {
                search.goToOverride = async (view, parameters) => {
                    let dnParams = buildDotNetGoToOverrideParameters(parameters, viewId);
                    await widget.searchWidgetObjectReference.invokeMethodAsync('OnJavaScriptGoToOverride', dnParams);
                }
            }

            search.on('select-result', (evt) => {
                widget.searchWidgetObjectReference.invokeMethodAsync('OnJavaScriptSearchSelectResult', {
                    extent: buildDotNetExtent(evt.result.extent),
                    feature: buildDotNetFeature(evt.result.feature),
                    name: evt.result.name
                });
            });

            copyValuesIfExists(widget, search, 'activeMenu', 'activeSourceIndex', 'allPlaceholder',
                'autoSelect', 'disabled', 'includeDefaultSources', 'label', 'locationEnabled', 'maxResults',
                'maxSuggestions', 'minSuggestCharacters', 'popupEnabled', 'resultGraphicEnabled', 'searchAllEnabled',
                'searchTerm', 'suggestionsEnabled');
            break;
        case 'basemapToggle':
            // the esri definition file is missing basemapToggle.nextBasemap, but it is in the docs.
            let basemapToggle = new BasemapToggle({
                view: view
            });
            newWidget = basemapToggle;
            if (hasValue(widget.nextBasemapStyle)) {
                basemapToggle.nextBasemap = widget.nextBasemapStyle;
            }
            else if (hasValue(widget.nextBasemapName)) {
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

            if (hasValue(widget.layerInfos) && widget.layerInfos.length > 0) {
                view.when(() => {
                    legend.layerInfos = widget.layerInfos.map(li => {
                        let jsLayerInfo = {
                            layer: arcGisObjectRefs[li.layer.id]
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
            if (hasValue(widget.style)) {
                if (hasValue(widget.style.layout)) {
                    legend.style = {
                        type: widget.style.type,
                        layout: widget.style.layout
                    };
                }
                else {
                    legend.style = widget.style.type;
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
        case 'layerList':
            const layerListWidget = new LayerList({
                view: view
            });
            newWidget = layerListWidget;

            if (hasValue(widget.hasCustomHandler) && widget.hasCustomHandler) {
                layerListWidget.listItemCreatedFunction = async (evt) => {
                    let dotNetListItem = buildDotNetListItem(evt.item);
                    let returnItem = await widget.layerListWidgetObjectReference.invokeMethodAsync('OnListItemCreated', dotNetListItem) as DotNetListItem;
                    if (hasValue(returnItem) && hasValue(evt.item)) {
                        updateListItem(evt.item, returnItem);
                    }
                };
            }

            break;
        case 'basemapLayerList':
            const basemapLayerListWidget = new BasemapLayerList({
                view: view
            });
            newWidget = basemapLayerListWidget;

            if (hasValue(widget.hasCustomBaseListHandler) && widget.hasCustomBaseListHandler) {
                basemapLayerListWidget.baseListItemCreatedFunction = async (evt) => {
                    let dotNetBaseListItem = buildDotNetListItem(evt.item);
                    let returnItem = await widget.baseLayerListWidgetObjectReference.invokeMethodAsync('OnBaseListItemCreated', dotNetBaseListItem) as DotNetListItem;
                    if (hasValue(returnItem) && hasValue(evt.item)) {
                        updateListItem(evt.item, returnItem);
                    }
                };
            }
            if (hasValue(widget.hasCustomReferenceListHandler) && widget.hasCustomReferenceListHandler) {
                basemapLayerListWidget.baseListItemCreatedFunction = async (evt) => {
                    let dotNetReferenceListItem = buildDotNetListItem(evt.item);
                    let returnItem = await widget.baseLayerListWidgetObjectReference.invokeMethodAsync('OnReferenceListItemCreated', dotNetReferenceListItem) as DotNetListItem;
                    if (hasValue(returnItem) && hasValue(evt.item)) {
                        updateListItem(evt.item, returnItem);
                    }
                };
            }
            
            if (hasValue(widget.visibleElements)) {
                basemapLayerListWidget.visibleElements = {
                    statusIndicators: widget.visibleElements.statusIndicators,
                    baseLayers: widget.visibleElements.baseLayers,
                    referenceLayers: widget.visibleElements.referenceLayers,
                    errors: widget.visibleElements.errors
                };
            }
            
            copyValuesIfExists(widget, basemapLayerListWidget, 'basemapTitle', 'editingEnabled', 'headingLevel',
                'multipleSelectionEnabled');
            
            break;
        case 'expand':
            let content: any;
            let expandWidgetDiv = 
                document.getElementById(`widget-container-${widget.id}`) as HTMLElement;
            if (expandWidgetDiv === null) {
                return null;
            }
            
            // remove comment nodes
            for (let i = 0; i < expandWidgetDiv.childNodes.length; i++) {
                let childNode = expandWidgetDiv.childNodes[i];
                if (childNode.nodeType === 8) {
                    expandWidgetDiv.removeChild(childNode);
                    i --;
                }
            }
            expandWidgetDiv.hidden = false;
            if (hasValue(widget.htmlContent)) {
                let templatedContent = document.createElement('template');
                templatedContent.innerHTML = widget.htmlContent;
                expandWidgetDiv.appendChild(templatedContent.content.firstChild!);
            }
            
            if (hasValue(widget.widgetContent)) {
                await addWidget(widget.widgetContent, viewId, true);
            }
            view.ui.remove(content);
            const expand = new Expand({
                view,
                content: expandWidgetDiv,
                expanded: widget.expanded,
                mode: widget.mode,
            });

            if (hasValue(widget.autoCollapse)) {
                expand.autoCollapse = widget.autoCollapse;
            }

            if (hasValue(widget.closeOnEsc)) {
                expand.closeOnEsc = widget.closeOnEsc;
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
                icon: widget.icon ?? undefined,
            });
            break;
        case 'bookmarks':
            const bookmarkWidget = new Bookmarks({
                view: view,
                editingEnabled: widget.editingEnabled,
                disabled: widget.disabled,
                icon: widget.icon
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
        case 'slider':
            const slider = new Slider({
                container: widget.containerId
            });
            newWidget = slider;
            copyValuesIfExists(widget, slider, 'disabled', 'draggableSegmentsEnabled', 'effectiveMax',
                'effectiveMin', 'labelInputsEnabled', 'layout', 'max', 'min', 'precision', 
                'rangeLabelInputsEnabled', 'snapOnClickEnabled', 'syncedSegmentsEnabled', 'thumbsConstrained',
                'values', 'visible');
            
            if (hasValue(widget.steps)) {
                slider.steps = widget.steps;
            } else if (hasValue(widget.stepInterval)) {
                slider.steps = widget.stepInterval;
            }
            
            if (hasValue(widget.inputCreatedFunction)) {
                slider.inputCreatedFunction = (inputElement, type, thumbIndex) => {
                    return new Function('inputElement', 'type', 'thumbIndex', widget.inputCreatedFunction)(inputElement, type, thumbIndex);
                };
            }
            
            if (hasValue(widget.inputFormatFunction)) {
                slider.inputFormatFunction = (value, type, index) => {
                    return new Function('value', 'type', 'index', widget.inputFormatFunction)(value, type, index);
                };
            }
            if (hasValue(widget.inputParseFunction)) {
                slider.inputParseFunction = (value, type, index) => {
                    return new Function('value', 'type', 'index', widget.inputParseFunction)(value, type, index);
                };
            }
            if (hasValue(widget.labelFormatFunction)) {
                slider.labelFormatFunction = (value, type, index) => {
                    return new Function('value', 'type', 'index', widget.labelFormatFunction)(value, type, index);
                }
            }
            if (hasValue(widget.thumbCreatedFunction)) {
                slider.thumbCreatedFunction = (index, value, thumbElement, labelElement) => {
                    return new Function ('index', 'value', 'thumbElement', 'labelElement', widget.thumbCreatedFunction)(index, value, thumbElement, labelElement);
                };
            }
            
            if (hasValue(widget.tickConfigs) && widget.tickConfigs.length > 0) {
                slider.tickConfigs = widget.tickConfigs.map(buildJsTickConfig);
            }
            if (hasValue(widget.visibleElements)) {
                slider.visibleElements = {
                    labels: widget.visibleElements.labels ?? false,
                    rangeLabels: widget.visibleElements.rangeLabels ?? false
                };
            }
            
            slider.on('max-change', async (event) => {
                await widget.dotNetWidgetReference.invokeMethodAsync('OnJsMaxChange', {
                    value: event.value,
                    oldValue: event.oldValue
                });
            });
            slider.on('max-click', async (event) => {
                await widget.dotNetWidgetReference.invokeMethodAsync('OnJsMaxClick', {
                    value: event.value
                });                
            });
            slider.on('min-change', async (event) => {
                await widget.dotNetWidgetReference.invokeMethodAsync('OnJsMinChange', {
                    value: event.value,
                    oldValue: event.oldValue
                });
            });
            slider.on('min-click', async (event) => {
                await widget.dotNetWidgetReference.invokeMethodAsync('OnJsMinClick', {
                    value: event.value
                });
            });
            slider.on('segment-click', async (event) => {
                await widget.dotNetWidgetReference.invokeMethodAsync('OnJsSegmentClick', {
                    index: event.index,
                    thumbIndices: event.thumbIndices,
                    value: event.value
                });
            });
            slider.on('segment-drag', async (event) => {
                await widget.dotNetWidgetReference.invokeMethodAsync('OnJsSegmentDrag', {
                    index: event.index,
                    state: event.state,
                    thumbIndices: event.thumbIndices
                });
            });
            slider.on('thumb-change', async (event) => {
                await widget.dotNetWidgetReference.invokeMethodAsync('OnJsThumbChange', {
                    index: event.index,
                    value: event.value,
                    oldValue: event.oldValue
                });
            });
            slider.on('thumb-click', async (event) => {
                await widget.dotNetWidgetReference.invokeMethodAsync('OnJsThumbClick', {
                    index: event.index,
                    value: event.value
                });
            });
            slider.on('thumb-drag', async (event) => {
                await widget.dotNetWidgetReference.invokeMethodAsync('OnJsThumbDrag', {
                    index: event.index,
                    state: event.state,
                    value: event.value
                });
            });
            slider.on('tick-click', async (event) => {
                await widget.dotNetWidgetReference.invokeMethodAsync('OnJsTickClick', {
                    value: event.value,
                    configIndex: event.configIndex,
                    groupIndex: event.groupIndex
                });
            });
            slider.on('track-click', async (event) => {
                await widget.dotNetWidgetReference.invokeMethodAsync('OnJsTrackClick', {
                    value: event.value
                });
            });

            reactiveUtils.watch(
                () => slider.values,
                async () => {
                    await widget.dotNetWidgetReference.invokeMethodAsync('OnJsValueChanged', slider.values);
                }
            );
            break;
        default:
            return null;
    }

    if (hasValue(widget.widgetId)) {
        newWidget.id = widget.widgetId;
    }

    copyValuesIfExists(widget, newWidget, 'icon', 'label');

    arcGisObjectRefs[widget.id] = newWidget;
    dotNetRefs[widget.id] = widget.dotNetComponentReference;
    // @ts-ignore
    let jsRef = DotNet.createJSObjectReference(getObjectReference(newWidget));
    await widget.dotNetWidgetReference.invokeMethodAsync('OnJsWidgetCreated', jsRef);
    return newWidget;
}

function updateListItem(jsItem: ListItem, dnItem: DotNetListItem) {
    copyValuesIfExists(dnItem, jsItem, 'title', 'visible', 'childrenSortable', 'hidden',
        'open', 'sortable');
    
    if (hasValue(dnItem.children)) {
        for (let i = 0; i < dnItem.children.length; i++) {
            let child = dnItem.children[i];
            let jsChild = jsItem.children[i];
            updateListItem(jsChild, child);
        }
    }
    if (hasValue(dnItem.actionsSections)) {
        let actionsSections: any[] = [];
        for (let i = 0; i < dnItem.actionsSections.length; i++) {
            let section: any[] = [];
            actionsSections.push(section);
            let dnSection = dnItem.actionsSections[i];
            for (let j = 0; j < dnSection.length; j++) {
                let dnAction = dnSection[j];
                let action = buildJsAction(dnAction);
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
            let contentDiv = document.getElementById(dnItem.panel.contentDivId);
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
            let contentWidget = arcGisObjectRefs[dnItem.panel.contentWidgetId] as Widget;
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

        let newLayer = await createLayer(layerObject, null, viewId);

        if (newLayer === null) return;

        if (isBasemapLayer) {
            if (layerObject.isBasemapReferenceLayer) {
                view.map?.basemap.referenceLayers.push(newLayer);
            } else {
                view.map?.basemap.baseLayers.push(newLayer);
            }
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
    if (arcGisObjectRefs.hasOwnProperty(layerObject.id)) {
        let oldLayer = arcGisObjectRefs[layerObject.id] as Layer;
        if (!oldLayer.destroyed) {
            if (wrap) {
                return getObjectReference(arcGisObjectRefs[layerObject.id] as Layer);
            }
            return arcGisObjectRefs[layerObject.id] as Layer;
        }
    }
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
            
            copyValuesIfExists(layerObject, graphicsLayer, 'blendMode',
                'maxScale', 'minScale', 'screenSizePerspectiveEnabled');

            if (hasValue(layerObject.effect)) {
                graphicsLayer.effect = buildJsEffect(layerObject.effect);
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
                'definitionExpression', 'outFields', 'legendEnabled', 'popupEnabled', 'apiKey', 'blendMode',
                'geometryType');

            if (hasValue(layerObject.formTemplate)) {
                featureLayer.formTemplate = buildJsFormTemplate(layerObject.formTemplate);
            }

            if (hasValue(layerObject.popupTemplate)) {
                featureLayer.popupTemplate = buildJsPopupTemplate(layerObject.popupTemplate, viewId ?? null) as PopupTemplate;
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
            
            if (hasValue(layerObject.labelingInfo)) {
                featureLayer.labelingInfo = layerObject.labelingInfo.map(buildJsLabelClass);
            }

            if (hasValue(layerObject.proProperties?.FeatureReduction)) {
                (newLayer as FeatureLayer).featureReduction = buildJsFeatureReduction(layerObject.proProperties.FeatureReduction, viewId!);
            }
            
            if (hasValue(layerObject.effect)) {
                featureLayer.effect = buildJsEffect(layerObject.effect);
            }
            break;
        case 'map-image':
            if (hasValue(layerObject.portalItem)) {
                let portalItem = buildJsPortalItem(layerObject.portalItem);
                newLayer = new MapImageLayer({ portalItem: portalItem });
            } else {
                newLayer = new MapImageLayer({
                    url: layerObject.url
                });
            }
            
            copyValuesIfExists(layerObject, newLayer, 'blendMode', 'customParameters', 'dpi',
                'gdbVersion', 'imageFormat', 'imageMaxHeight', 'imageMaxWidth', 'imageTransparency', 'legendEnabled',
                'maxScale', 'minScale', 'refreshInterval', 'timeExtent', 'timeInfo',
                'useViewTime');
            
            if (hasValue(layerObject.sublayers) && layerObject.sublayers.length > 0) {
                (newLayer as MapImageLayer).sublayers = layerObject.sublayers.map(buildJsSublayer);
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
            let tileLayer = newLayer as TileLayer;
            copyValuesIfExists(layerObject, newLayer, 'minScale', 'maxScale', 'opacity', 'apiKey',
                'blendMode', 'copyright', 'customParameters', 'legendEnabled', 'listMode', 
                'refreshInterval', 'resampling', 'tileInfo', 'tileServers', 'title', 'version');

            if (hasValue(layerObject.effect)) {
                tileLayer.effect = buildJsEffect(layerObject.effect);
            }
            
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
                url: layerObject.url
            });
            let gjLayer = newLayer as GeoJSONLayer;
            if (hasValue(layerObject.renderer)) {
                gjLayer.renderer = buildJsRenderer(layerObject.renderer) as Renderer;
            }
            if (hasValue(layerObject.spatialReference)) {
                gjLayer.spatialReference = buildJsSpatialReference(layerObject.spatialReference);
            }
            if (hasValue(layerObject.popupTemplate)) {
                gjLayer.popupTemplate = buildJsPopupTemplate(layerObject.popupTemplate, viewId ?? null) as PopupTemplate;
            }
            if (hasValue(layerObject.proProperties?.FeatureReduction)) {
                (newLayer as GeoJSONLayer).featureReduction = buildJsFeatureReduction(layerObject.proProperties.FeatureReduction, viewId!);
            }
            
            copyValuesIfExists(layerObject, gjLayer, 'copyright');
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
                csvLayer.popupTemplate = buildJsPopupTemplate(layerObject.popupTemplate, viewId ?? null) as PopupTemplate;
            }
            if (hasValue(layerObject.proProperties?.FeatureReduction)) {
                (newLayer as CSVLayer).featureReduction = buildJsFeatureReduction(layerObject.proProperties.FeatureReduction, viewId!);
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
        case 'bing-maps':
            const bing = new BingMapsLayer({
                key: layerObject.key,
                style: layerObject.style
            });

            newLayer = bing;

            if (hasValue(layerObject.spatialReference)) {
                bing.spatialReference = buildJsSpatialReference(layerObject.spatialReference);
            }

            if (hasValue(layerObject.effect)) {
                bing.effect = buildJsEffect(layerObject.effect);
            }

            copyValuesIfExists('blendMode', 'maxScale', 'minScale', 'refreshInterval');
            break;
        case 'imagery':
            if (hasValue(layerObject.url)) {
                newLayer = new ImageryLayer({
                    url: layerObject.url
                });
            } else {
                let portalItem = buildJsPortalItem(layerObject.portalItem);
                newLayer = new ImageryLayer({ portalItem: portalItem });
            }

            let imageryLayer = newLayer as ImageryLayer;

            if (hasValue(layerObject.renderer)) {
                imageryLayer.renderer = buildJsImageryRenderer(layerObject.renderer) as any;
            }
            
            if (hasValue(layerObject.effect)) {
                imageryLayer.effect = buildJsEffect(layerObject.effect);
            }
            if (hasValue(layerObject.fields && layerObject.fields.length > 0)) {
                imageryLayer.fields = buildJsFields(layerObject.fields);
            }
            if (hasValue(layerObject.multidimensionsionalSubset)) {
                imageryLayer.multidimensionalSubset = 
                    buildJsMultidimensionalSubset(layerObject.multidimensionsionalSubset);
            }
            if (hasValue(layerObject.noData)) {
                imageryLayer.noData = layerObject.noData;
            }
            
            if (hasValue(layerObject.popupTemplate)) {
                imageryLayer.popupTemplate = buildJsPopupTemplate(layerObject.popupTemplate, viewId ?? null) as PopupTemplate;
            }

            copyValuesIfExists('bandIds', 'blendMode', 'compressionQuality', 'compressionTolerance',
                'copyright', 'definitionExpression', 'format', 'hasMultidimensions', 'imageMaxHeight', 'imageMaxWidth',
                'interpolation', 'legendEnabled', 'maxScale', 'minScale', 'multidimensionalInfo', 'noDataInterpretation',
                'objectIdField', 'pixelType', 'popupEnabled', 'refreshInterval', 
                'serviceRasterInfo', 'useViewTime', 'version', 'capabilities', 'customParameters', 'timeExtent',
                'timeInfo', 'timeOffset');

            newLayer = imageryLayer;
            break;
        case 'imagery-tile':
            if (hasValue(layerObject.url)) {
                newLayer = new ImageryTileLayer({
                    url: layerObject.url
                });
            } else {
                let portalItem = buildJsPortalItem(layerObject.portalItem);
                newLayer = new ImageryTileLayer({ portalItem: portalItem });
            }

            let imageryTileLayer = newLayer as ImageryTileLayer;

            if (hasValue(layerObject.renderer)) {
                imageryTileLayer.renderer = buildJsImageryRenderer(layerObject.renderer) as any;
            }

            if (hasValue(layerObject.effect)) {
                imageryTileLayer.effect = buildJsEffect(layerObject.effect);
            }
            if (hasValue(layerObject.multidimensionsionalSubset)) {
                imageryTileLayer.multidimensionalSubset = buildJsMultidimensionalSubset(layerObject.multidimensionsionalSubset);
            }
            if (hasValue(layerObject.popupTemplate)) {
                imageryTileLayer.popupTemplate = buildJsPopupTemplate(layerObject.popupTemplate, viewId ?? null) as PopupTemplate;
            }

            copyValuesIfExists('bandIds', 'blendMode', 'copyright', 'interpolation', 
                'legendEnabled', 'maxScale', 'minScale', 'popupEnabled', 'serviceRasterInfo', 
                'useViewTime', 'version', 'customParameters', 'timeExtent', 'timeInfo', 'timeOffset', 'interpolation');

            newLayer = imageryTileLayer;
            break;
         default:
            return null;
    }
    
    copyValuesIfExists(layerObject, newLayer, 'title', 'opacity', 'listMode', 'visible',
        'persistenceEnabled');

    if (hasValue(layerObject.fullExtent) && layerObject.type !== 'open-street-map') {
        newLayer.fullExtent = buildJsExtent(layerObject.fullExtent, null);
    }

    arcGisObjectRefs[layerObject.id] = newLayer;

    if (wrap) {
        return getObjectReference(newLayer);
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
        delete arcGisObjectRefs[layerId];
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
                // listen for click on zoom widget
                if (!zoomWidgetListenerAdded) {
                    let zoomWidgetButtons =  document.querySelectorAll('[title="Zoom in"], [title="Zoom out"]');
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
    let children: Array<DotNetListItem> = [];
    item.children.forEach(c => {
        let child = buildDotNetListItem(c);
        if (child !== null) {
            children.push(child);
        }
    });
    
    let layerId: string | null = null;
    // iterate through arcGisObjectRefs and find the value that equals the layer
    for (let key in arcGisObjectRefs) {
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

export async function awaitReactiveSingleWatchUpdate(targetId: string, targetName: string, watchExpression: string): Promise<any> {
    let target = arcGisObjectRefs[targetId];
    console.debug(`Adding once watcher: "${watchExpression}"`);
    const AsyncFunction = async function () {}.constructor;
    // @ts-ignore
    const onceFunc = new AsyncFunction(targetName, 'reactiveUtils',
        `return reactiveUtils.once(() => ${watchExpression});`);
    return await onceFunc(target, reactiveUtils);
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
        return;
    }
    // check graphics too
    let graphic = graphicsRefs[componentId];
    if (graphic !== undefined) {
        graphic.visible = visible;
        return;
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

export let ProtoGraphicCollection;
export let ProtoViewHitCollection;

export async function loadProtobuf() {
    load("_content/dymaptic.GeoBlazor.Core/graphic.json", function (err, root) {
        try {
            if (err) throw err;
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
    let decoded = ProtoGraphicCollection.decode(uintArray);
    let array = ProtoGraphicCollection.toObject(decoded, {
        defaults: false,
        enums: String,
        longs: String,
        arrays: false,
        objects: false
    });
    return array.graphics;
}

export function getProtobufGraphicStream(graphics: DotNetGraphic[]): any {
    for (let i = 0; i < graphics.length; i++) {
        updateGraphicForProtobuf(graphics[i]);
    }
    let obj = {
        graphics: graphics
    };
    let collection = ProtoGraphicCollection.fromObject(obj);
    let encoded = ProtoGraphicCollection.encode(collection).finish();
    // @ts-ignore
    return DotNet.createJSStreamReference(encoded);
}

function getProtobufViewHitStream(viewHits: DotNetViewHit[]): any{
    for (let i = 0; i < viewHits.length; i++) {
        let viewHit = viewHits[i];
        if (viewHit.type === "graphic") {
            let graphic = (viewHit as DotNetGraphicHit).graphic;
            updateGraphicForProtobuf(graphic);
        }
    }

    let obj = {
        viewHits: viewHits
    };
    let collection = ProtoViewHitCollection.fromObject(obj);
    let encoded = ProtoViewHitCollection.encode(collection).finish();
    // @ts-ignore
    return DotNet.createJSStreamReference(encoded);
}

function updateGraphicForProtobuf(graphic: DotNetGraphic) {
    if (hasValue(graphic.attributes)) {
        graphic.attributes = Object.keys(graphic.attributes).map(attr => {
            return {
                key: attr,
                value: graphic.attributes[attr]?.toString(),
                valueType: Object.prototype.toString.call(graphic.attributes[attr])
            }
        });
    }
    if (hasValue(graphic.geometry)) {
        updateGeometryForProtobuf(graphic.geometry);
    }
    let symbol: any = graphic.symbol;
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
    portalUrl: string | null, trustedServers: string[] | null): AuthenticationManager {
    if (_authenticationManager === null) {
        _authenticationManager = new AuthenticationManager(dotNetRef, apiKey, appId, portalUrl, trustedServers);
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

export function setStretchTypeForRenderer(rendererId, stretchType) {
    let renderer = arcGisObjectRefs[rendererId] as RasterStretchRenderer;
    renderer.stretchType = stretchType;
}

export function getBrowserLanguage(): string {
    return navigator.language;
}