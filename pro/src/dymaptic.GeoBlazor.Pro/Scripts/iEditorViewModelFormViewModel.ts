import {hasValue} from './geoBlazorCore';

export async function buildDotNetIEditorViewModelFormViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!jsObject) {
        return null;
    }
    
    if (hasValue(jsObject.mode)) {
        let {buildDotNetBatchAttributeFormViewModel} = await import('./batchAttributeFormViewModel');
        return buildDotNetBatchAttributeFormViewModel(jsObject);
    }

    let { buildDotNetFeatureFormViewModel } = await import('./featureFormViewModel');

    return buildDotNetFeatureFormViewModel(jsObject, layerId, viewId);
}

export async function buildJsIEditorViewModelFormViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!dotNetObject) {
        return null;
    }

    if (hasValue(dotNetObject.mode)) {
        let {buildJsBatchAttributeFormViewModel} = await import('./batchAttributeFormViewModel');
        return buildJsBatchAttributeFormViewModel(dotNetObject, layerId, viewId);
    }

    let { buildJsFeatureFormViewModel } = await import('./featureFormViewModel');

    return buildJsFeatureFormViewModel(dotNetObject, layerId, viewId);
}