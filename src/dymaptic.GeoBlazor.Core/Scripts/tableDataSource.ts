
export async function buildJsTableDataSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableDataSourceGenerated } = await import('./tableDataSource.gb');
    return await buildJsTableDataSourceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTableDataSource(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTableDataSourceGenerated } = await import('./tableDataSource.gb');
    return await buildDotNetTableDataSourceGenerated(jsObject, layerId, viewId);
}
