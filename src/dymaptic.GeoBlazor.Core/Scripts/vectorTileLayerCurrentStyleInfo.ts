
export async function buildJsVectorTileLayerCurrentStyleInfo(dotNetObject: any): Promise<any> {
    let { buildJsVectorTileLayerCurrentStyleInfoGenerated } = await import('./vectorTileLayerCurrentStyleInfo.gb');
    return await buildJsVectorTileLayerCurrentStyleInfoGenerated(dotNetObject);
}     

export async function buildDotNetVectorTileLayerCurrentStyleInfo(jsObject: any): Promise<any> {
    let { buildDotNetVectorTileLayerCurrentStyleInfoGenerated } = await import('./vectorTileLayerCurrentStyleInfo.gb');
    return await buildDotNetVectorTileLayerCurrentStyleInfoGenerated(jsObject);
}
