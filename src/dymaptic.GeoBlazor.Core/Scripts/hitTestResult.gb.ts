import {buildDotNetHitTestResult} from './hitTestResult';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsHitTestResultGenerated(dotNetObject: any): Promise<any> {
    let jsHitTestResult: any = {}

    if (hasValue(dotNetObject.results)) {
        jsHitTestResult.results = dotNetObject.results;
    }
    if (hasValue(dotNetObject.screenPoint)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedScreenPoint} = dotNetObject.screenPoint;
        jsHitTestResult.screenPoint = sanitizedScreenPoint;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsHitTestResult);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsHitTestResult;

    let dnInstantiatedObject = await buildDotNetHitTestResult(jsHitTestResult);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for HitTestResult', e);
    }

    return jsHitTestResult;
}

export async function buildDotNetHitTestResultGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetHitTestResult: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.results)) {
        dotNetHitTestResult.results = jsObject.results;
    }
    if (hasValue(jsObject.screenPoint)) {
        dotNetHitTestResult.screenPoint = jsObject.screenPoint;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetHitTestResult.id = k;
                break;
            }
        }
    }

    return dotNetHitTestResult;
}

