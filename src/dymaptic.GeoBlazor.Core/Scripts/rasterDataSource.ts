
export async function buildJsRasterDataSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterDataSourceGenerated } = await import('./rasterDataSource.gb');
    return await buildJsRasterDataSourceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterDataSource(jsObject: any): Promise<any> {
    let { buildDotNetRasterDataSourceGenerated } = await import('./rasterDataSource.gb');
    return await buildDotNetRasterDataSourceGenerated(jsObject);
}
