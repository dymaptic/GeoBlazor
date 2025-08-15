import {buildDotNetPoint, buildJsPoint} from "./point";
import {buildDotNetPolygon, buildJsPolygon} from "./polygon";
import {buildDotNetPolyline, buildJsPolyline} from "./polyline";
import {buildDotNetExtent, buildJsExtent} from "./extent";
import {buildDotNetMultipoint, buildJsMultipoint} from "./multipoint";
import {buildDotNetMesh, buildJsMesh} from "./mesh";
import {hasValue} from "./arcGisJsInterop";

export function buildDotNetGeometry(geometry: any, viewId: string | null): any {
    if (!hasValue(geometry)) {
        return null;
    }
    switch (geometry?.type) {
        case "point":
            return buildDotNetPoint(geometry, viewId);
        case "polyline":
            return buildDotNetPolyline(geometry, viewId);
        case "polygon":
            return buildDotNetPolygon(geometry, viewId);
        case "extent":
            return buildDotNetExtent(geometry, viewId);
        case "multipoint":
            return buildDotNetMultipoint(geometry, viewId);
        case "mesh":
            return buildDotNetMesh(geometry, viewId);
    }
}

export function buildJsGeometry(geometry: any, viewId: string | null): any {
    if (!hasValue(geometry)) {
        return null;
    }
    switch (geometry?.type) {
        case "point":
            return buildJsPoint(geometry, viewId);
        case "polyline":
            return buildJsPolyline(geometry, viewId);
        case "polygon":
            return buildJsPolygon(geometry, viewId);
        case "extent":
            return buildJsExtent(geometry, viewId);
        case "multipoint":
            return buildJsMultipoint(geometry, viewId);
        case "mesh":
            return buildJsMesh(geometry, viewId);
    }

    return geometry as any;
}
