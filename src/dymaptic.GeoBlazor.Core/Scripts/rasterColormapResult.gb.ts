import {buildDotNetRasterColormapResult} from './rasterColormapResult';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsRasterColormapResultGenerated(dotNetObject: any): Promise<any> {
    let jsRasterColormapResult: any = {}
    if (hasValue(dotNetObject.renderer)) {
        let {buildJsRasterColormapRenderer} = await import('./rasterColormapRenderer');
        jsRasterColormapResult.renderer = await buildJsRasterColormapRenderer(dotNetObject.renderer, layerId, viewId) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsRasterColormapResult);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsRasterColormapResult;

    let dnInstantiatedObject = await buildDotNetRasterColormapResult(jsRasterColormapResult);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for RasterColormapResult', e);
    }

    return jsRasterColormapResult;
}

export async function buildDotNetRasterColormapResultGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetRasterColormapResult: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetRasterColormapRenderer} = await import('./rasterColormapRenderer');
        dotNetRasterColormapResult.renderer = await buildDotNetRasterColormapRenderer(jsObject.renderer);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetRasterColormapResult.id = k;
                break;
            }
        }
    }

    return dotNetRasterColormapResult;
}

