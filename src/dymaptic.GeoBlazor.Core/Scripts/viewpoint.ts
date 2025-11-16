import {DotNetViewpoint} from "./definitions";
import {hasValue} from "./arcGisJsInterop";
import {buildDotNetGeometry, buildJsGeometry} from "./geometry";
import Viewpoint from "@arcgis/core/Viewpoint";
import Geometry from "@arcgis/core/geometry/Geometry";

export function buildDotNetViewpoint(jsObject: any): any {
    if (!hasValue(jsObject)) return null;
    return {
        rotation: jsObject.rotation,
        scale: jsObject.scale,
        targetGeometry: buildDotNetGeometry(jsObject.targetGeometry)
    } as DotNetViewpoint;
}

export function buildJsViewpoint(dotNetObject: any): any {
    if (dotNetObject === undefined || dotNetObject === null) return null;
    let viewpoint = new Viewpoint();

    if (hasValue(dotNetObject.scale)) {
        viewpoint.scale = dotNetObject.scale
    }
    
    if (hasValue(dotNetObject.rotation)) {
        viewpoint.rotation = dotNetObject.rotation
    }

    viewpoint.targetGeometry = buildJsGeometry(dotNetObject.targetGeometry) as Geometry;
    return viewpoint as Viewpoint;
}
