import {buildDotNetSymbolUtilsGetLegendLabelOptions} from './symbolUtilsGetLegendLabelOptions';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSymbolUtilsGetLegendLabelOptionsGenerated(dotNetObject: any): Promise<any> {
    let jssymbolUtilsGetLegendLabelOptions: any = {}
    if (hasValue(dotNetObject.renderer)) {
        let {buildJsRenderer} = await import('./renderer');
        jssymbolUtilsGetLegendLabelOptions.renderer = await buildJsRenderer(dotNetObject.renderer, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.spatialReference)) {
        let {buildJsSpatialReference} = await import('./spatialReference');
        jssymbolUtilsGetLegendLabelOptions.spatialReference = buildJsSpatialReference(dotNetObject.spatialReference) as any;
    }

    if (hasValue(dotNetObject.resolution)) {
        jssymbolUtilsGetLegendLabelOptions.resolution = dotNetObject.resolution;
    }
    if (hasValue(dotNetObject.scale)) {
        jssymbolUtilsGetLegendLabelOptions.scale = dotNetObject.scale;
    }
    if (hasValue(dotNetObject.viewingMode)) {
        jssymbolUtilsGetLegendLabelOptions.viewingMode = dotNetObject.viewingMode;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jssymbolUtilsGetLegendLabelOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jssymbolUtilsGetLegendLabelOptions;

    let dnInstantiatedObject = await buildDotNetSymbolUtilsGetLegendLabelOptions(jssymbolUtilsGetLegendLabelOptions);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SymbolUtilsGetLegendLabelOptions', e);
    }

    return jssymbolUtilsGetLegendLabelOptions;
}

export async function buildDotNetSymbolUtilsGetLegendLabelOptionsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSymbolUtilsGetLegendLabelOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetRenderer} = await import('./renderer');
        dotNetSymbolUtilsGetLegendLabelOptions.renderer = await buildDotNetRenderer(jsObject.renderer);
    }
    if (hasValue(jsObject.spatialReference)) {
        let {buildDotNetSpatialReference} = await import('./spatialReference');
        dotNetSymbolUtilsGetLegendLabelOptions.spatialReference = buildDotNetSpatialReference(jsObject.spatialReference);
    }
    if (hasValue(jsObject.resolution)) {
        dotNetSymbolUtilsGetLegendLabelOptions.resolution = jsObject.resolution;
    }
    if (hasValue(jsObject.scale)) {
        dotNetSymbolUtilsGetLegendLabelOptions.scale = jsObject.scale;
    }
    if (hasValue(jsObject.viewingMode)) {
        dotNetSymbolUtilsGetLegendLabelOptions.viewingMode = jsObject.viewingMode;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSymbolUtilsGetLegendLabelOptions.id = k;
                break;
            }
        }
    }

    return dotNetSymbolUtilsGetLegendLabelOptions;
}

