// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetHitTestResult } from './hitTestResult';

export async function buildJsHitTestResultGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsHitTestResult: any = {};
    if (hasValue(dotNetObject.screenPoint)) {
        let { buildJsMapViewScreenPoint } = await import('./mapViewScreenPoint');
        jsHitTestResult.screenPoint = await buildJsMapViewScreenPoint(dotNetObject.screenPoint, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.results) && dotNetObject.results.length > 0) {
        jsHitTestResult.results = dotNetObject.results;
    }
    
    jsObjectRefs[dotNetObject.id] = jsHitTestResult;
    arcGisObjectRefs[dotNetObject.id] = jsHitTestResult;
    
    return jsHitTestResult;
}


export async function buildDotNetHitTestResultGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetHitTestResult: any = {};
    
    if (hasValue(jsObject.screenPoint)) {
        let { buildDotNetMapViewScreenPoint } = await import('./mapViewScreenPoint');
        dotNetHitTestResult.screenPoint = await buildDotNetMapViewScreenPoint(jsObject.screenPoint, layerId, viewId);
    }
    
    if (hasValue(jsObject.results)) {
        dotNetHitTestResult.results = removeCircularReferences(jsObject.results);
    }
    

    return dotNetHitTestResult;
}

