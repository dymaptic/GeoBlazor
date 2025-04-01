
export async function buildJsITemporalLayer(dotNetObject: any): Promise<any> {
    let { buildJsITemporalLayerGenerated } = await import('./iTemporalLayer.gb');
    return await buildJsITemporalLayerGenerated(dotNetObject);
}     

export async function buildDotNetITemporalLayer(jsObject: any): Promise<any> {
    let { buildDotNetITemporalLayerGenerated } = await import('./iTemporalLayer.gb');
    return await buildDotNetITemporalLayerGenerated(jsObject);
}
