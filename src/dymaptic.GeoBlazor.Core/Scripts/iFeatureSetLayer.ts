
export async function buildJsIFeatureSetLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIFeatureSetLayerGenerated } = await import('./iFeatureSetLayer.gb');
    return await buildJsIFeatureSetLayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIFeatureSetLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIFeatureSetLayerGenerated } = await import('./iFeatureSetLayer.gb');
    return await buildDotNetIFeatureSetLayerGenerated(jsObject, viewId);
}
