// override generated code in this file
import SpatialReference from '@arcgis/core/geometry/SpatialReference';
import {arcGisObjectRefs, jsObjectRefs, hasValue} from "./arcGisJsInterop";


export function buildDotNetSpatialReference(spatialReference: SpatialReference) {
    if (spatialReference === undefined || spatialReference === null) return null;

    return {
        isGeographic: spatialReference.isGeographic,
        isWebMercator: spatialReference.isWebMercator,
        isWgs84: spatialReference.isWGS84,
        isWrappable: spatialReference.isWrappable,
        wkid: spatialReference.wkid,
        wkt: spatialReference.wkt,
        wkt2: spatialReference.wkt2,
        imageCoordinateSystem: spatialReference.imageCoordinateSystem
    };
}

export function buildJsSpatialReference(dotNetObject): SpatialReference {
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
