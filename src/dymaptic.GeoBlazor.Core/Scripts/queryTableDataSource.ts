export async function buildJsQueryTableDataSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsQueryTableDataSourceGenerated} = await import('./queryTableDataSource.gb');
    let jsSource = await buildJsQueryTableDataSourceGenerated(dotNetObject, layerId, viewId);
    jsSource.type = 'query-table';
    return jsSource;
}

export async function buildDotNetQueryTableDataSource(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetQueryTableDataSourceGenerated} = await import('./queryTableDataSource.gb');
    return await buildDotNetQueryTableDataSourceGenerated(jsObject, layerId, viewId);
}
