import {buildDotNetWebSceneSaveAsOptions} from './webSceneSaveAsOptions';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsWebSceneSaveAsOptionsGenerated(dotNetObject: any): Promise<any> {
    let jsWebSceneSaveAsOptions: any = {}

    if (hasValue(dotNetObject.folder)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedFolder} = dotNetObject.folder;
        jsWebSceneSaveAsOptions.folder = sanitizedFolder;
    }
    if (hasValue(dotNetObject.ignoreUnsupported)) {
        jsWebSceneSaveAsOptions.ignoreUnsupported = dotNetObject.ignoreUnsupported;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsWebSceneSaveAsOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsWebSceneSaveAsOptions;

    let dnInstantiatedObject = await buildDotNetWebSceneSaveAsOptions(jsWebSceneSaveAsOptions);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for WebSceneSaveAsOptions', e);
    }

    return jsWebSceneSaveAsOptions;
}

export async function buildDotNetWebSceneSaveAsOptionsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetWebSceneSaveAsOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.folder)) {
        dotNetWebSceneSaveAsOptions.folder = jsObject.folder;
    }
    if (hasValue(jsObject.ignoreUnsupported)) {
        dotNetWebSceneSaveAsOptions.ignoreUnsupported = jsObject.ignoreUnsupported;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetWebSceneSaveAsOptions.id = k;
                break;
            }
        }
    }

    return dotNetWebSceneSaveAsOptions;
}

