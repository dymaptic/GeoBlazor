
export async function buildJsVectorTileLayerCurrentStyleInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVectorTileLayerCurrentStyleInfoGenerated } = await import('./vectorTileLayerCurrentStyleInfo.gb');
    return await buildJsVectorTileLayerCurrentStyleInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVectorTileLayerCurrentStyleInfo(jsObject: any): Promise<any> {
    let { buildDotNetVectorTileLayerCurrentStyleInfoGenerated } = await import('./vectorTileLayerCurrentStyleInfo.gb');
    return await buildDotNetVectorTileLayerCurrentStyleInfoGenerated(jsObject);
}
