
export async function buildJsIRefreshableLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIRefreshableLayerGenerated } = await import('./iRefreshableLayer.gb');
    return await buildJsIRefreshableLayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIRefreshableLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIRefreshableLayerGenerated } = await import('./iRefreshableLayer.gb');
    return await buildDotNetIRefreshableLayerGenerated(jsObject, viewId);
}
