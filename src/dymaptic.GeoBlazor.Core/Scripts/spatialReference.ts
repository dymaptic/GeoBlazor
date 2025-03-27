// override generated code in this file
import SpatialReference from '@arcgis/core/geometry/SpatialReference';
import {arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId} from "./arcGisJsInterop";


export function buildDotNetSpatialReference(spatialReference: SpatialReference) {
    if (!hasValue(spatialReference)) {
        return null;
    }
    
    let dotNetSpatialReference: any = {};
    if (hasValue(spatialReference.imageCoordinateSystem)) {
        dotNetSpatialReference.imageCoordinateSystem = spatialReference.imageCoordinateSystem;
    }
    if (hasValue(spatialReference.wkid)) {
        dotNetSpatialReference.wkid = spatialReference.wkid;
    }
    if (hasValue(spatialReference.wkt)) {
        dotNetSpatialReference.wkt = spatialReference.wkt;
    }
    if (hasValue(spatialReference.wkt2)) {
        dotNetSpatialReference.wkt2 = spatialReference.wkt2;
    }
    if (hasValue(spatialReference.isGeographic)) {
        dotNetSpatialReference.isGeographic = spatialReference.isGeographic;
    }
    if (hasValue(spatialReference.isWebMercator)) {
        dotNetSpatialReference.isWebMercator = spatialReference.isWebMercator;
    }
    if (hasValue(spatialReference.isWGS84)) {
        dotNetSpatialReference.isWGS84 = spatialReference.isWGS84;
    }
    if (hasValue(spatialReference.isWrappable)) {
        dotNetSpatialReference.isWrappable = spatialReference.isWrappable;
    }
    if (hasValue(spatialReference.imageCoordinateSystem)) {
        dotNetSpatialReference.imageCoordinateSystem = spatialReference.imageCoordinateSystem;
    }

    dotNetSpatialReference.id = lookupGeoBlazorId(spatialReference);
    
    return dotNetSpatialReference;
}

export function buildJsSpatialReference(dotNetObject): SpatialReference | null {
    if (!hasValue(dotNetObject)) {
        return null;
    }
    let jsSpatialReference = new SpatialReference();

    if (hasValue(dotNetObject.imageCoordinateSystem)) {
        jsSpatialReference.imageCoordinateSystem = dotNetObject.imageCoordinateSystem;
    }
    if (hasValue(dotNetObject.wkid)) {
        jsSpatialReference.wkid = dotNetObject.wkid;
    }
    if (hasValue(dotNetObject.wkt)) {
        jsSpatialReference.wkt = dotNetObject.wkt;
    }
    if (hasValue(dotNetObject.wkt2)) {
        jsSpatialReference.wkt2 = dotNetObject.wkt2;
    }

    jsObjectRefs[dotNetObject.id] = jsSpatialReference;
    arcGisObjectRefs[dotNetObject.id] = jsSpatialReference;

    return jsSpatialReference;
}
