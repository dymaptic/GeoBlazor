// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import SiteLayerInfo from '@arcgis/core/layers/support/SiteLayerInfo';
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetSiteLayerInfo } from './siteLayerInfo';

export async function buildJsSiteLayerInfoGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};

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
    let jsSiteLayerInfo = new SiteLayerInfo(properties);
    
    jsObjectRefs[dotNetObject.id] = jsSiteLayerInfo;
    arcGisObjectRefs[dotNetObject.id] = jsSiteLayerInfo;
    
    return jsSiteLayerInfo;
}


export async function buildDotNetSiteLayerInfoGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSiteLayerInfo: any = {};
    
    if (hasValue(jsObject.layerId)) {
        dotNetSiteLayerInfo.layerId = jsObject.layerId;
    }
    
    if (hasValue(jsObject.nameField)) {
        dotNetSiteLayerInfo.nameField = jsObject.nameField;
    }
    
    if (hasValue(jsObject.siteIdField)) {
        dotNetSiteLayerInfo.siteIdField = jsObject.siteIdField;
    }
    
    if (hasValue(jsObject.sublayerId)) {
        dotNetSiteLayerInfo.sublayerId = jsObject.sublayerId;
    }
    

    return dotNetSiteLayerInfo;
}

