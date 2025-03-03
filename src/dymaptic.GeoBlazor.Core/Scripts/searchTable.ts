
export async function buildJsSearchTable(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchTableGenerated } = await import('./searchTable.gb');
    return await buildJsSearchTableGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchTable(jsObject: any): Promise<any> {
    let { buildDotNetSearchTableGenerated } = await import('./searchTable.gb');
    return await buildDotNetSearchTableGenerated(jsObject);
}
