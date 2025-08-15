
export async function buildJsIFeatureTemplatesViewModelLayers(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIFeatureTemplatesViewModelLayersGenerated } = await import('./iFeatureTemplatesViewModelLayers.gb');
    return await buildJsIFeatureTemplatesViewModelLayersGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIFeatureTemplatesViewModelLayers(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIFeatureTemplatesViewModelLayersGenerated } = await import('./iFeatureTemplatesViewModelLayers.gb');
    return await buildDotNetIFeatureTemplatesViewModelLayersGenerated(jsObject, viewId);
}
