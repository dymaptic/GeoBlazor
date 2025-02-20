import {buildDotNetRasterFunctionUtilsClipParameters} from './rasterFunctionUtilsClipParameters';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsRasterFunctionUtilsClipParametersGenerated(dotNetObject: any): Promise<any> {
    let jsrasterFunctionUtilsClipParameters: any = {}
    if (hasValue(dotNetObject.geometry)) {
        let {buildJsGeometry} = await import('./geometry');
        jsrasterFunctionUtilsClipParameters.geometry = buildJsGeometry(dotNetObject.geometry) as any;
    }

    if (hasValue(dotNetObject.keepOutside)) {
        jsrasterFunctionUtilsClipParameters.keepOutside = dotNetObject.keepOutside;
    }
    if (hasValue(dotNetObject.outputPixelType)) {
        jsrasterFunctionUtilsClipParameters.outputPixelType = dotNetObject.outputPixelType;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsrasterFunctionUtilsClipParameters);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsrasterFunctionUtilsClipParameters;

    let dnInstantiatedObject = await buildDotNetRasterFunctionUtilsClipParameters(jsrasterFunctionUtilsClipParameters);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for RasterFunctionUtilsClipParameters', e);
    }

    return jsrasterFunctionUtilsClipParameters;
}

export async function buildDotNetRasterFunctionUtilsClipParametersGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetRasterFunctionUtilsClipParameters: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.geometry)) {
        let {buildDotNetGeometry} = await import('./geometry');
        dotNetRasterFunctionUtilsClipParameters.geometry = buildDotNetGeometry(jsObject.geometry);
    }
    if (hasValue(jsObject.keepOutside)) {
        dotNetRasterFunctionUtilsClipParameters.keepOutside = jsObject.keepOutside;
    }
    if (hasValue(jsObject.outputPixelType)) {
        dotNetRasterFunctionUtilsClipParameters.outputPixelType = jsObject.outputPixelType;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetRasterFunctionUtilsClipParameters.id = k;
                break;
            }
        }
    }

    return dotNetRasterFunctionUtilsClipParameters;
}

