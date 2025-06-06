// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo } from './knowledgeGraphSublayerElevationInfoFeatureExpressionInfo';

export async function buildJsKnowledgeGraphSublayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo: any = {};

    if (hasValue(dotNetObject.expression)) {
        jsKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo.expression = dotNetObject.expression;
    }
    if (hasValue(dotNetObject.title)) {
        jsKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo.title = dotNetObject.title;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo;
    
    return jsKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo;
}


export async function buildDotNetKnowledgeGraphSublayerElevationInfoFeatureExpressionInfoGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo: any = {};
    
    if (hasValue(jsObject.expression)) {
        dotNetKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo.expression = jsObject.expression;
    }
    
    if (hasValue(jsObject.title)) {
        dotNetKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo.title = jsObject.title;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo.id = geoBlazorId;
    }

    return dotNetKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo;
}

