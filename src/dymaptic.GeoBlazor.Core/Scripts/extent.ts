import {DotNetExtent} from "./definitions";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Extent from "@arcgis/core/geometry/Extent";
import {buildJsSpatialReference, copyValuesIfExists, hasValue} from "./arcGisJsInterop";
import { buildDotNetSpatialReference } from "./spatialReference";

export function buildJsExtent(dotNetExtent: DotNetExtent, currentSpatialReference: SpatialReference | null = null): Extent {
    let extent = new Extent();
    copyValuesIfExists(dotNetExtent, extent, 'xmax', 'xmin', 'ymax', 'ymin', 'zmax', 'zmin', 'mmax', 'mmin');

    if (hasValue(dotNetExtent.spatialReference)) {
        extent.spatialReference = buildJsSpatialReference(dotNetExtent.spatialReference)
    } else if (currentSpatialReference !== null) {
        extent.spatialReference = currentSpatialReference;
    }

    return extent;
}

export function buildDotNetExtent(extent: Extent): DotNetExtent | null {
    if (extent === undefined || extent === null) return null;
    return {
        type: 'extent',
        xmin: extent.xmin,
        ymin: extent.ymin,
        xmax: extent.xmax,
        ymax: extent.ymax,
        zmin: extent.zmin,
        zmax: extent.zmax,
        mmin: extent.mmin,
        mmax: extent.mmax,
        hasM: extent.hasM,
        hasZ: extent.hasZ,
        spatialReference: buildDotNetSpatialReference(extent.spatialReference)
    } as DotNetExtent;
}

export function buildJsExtentFromJson(json: any): Extent {
    let extent = new Extent();
    copyValuesIfExists(json, extent, 'xmax', 'xmin', 'ymax', 'ymin', 'zmax', 'zmin', 'mmax', 'mmin');

    if (hasValue(json.spatialReference)) {
        extent.spatialReference = buildJsSpatialReference(json.spatialReference)
    }

    return extent;
}