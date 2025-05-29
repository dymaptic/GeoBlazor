
export async function buildJsTile(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTileGenerated } = await import('./tile.gb');
    return await buildJsTileGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTile(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTileGenerated } = await import('./tile.gb');
    return await buildDotNetTileGenerated(jsObject, layerId, viewId);
}
