
export async function buildJsRasterDataSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterDataSourceGenerated } = await import('./rasterDataSource.gb');
    let jsSource = await buildJsRasterDataSourceGenerated(dotNetObject, layerId, viewId);
    jsSource.type = 'raster';
    return jsSource;
}     

export async function buildDotNetRasterDataSource(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRasterDataSourceGenerated } = await import('./rasterDataSource.gb');
    return await buildDotNetRasterDataSourceGenerated(jsObject, layerId, viewId);
}
