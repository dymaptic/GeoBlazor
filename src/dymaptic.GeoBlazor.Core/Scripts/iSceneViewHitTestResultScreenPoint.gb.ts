// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetISceneViewHitTestResultScreenPoint } from './iSceneViewHitTestResultScreenPoint';

export async function buildJsISceneViewHitTestResultScreenPointGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsSceneViewHitTestResultScreenPoint: any = {};

    
    let jsObjectRef = DotNet.createJSObjectReference(jsSceneViewHitTestResultScreenPoint);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSceneViewHitTestResultScreenPoint;
    
    return jsSceneViewHitTestResultScreenPoint;
}


export async function buildDotNetISceneViewHitTestResultScreenPointGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetISceneViewHitTestResultScreenPoint: any = {};
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetISceneViewHitTestResultScreenPoint.id = geoBlazorId;
    }

    return dotNetISceneViewHitTestResultScreenPoint;
}

