import {buildDotNetSizeRangeResult} from './sizeRangeResult';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSizeRangeResultGenerated(dotNetObject: any): Promise<any> {
    let jsSizeRangeResult: any = {}
    if (hasValue(dotNetObject.maxSize)) {
        let {buildJsScaleDependentStops} = await import('./scaleDependentStops');
        jsSizeRangeResult.maxSize = await buildJsScaleDependentStops(dotNetObject.maxSize, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.minSize)) {
        let {buildJsScaleDependentStops} = await import('./scaleDependentStops');
        jsSizeRangeResult.minSize = await buildJsScaleDependentStops(dotNetObject.minSize, layerId, viewId) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsSizeRangeResult);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSizeRangeResult;

    let dnInstantiatedObject = await buildDotNetSizeRangeResult(jsSizeRangeResult);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SizeRangeResult', e);
    }

    return jsSizeRangeResult;
}

export async function buildDotNetSizeRangeResultGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSizeRangeResult: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.maxSize)) {
        let {buildDotNetScaleDependentStops} = await import('./scaleDependentStops');
        dotNetSizeRangeResult.maxSize = await buildDotNetScaleDependentStops(jsObject.maxSize);
    }
    if (hasValue(jsObject.minSize)) {
        let {buildDotNetScaleDependentStops} = await import('./scaleDependentStops');
        dotNetSizeRangeResult.minSize = await buildDotNetScaleDependentStops(jsObject.minSize);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSizeRangeResult.id = k;
                break;
            }
        }
    }

    return dotNetSizeRangeResult;
}

