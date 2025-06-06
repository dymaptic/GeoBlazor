// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetBasemapView } from './basemapView';

export async function buildJsBasemapViewGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsBasemapView: any = {};
    if (hasValue(viewId)) {
        jsBasemapView.view = arcGisObjectRefs[viewId!];
    }

    
    let jsObjectRef = DotNet.createJSObjectReference(jsBasemapView);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBasemapView;
    
    return jsBasemapView;
}


export async function buildDotNetBasemapViewGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetBasemapView: any = {};
    
    if (hasValue(jsObject.baseLayerViews)) {
        let { buildDotNetLayerView } = await import('./layerView');
        dotNetBasemapView.baseLayerViews = await Promise.all(jsObject.baseLayerViews.map(async i => await buildDotNetLayerView(i)));
    }
    
    if (hasValue(jsObject.referenceLayerViews)) {
        let { buildDotNetLayerView } = await import('./layerView');
        dotNetBasemapView.referenceLayerViews = await Promise.all(jsObject.referenceLayerViews.map(async i => await buildDotNetLayerView(i)));
    }
    
    if (hasValue(jsObject.updating)) {
        dotNetBasemapView.updating = jsObject.updating;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetBasemapView.id = geoBlazorId;
    }

    return dotNetBasemapView;
}

