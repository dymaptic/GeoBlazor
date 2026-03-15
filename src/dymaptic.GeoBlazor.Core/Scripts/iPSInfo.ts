
export async function buildJsIPSInfo(dotNetObject: any): Promise<any> {
    let { buildJsIPSInfoGenerated } = await import('./iPSInfo.gb');
    return null;
}     

export async function buildDotNetIPSInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIPSInfoGenerated } = await import('./iPSInfo.gb');
    return await buildDotNetIPSInfoGenerated(jsObject, layerId, viewId);
}
