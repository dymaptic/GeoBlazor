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
    viewpoint.rotation = dnViewpoint.rotation ?? undefined;
    viewpoint.scale = dnViewpoint.scale ?? undefined;
    viewpoint.targetGeometry = buildJsGeometry(dnViewpoint.targetGeometry) as Geometry;
    return viewpoint as Viewpoint;
}
