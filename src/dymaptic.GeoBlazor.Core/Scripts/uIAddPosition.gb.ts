import {buildDotNetUIAddPosition} from './uIAddPosition';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsUIAddPositionGenerated(dotNetObject: any): Promise<any> {
    let jsUIAddPosition: any = {}
    if (hasValue(dotNetObject.position)) {
        let {buildJsPosition} = await import('./position');
        jsUIAddPosition.position = await buildJsPosition(dotNetObject.position, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.index)) {
        jsUIAddPosition.index = dotNetObject.index;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsUIAddPosition);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsUIAddPosition;

    let dnInstantiatedObject = await buildDotNetUIAddPosition(jsUIAddPosition);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for UIAddPosition', e);
    }

    return jsUIAddPosition;
}

export async function buildDotNetUIAddPositionGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetUIAddPosition: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.position)) {
        let {buildDotNetPosition} = await import('./position');
        dotNetUIAddPosition.position = await buildDotNetPosition(jsObject.position);
    }
    if (hasValue(jsObject.index)) {
        dotNetUIAddPosition.index = jsObject.index;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetUIAddPosition.id = k;
                break;
            }
        }
    }

    return dotNetUIAddPosition;
}

