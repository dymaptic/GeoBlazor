
export async function buildJsWaterSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWaterSymbol3DLayerGenerated } = await import('./waterSymbol3DLayer.gb');
    return await buildJsWaterSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWaterSymbol3DLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetWaterSymbol3DLayerGenerated } = await import('./waterSymbol3DLayer.gb');
    return await buildDotNetWaterSymbol3DLayerGenerated(jsObject, layerId, viewId);
}
