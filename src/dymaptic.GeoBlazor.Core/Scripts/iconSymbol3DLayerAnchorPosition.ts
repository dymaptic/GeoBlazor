
export async function buildJsIconSymbol3DLayerAnchorPosition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIconSymbol3DLayerAnchorPositionGenerated } = await import('./iconSymbol3DLayerAnchorPosition.gb');
    return await buildJsIconSymbol3DLayerAnchorPositionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIconSymbol3DLayerAnchorPosition(jsObject: any): Promise<any> {
    let { buildDotNetIconSymbol3DLayerAnchorPositionGenerated } = await import('./iconSymbol3DLayerAnchorPosition.gb');
    return await buildDotNetIconSymbol3DLayerAnchorPositionGenerated(jsObject);
}
