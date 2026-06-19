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

    // Geometries returned from the operator API (e.g. unionOperator) do not always
    // expose a cached `extent`, which previously left the .NET Geometry.Extent null
    // (breaking e.g. view.GoTo(extent)). Always populate a missing extent, computing
    // it from the geometry's coordinates when the geometry does not provide one.
    if (hasValue(dotNetGeometry) && !hasValue(dotNetGeometry.extent)) {
        let calculatedExtent = calculateGeometryExtent(geometry);
        if (hasValue(calculatedExtent)) {
            dotNetGeometry.extent = buildDotNetExtent(calculatedExtent);
        }
    }

    return dotNetGeometry;
}

// Returns an extent-like object ({ xmin, ymin, xmax, ymax, spatialReference }) for a
// vertex-based geometry (polygon/polyline/multipoint). Prefers the geometry's own
// (lazily computed) extent and falls back to a bounding box over its raw coordinates.
function calculateGeometryExtent(geometry: any): any {
    if (hasValue(geometry?.extent)) {
        return geometry.extent;
    }

    // Coordinates are [x, y, z?, m?]: z is at index 2 when hasZ; m is at index 3 when
    // hasZ, otherwise index 2.
    let hasZ = geometry?.hasZ === true;
    let hasM = geometry?.hasM === true;
    let zIndex = hasZ ? 2 : -1;
    let mIndex = hasM ? (hasZ ? 3 : 2) : -1;

    let xmin = Infinity, ymin = Infinity, xmax = -Infinity, ymax = -Infinity;
    let zmin = Infinity, zmax = -Infinity, mmin = Infinity, mmax = -Infinity;
    let anyZ = false, anyM = false;
    let consider = (pt: Array<number>) => {
        if (!hasValue(pt) || pt.length < 2) return;
        if (pt[0] < xmin) xmin = pt[0];
        if (pt[0] > xmax) xmax = pt[0];
        if (pt[1] < ymin) ymin = pt[1];
        if (pt[1] > ymax) ymax = pt[1];
        if (zIndex >= 0 && pt.length > zIndex) {
            anyZ = true;
            if (pt[zIndex] < zmin) zmin = pt[zIndex];
            if (pt[zIndex] > zmax) zmax = pt[zIndex];
        }
        if (mIndex >= 0 && pt.length > mIndex) {
            anyM = true;
            if (pt[mIndex] < mmin) mmin = pt[mIndex];
            if (pt[mIndex] > mmax) mmax = pt[mIndex];
        }
    };

    if (hasValue(geometry?.rings)) {
        for (let ring of geometry.rings) for (let pt of ring) consider(pt);
    } else if (hasValue(geometry?.paths)) {
        for (let path of geometry.paths) for (let pt of path) consider(pt);
    } else if (hasValue(geometry?.points)) {
        for (let pt of geometry.points) consider(pt);
    }

    if (xmin === Infinity) {
        return null;
    }

    let extent: any = {
        type: 'extent',
        xmin, ymin, xmax, ymax,
        spatialReference: geometry?.spatialReference ?? null
    };
    if (anyZ) {
        extent.zmin = zmin;
        extent.zmax = zmax;
        extent.hasZ = true;
    }
    if (anyM) {
        extent.mmin = mmin;
        extent.mmax = mmax;
        extent.hasM = true;
    }
    return extent;
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
