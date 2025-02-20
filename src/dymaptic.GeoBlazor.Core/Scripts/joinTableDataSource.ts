
export async function buildJsJoinTableDataSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsJoinTableDataSourceGenerated } = await import('./joinTableDataSource.gb');
    return await buildJsJoinTableDataSourceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetJoinTableDataSource(jsObject: any): Promise<any> {
    let { buildDotNetJoinTableDataSourceGenerated } = await import('./joinTableDataSource.gb');
    return await buildDotNetJoinTableDataSourceGenerated(jsObject);
}
