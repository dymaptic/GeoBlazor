// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetCapabilitiesQueryRelated } from './capabilitiesQueryRelated';

export async function buildJsCapabilitiesQueryRelatedGenerated(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsCapabilitiesQueryRelated: any = {};

    if (hasValue(dotNetObject.supportsCacheHint)) {
        jsCapabilitiesQueryRelated.supportsCacheHint = dotNetObject.supportsCacheHint;
    }
    if (hasValue(dotNetObject.supportsCount)) {
        jsCapabilitiesQueryRelated.supportsCount = dotNetObject.supportsCount;
    }
    if (hasValue(dotNetObject.supportsOrderBy)) {
        jsCapabilitiesQueryRelated.supportsOrderBy = dotNetObject.supportsOrderBy;
    }
    if (hasValue(dotNetObject.supportsPagination)) {
        jsCapabilitiesQueryRelated.supportsPagination = dotNetObject.supportsPagination;
    }
    
    jsObjectRefs[dotNetObject.id] = jsCapabilitiesQueryRelated;
    arcGisObjectRefs[dotNetObject.id] = jsCapabilitiesQueryRelated;
    
    return jsCapabilitiesQueryRelated;
}


export async function buildDotNetCapabilitiesQueryRelatedGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetCapabilitiesQueryRelated: any = {};
    
    if (hasValue(jsObject.supportsCacheHint)) {
        dotNetCapabilitiesQueryRelated.supportsCacheHint = jsObject.supportsCacheHint;
    }
    
    if (hasValue(jsObject.supportsCount)) {
        dotNetCapabilitiesQueryRelated.supportsCount = jsObject.supportsCount;
    }
    
    if (hasValue(jsObject.supportsOrderBy)) {
        dotNetCapabilitiesQueryRelated.supportsOrderBy = jsObject.supportsOrderBy;
    }
    
    if (hasValue(jsObject.supportsPagination)) {
        dotNetCapabilitiesQueryRelated.supportsPagination = jsObject.supportsPagination;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetCapabilitiesQueryRelated.id = geoBlazorId;
    }

    return dotNetCapabilitiesQueryRelated;
}

