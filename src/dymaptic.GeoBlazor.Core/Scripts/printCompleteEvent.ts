
export async function buildJsPrintCompleteEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPrintCompleteEventGenerated } = await import('./printCompleteEvent.gb');
    return await buildJsPrintCompleteEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPrintCompleteEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPrintCompleteEventGenerated } = await import('./printCompleteEvent.gb');
    return await buildDotNetPrintCompleteEventGenerated(jsObject, layerId, viewId);
}
