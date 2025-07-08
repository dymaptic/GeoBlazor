import {buildDotNetPoint, buildJsPoint} from "./point";
import {buildDotNetPolygon, buildJsPolygon} from "./polygon";
import {buildDotNetPolyline, buildJsPolyline} from "./polyline";
import {buildDotNetExtent, buildJsExtent} from "./extent";
import {buildDotNetMultipoint, buildJsMultipoint} from "./multipoint";
import {buildDotNetMesh, buildJsMesh} from "./mesh";
import {hasValue} from "./arcGisJsInterop";

export function buildDotNetGeometry(geometry): any {
    if (!hasValue(geometry)) {
        return null;
    }
    switch (geometry?.type) {
        case "point":
            return buildDotNetPoint(geometry);
        case "polyline":
            return buildDotNetPolyline(geometry);
        case "polygon":
            return buildDotNetPolygon(geometry);
        case "extent":
            return buildDotNetExtent(geometry);
        case "multipoint":
            return buildDotNetMultipoint(geometry);
        case "mesh":
            return buildDotNetMesh(geometry);
    }
}

export function buildJsGeometry(geometry): any {
    if (!hasValue(geometry)) {
        return null;
    }
    switch (geometry?.type) {
        case "point":
            return buildJsPoint(geometry);
        case "polyline":
            return buildJsPolyline(geometry);
        case "polygon":
            return buildJsPolygon(geometry);
        case "extent":
            return buildJsExtent(geometry);
        case "multipoint":
            return buildJsMultipoint(geometry);
        case "mesh":
            return buildJsMesh(geometry);
    }

    return geometry as any;
}
