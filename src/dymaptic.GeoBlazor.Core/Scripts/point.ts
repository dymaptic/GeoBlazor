import { buildDotNetExtent } from "./extent";
import { buildDotNetSpatialReference } from "./spatialReference";

export function buildDotNetPoint(point): any {
    if (point === undefined || point === null) return null;
    return {
        type: 'point',
        latitude: point.latitude,
        longitude: point.longitude,
        hasM: point.hasM,
        hasZ: point.hasZ,
        extent: buildDotNetExtent(point.extent),
        x: point.x,
        y: point.y,
        z: point.z,
        m: point.m,
        spatialReference: buildDotNetSpatialReference(point.spatialReference)
    };
}

export function buildJsPoint(point): any {
    if (point === undefined || point === null) return null;
    return {
        type: 'point',
        latitude: point.latitude,
        longitude: point.longitude,
        hasM: point.hasM,
        hasZ: point.hasZ,
        extent: point.extent,
        x: point.x,
        y: point.y,
        z: point.z,
        m: point.m,
        spatialReference: point.spatialReference
    };
}