import {buildDotNetPoint, buildJsPoint} from "./point";
import {buildDotNetPolygon, buildJsPolygon} from "./polygon";
import {buildDotNetPolyline, buildJsPolyline} from "./polyline";
import {buildDotNetExtent, buildJsExtent} from "./extent";
import {buildDotNetMultipoint, buildJsMultipoint} from "./multipoint";
import {buildDotNetMesh, buildJsMesh} from "./mesh";
import {hasValue} from './geoBlazorCore';

export function buildDotNetGeometry(geometry: any): any {
    if (!hasValue(geometry)) {
        return null;
    }
    let dotNetGeometry: any;
    switch (geometry?.type) {
        case "point":
            return buildDotNetPoint(geometry);
        case "polyline":
            dotNetGeometry = buildDotNetPolyline(geometry);
            break;
        case "polygon":
            dotNetGeometry = buildDotNetPolygon(geometry);
            break;
        case "extent":
            return buildDotNetExtent(geometry);
        case "multipoint":
            dotNetGeometry = buildDotNetMultipoint(geometry);
            break;
        case "mesh":
            return buildDotNetMesh(geometry);
        default:
            return undefined;
    }

    // Geometries returned from the operator API (e.g. unionOperator) do not always expose
    // a cached `extent`, which previously left the .NET Geometry.Extent null (breaking
    // e.g. view.GoTo(extent)). Use ArcGIS to compute a missing extent.
    if (hasValue(dotNetGeometry) && !hasValue(dotNetGeometry.extent)) {
        let jsExtent = getArcGisExtent(geometry, dotNetGeometry);
        if (hasValue(jsExtent)) {
            dotNetGeometry.extent = buildDotNetExtent(jsExtent);
        }
    }

    return dotNetGeometry;
}

// Returns the ArcGIS-computed extent for a geometry. Prefers the geometry's own `.extent`
// (computed lazily by the SDK, including Z/M bounds); when an operator result doesn't
// expose one, rebuilds a typed ArcGIS geometry from the same coordinates so the SDK
// recomputes it, rather than calculating the bounding box by hand.
function getArcGisExtent(geometry: any, dotNetGeometry: any): any {
    if (hasValue(geometry?.extent)) {
        return geometry.extent;
    }
    let rebuilt = buildJsGeometry(dotNetGeometry);
    return rebuilt?.extent ?? null;
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
