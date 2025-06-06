// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetQueryQuantizationParameters } from './queryQuantizationParameters';

export async function buildJsQueryQuantizationParametersGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsQueryQuantizationParameters: any = {};
    if (hasValue(dotNetObject.extent)) {
        let { buildJsExtent } = await import('./extent');
        jsQueryQuantizationParameters.extent = buildJsExtent(dotNetObject.extent) as any;
    }

    if (hasValue(dotNetObject.mode)) {
        jsQueryQuantizationParameters.mode = dotNetObject.mode;
    }
    if (hasValue(dotNetObject.originPosition)) {
        jsQueryQuantizationParameters.originPosition = dotNetObject.originPosition;
    }
    if (hasValue(dotNetObject.tolerance)) {
        jsQueryQuantizationParameters.tolerance = dotNetObject.tolerance;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsQueryQuantizationParameters);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsQueryQuantizationParameters;
    
    return jsQueryQuantizationParameters;
}


export async function buildDotNetQueryQuantizationParametersGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetQueryQuantizationParameters: any = {};
    
    if (hasValue(jsObject.extent)) {
        let { buildDotNetExtent } = await import('./extent');
        dotNetQueryQuantizationParameters.extent = buildDotNetExtent(jsObject.extent);
    }
    
    if (hasValue(jsObject.mode)) {
        dotNetQueryQuantizationParameters.mode = removeCircularReferences(jsObject.mode);
    }
    
    if (hasValue(jsObject.originPosition)) {
        dotNetQueryQuantizationParameters.originPosition = removeCircularReferences(jsObject.originPosition);
    }
    
    if (hasValue(jsObject.tolerance)) {
        dotNetQueryQuantizationParameters.tolerance = jsObject.tolerance;
    }
    

    return dotNetQueryQuantizationParameters;
}

