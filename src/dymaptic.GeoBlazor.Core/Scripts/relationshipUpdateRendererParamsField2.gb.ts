// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetRelationshipUpdateRendererParamsField2 } from './relationshipUpdateRendererParamsField2';

export async function buildJsRelationshipUpdateRendererParamsField2Generated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsrelationshipUpdateRendererParamsField2: any = {};
    if (hasValue(dotNetObject.classBreakInfos) && dotNetObject.classBreakInfos.length > 0) {
        let { buildJsClassBreak } = await import('./classBreak');
        jsrelationshipUpdateRendererParamsField2.classBreakInfos = await Promise.all(dotNetObject.classBreakInfos.map(async i => await buildJsClassBreak(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.field)) {
        jsrelationshipUpdateRendererParamsField2.field = dotNetObject.field;
    }
    if (hasValue(dotNetObject.label)) {
        jsrelationshipUpdateRendererParamsField2.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.normalizationField)) {
        jsrelationshipUpdateRendererParamsField2.normalizationField = dotNetObject.normalizationField;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsrelationshipUpdateRendererParamsField2);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsrelationshipUpdateRendererParamsField2;
    
    return jsrelationshipUpdateRendererParamsField2;
}


export async function buildDotNetRelationshipUpdateRendererParamsField2Generated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetRelationshipUpdateRendererParamsField2: any = {};
    
    if (hasValue(jsObject.classBreakInfos)) {
        let { buildDotNetClassBreak } = await import('./classBreak');
        dotNetRelationshipUpdateRendererParamsField2.classBreakInfos = await Promise.all(jsObject.classBreakInfos.map(async i => await buildDotNetClassBreak(i, layerId, viewId)));
    }
    
    if (hasValue(jsObject.field)) {
        dotNetRelationshipUpdateRendererParamsField2.field = jsObject.field;
    }
    
    if (hasValue(jsObject.label)) {
        dotNetRelationshipUpdateRendererParamsField2.label = jsObject.label;
    }
    
    if (hasValue(jsObject.normalizationField)) {
        dotNetRelationshipUpdateRendererParamsField2.normalizationField = jsObject.normalizationField;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetRelationshipUpdateRendererParamsField2.id = geoBlazorId;
    }

    return dotNetRelationshipUpdateRendererParamsField2;
}

