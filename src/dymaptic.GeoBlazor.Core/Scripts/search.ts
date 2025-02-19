
export async function buildJsSearch(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchGenerated } = await import('./search.gb');
    return await buildJsSearchGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearch(jsObject: any): Promise<any> {
    let { buildDotNetSearchGenerated } = await import('./search.gb');
    return await buildDotNetSearchGenerated(jsObject);
}
