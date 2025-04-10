import {DotNetViewpoint} from "./definitions";
import {hasValue} from "./arcGisJsInterop";
import {buildDotNetGeometry, buildJsGeometry} from "./geometry";
import Viewpoint from "@arcgis/core/Viewpoint";
import Geometry from "@arcgis/core/geometry/Geometry";

export function buildDotNetViewpoint(viewpoint: any): any {
    if (!hasValue(viewpoint)) return null;
    return {
        rotation: viewpoint.rotation,
        scale: viewpoint.scale,
        targetGeometry: buildDotNetGeometry(viewpoint.targetGeometry)
    } as DotNetViewpoint;
}

export function buildJsViewpoint(dnViewpoint): any {
    if (dnViewpoint === undefined || dnViewpoint === null) return null;
    let viewpoint = new Viewpoint();

    if (hasValue(dnViewpoint.scale)) {
        viewpoint.scale = dnViewpoint.scale
    }
    
    if (hasValue(dnViewpoint.rotation)) {
        viewpoint.rotation = dnViewpoint.rotation
    }

    viewpoint.targetGeometry = buildJsGeometry(dnViewpoint.targetGeometry) as Geometry;
    return viewpoint as Viewpoint;
}
