import {buildDotNetStopsByCount} from './stopsByCount';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsStopsByCountGenerated(dotNetObject: any): Promise<any> {
    let jsStopsByCount: any = {}
    if (hasValue(dotNetObject.timeExtent)) {
        let {buildJsTimeExtent} = await import('./timeExtent');
        jsStopsByCount.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.count)) {
        jsStopsByCount.count = dotNetObject.count;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsStopsByCount);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsStopsByCount;

    let dnInstantiatedObject = await buildDotNetStopsByCount(jsStopsByCount);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for StopsByCount', e);
    }

    return jsStopsByCount;
}

export async function buildDotNetStopsByCountGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetStopsByCount: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.timeExtent)) {
        let {buildDotNetTimeExtent} = await import('./timeExtent');
        dotNetStopsByCount.timeExtent = buildDotNetTimeExtent(jsObject.timeExtent);
    }
    if (hasValue(jsObject.count)) {
        dotNetStopsByCount.count = jsObject.count;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetStopsByCount.id = k;
                break;
            }
        }
    }

    return dotNetStopsByCount;
}

