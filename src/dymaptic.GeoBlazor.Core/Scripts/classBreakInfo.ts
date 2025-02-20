export async function buildJsClassBreakInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsClassBreakInfoGenerated} = await import('./classBreakInfo.gb');
    return await buildJsClassBreakInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetClassBreakInfo(jsObject: any): Promise<any> {
    let {buildDotNetClassBreakInfoGenerated} = await import('./classBreakInfo.gb');
    return await buildDotNetClassBreakInfoGenerated(jsObject);
}
