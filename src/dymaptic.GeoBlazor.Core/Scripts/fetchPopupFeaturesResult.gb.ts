import {buildDotNetFetchPopupFeaturesResult} from './fetchPopupFeaturesResult';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsFetchPopupFeaturesResultGenerated(dotNetObject: any): Promise<any> {
    let jsFetchPopupFeaturesResult: any = {}
    if (hasValue(dotNetObject.allGraphicsPromise)) {
        let {buildJsGraphic} = await import('./graphic');
        jsFetchPopupFeaturesResult.allGraphicsPromise = dotNetObject.allGraphicsPromise.map(i => buildJsGraphic(i)) as any;
    }
    if (hasValue(dotNetObject.location)) {
        let {buildJsPoint} = await import('./point');
        jsFetchPopupFeaturesResult.location = buildJsPoint(dotNetObject.location) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsFetchPopupFeaturesResult);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFetchPopupFeaturesResult;

    let dnInstantiatedObject = await buildDotNetFetchPopupFeaturesResult(jsFetchPopupFeaturesResult);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for FetchPopupFeaturesResult', e);
    }

    return jsFetchPopupFeaturesResult;
}

export async function buildDotNetFetchPopupFeaturesResultGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFetchPopupFeaturesResult: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.allGraphicsPromise)) {
        let {buildDotNetGraphic} = await import('./graphic');
        dotNetFetchPopupFeaturesResult.allGraphicsPromise = jsObject.allGraphicsPromise.map(i => buildDotNetGraphic(i, layerId, viewId));
    }
    if (hasValue(jsObject.location)) {
        let {buildDotNetPoint} = await import('./point');
        dotNetFetchPopupFeaturesResult.location = buildDotNetPoint(jsObject.location);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetFetchPopupFeaturesResult.id = k;
                break;
            }
        }
    }

    return dotNetFetchPopupFeaturesResult;
}

