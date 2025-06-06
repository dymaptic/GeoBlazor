// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import SearchLayer from '@arcgis/core/webdoc/applicationProperties/SearchLayer';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetSearchLayer } from './searchLayer';

export async function buildJsSearchLayerGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.field)) {
        let { buildJsSearchLayerField } = await import('./searchLayerField');
        properties.field = await buildJsSearchLayerField(dotNetObject.field, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.searchLayerId)) {
        properties.id = dotNetObject.searchLayerId;
    }
    if (hasValue(dotNetObject.subLayer)) {
        properties.subLayer = dotNetObject.subLayer;
    }
    let jsSearchLayer = new SearchLayer(properties);
    
    jsObjectRefs[dotNetObject.id] = jsSearchLayer;
    arcGisObjectRefs[dotNetObject.id] = jsSearchLayer;
    
    return jsSearchLayer;
}


export async function buildDotNetSearchLayerGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSearchLayer: any = {};
    
    if (hasValue(jsObject.field)) {
        let { buildDotNetSearchLayerField } = await import('./searchLayerField');
        dotNetSearchLayer.field = await buildDotNetSearchLayerField(jsObject.field, layerId, viewId);
    }
    
    if (hasValue(jsObject.id)) {
        dotNetSearchLayer.searchLayerId = jsObject.id;
    }
    
    if (hasValue(jsObject.subLayer)) {
        dotNetSearchLayer.subLayer = jsObject.subLayer;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetSearchLayer.id = geoBlazorId;
    }

    return dotNetSearchLayer;
}

