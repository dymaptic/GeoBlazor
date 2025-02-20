import {buildDotNetRasterClassBreaksResult} from './rasterClassBreaksResult';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsRasterClassBreaksResultGenerated(dotNetObject: any): Promise<any> {
    let jsRasterClassBreaksResult: any = {}
    if (hasValue(dotNetObject.renderer)) {
        let {buildJsClassBreaksRenderer} = await import('./classBreaksRenderer');
        jsRasterClassBreaksResult.renderer = await buildJsClassBreaksRenderer(dotNetObject.renderer, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.classBreaksResult)) {
        jsRasterClassBreaksResult.classBreaksResult = dotNetObject.classBreaksResult;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsRasterClassBreaksResult);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsRasterClassBreaksResult;

    let dnInstantiatedObject = await buildDotNetRasterClassBreaksResult(jsRasterClassBreaksResult);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for RasterClassBreaksResult', e);
    }

    return jsRasterClassBreaksResult;
}

export async function buildDotNetRasterClassBreaksResultGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetRasterClassBreaksResult: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetClassBreaksRenderer} = await import('./classBreaksRenderer');
        dotNetRasterClassBreaksResult.renderer = await buildDotNetClassBreaksRenderer(jsObject.renderer);
    }
    if (hasValue(jsObject.classBreaksResult)) {
        dotNetRasterClassBreaksResult.classBreaksResult = jsObject.classBreaksResult;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetRasterClassBreaksResult.id = k;
                break;
            }
        }
    }

    return dotNetRasterClassBreaksResult;
}

