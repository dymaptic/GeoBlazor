
export async function buildJsEditorStartCreateFeaturesWorkflowAtFeatureEditParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorStartCreateFeaturesWorkflowAtFeatureEditParamsGenerated } = await import('./editorStartCreateFeaturesWorkflowAtFeatureEditParams.gb');
    return await buildJsEditorStartCreateFeaturesWorkflowAtFeatureEditParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorStartCreateFeaturesWorkflowAtFeatureEditParams(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorStartCreateFeaturesWorkflowAtFeatureEditParamsGenerated } = await import('./editorStartCreateFeaturesWorkflowAtFeatureEditParams.gb');
    return await buildDotNetEditorStartCreateFeaturesWorkflowAtFeatureEditParamsGenerated(jsObject, layerId, viewId);
}
