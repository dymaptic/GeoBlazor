import {buildDotNetColormapCreateRendererParams} from './colormapCreateRendererParams';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsColormapCreateRendererParamsGenerated(dotNetObject: any): Promise<any> {
    let jscolormapCreateRendererParams: any = {}
    if (hasValue(dotNetObject.layer)) {
        let {buildJsLayer} = await import('./layer');
        jscolormapCreateRendererParams.layer = await buildJsLayer(dotNetObject.layer, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.rasterFunction)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedRasterFunction} = dotNetObject.rasterFunction;
        jscolormapCreateRendererParams.rasterFunction = sanitizedRasterFunction;
    }
    if (hasValue(dotNetObject.renderingRule)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedRenderingRule} = dotNetObject.renderingRule;
        jscolormapCreateRendererParams.renderingRule = sanitizedRenderingRule;
    }
    if (hasValue(dotNetObject.signal)) {
        jscolormapCreateRendererParams.signal = dotNetObject.signal;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jscolormapCreateRendererParams);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jscolormapCreateRendererParams;

    let dnInstantiatedObject = await buildDotNetColormapCreateRendererParams(jscolormapCreateRendererParams);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ColormapCreateRendererParams', e);
    }

    return jscolormapCreateRendererParams;
}

export async function buildDotNetColormapCreateRendererParamsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetColormapCreateRendererParams: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.rasterFunction)) {
        dotNetColormapCreateRendererParams.rasterFunction = jsObject.rasterFunction;
    }
    if (hasValue(jsObject.renderingRule)) {
        dotNetColormapCreateRendererParams.renderingRule = jsObject.renderingRule;
    }
    if (hasValue(jsObject.signal)) {
        dotNetColormapCreateRendererParams.signal = jsObject.signal;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetColormapCreateRendererParams.id = k;
                break;
            }
        }
    }

    return dotNetColormapCreateRendererParams;
}

