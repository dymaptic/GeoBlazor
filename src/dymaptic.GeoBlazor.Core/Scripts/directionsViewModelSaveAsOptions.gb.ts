import {buildDotNetDirectionsViewModelSaveAsOptions} from './directionsViewModelSaveAsOptions';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsDirectionsViewModelSaveAsOptionsGenerated(dotNetObject: any): Promise<any> {
    let jsDirectionsViewModelSaveAsOptions: any = {}

    if (hasValue(dotNetObject.folder)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedFolder} = dotNetObject.folder;
        jsDirectionsViewModelSaveAsOptions.folder = sanitizedFolder;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsDirectionsViewModelSaveAsOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsDirectionsViewModelSaveAsOptions;

    let dnInstantiatedObject = await buildDotNetDirectionsViewModelSaveAsOptions(jsDirectionsViewModelSaveAsOptions);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for DirectionsViewModelSaveAsOptions', e);
    }

    return jsDirectionsViewModelSaveAsOptions;
}

export async function buildDotNetDirectionsViewModelSaveAsOptionsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetDirectionsViewModelSaveAsOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.folder)) {
        dotNetDirectionsViewModelSaveAsOptions.folder = jsObject.folder;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetDirectionsViewModelSaveAsOptions.id = k;
                break;
            }
        }
    }

    return dotNetDirectionsViewModelSaveAsOptions;
}

