export async function buildJsServiceContentsTables(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsServiceContentsTablesGenerated } = await import('./serviceContentsTables.gb');
    return await buildJsServiceContentsTablesGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetServiceContentsTables(jsObject: any): Promise<any> {
    let { buildDotNetServiceContentsTablesGenerated } = await import('./serviceContentsTables.gb');
    return await buildDotNetServiceContentsTablesGenerated(jsObject);
}
