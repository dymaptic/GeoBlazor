export async function buildJsPrintExport(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPrintExportGenerated } = await import('./printExport.gb');
    return await buildJsPrintExportGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPrintExport(jsObject: any): Promise<any> {
    let { buildDotNetPrintExportGenerated } = await import('./printExport.gb');
    return await buildDotNetPrintExportGenerated(jsObject);
}
