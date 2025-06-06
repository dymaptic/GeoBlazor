// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import OrderByInfo from '@arcgis/core/layers/support/OrderByInfo';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetOrderByInfo } from './orderByInfo';

export async function buildJsOrderByInfoGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};

    if (hasValue(dotNetObject.field)) {
        properties.field = dotNetObject.field;
    }
    if (hasValue(dotNetObject.order)) {
        properties.order = dotNetObject.order;
    }
    if (hasValue(dotNetObject.valueExpression)) {
        properties.valueExpression = dotNetObject.valueExpression;
    }
    let jsOrderByInfo = new OrderByInfo(properties);
    
    jsObjectRefs[dotNetObject.id] = jsOrderByInfo;
    arcGisObjectRefs[dotNetObject.id] = jsOrderByInfo;
    
    return jsOrderByInfo;
}


export async function buildDotNetOrderByInfoGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetOrderByInfo: any = {};
    
    if (hasValue(jsObject.field)) {
        dotNetOrderByInfo.field = jsObject.field;
    }
    
    if (hasValue(jsObject.order)) {
        dotNetOrderByInfo.order = removeCircularReferences(jsObject.order);
    }
    
    if (hasValue(jsObject.valueExpression)) {
        dotNetOrderByInfo.valueExpression = jsObject.valueExpression;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetOrderByInfo.id = geoBlazorId;
    }

    return dotNetOrderByInfo;
}

