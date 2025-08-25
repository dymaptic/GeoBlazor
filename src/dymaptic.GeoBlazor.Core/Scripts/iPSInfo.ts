
export async function buildJsIPSInfo(dotNetObject: any): Promise<any> {
    let { buildJsIPSInfoGenerated } = await import('./iPSInfo.gb');
    return null;
}     

export async function buildDotNetIPSInfo(jsObject: any): Promise<any> {
    let { buildDotNetIPSInfoGenerated } = await import('./iPSInfo.gb');
    return await buildDotNetIPSInfoGenerated(jsObject);
}
