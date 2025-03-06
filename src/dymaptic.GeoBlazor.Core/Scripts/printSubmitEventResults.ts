
export async function buildJsPrintSubmitEventResults(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPrintSubmitEventResultsGenerated } = await import('./printSubmitEventResults.gb');
    return await buildJsPrintSubmitEventResultsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPrintSubmitEventResults(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPrintSubmitEventResultsGenerated } = await import('./printSubmitEventResults.gb');
    return await buildDotNetPrintSubmitEventResultsGenerated(jsObject, layerId, viewId);
}
