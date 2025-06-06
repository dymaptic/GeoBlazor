// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetExternalReferencePoint } from './externalReferencePoint';

export async function buildJsExternalReferencePointGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsExternalReferencePoint: any = {};
    if (hasValue(dotNetObject.spatialReference)) {
        let { buildJsExternalReferenceSpatialReference } = await import('./externalReferenceSpatialReference');
        jsExternalReferencePoint.spatialReference = await buildJsExternalReferenceSpatialReference(dotNetObject.spatialReference, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.m)) {
        jsExternalReferencePoint.m = dotNetObject.m;
    }
    if (hasValue(dotNetObject.x)) {
        jsExternalReferencePoint.x = dotNetObject.x;
    }
    if (hasValue(dotNetObject.y)) {
        jsExternalReferencePoint.y = dotNetObject.y;
    }
    if (hasValue(dotNetObject.z)) {
        jsExternalReferencePoint.z = dotNetObject.z;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsExternalReferencePoint);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsExternalReferencePoint;
    
    return jsExternalReferencePoint;
}


export async function buildDotNetExternalReferencePointGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetExternalReferencePoint: any = {};
    
    if (hasValue(jsObject.spatialReference)) {
        let { buildDotNetExternalReferenceSpatialReference } = await import('./externalReferenceSpatialReference');
        dotNetExternalReferencePoint.spatialReference = await buildDotNetExternalReferenceSpatialReference(jsObject.spatialReference, layerId, viewId);
    }
    
    if (hasValue(jsObject.m)) {
        dotNetExternalReferencePoint.m = jsObject.m;
    }
    
    if (hasValue(jsObject.x)) {
        dotNetExternalReferencePoint.x = jsObject.x;
    }
    
    if (hasValue(jsObject.y)) {
        dotNetExternalReferencePoint.y = jsObject.y;
    }
    
    if (hasValue(jsObject.z)) {
        dotNetExternalReferencePoint.z = jsObject.z;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetExternalReferencePoint.id = geoBlazorId;
    }

    return dotNetExternalReferencePoint;
}

