import {DotNetHitTestResult, DotNetViewHit,} from "./definitions";
import {arcGisObjectRefs} from "./arcGisJsInterop";
import View from "@arcgis/core/views/View";
import MapView from "@arcgis/core/views/MapView";
import SceneView from "@arcgis/core/views/SceneView";
import {buildDotNetGraphic} from "./graphic";
import {buildDotNetExtent} from "./extent";
import {buildDotNetPoint} from "./point";
import HitTestResult = __esri.HitTestResult;
import ViewHit = __esri.ViewHit;

export async function buildDotNetHitTestResult(hitTestResult: HitTestResult, viewId: string): Promise<DotNetHitTestResult> {
    let results = await Promise.all(hitTestResult.results.map(async r => await buildDotNetViewHit(r, viewId)))
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