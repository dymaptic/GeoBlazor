// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetFeatureServiceCapabilitiesEditing } from './featureServiceCapabilitiesEditing';

export async function buildJsFeatureServiceCapabilitiesEditingGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsFeatureServiceCapabilitiesEditing: any = {};

    if (hasValue(dotNetObject.supportsAsyncApplyEdits)) {
        jsFeatureServiceCapabilitiesEditing.supportsAsyncApplyEdits = dotNetObject.supportsAsyncApplyEdits;
    }
    if (hasValue(dotNetObject.supportsGlobalId)) {
        jsFeatureServiceCapabilitiesEditing.supportsGlobalId = dotNetObject.supportsGlobalId;
    }
    if (hasValue(dotNetObject.supportsReturnServiceEditsInSourceSpatialReference)) {
        jsFeatureServiceCapabilitiesEditing.supportsReturnServiceEditsInSourceSpatialReference = dotNetObject.supportsReturnServiceEditsInSourceSpatialReference;
    }
    if (hasValue(dotNetObject.supportsSplit)) {
        jsFeatureServiceCapabilitiesEditing.supportsSplit = dotNetObject.supportsSplit;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsFeatureServiceCapabilitiesEditing);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFeatureServiceCapabilitiesEditing;
    
    return jsFeatureServiceCapabilitiesEditing;
}


export async function buildDotNetFeatureServiceCapabilitiesEditingGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetFeatureServiceCapabilitiesEditing: any = {};
    
    if (hasValue(jsObject.supportsAsyncApplyEdits)) {
        dotNetFeatureServiceCapabilitiesEditing.supportsAsyncApplyEdits = jsObject.supportsAsyncApplyEdits;
    }
    
    if (hasValue(jsObject.supportsGlobalId)) {
        dotNetFeatureServiceCapabilitiesEditing.supportsGlobalId = jsObject.supportsGlobalId;
    }
    
    if (hasValue(jsObject.supportsReturnServiceEditsInSourceSpatialReference)) {
        dotNetFeatureServiceCapabilitiesEditing.supportsReturnServiceEditsInSourceSpatialReference = jsObject.supportsReturnServiceEditsInSourceSpatialReference;
    }
    
    if (hasValue(jsObject.supportsSplit)) {
        dotNetFeatureServiceCapabilitiesEditing.supportsSplit = jsObject.supportsSplit;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetFeatureServiceCapabilitiesEditing.id = geoBlazorId;
    }

    return dotNetFeatureServiceCapabilitiesEditing;
}

