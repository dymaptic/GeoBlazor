
export async function buildJsIFeatureSetLayer(dotNetObject: any): Promise<any> {
    let { buildJsIFeatureSetLayerGenerated } = await import('./iFeatureSetLayer.gb');
    return await buildJsIFeatureSetLayerGenerated(dotNetObject);
}     

export async function buildDotNetIFeatureSetLayer(jsObject: any): Promise<any> {
    let { buildDotNetIFeatureSetLayerGenerated } = await import('./iFeatureSetLayer.gb');
    return await buildDotNetIFeatureSetLayerGenerated(jsObject);
}
