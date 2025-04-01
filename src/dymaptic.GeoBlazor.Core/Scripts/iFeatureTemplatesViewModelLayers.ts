
export async function buildJsIFeatureTemplatesViewModelLayers(dotNetObject: any): Promise<any> {
    let { buildJsIFeatureTemplatesViewModelLayersGenerated } = await import('./iFeatureTemplatesViewModelLayers.gb');
    return await buildJsIFeatureTemplatesViewModelLayersGenerated(dotNetObject);
}     

export async function buildDotNetIFeatureTemplatesViewModelLayers(jsObject: any): Promise<any> {
    let { buildDotNetIFeatureTemplatesViewModelLayersGenerated } = await import('./iFeatureTemplatesViewModelLayers.gb');
    return await buildDotNetIFeatureTemplatesViewModelLayersGenerated(jsObject);
}
