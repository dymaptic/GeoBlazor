
export async function buildJsTableDataSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableDataSourceGenerated } = await import('./tableDataSource.gb');
    let jsSource = await buildJsTableDataSourceGenerated(dotNetObject, layerId, viewId);
    jsSource.type = 'table';
    return jsSource;
}     

export async function buildDotNetTableDataSource(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTableDataSourceGenerated } = await import('./tableDataSource.gb');
    return await buildDotNetTableDataSourceGenerated(jsObject, layerId, viewId);
}
