
export async function buildJsIconSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIconSymbol3DLayerGenerated } = await import('./iconSymbol3DLayer.gb');
    return await buildJsIconSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIconSymbol3DLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIconSymbol3DLayerGenerated } = await import('./iconSymbol3DLayer.gb');
    return await buildDotNetIconSymbol3DLayerGenerated(jsObject, layerId, viewId);
}
