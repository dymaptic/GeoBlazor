
export async function buildJsIRefreshableLayer(dotNetObject: any): Promise<any> {
    let { buildJsIRefreshableLayerGenerated } = await import('./iRefreshableLayer.gb');
    return await buildJsIRefreshableLayerGenerated(dotNetObject);
}     

export async function buildDotNetIRefreshableLayer(jsObject: any): Promise<any> {
    let { buildDotNetIRefreshableLayerGenerated } = await import('./iRefreshableLayer.gb');
    return await buildDotNetIRefreshableLayerGenerated(jsObject);
}
