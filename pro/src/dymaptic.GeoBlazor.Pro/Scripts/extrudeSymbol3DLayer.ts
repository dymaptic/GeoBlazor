
export async function buildJsExtrudeSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsExtrudeSymbol3DLayerGenerated } = await import('./extrudeSymbol3DLayer.gb');
    return await buildJsExtrudeSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetExtrudeSymbol3DLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetExtrudeSymbol3DLayerGenerated } = await import('./extrudeSymbol3DLayer.gb');
    return await buildDotNetExtrudeSymbol3DLayerGenerated(jsObject, layerId, viewId);
}
