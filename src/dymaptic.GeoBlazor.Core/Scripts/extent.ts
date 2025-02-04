import {DotNetExtent} from "./definitions";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Extent from "@arcgis/core/geometry/Extent";
import {buildJsSpatialReference, copyValuesIfExists, hasValue} from "./arcGisJsInterop";

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