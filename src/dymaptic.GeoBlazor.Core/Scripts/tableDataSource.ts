
export async function buildJsTableDataSource(dotNetObject: any): Promise<any> {
    let { buildJsTableDataSourceGenerated } = await import('./tableDataSource.gb');
    let jsSource = await buildJsTableDataSourceGenerated(dotNetObject);
    jsSource.type = 'table';
    return jsSource;
}     

export async function buildDotNetTableDataSource(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetTableDataSourceGenerated } = await import('./tableDataSource.gb');
    return await buildDotNetTableDataSourceGenerated(jsObject, viewId);
}
