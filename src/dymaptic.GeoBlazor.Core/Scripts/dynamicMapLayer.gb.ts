// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetDynamicMapLayer } from './dynamicMapLayer';

export async function buildJsDynamicMapLayerGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsDynamicMapLayer: any = {};

    if (hasValue(dotNetObject.gdbVersion)) {
        jsDynamicMapLayer.gdbVersion = dotNetObject.gdbVersion;
    }
    if (hasValue(dotNetObject.mapLayerId)) {
        jsDynamicMapLayer.mapLayerId = dotNetObject.mapLayerId;
    }
    
    jsObjectRefs[dotNetObject.id] = jsDynamicMapLayer;
    arcGisObjectRefs[dotNetObject.id] = jsDynamicMapLayer;
    
    return jsDynamicMapLayer;
}


export async function buildDotNetDynamicMapLayerGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetDynamicMapLayer: any = {};
    
    if (hasValue(jsObject.gdbVersion)) {
        dotNetDynamicMapLayer.gdbVersion = jsObject.gdbVersion;
    }
    
    if (hasValue(jsObject.mapLayerId)) {
        dotNetDynamicMapLayer.mapLayerId = jsObject.mapLayerId;
    }
    
    if (hasValue(jsObject.type)) {
        dotNetDynamicMapLayer.type = jsObject.type;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetDynamicMapLayer.id = geoBlazorId;
    }

    return dotNetDynamicMapLayer;
}

