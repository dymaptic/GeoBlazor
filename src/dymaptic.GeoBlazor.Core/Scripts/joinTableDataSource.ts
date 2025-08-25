
export async function buildJsJoinTableDataSource(dotNetObject: any): Promise<any> {
    let { buildJsJoinTableDataSourceGenerated } = await import('./joinTableDataSource.gb');
    let jsSource = await buildJsJoinTableDataSourceGenerated(dotNetObject);
    jsSource.type = 'join-table';
    return jsSource;
}     

export async function buildDotNetJoinTableDataSource(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetJoinTableDataSourceGenerated } = await import('./joinTableDataSource.gb');
    return await buildDotNetJoinTableDataSourceGenerated(jsObject, viewId);
}
