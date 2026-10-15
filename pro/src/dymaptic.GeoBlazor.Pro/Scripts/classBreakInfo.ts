export async function buildJsClassBreakInfo(dotNetObject: any): Promise<any> {
    let {buildJsClassBreakInfoGenerated} = await import('./classBreakInfo.gb');
    return await buildJsClassBreakInfoGenerated(dotNetObject);
}

export async function buildDotNetClassBreakInfo(jsObject: any): Promise<any> {
    let {buildDotNetClassBreakInfoGenerated} = await import('./classBreakInfo.gb');
    return await buildDotNetClassBreakInfoGenerated(jsObject);
}
