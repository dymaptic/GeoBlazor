
export async function buildJsObjectSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsObjectSymbol3DLayerGenerated } = await import('./objectSymbol3DLayer.gb');
    return await buildJsObjectSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetObjectSymbol3DLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetObjectSymbol3DLayerGenerated } = await import('./objectSymbol3DLayer.gb');
    return await buildDotNetObjectSymbol3DLayerGenerated(jsObject, layerId, viewId);
}
