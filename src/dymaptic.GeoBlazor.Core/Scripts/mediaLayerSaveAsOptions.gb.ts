import {buildDotNetMediaLayerSaveAsOptions} from './mediaLayerSaveAsOptions';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsMediaLayerSaveAsOptionsGenerated(dotNetObject: any): Promise<any> {
    let jsMediaLayerSaveAsOptions: any = {}

    if (hasValue(dotNetObject.folder)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedFolder} = dotNetObject.folder;
        jsMediaLayerSaveAsOptions.folder = sanitizedFolder;
    }
    if (hasValue(dotNetObject.validationOptions)) {
        jsMediaLayerSaveAsOptions.validationOptions = dotNetObject.validationOptions;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsMediaLayerSaveAsOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsMediaLayerSaveAsOptions;

    let dnInstantiatedObject = await buildDotNetMediaLayerSaveAsOptions(jsMediaLayerSaveAsOptions);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for MediaLayerSaveAsOptions', e);
    }

    return jsMediaLayerSaveAsOptions;
}

export async function buildDotNetMediaLayerSaveAsOptionsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMediaLayerSaveAsOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.folder)) {
        dotNetMediaLayerSaveAsOptions.folder = jsObject.folder;
    }
    if (hasValue(jsObject.validationOptions)) {
        dotNetMediaLayerSaveAsOptions.validationOptions = jsObject.validationOptions;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetMediaLayerSaveAsOptions.id = k;
                break;
            }
        }
    }

    return dotNetMediaLayerSaveAsOptions;
}

