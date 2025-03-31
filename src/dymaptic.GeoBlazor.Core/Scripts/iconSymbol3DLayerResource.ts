
export async function buildJsIconSymbol3DLayerResource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIconSymbol3DLayerResourceGenerated } = await import('./iconSymbol3DLayerResource.gb');
    return await buildJsIconSymbol3DLayerResourceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIconSymbol3DLayerResource(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIconSymbol3DLayerResourceGenerated } = await import('./iconSymbol3DLayerResource.gb');
    return await buildDotNetIconSymbol3DLayerResourceGenerated(jsObject, layerId, viewId);
}
