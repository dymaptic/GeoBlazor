// override generated code in this file

import {hasValue, lookupGeoBlazorId} from "./arcGisJsInterop";

export async function buildJsLayerSearchSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLayerSearchSourceGenerated} = await import('./layerSearchSource.gb');
    return await buildJsLayerSearchSourceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLayerSearchSource(jsObject: any): Promise<any> {
    let {buildDotNetLayerSearchSourceGenerated} = await import('./layerSearchSource.gb');
    let dnObject = await buildDotNetLayerSearchSourceGenerated(jsObject);
    
    if (hasValue(jsObject.layer)) {
        dnObject.layerId = lookupGeoBlazorId(jsObject.layer);
    }
    
    return dnObject;
}
