export async function buildJsSearchSourceFilter(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSearchSourceFilterGenerated} = await import('./searchSourceFilter.gb');
    return await buildJsSearchSourceFilterGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSearchSourceFilter(jsObject: any): Promise<any> {
    let {buildDotNetSearchSourceFilterGenerated} = await import('./searchSourceFilter.gb');
    return await buildDotNetSearchSourceFilterGenerated(jsObject);
}
