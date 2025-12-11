import {hasValue, lookupGeoBlazorId} from './geoBlazorCore';
import {buildDotNetPoint} from "./point";
import Graphic from "@arcgis/core/Graphic";
import {buildDotNetGraphic} from "./graphic";
import Geometry from "@arcgis/core/geometry/Geometry";
import {buildDotNetGeometry} from "./geometry";

export function buildJsGoToOverride(dotNetObject: any, viewId: string | null) {
    return async (view: any, goToParameters: any) => {
        viewId ??= lookupGeoBlazorId(view);
        let parameters = buildDotNetGoToOverrideParameters(goToParameters, viewId!);
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsGoToOverride', parameters);
    };
}

export async function buildDotNetGoToOverride(jsObject: any): Promise<any> {
    return null;
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
