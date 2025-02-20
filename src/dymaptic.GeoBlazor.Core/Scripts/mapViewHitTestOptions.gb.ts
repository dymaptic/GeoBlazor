import {buildDotNetMapViewHitTestOptions} from './mapViewHitTestOptions';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsMapViewHitTestOptionsGenerated(dotNetObject: any): Promise<any> {
    let jsMapViewHitTestOptions: any = {}

    if (hasValue(dotNetObject.exclude)) {
        jsMapViewHitTestOptions.exclude = dotNetObject.exclude;
    }
    if (hasValue(dotNetObject.include)) {
        jsMapViewHitTestOptions.include = dotNetObject.include;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsMapViewHitTestOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsMapViewHitTestOptions;

    let dnInstantiatedObject = await buildDotNetMapViewHitTestOptions(jsMapViewHitTestOptions);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for MapViewHitTestOptions', e);
    }

    return jsMapViewHitTestOptions;
}

export async function buildDotNetMapViewHitTestOptionsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMapViewHitTestOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.exclude)) {
        dotNetMapViewHitTestOptions.exclude = jsObject.exclude;
    }
    if (hasValue(jsObject.include)) {
        dotNetMapViewHitTestOptions.include = jsObject.include;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetMapViewHitTestOptions.id = k;
                break;
            }
        }
    }

    return dotNetMapViewHitTestOptions;
}

