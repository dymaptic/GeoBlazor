// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetFeatureLayerBaseElevationInfoFeatureExpressionInfo } from './featureLayerBaseElevationInfoFeatureExpressionInfo';

export async function buildJsFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsFeatureLayerBaseElevationInfoFeatureExpressionInfo: any = {};

    if (hasValue(dotNetObject.expression)) {
        jsFeatureLayerBaseElevationInfoFeatureExpressionInfo.expression = dotNetObject.expression;
    }
    if (hasValue(dotNetObject.title)) {
        jsFeatureLayerBaseElevationInfoFeatureExpressionInfo.title = dotNetObject.title;
    }
    
    jsObjectRefs[dotNetObject.id] = jsFeatureLayerBaseElevationInfoFeatureExpressionInfo;
    arcGisObjectRefs[dotNetObject.id] = jsFeatureLayerBaseElevationInfoFeatureExpressionInfo;
    
    return jsFeatureLayerBaseElevationInfoFeatureExpressionInfo;
}


export async function buildDotNetFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetFeatureLayerBaseElevationInfoFeatureExpressionInfo: any = {};
    
    if (hasValue(jsObject.expression)) {
        dotNetFeatureLayerBaseElevationInfoFeatureExpressionInfo.expression = jsObject.expression;
    }
    
    if (hasValue(jsObject.title)) {
        dotNetFeatureLayerBaseElevationInfoFeatureExpressionInfo.title = jsObject.title;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetFeatureLayerBaseElevationInfoFeatureExpressionInfo.id = geoBlazorId;
    }

    return dotNetFeatureLayerBaseElevationInfoFeatureExpressionInfo;
}

