import { buildDotNetExtent } from "./extent";
import { buildDotNetSpatialReference } from "./spatialReference";

export function buildDotNetPolyline(polyline: any): any {
    return {
        type: 'polyline',
        paths: polyline.paths,
        hasM: polyline.hasM,
        hasZ: polyline.hasZ,
        extent: buildDotNetExtent(polyline.extent),
        spatialReference: buildDotNetSpatialReference(polyline.spatialReference)
    };
}

export function buildJsPolyline(polyline: any): any {
    return {
        type: 'polyline',
        paths: polyline.paths,
        hasM: polyline.hasM,
        hasZ: polyline.hasZ,
        extent: polyline.extent,
        spatialReference: polyline.spatialReference
    };
}