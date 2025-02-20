import {buildDotNetVideoViewParams} from './videoViewParams';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsVideoViewParamsGenerated(dotNetObject: any): Promise<any> {
    let jsVideoViewParams: any = {}
    if (hasValue(dotNetObject.layer)) {
        let {buildJsVideoLayer} = await import('./videoLayer');
        jsVideoViewParams.layer = await buildJsVideoLayer(dotNetObject.layer, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.container)) {
        jsVideoViewParams.container = dotNetObject.container;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsVideoViewParams);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsVideoViewParams;

    let dnInstantiatedObject = await buildDotNetVideoViewParams(jsVideoViewParams);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for VideoViewParams', e);
    }

    return jsVideoViewParams;
}

export async function buildDotNetVideoViewParamsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetVideoViewParams: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.container)) {
        dotNetVideoViewParams.container = jsObject.container;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetVideoViewParams.id = k;
                break;
            }
        }
    }

    return dotNetVideoViewParams;
}

