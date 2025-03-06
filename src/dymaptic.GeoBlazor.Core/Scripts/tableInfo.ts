
export async function buildJsTableInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableInfoGenerated } = await import('./tableInfo.gb');
    return await buildJsTableInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTableInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTableInfoGenerated } = await import('./tableInfo.gb');
    return await buildDotNetTableInfoGenerated(jsObject, layerId, viewId);
}
