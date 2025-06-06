// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetBin } from './bin';

export async function buildJsBinGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsBin: any = {};

    if (hasValue(dotNetObject.count)) {
        jsBin.count = dotNetObject.count;
    }
    if (hasValue(dotNetObject.maxValue)) {
        jsBin.maxValue = dotNetObject.maxValue;
    }
    if (hasValue(dotNetObject.minValue)) {
        jsBin.minValue = dotNetObject.minValue;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsBin);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBin;
    
    return jsBin;
}


export async function buildDotNetBinGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetBin: any = {};
    
    if (hasValue(jsObject.count)) {
        dotNetBin.count = jsObject.count;
    }
    
    if (hasValue(jsObject.maxValue)) {
        dotNetBin.maxValue = jsObject.maxValue;
    }
    
    if (hasValue(jsObject.minValue)) {
        dotNetBin.minValue = jsObject.minValue;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetBin.id = geoBlazorId;
    }

    return dotNetBin;
}

