export async function buildJsSearchSourceFilter(dotNetObject: any): Promise<any> {
    let {buildJsSearchSourceFilterGenerated} = await import('./searchSourceFilter.gb');
    return await buildJsSearchSourceFilterGenerated(dotNetObject);
}

export async function buildDotNetSearchSourceFilter(jsObject: any): Promise<any> {
    let {buildDotNetSearchSourceFilterGenerated} = await import('./searchSourceFilter.gb');
    return await buildDotNetSearchSourceFilterGenerated(jsObject);
}
