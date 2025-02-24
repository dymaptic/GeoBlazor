import {buildDotNetPoint, buildJsPoint} from "./point";
import {buildDotNetPolygon, buildJsPolygon} from "./polygon";
import {buildDotNetPolyline, buildJsPolyline} from "./polyline";
import {buildDotNetExtent, buildJsExtent} from "./extent";
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
        default:
            let { id, dotNetComponentReference, sanitizedGeometry } = geometry;
            return sanitizedGeometry;
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
    }

    return geometry as any;
}
