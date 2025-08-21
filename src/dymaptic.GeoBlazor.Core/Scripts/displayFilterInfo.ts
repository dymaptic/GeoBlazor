
export async function buildJsDisplayFilterInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDisplayFilterInfoGenerated } = await import('./displayFilterInfo.gb');
    return await buildJsDisplayFilterInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDisplayFilterInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetDisplayFilterInfoGenerated } = await import('./displayFilterInfo.gb');
    return await buildDotNetDisplayFilterInfoGenerated(jsObject, viewId);
}
