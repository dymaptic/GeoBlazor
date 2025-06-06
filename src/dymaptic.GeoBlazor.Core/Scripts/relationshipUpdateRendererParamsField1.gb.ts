// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetRelationshipUpdateRendererParamsField1 } from './relationshipUpdateRendererParamsField1';

export async function buildJsRelationshipUpdateRendererParamsField1Generated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsrelationshipUpdateRendererParamsField1: any = {};
    if (hasValue(dotNetObject.classBreakInfos) && dotNetObject.classBreakInfos.length > 0) {
        let { buildJsClassBreak } = await import('./classBreak');
        jsrelationshipUpdateRendererParamsField1.classBreakInfos = await Promise.all(dotNetObject.classBreakInfos.map(async i => await buildJsClassBreak(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.field)) {
        jsrelationshipUpdateRendererParamsField1.field = dotNetObject.field;
    }
    if (hasValue(dotNetObject.label)) {
        jsrelationshipUpdateRendererParamsField1.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.normalizationField)) {
        jsrelationshipUpdateRendererParamsField1.normalizationField = dotNetObject.normalizationField;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsrelationshipUpdateRendererParamsField1);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsrelationshipUpdateRendererParamsField1;
    
    return jsrelationshipUpdateRendererParamsField1;
}


export async function buildDotNetRelationshipUpdateRendererParamsField1Generated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetRelationshipUpdateRendererParamsField1: any = {};
    
    if (hasValue(jsObject.classBreakInfos)) {
        let { buildDotNetClassBreak } = await import('./classBreak');
        dotNetRelationshipUpdateRendererParamsField1.classBreakInfos = await Promise.all(jsObject.classBreakInfos.map(async i => await buildDotNetClassBreak(i, layerId, viewId)));
    }
    
    if (hasValue(jsObject.field)) {
        dotNetRelationshipUpdateRendererParamsField1.field = jsObject.field;
    }
    
    if (hasValue(jsObject.label)) {
        dotNetRelationshipUpdateRendererParamsField1.label = jsObject.label;
    }
    
    if (hasValue(jsObject.normalizationField)) {
        dotNetRelationshipUpdateRendererParamsField1.normalizationField = jsObject.normalizationField;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetRelationshipUpdateRendererParamsField1.id = geoBlazorId;
    }

    return dotNetRelationshipUpdateRendererParamsField1;
}

