
export async function buildJsVectorTileOrigin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVectorTileOriginGenerated } = await import('./vectorTileOrigin.gb');
    return await buildJsVectorTileOriginGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVectorTileOrigin(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVectorTileOriginGenerated } = await import('./vectorTileOrigin.gb');
    return await buildDotNetVectorTileOriginGenerated(jsObject, layerId, viewId);
}
