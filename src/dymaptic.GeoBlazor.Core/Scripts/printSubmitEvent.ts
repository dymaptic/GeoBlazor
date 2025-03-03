
export async function buildJsPrintSubmitEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPrintSubmitEventGenerated } = await import('./printSubmitEvent.gb');
    return await buildJsPrintSubmitEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPrintSubmitEvent(jsObject: any): Promise<any> {
    let { buildDotNetPrintSubmitEventGenerated } = await import('./printSubmitEvent.gb');
    return await buildDotNetPrintSubmitEventGenerated(jsObject);
}
