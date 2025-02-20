import {buildDotNetConvertMeshOptions} from './convertMeshOptions';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsConvertMeshOptionsGenerated(dotNetObject: any): Promise<any> {
    let jsConvertMeshOptions: any = {}
    if (hasValue(dotNetObject.location)) {
        let {buildJsPoint} = await import('./point');
        jsConvertMeshOptions.location = buildJsPoint(dotNetObject.location) as any;
    }

    if (hasValue(dotNetObject.signal)) {
        jsConvertMeshOptions.signal = dotNetObject.signal;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsConvertMeshOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsConvertMeshOptions;

    let dnInstantiatedObject = await buildDotNetConvertMeshOptions(jsConvertMeshOptions);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ConvertMeshOptions', e);
    }

    return jsConvertMeshOptions;
}

export async function buildDotNetConvertMeshOptionsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetConvertMeshOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.location)) {
        let {buildDotNetPoint} = await import('./point');
        dotNetConvertMeshOptions.location = buildDotNetPoint(jsObject.location);
    }
    if (hasValue(jsObject.signal)) {
        dotNetConvertMeshOptions.signal = jsObject.signal;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetConvertMeshOptions.id = k;
                break;
            }
        }
    }

    return dotNetConvertMeshOptions;
}

