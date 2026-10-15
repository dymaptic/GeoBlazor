
export async function buildJsLineSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLineSymbol3DLayerGenerated } = await import('./lineSymbol3DLayer.gb');
    return await buildJsLineSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLineSymbol3DLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLineSymbol3DLayerGenerated } = await import('./lineSymbol3DLayer.gb');
    return await buildDotNetLineSymbol3DLayerGenerated(jsObject, layerId, viewId);
}
