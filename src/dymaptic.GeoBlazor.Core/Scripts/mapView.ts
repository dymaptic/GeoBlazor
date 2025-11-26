import {
    DotNetHitTestOptions,
    DotNetHitTestResult,
    DotNetViewHit,
    MapCollection,
} from "./definitions";
import {arcGisObjectRefs, hasValue} from "./arcGisJsInterop";
import View from "@arcgis/core/views/View";
import MapView from "@arcgis/core/views/MapView";
import SceneView from "@arcgis/core/views/SceneView";
import {buildDotNetGraphic} from "./graphic";
import {buildDotNetExtent} from "./extent";
import {buildDotNetPoint} from "./point";
import HitTestResult = __esri.HitTestResult;
import MapViewHitTestOptions = __esri.MapViewHitTestOptions;
import ViewHit = __esri.ViewHit;
import BaseComponent from "./baseComponent";
import Layer from "@arcgis/core/layers/Layer";
import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";

export default class MapViewWrapper extends BaseComponent {
    public view: MapView | SceneView;
    
    constructor (public arcGisView: MapView | SceneView) {
        super();
        this.view = arcGisView;
    }

    async hitTest(screenPoint: any, viewId: string, options: DotNetHitTestOptions | null)
        : Promise<DotNetHitTestResult | void> {
        const view = arcGisObjectRefs[viewId] as MapView;
        let result: HitTestResult;

        if (options !== null) {
            const hitOptions = this.buildHitTestOptions(options, view);
            result = await view.hitTest(screenPoint, hitOptions);
        } else {
            result = await view.hitTest(screenPoint);
        }

        return await this.buildDotNetHitTestResult(result, viewId);
    }

    buildHitTestOptions(options: DotNetHitTestOptions, view: MapView): MapViewHitTestOptions {
        const hitOptions: MapViewHitTestOptions = {};
        let hitIncludeOptions: Array<any> = [];
        let hitExcludeOptions: Array<any> = [];
        const layers = (view.map!.layers as MapCollection).items as Array<Layer>;
        const graphicsLayers = layers.filter(l => l.type === "graphics") as Array<GraphicsLayer>;

        if (hasValue(options.includeByGeoBlazorId)) {
            const gbInclude = options.includeByGeoBlazorId!.map(i => arcGisObjectRefs[i]);
            hitIncludeOptions = hitIncludeOptions.concat(gbInclude);
        }
        if (hasValue(options.excludeByGeoBlazorId)) {
            const gbExclude = options.excludeByGeoBlazorId!.map(i => arcGisObjectRefs[i]);
            hitExcludeOptions = hitExcludeOptions.concat(gbExclude);
        }
        if (hasValue(options.includeLayersByArcGISId)) {
            const layerInclude = layers.filter(l => options.includeLayersByArcGISId!.includes(l.id));
            hitIncludeOptions = hitIncludeOptions.concat(layerInclude);
        }
        if (hasValue(options.excludeLayersByArcGISId)) {
            const layerExclude = layers.filter(l => options.excludeLayersByArcGISId!.includes(l.id));
            hitExcludeOptions = hitExcludeOptions.concat(layerExclude);
        }
        if (hasValue(options.includeGraphicsByArcGISId)) {
            const graphicInclude = options.includeGraphicsByArcGISId!.map(i =>
                view.graphics.find(g => g.attributes['OBJECTID'] == i) ||
                graphicsLayers.map(l => l.graphics.find(g => g.attributes['OBJECTID'] == i)));
            hitIncludeOptions = hitIncludeOptions.concat(graphicInclude);
        }
        if (hasValue(options.excludeGraphicsByArcGISId)) {
            const graphicExclude = options.excludeGraphicsByArcGISId!.map(i =>
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

    async buildDotNetHitTestResult(hitTestResult: HitTestResult, viewId: string): Promise<DotNetHitTestResult> {
        let results = await Promise.all(hitTestResult.results
            .map(async r => await this.buildDotNetViewHit(r as ViewHit, viewId)))
            .then(res => res.filter(r => r !== null)) as Array<DotNetViewHit>;
        return {
            results: results,
            screenPoint: hitTestResult.screenPoint
        }
    }

    async buildDotNetViewHit(viewHit: ViewHit, viewId: string): Promise<any> {
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