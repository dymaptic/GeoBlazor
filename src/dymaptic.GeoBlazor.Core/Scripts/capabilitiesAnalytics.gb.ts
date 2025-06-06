// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetCapabilitiesAnalytics } from './capabilitiesAnalytics';

export async function buildJsCapabilitiesAnalyticsGenerated(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsCapabilitiesAnalytics: any = {};

    if (hasValue(dotNetObject.supportsCacheHint)) {
        jsCapabilitiesAnalytics.supportsCacheHint = dotNetObject.supportsCacheHint;
    }
    
    jsObjectRefs[dotNetObject.id] = jsCapabilitiesAnalytics;
    arcGisObjectRefs[dotNetObject.id] = jsCapabilitiesAnalytics;
    
    return jsCapabilitiesAnalytics;
}


export async function buildDotNetCapabilitiesAnalyticsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetCapabilitiesAnalytics: any = {};
    
    if (hasValue(jsObject.supportsCacheHint)) {
        dotNetCapabilitiesAnalytics.supportsCacheHint = jsObject.supportsCacheHint;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetCapabilitiesAnalytics.id = geoBlazorId;
    }

    return dotNetCapabilitiesAnalytics;
}

