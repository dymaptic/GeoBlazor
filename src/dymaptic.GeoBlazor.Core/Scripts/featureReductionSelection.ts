
export async function buildJsFeatureReductionSelection(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureReductionSelectionGenerated } = await import('./featureReductionSelection.gb');
    return await buildJsFeatureReductionSelectionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureReductionSelection(jsObject: any): Promise<any> {
    let { buildDotNetFeatureReductionSelectionGenerated } = await import('./featureReductionSelection.gb');
    return await buildDotNetFeatureReductionSelectionGenerated(jsObject);
}
