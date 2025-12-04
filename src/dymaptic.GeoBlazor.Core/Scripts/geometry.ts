import {buildDotNetPoint, buildJsPoint} from "./point";
import {buildDotNetPolygon, buildJsPolygon} from "./polygon";
import {buildDotNetPolyline, buildJsPolyline} from "./polyline";
import {buildDotNetExtent, buildJsExtent} from "./extent";
import {buildDotNetMultipoint, buildJsMultipoint} from "./multipoint";
import {buildDotNetMesh, buildJsMesh} from "./mesh";
import {
    hasValue,
    removeCircularReferences,
    updateGeometryForProtobuf,
    UseStreams
} from './geoBlazorCore';
import {DotNetGeometry} from "./definitions";

export function buildDotNetGeometry(geometry: any): any {
    if (!hasValue(geometry)) {
        return null;
    }
    
    let dnGeometry: DotNetGeometry;
    switch (geometry?.type) {
        case "point":
            dnGeometry = buildDotNetPoint(geometry);
            break;
        case "polyline":
            dnGeometry = buildDotNetPolyline(geometry);
            break;
        case "polygon":
            dnGeometry = buildDotNetPolygon(geometry);
            break;
        case "extent":
            dnGeometry = buildDotNetExtent(geometry);
            break;
        case "multipoint":
            dnGeometry = buildDotNetMultipoint(geometry);
            break;
        case "mesh":
            dnGeometry = buildDotNetMesh(geometry);
            break;
        default:
            // unknown type
            return removeCircularReferences(geometry);
    }
    
    if (UseStreams) {
        updateGeometryForProtobuf(dnGeometry);
    }
}

export function buildJsGeometry(geometry: any): any {
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
