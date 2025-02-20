
export async function buildJsIFeatureLayerBase(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIFeatureLayerBaseGenerated } = await import('./iFeatureLayerBase.gb');
    return await buildJsIFeatureLayerBaseGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIFeatureLayerBase(jsObject: any): Promise<any> {
    let { buildDotNetIFeatureLayerBaseGenerated } = await import('./iFeatureLayerBase.gb');
    return await buildDotNetIFeatureLayerBaseGenerated(jsObject);
}
