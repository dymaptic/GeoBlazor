// override generated code in this file
export async function buildJsQuery(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsQueryGenerated } = await import('./query.gb');
    return await buildJsQueryGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetQuery(jsObject: any): Promise<any> {
    let { buildDotNetQueryGenerated } = await import('./query.gb');
    return await buildDotNetQueryGenerated(jsObject);
}
