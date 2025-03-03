
export async function buildJsObjectSymbol3DLayerAnchorPosition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsObjectSymbol3DLayerAnchorPositionGenerated } = await import('./objectSymbol3DLayerAnchorPosition.gb');
    return await buildJsObjectSymbol3DLayerAnchorPositionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetObjectSymbol3DLayerAnchorPosition(jsObject: any): Promise<any> {
    let { buildDotNetObjectSymbol3DLayerAnchorPositionGenerated } = await import('./objectSymbol3DLayerAnchorPosition.gb');
    return await buildDotNetObjectSymbol3DLayerAnchorPositionGenerated(jsObject);
}
