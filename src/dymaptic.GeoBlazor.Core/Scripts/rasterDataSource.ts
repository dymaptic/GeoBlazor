
export async function buildJsRasterDataSource(dotNetObject: any): Promise<any> {
    let { buildJsRasterDataSourceGenerated } = await import('./rasterDataSource.gb');
    let jsSource = await buildJsRasterDataSourceGenerated(dotNetObject);
    jsSource.type = 'raster';
    return jsSource;
}     

export async function buildDotNetRasterDataSource(jsObject: any): Promise<any> {
    let { buildDotNetRasterDataSourceGenerated } = await import('./rasterDataSource.gb');
    return await buildDotNetRasterDataSourceGenerated(jsObject);
}
