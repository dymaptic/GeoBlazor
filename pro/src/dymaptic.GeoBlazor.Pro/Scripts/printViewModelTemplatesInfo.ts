
export async function buildJsPrintViewModelTemplatesInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPrintViewModelTemplatesInfoGenerated } = await import('./printViewModelTemplatesInfo.gb');
    return await buildJsPrintViewModelTemplatesInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPrintViewModelTemplatesInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPrintViewModelTemplatesInfoGenerated } = await import('./printViewModelTemplatesInfo.gb');
    return await buildDotNetPrintViewModelTemplatesInfoGenerated(jsObject, viewId);
}
