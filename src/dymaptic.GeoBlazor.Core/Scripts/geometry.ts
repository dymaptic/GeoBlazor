import { buildDotNetPoint } from "./point";
import { buildDotNetPolygon } from "./polygon";
import { buildDotNetPolyline } from "./polyline";
import {buildDotNetExtent} from "./extent";

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