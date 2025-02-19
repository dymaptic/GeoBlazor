export async function buildJsQueryTableDataSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsQueryTableDataSourceGenerated } = await import('./queryTableDataSource.gb');
    return await buildJsQueryTableDataSourceGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetQueryTableDataSource(jsObject: any): Promise<any> {
    let { buildDotNetQueryTableDataSourceGenerated } = await import('./queryTableDataSource.gb');
    return await buildDotNetQueryTableDataSourceGenerated(jsObject);
}
