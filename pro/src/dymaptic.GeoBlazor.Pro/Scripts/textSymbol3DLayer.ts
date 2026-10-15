
export async function buildJsTextSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTextSymbol3DLayerGenerated } = await import('./textSymbol3DLayer.gb');
    return await buildJsTextSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTextSymbol3DLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTextSymbol3DLayerGenerated } = await import('./textSymbol3DLayer.gb');
    return await buildDotNetTextSymbol3DLayerGenerated(jsObject, layerId, viewId);
}
