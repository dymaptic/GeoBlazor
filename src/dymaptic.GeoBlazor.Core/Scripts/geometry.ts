import { buildDotNetPoint, buildJsPoint } from "./point";
import { buildDotNetPolygon, buildJsPolygon } from "./polygon";
import { buildDotNetPolyline, buildJsPolyline } from "./polyline";
import {buildDotNetExtent, buildJsExtent} from "./extent";

export function buildDotNetGeometry(geometry): any {
   
    switch (geometry?.type) {
        case "point":
            return buildDotNetPoint(geometry);
        case "polyline":
            return buildDotNetPolyline(geometry);
        case "polygon":
            return buildDotNetPolygon(geometry);
        case "extent":
            return buildDotNetExtent(geometry);
    }

    return geometry as any;
}

export function buildJsGeometry(geometry): any {
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
