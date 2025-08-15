
export async function buildJsIFeatureLayerBase(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIFeatureLayerBaseGenerated } = await import('./iFeatureLayerBase.gb');
    return await buildJsIFeatureLayerBaseGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIFeatureLayerBase(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIFeatureLayerBaseGenerated } = await import('./iFeatureLayerBase.gb');
    return await buildDotNetIFeatureLayerBaseGenerated(jsObject, viewId);
}
