
export async function buildJsJoinTableDataSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsJoinTableDataSourceGenerated } = await import('./joinTableDataSource.gb');
    let jsSource = await buildJsJoinTableDataSourceGenerated(dotNetObject, layerId, viewId);
    jsSource.type = 'join-table';
    return jsSource;
}     

export async function buildDotNetJoinTableDataSource(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetJoinTableDataSourceGenerated } = await import('./joinTableDataSource.gb');
    return await buildDotNetJoinTableDataSourceGenerated(jsObject, layerId, viewId);
}
