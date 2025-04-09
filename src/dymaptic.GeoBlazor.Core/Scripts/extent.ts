import {DotNetExtent} from "./definitions";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Extent from "@arcgis/core/geometry/Extent";
import {arcGisObjectRefs, copyValuesIfExists, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";

export function buildJsExtent(dotNetExtent, currentSpatialReference: any | null = null): any {
    if (!hasValue(dotNetExtent)) {
        return null;
    }
    
    let properties: any = {};
    copyValuesIfExists(dotNetExtent, properties, 'xmax', 'xmin', 'ymax', 'ymin', 'zmax', 'zmin', 'mmax', 'mmin');

    if (hasValue(dotNetExtent.spatialReference)) {
        properties.spatialReference = buildJsSpatialReference(dotNetExtent.spatialReference)
    } else if (currentSpatialReference !== null) {
        properties.spatialReference = currentSpatialReference;
    }
    let extent = new Extent(properties);
    let jsObjectRef = DotNet.createJSObjectReference(extent);
    jsObjectRefs[dotNetExtent.id] = jsObjectRef;
    arcGisObjectRefs[dotNetExtent.id] = extent;
    return extent;
}

export function buildDotNetExtent(extent: Extent | null | undefined): DotNetExtent | null {
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
