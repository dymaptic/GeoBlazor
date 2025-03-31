
export async function buildJsIFeatureLayerBase(dotNetObject: any): Promise<any> {
    let { buildJsIFeatureLayerBaseGenerated } = await import('./iFeatureLayerBase.gb');
    return buildJsIFeatureLayerBaseGenerated(dotNetObject);
}     

export async function buildDotNetIFeatureLayerBase(jsObject: any): Promise<any> {
    let { buildDotNetIFeatureLayerBaseGenerated } = await import('./iFeatureLayerBase.gb');
    return await buildDotNetIFeatureLayerBaseGenerated(jsObject);
}
