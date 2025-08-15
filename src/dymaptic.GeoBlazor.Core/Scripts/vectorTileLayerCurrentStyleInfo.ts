
export async function buildJsVectorTileLayerCurrentStyleInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsVectorTileLayerCurrentStyleInfoGenerated } = await import('./vectorTileLayerCurrentStyleInfo.gb');
    return await buildJsVectorTileLayerCurrentStyleInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetVectorTileLayerCurrentStyleInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVectorTileLayerCurrentStyleInfoGenerated } = await import('./vectorTileLayerCurrentStyleInfo.gb');
    return await buildDotNetVectorTileLayerCurrentStyleInfoGenerated(jsObject, viewId);
}
