import {
    DotNetHitTestResult,
    DotNetViewHit,
} from "./definitions";
import Geometry from "@arcgis/core/geometry/Geometry";
import { 
    arcGisObjectRefs, 
    hasValue
} from "./arcGisJsInterop";
import Graphic from "@arcgis/core/Graphic";
import View from "@arcgis/core/views/View";
import MapView from "@arcgis/core/views/MapView";
import SceneView from "@arcgis/core/views/SceneView";
import HitTestResult = __esri.HitTestResult;
import ViewHit = __esri.ViewHit;
import { buildDotNetGraphic } from "./graphic";
import { buildDotNetExtent } from "./extent";
import { buildDotNetPoint } from "./point";
import {buildDotNetGeometry} from "./geometry";

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
            let { buildDotNetPoint } = await import('./point');
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

export function buildDotNetGoToOverrideParameters(parameters: any, viewId: string): any {
    let dnParams: any = {
        viewId: viewId,
        options: {
            animate: parameters.options.animate,
            duration: parameters.options.duration,
            easing: parameters.options.easing,
            pickClosestTarget: parameters.options.pickClosestTarget
        }
    }
    if (hasValue(parameters.target)) {
        let target: any = {
            target: parameters.target.target.toJSON(),
            center: parameters.target.center,
            scale: parameters.target.scale,
            zoom: parameters.target.zoom,
            heading: parameters.target.heading,
            tilt: parameters.target.tilt,
            position: buildDotNetPoint(parameters.target.position)
        };
        if (Array.isArray(parameters.target.target) && parameters.target.target.length > 0) {
            let firstObject = parameters.target.target[0];
            if (firstObject instanceof Graphic || firstObject.declaredClass.includes('graphic')) {
                target.targetGraphics = [];
                for (let g in parameters.target.target as Graphic[]) {
                    target.targetGraphics.push(buildDotNetGraphic(g as any, null, viewId));
                }
            } else if (firstObject instanceof Geometry || firstObject.declaredClass.includes('geometry')) {
                target.targetGeometries = [];
                for (let g in parameters.target.target as Geometry[]) {
                    target.targetGeometries.push(buildDotNetGeometry(g as any));
                }
            } else {
                target.targetCoordinates = parameters.target.target;
            }
        } else if (parameters.target.target instanceof Graphic || parameters.target.target.declaredClass.includes('graphic')) {
            target.targetGraphic = buildDotNetGraphic(parameters.target.target, null, viewId);
        } else if (parameters.target.target instanceof Geometry || parameters.target.target.declaredClass.includes('geometry')) {
            target.targetGeometry = buildDotNetGeometry(parameters.target.target);
        }
        dnParams.target = target;
    }
    
    return dnParams;
}
