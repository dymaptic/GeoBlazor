
export async function buildJsPrintViewModelTemplatesInfoFormat(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPrintViewModelTemplatesInfoFormatGenerated } = await import('./printViewModelTemplatesInfoFormat.gb');
    return await buildJsPrintViewModelTemplatesInfoFormatGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPrintViewModelTemplatesInfoFormat(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPrintViewModelTemplatesInfoFormatGenerated } = await import('./printViewModelTemplatesInfoFormat.gb');
    return await buildDotNetPrintViewModelTemplatesInfoFormatGenerated(jsObject, viewId);
}
