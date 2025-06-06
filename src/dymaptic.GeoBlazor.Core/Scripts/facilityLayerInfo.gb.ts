// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import FacilityLayerInfo from '@arcgis/core/layers/support/FacilityLayerInfo';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetFacilityLayerInfo } from './facilityLayerInfo';

export async function buildJsFacilityLayerInfoGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};

    if (hasValue(dotNetObject.facilityIdField)) {
        properties.facilityIdField = dotNetObject.facilityIdField;
    }
    if (hasValue(dotNetObject.layerId)) {
        properties.layerId = dotNetObject.layerId;
    }
    if (hasValue(dotNetObject.nameField)) {
        properties.nameField = dotNetObject.nameField;
    }
    if (hasValue(dotNetObject.siteIdField)) {
        properties.siteIdField = dotNetObject.siteIdField;
    }
    if (hasValue(dotNetObject.sublayerId)) {
        properties.sublayerId = dotNetObject.sublayerId;
    }
    let jsFacilityLayerInfo = new FacilityLayerInfo(properties);
    
    jsObjectRefs[dotNetObject.id] = jsFacilityLayerInfo;
    arcGisObjectRefs[dotNetObject.id] = jsFacilityLayerInfo;
    
    return jsFacilityLayerInfo;
}


export async function buildDotNetFacilityLayerInfoGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetFacilityLayerInfo: any = {};
    
    if (hasValue(jsObject.facilityIdField)) {
        dotNetFacilityLayerInfo.facilityIdField = jsObject.facilityIdField;
    }
    
    if (hasValue(jsObject.layerId)) {
        dotNetFacilityLayerInfo.layerId = jsObject.layerId;
    }
    
    if (hasValue(jsObject.nameField)) {
        dotNetFacilityLayerInfo.nameField = jsObject.nameField;
    }
    
    if (hasValue(jsObject.siteIdField)) {
        dotNetFacilityLayerInfo.siteIdField = jsObject.siteIdField;
    }
    
    if (hasValue(jsObject.sublayerId)) {
        dotNetFacilityLayerInfo.sublayerId = jsObject.sublayerId;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetFacilityLayerInfo.id = geoBlazorId;
    }

    return dotNetFacilityLayerInfo;
}

