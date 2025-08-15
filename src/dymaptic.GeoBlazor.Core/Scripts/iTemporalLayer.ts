
export async function buildJsITemporalLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsITemporalLayerGenerated } = await import('./iTemporalLayer.gb');
    return await buildJsITemporalLayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetITemporalLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetITemporalLayerGenerated } = await import('./iTemporalLayer.gb');
    return await buildDotNetITemporalLayerGenerated(jsObject, viewId);
}
