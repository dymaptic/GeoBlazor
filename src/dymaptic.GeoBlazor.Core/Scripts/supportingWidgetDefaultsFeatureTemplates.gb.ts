// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetSupportingWidgetDefaultsFeatureTemplates } from './supportingWidgetDefaultsFeatureTemplates';

export async function buildJsSupportingWidgetDefaultsFeatureTemplatesGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsSupportingWidgetDefaultsFeatureTemplates: any = {};
    if (hasValue(dotNetObject.visibleElements)) {
        let { buildJsSupportingWidgetDefaultsFeatureTemplatesVisibleElements } = await import('./supportingWidgetDefaultsFeatureTemplatesVisibleElements');
        jsSupportingWidgetDefaultsFeatureTemplates.visibleElements = await buildJsSupportingWidgetDefaultsFeatureTemplatesVisibleElements(dotNetObject.visibleElements, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.enableListScroll)) {
        jsSupportingWidgetDefaultsFeatureTemplates.enableListScroll = dotNetObject.enableListScroll;
    }
    if (hasValue(dotNetObject.groupBy)) {
        jsSupportingWidgetDefaultsFeatureTemplates.groupBy = dotNetObject.groupBy;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsSupportingWidgetDefaultsFeatureTemplates);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSupportingWidgetDefaultsFeatureTemplates;
    
    return jsSupportingWidgetDefaultsFeatureTemplates;
}


export async function buildDotNetSupportingWidgetDefaultsFeatureTemplatesGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSupportingWidgetDefaultsFeatureTemplates: any = {};
    
    if (hasValue(jsObject.visibleElements)) {
        let { buildDotNetSupportingWidgetDefaultsFeatureTemplatesVisibleElements } = await import('./supportingWidgetDefaultsFeatureTemplatesVisibleElements');
        dotNetSupportingWidgetDefaultsFeatureTemplates.visibleElements = await buildDotNetSupportingWidgetDefaultsFeatureTemplatesVisibleElements(jsObject.visibleElements, layerId, viewId);
    }
    
    if (hasValue(jsObject.enableListScroll)) {
        dotNetSupportingWidgetDefaultsFeatureTemplates.enableListScroll = jsObject.enableListScroll;
    }
    
    if (hasValue(jsObject.groupBy)) {
        dotNetSupportingWidgetDefaultsFeatureTemplates.groupBy = jsObject.groupBy;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetSupportingWidgetDefaultsFeatureTemplates.id = geoBlazorId;
    }

    return dotNetSupportingWidgetDefaultsFeatureTemplates;
}

