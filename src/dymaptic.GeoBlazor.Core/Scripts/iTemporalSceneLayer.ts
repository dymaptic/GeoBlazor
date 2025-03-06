
export async function buildJsITemporalSceneLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsITemporalSceneLayerGenerated } = await import('./iTemporalSceneLayer.gb');
    return await buildJsITemporalSceneLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetITemporalSceneLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetITemporalSceneLayerGenerated } = await import('./iTemporalSceneLayer.gb');
    return await buildDotNetITemporalSceneLayerGenerated(jsObject, layerId, viewId);
}
