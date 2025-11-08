
export async function buildJsDisplayFilterInfo(dotNetObject: any): Promise<any> {
    let { buildJsDisplayFilterInfoGenerated } = await import('./displayFilterInfo.gb');
    return await buildJsDisplayFilterInfoGenerated(dotNetObject);
}     

export async function buildDotNetDisplayFilterInfo(jsObject: any): Promise<any> {
    let { buildDotNetDisplayFilterInfoGenerated } = await import('./displayFilterInfo.gb');
    return await buildDotNetDisplayFilterInfoGenerated(jsObject);
}
