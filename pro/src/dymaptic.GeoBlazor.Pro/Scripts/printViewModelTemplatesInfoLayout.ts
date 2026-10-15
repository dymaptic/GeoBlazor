
export async function buildJsPrintViewModelTemplatesInfoLayout(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPrintViewModelTemplatesInfoLayoutGenerated } = await import('./printViewModelTemplatesInfoLayout.gb');
    return await buildJsPrintViewModelTemplatesInfoLayoutGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPrintViewModelTemplatesInfoLayout(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPrintViewModelTemplatesInfoLayoutGenerated } = await import('./printViewModelTemplatesInfoLayout.gb');
    return await buildDotNetPrintViewModelTemplatesInfoLayoutGenerated(jsObject, viewId);
}
