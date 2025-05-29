
export async function buildJsITableListViewModelTables(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsITableListViewModelTablesGenerated } = await import('./iTableListViewModelTables.gb');
    return await buildJsITableListViewModelTablesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetITableListViewModelTables(jsObject: any): Promise<any> {
    let { buildDotNetITableListViewModelTablesGenerated } = await import('./iTableListViewModelTables.gb');
    return await buildDotNetITableListViewModelTablesGenerated(jsObject);
}
