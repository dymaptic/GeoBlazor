// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetElevationSource } from './elevationSource';

export async function buildJsElevationSourceGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsElevationSource: any = {};

    if (hasValue(dotNetObject.lod)) {
        jsElevationSource.lod = dotNetObject.lod;
    }
    if (hasValue(dotNetObject.rasterFunction)) {
        jsElevationSource.rasterFunction = dotNetObject.rasterFunction;
    }
    if (hasValue(dotNetObject.url)) {
        jsElevationSource.url = dotNetObject.url;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsElevationSource);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsElevationSource;
    
    return jsElevationSource;
}


export async function buildDotNetElevationSourceGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetElevationSource: any = {};
    
    if (hasValue(jsObject.lod)) {
        dotNetElevationSource.lod = jsObject.lod;
    }
    
    if (hasValue(jsObject.rasterFunction)) {
        dotNetElevationSource.rasterFunction = jsObject.rasterFunction;
    }
    
    if (hasValue(jsObject.url)) {
        dotNetElevationSource.url = jsObject.url;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetElevationSource.id = geoBlazorId;
    }

    return dotNetElevationSource;
}

