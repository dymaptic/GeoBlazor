
export async function buildJsClassBreak(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassBreakGenerated } = await import('./classBreak.gb');
    return await buildJsClassBreakGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClassBreak(jsObject: any): Promise<any> {
    let { buildDotNetClassBreakGenerated } = await import('./classBreak.gb');
    return await buildDotNetClassBreakGenerated(jsObject);
}
