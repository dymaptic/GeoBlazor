
export async function buildJsIPSInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIPSInfoGenerated } = await import('./iPSInfo.gb');
    return await buildJsIPSInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIPSInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIPSInfoGenerated } = await import('./iPSInfo.gb');
    return await buildDotNetIPSInfoGenerated(jsObject, viewId);
}
