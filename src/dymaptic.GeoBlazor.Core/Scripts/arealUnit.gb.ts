// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import ArealUnit from '@arcgis/core/rest/support/ArealUnit';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetArealUnit } from './arealUnit';

export async function buildJsArealUnitGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};

    if (hasValue(dotNetObject.area)) {
        properties.area = dotNetObject.area;
    }
    if (hasValue(dotNetObject.units)) {
        properties.units = dotNetObject.units;
    }
    let jsArealUnit = new ArealUnit(properties);
    
    let jsObjectRef = DotNet.createJSObjectReference(jsArealUnit);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsArealUnit;
    
    return jsArealUnit;
}


export async function buildDotNetArealUnitGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetArealUnit: any = {};
    
    if (hasValue(jsObject.area)) {
        dotNetArealUnit.area = jsObject.area;
    }
    
    if (hasValue(jsObject.units)) {
        dotNetArealUnit.units = removeCircularReferences(jsObject.units);
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetArealUnit.id = geoBlazorId;
    }

    return dotNetArealUnit;
}

