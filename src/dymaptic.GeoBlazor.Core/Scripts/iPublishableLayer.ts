
export async function buildJsIPublishableLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIPublishableLayerGenerated } = await import('./iPublishableLayer.gb');
    return await buildJsIPublishableLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIPublishableLayer(jsObject: any): Promise<any> {
    let { buildDotNetIPublishableLayerGenerated } = await import('./iPublishableLayer.gb');
    return await buildDotNetIPublishableLayerGenerated(jsObject);
}
