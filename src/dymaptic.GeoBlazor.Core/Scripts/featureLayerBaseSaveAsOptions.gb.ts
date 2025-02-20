import {buildDotNetFeatureLayerBaseSaveAsOptions} from './featureLayerBaseSaveAsOptions';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsFeatureLayerBaseSaveAsOptionsGenerated(dotNetObject: any): Promise<any> {
    let jsFeatureLayerBaseSaveAsOptions: any = {}

    if (hasValue(dotNetObject.folder)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedFolder} = dotNetObject.folder;
        jsFeatureLayerBaseSaveAsOptions.folder = sanitizedFolder;
    }
    if (hasValue(dotNetObject.validationOptions)) {
        jsFeatureLayerBaseSaveAsOptions.validationOptions = dotNetObject.validationOptions;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsFeatureLayerBaseSaveAsOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFeatureLayerBaseSaveAsOptions;

    let dnInstantiatedObject = await buildDotNetFeatureLayerBaseSaveAsOptions(jsFeatureLayerBaseSaveAsOptions);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for FeatureLayerBaseSaveAsOptions', e);
    }

    return jsFeatureLayerBaseSaveAsOptions;
}

export async function buildDotNetFeatureLayerBaseSaveAsOptionsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFeatureLayerBaseSaveAsOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.folder)) {
        dotNetFeatureLayerBaseSaveAsOptions.folder = jsObject.folder;
    }
    if (hasValue(jsObject.validationOptions)) {
        dotNetFeatureLayerBaseSaveAsOptions.validationOptions = jsObject.validationOptions;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetFeatureLayerBaseSaveAsOptions.id = k;
                break;
            }
        }
    }

    return dotNetFeatureLayerBaseSaveAsOptions;
}

