import {buildDotNetSizeUpdateRendererWithReferenceSizeParams} from './sizeUpdateRendererWithReferenceSizeParams';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSizeUpdateRendererWithReferenceSizeParamsGenerated(dotNetObject: any): Promise<any> {
    let jssizeUpdateRendererWithReferenceSizeParams: any = {}
    if (hasValue(dotNetObject.layer)) {
        let {buildJsLayer} = await import('./layer');
        jssizeUpdateRendererWithReferenceSizeParams.layer = await buildJsLayer(dotNetObject.layer, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.renderer)) {
        let {buildJsRenderer} = await import('./renderer');
        jssizeUpdateRendererWithReferenceSizeParams.renderer = await buildJsRenderer(dotNetObject.renderer, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.field)) {
        jssizeUpdateRendererWithReferenceSizeParams.field = dotNetObject.field;
    }
    if (hasValue(dotNetObject.forBinning)) {
        jssizeUpdateRendererWithReferenceSizeParams.forBinning = dotNetObject.forBinning;
    }
    if (hasValue(dotNetObject.normalizationField)) {
        jssizeUpdateRendererWithReferenceSizeParams.normalizationField = dotNetObject.normalizationField;
    }
    if (hasValue(dotNetObject.referenceSizeOptions)) {
        jssizeUpdateRendererWithReferenceSizeParams.referenceSizeOptions = dotNetObject.referenceSizeOptions;
    }
    if (hasValue(dotNetObject.sizeOptimizationEnabled)) {
        jssizeUpdateRendererWithReferenceSizeParams.sizeOptimizationEnabled = dotNetObject.sizeOptimizationEnabled;
    }
    if (hasValue(dotNetObject.sizeScheme)) {
        jssizeUpdateRendererWithReferenceSizeParams.sizeScheme = dotNetObject.sizeScheme;
    }
    if (hasValue(dotNetObject.sizeStops)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedSizeStops} = dotNetObject.sizeStops;
        jssizeUpdateRendererWithReferenceSizeParams.sizeStops = sanitizedSizeStops;
    }
    if (hasValue(dotNetObject.typeScheme)) {
        jssizeUpdateRendererWithReferenceSizeParams.typeScheme = dotNetObject.typeScheme;
    }
    if (hasValue(dotNetObject.view)) {
        jssizeUpdateRendererWithReferenceSizeParams.view = dotNetObject.view;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jssizeUpdateRendererWithReferenceSizeParams);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jssizeUpdateRendererWithReferenceSizeParams;

    let dnInstantiatedObject = await buildDotNetSizeUpdateRendererWithReferenceSizeParams(jssizeUpdateRendererWithReferenceSizeParams);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SizeUpdateRendererWithReferenceSizeParams', e);
    }

    return jssizeUpdateRendererWithReferenceSizeParams;
}

export async function buildDotNetSizeUpdateRendererWithReferenceSizeParamsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSizeUpdateRendererWithReferenceSizeParams: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetRenderer} = await import('./renderer');
        dotNetSizeUpdateRendererWithReferenceSizeParams.renderer = await buildDotNetRenderer(jsObject.renderer);
    }
    if (hasValue(jsObject.field)) {
        dotNetSizeUpdateRendererWithReferenceSizeParams.field = jsObject.field;
    }
    if (hasValue(jsObject.forBinning)) {
        dotNetSizeUpdateRendererWithReferenceSizeParams.forBinning = jsObject.forBinning;
    }
    if (hasValue(jsObject.normalizationField)) {
        dotNetSizeUpdateRendererWithReferenceSizeParams.normalizationField = jsObject.normalizationField;
    }
    if (hasValue(jsObject.referenceSizeOptions)) {
        dotNetSizeUpdateRendererWithReferenceSizeParams.referenceSizeOptions = jsObject.referenceSizeOptions;
    }
    if (hasValue(jsObject.sizeOptimizationEnabled)) {
        dotNetSizeUpdateRendererWithReferenceSizeParams.sizeOptimizationEnabled = jsObject.sizeOptimizationEnabled;
    }
    if (hasValue(jsObject.sizeScheme)) {
        dotNetSizeUpdateRendererWithReferenceSizeParams.sizeScheme = jsObject.sizeScheme;
    }
    if (hasValue(jsObject.sizeStops)) {
        dotNetSizeUpdateRendererWithReferenceSizeParams.sizeStops = jsObject.sizeStops;
    }
    if (hasValue(jsObject.typeScheme)) {
        dotNetSizeUpdateRendererWithReferenceSizeParams.typeScheme = jsObject.typeScheme;
    }
    if (hasValue(jsObject.view)) {
        dotNetSizeUpdateRendererWithReferenceSizeParams.view = jsObject.view;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSizeUpdateRendererWithReferenceSizeParams.id = k;
                break;
            }
        }
    }

    return dotNetSizeUpdateRendererWithReferenceSizeParams;
}

