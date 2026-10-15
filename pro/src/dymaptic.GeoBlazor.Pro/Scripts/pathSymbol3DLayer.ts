
export async function buildJsPathSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPathSymbol3DLayerGenerated } = await import('./pathSymbol3DLayer.gb');
    return await buildJsPathSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPathSymbol3DLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPathSymbol3DLayerGenerated } = await import('./pathSymbol3DLayer.gb');
    return await buildDotNetPathSymbol3DLayerGenerated(jsObject, layerId, viewId);
}
