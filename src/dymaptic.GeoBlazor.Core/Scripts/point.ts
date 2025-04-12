import { buildDotNetExtent } from "./extent";
import { buildDotNetSpatialReference, buildJsSpatialReference } from "./spatialReference";
import { DotNetPoint } from "./definitions";
import Point from "@arcgis/core/geometry/Point";
import { arcGisObjectRefs, copyValuesIfExists, hasValue, jsObjectRefs } from "./arcGisJsInterop";
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

export function buildJsPoint(dotNetObject: any): any {
    if (dotNetObject === undefined || dotNetObject === null) return null;
    let properties: any = {};
    if (hasValue(dotNetObject.spatialReference)) {
        properties.spatialReference = buildJsSpatialReference(dotNetObject.spatialReference);
    } else {
        properties.spatialReference = new SpatialReference({ wkid: 4326 });
    }
    copyValuesIfExists(dotNetObject, properties, 'latitude', 'longitude', 'x', 'y', 'z', 'm',
        'hasZ', 'hasM');
    let point = new Point(properties);
    let jsObjectRef = DotNet.createJSObjectReference(point);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = point;

    return point;
}
