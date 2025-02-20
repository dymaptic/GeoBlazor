import {buildDotNetRasterFunctionUtilsTableParameters} from './rasterFunctionUtilsTableParameters';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsRasterFunctionUtilsTableParametersGenerated(dotNetObject: any): Promise<any> {
    let jsrasterFunctionUtilsTableParameters: any = {}
    if (hasValue(dotNetObject.attributeTable)) {
        let {buildJsFeatureSet} = await import('./featureSet');
        jsrasterFunctionUtilsTableParameters.attributeTable = buildJsFeatureSet(dotNetObject.attributeTable) as any;
    }

    if (hasValue(dotNetObject.outputPixelType)) {
        jsrasterFunctionUtilsTableParameters.outputPixelType = dotNetObject.outputPixelType;
    }
    if (hasValue(dotNetObject.raster)) {
        jsrasterFunctionUtilsTableParameters.raster = dotNetObject.raster;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsrasterFunctionUtilsTableParameters);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsrasterFunctionUtilsTableParameters;

    let dnInstantiatedObject = await buildDotNetRasterFunctionUtilsTableParameters(jsrasterFunctionUtilsTableParameters);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for RasterFunctionUtilsTableParameters', e);
    }

    return jsrasterFunctionUtilsTableParameters;
}

export async function buildDotNetRasterFunctionUtilsTableParametersGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetRasterFunctionUtilsTableParameters: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.attributeTable)) {
        let {buildDotNetFeatureSet} = await import('./featureSet');
        dotNetRasterFunctionUtilsTableParameters.attributeTable = await buildDotNetFeatureSet(jsObject.attributeTable, layerId, viewId);
    }
    if (hasValue(jsObject.outputPixelType)) {
        dotNetRasterFunctionUtilsTableParameters.outputPixelType = jsObject.outputPixelType;
    }
    if (hasValue(jsObject.raster)) {
        dotNetRasterFunctionUtilsTableParameters.raster = jsObject.raster;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetRasterFunctionUtilsTableParameters.id = k;
                break;
            }
        }
    }

    return dotNetRasterFunctionUtilsTableParameters;
}

