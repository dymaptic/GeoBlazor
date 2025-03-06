
export async function buildJsObjectSymbol3DLayerResource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsObjectSymbol3DLayerResourceGenerated } = await import('./objectSymbol3DLayerResource.gb');
    return await buildJsObjectSymbol3DLayerResourceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetObjectSymbol3DLayerResource(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetObjectSymbol3DLayerResourceGenerated } = await import('./objectSymbol3DLayerResource.gb');
    return await buildDotNetObjectSymbol3DLayerResourceGenerated(jsObject, layerId, viewId);
}
