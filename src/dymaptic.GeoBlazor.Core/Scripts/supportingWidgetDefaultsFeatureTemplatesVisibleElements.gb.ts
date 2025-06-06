// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetSupportingWidgetDefaultsFeatureTemplatesVisibleElements } from './supportingWidgetDefaultsFeatureTemplatesVisibleElements';

export async function buildJsSupportingWidgetDefaultsFeatureTemplatesVisibleElementsGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsSupportingWidgetDefaultsFeatureTemplatesVisibleElements: any = {};

    if (hasValue(dotNetObject.filter)) {
        jsSupportingWidgetDefaultsFeatureTemplatesVisibleElements.filter = dotNetObject.filter;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsSupportingWidgetDefaultsFeatureTemplatesVisibleElements);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSupportingWidgetDefaultsFeatureTemplatesVisibleElements;
    
    return jsSupportingWidgetDefaultsFeatureTemplatesVisibleElements;
}


export async function buildDotNetSupportingWidgetDefaultsFeatureTemplatesVisibleElementsGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSupportingWidgetDefaultsFeatureTemplatesVisibleElements: any = {};
    
    if (hasValue(jsObject.filter)) {
        dotNetSupportingWidgetDefaultsFeatureTemplatesVisibleElements.filter = jsObject.filter;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetSupportingWidgetDefaultsFeatureTemplatesVisibleElements.id = geoBlazorId;
    }

    return dotNetSupportingWidgetDefaultsFeatureTemplatesVisibleElements;
}

