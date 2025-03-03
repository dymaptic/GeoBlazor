
export async function buildJsPrintCompleteEventResults(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPrintCompleteEventResultsGenerated } = await import('./printCompleteEventResults.gb');
    return await buildJsPrintCompleteEventResultsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPrintCompleteEventResults(jsObject: any): Promise<any> {
    let { buildDotNetPrintCompleteEventResultsGenerated } = await import('./printCompleteEventResults.gb');
    return await buildDotNetPrintCompleteEventResultsGenerated(jsObject);
}
