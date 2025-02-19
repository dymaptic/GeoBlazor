import { buildDotNetExtent } from "./extent";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import {DotNetPoint} from "./definitions";
import Point from "@arcgis/core/geometry/Point";
import {copyValuesIfExists, hasValue} from "./arcGisJsInterop";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";

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

export function buildJsPoint(dnPoint: DotNetPoint): Point | null {
    if (dnPoint === undefined || dnPoint === null) return null;
    let point = new Point({
        latitude: dnPoint.latitude ?? undefined,
        longitude: dnPoint.longitude ?? undefined,
        x: dnPoint.x ?? undefined,
        y: dnPoint.y ?? undefined
    });

    copyValuesIfExists(dnPoint, point, 'z', 'm', 'hasZ', 'hasM');
    if (hasValue(dnPoint.spatialReference)) {
        point.spatialReference = buildJsSpatialReference(dnPoint.spatialReference);
    } else {
        point.spatialReference = new SpatialReference({ wkid: 4326 });
    }

    return point;
}
