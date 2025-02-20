import {buildDotNetPCClassRendererResult} from './pCClassRendererResult';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsPCClassRendererResultGenerated(dotNetObject: any): Promise<any> {
    let jsPCClassRendererResult: any = {}
    if (hasValue(dotNetObject.renderer)) {
        let {buildJsPointCloudUniqueValueRenderer} = await import('./pointCloudUniqueValueRenderer');
        jsPCClassRendererResult.renderer = await buildJsPointCloudUniqueValueRenderer(dotNetObject.renderer, layerId, viewId) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsPCClassRendererResult);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsPCClassRendererResult;

    let dnInstantiatedObject = await buildDotNetPCClassRendererResult(jsPCClassRendererResult);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for PCClassRendererResult', e);
    }

    return jsPCClassRendererResult;
}

export async function buildDotNetPCClassRendererResultGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetPCClassRendererResult: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetPointCloudUniqueValueRenderer} = await import('./pointCloudUniqueValueRenderer');
        dotNetPCClassRendererResult.renderer = await buildDotNetPointCloudUniqueValueRenderer(jsObject.renderer);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetPCClassRendererResult.id = k;
                break;
            }
        }
    }

    return dotNetPCClassRendererResult;
}

