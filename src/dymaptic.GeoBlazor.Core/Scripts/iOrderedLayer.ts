
export async function buildJsIOrderedLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIOrderedLayerGenerated } = await import('./iOrderedLayer.gb');
    return await buildJsIOrderedLayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIOrderedLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIOrderedLayerGenerated } = await import('./iOrderedLayer.gb');
    return await buildDotNetIOrderedLayerGenerated(jsObject, viewId);
}
