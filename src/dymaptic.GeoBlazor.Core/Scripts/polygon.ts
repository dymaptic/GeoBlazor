import {buildDotNetExtent} from "./extent";
import {buildDotNetSpatialReference} from "./spatialReference";

export function buildDotNetPolygon(polygon: any): any {
    if (polygon === undefined || polygon === null) return null;
    return {
        type: 'polygon',
        rings: polygon.rings,
        hasM: polygon.hasM,
        hasZ: polygon.hasZ,
        extent: buildDotNetExtent(polygon.extent),
        spatialReference: buildDotNetSpatialReference(polygon.spatialReference)
    };
}

export function buildJsPolygon(polygon: any): any {
    if (polygon === undefined || polygon === null) return null;
    return {
        type: 'polygon',
        rings: polygon.rings,
        hasM: polygon.hasM,
        hasZ: polygon.hasZ,
        extent: polygon.extent,
        spatialReference: polygon.spatialReference
    };
}