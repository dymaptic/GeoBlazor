// override generated code in this file
import SpatialReferenceGenerated from './spatialReference.gb';
import SpatialReference from '@arcgis/core/geometry/SpatialReference';
import {hasValue} from "./jsBuilder";

export default class SpatialReferenceWrapper extends SpatialReferenceGenerated {

    constructor(component: SpatialReference) {
        super(component);
    }
    
}

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

export async function buildJsSpatialReference(dotNetSpatialReference, layerId: string | null, viewId: string | null): Promise<SpatialReference> {
    let { buildJsSpatialReferenceGenerated } = await import('./spatialReference.gb');
    return await buildJsSpatialReferenceGenerated(dotNetSpatialReference, layerId, viewId);
}