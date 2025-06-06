// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetSceneViewScreenPoint } from './sceneViewScreenPoint';

export async function buildJsSceneViewScreenPointGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsSceneViewScreenPoint: any = {};

    if (hasValue(dotNetObject.x)) {
        jsSceneViewScreenPoint.x = dotNetObject.x;
    }
    if (hasValue(dotNetObject.y)) {
        jsSceneViewScreenPoint.y = dotNetObject.y;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsSceneViewScreenPoint);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSceneViewScreenPoint;
    
    return jsSceneViewScreenPoint;
}


export async function buildDotNetSceneViewScreenPointGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSceneViewScreenPoint: any = {};
    
    if (hasValue(jsObject.x)) {
        dotNetSceneViewScreenPoint.x = jsObject.x;
    }
    
    if (hasValue(jsObject.y)) {
        dotNetSceneViewScreenPoint.y = jsObject.y;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetSceneViewScreenPoint.id = geoBlazorId;
    }

    return dotNetSceneViewScreenPoint;
}

