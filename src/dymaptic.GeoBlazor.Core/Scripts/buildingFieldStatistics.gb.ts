// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetBuildingFieldStatistics } from './buildingFieldStatistics';

export async function buildJsBuildingFieldStatisticsGenerated(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsBuildingFieldStatistics: any = {};

    if (hasValue(dotNetObject.fieldName)) {
        jsBuildingFieldStatistics.fieldName = dotNetObject.fieldName;
    }
    if (hasValue(dotNetObject.label)) {
        jsBuildingFieldStatistics.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.max)) {
        jsBuildingFieldStatistics.max = dotNetObject.max;
    }
    if (hasValue(dotNetObject.min)) {
        jsBuildingFieldStatistics.min = dotNetObject.min;
    }
    if (hasValue(dotNetObject.modelName)) {
        jsBuildingFieldStatistics.modelName = dotNetObject.modelName;
    }
    if (hasValue(dotNetObject.mostFrequentValues) && dotNetObject.mostFrequentValues.length > 0) {
        jsBuildingFieldStatistics.mostFrequentValues = dotNetObject.mostFrequentValues;
    }
    if (hasValue(dotNetObject.subLayerIds) && dotNetObject.subLayerIds.length > 0) {
        jsBuildingFieldStatistics.subLayerIds = dotNetObject.subLayerIds;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsBuildingFieldStatistics);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBuildingFieldStatistics;
    
    return jsBuildingFieldStatistics;
}


export async function buildDotNetBuildingFieldStatisticsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetBuildingFieldStatistics: any = {};
    
    if (hasValue(jsObject.fieldName)) {
        dotNetBuildingFieldStatistics.fieldName = jsObject.fieldName;
    }
    
    if (hasValue(jsObject.label)) {
        dotNetBuildingFieldStatistics.label = jsObject.label;
    }
    
    if (hasValue(jsObject.max)) {
        dotNetBuildingFieldStatistics.max = jsObject.max;
    }
    
    if (hasValue(jsObject.min)) {
        dotNetBuildingFieldStatistics.min = jsObject.min;
    }
    
    if (hasValue(jsObject.modelName)) {
        dotNetBuildingFieldStatistics.modelName = jsObject.modelName;
    }
    
    if (hasValue(jsObject.mostFrequentValues)) {
        dotNetBuildingFieldStatistics.mostFrequentValues = jsObject.mostFrequentValues;
    }
    
    if (hasValue(jsObject.subLayerIds)) {
        dotNetBuildingFieldStatistics.subLayerIds = jsObject.subLayerIds;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetBuildingFieldStatistics.id = geoBlazorId;
    }

    return dotNetBuildingFieldStatistics;
}

