export async function buildJsTileMatrixSet(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTileMatrixSetGenerated} = await import('./tileMatrixSet.gb');
    return await buildJsTileMatrixSetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTileMatrixSet(jsObject: any): Promise<any> {
    let {buildDotNetTileMatrixSetGenerated} = await import('./tileMatrixSet.gb');
    return await buildDotNetTileMatrixSetGenerated(jsObject);
}
