import {buildDotNetFromScreenPointResult} from './fromScreenPointResult';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsFromScreenPointResultGenerated(dotNetObject: any): Promise<any> {
    let jsFromScreenPointResult: any = {}
    if (hasValue(dotNetObject.mapPoint)) {
        let {buildJsPoint} = await import('./point');
        jsFromScreenPointResult.mapPoint = buildJsPoint(dotNetObject.mapPoint) as any;
    }

    if (hasValue(dotNetObject.vertex)) {
        jsFromScreenPointResult.vertex = dotNetObject.vertex;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsFromScreenPointResult);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFromScreenPointResult;

    let dnInstantiatedObject = await buildDotNetFromScreenPointResult(jsFromScreenPointResult);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for FromScreenPointResult', e);
    }

    return jsFromScreenPointResult;
}

export async function buildDotNetFromScreenPointResultGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFromScreenPointResult: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.mapPoint)) {
        let {buildDotNetPoint} = await import('./point');
        dotNetFromScreenPointResult.mapPoint = buildDotNetPoint(jsObject.mapPoint);
    }
    if (hasValue(jsObject.vertex)) {
        dotNetFromScreenPointResult.vertex = jsObject.vertex;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetFromScreenPointResult.id = k;
                break;
            }
        }
    }

    return dotNetFromScreenPointResult;
}

