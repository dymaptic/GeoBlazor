
export async function buildJsUtilityNetworkTraceAddFlagCompleteEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUtilityNetworkTraceAddFlagCompleteEventGenerated } = await import('./utilityNetworkTraceAddFlagCompleteEvent.gb');
    return await buildJsUtilityNetworkTraceAddFlagCompleteEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUtilityNetworkTraceAddFlagCompleteEvent(jsObject: any): Promise<any> {
    let { buildDotNetUtilityNetworkTraceAddFlagCompleteEventGenerated } = await import('./utilityNetworkTraceAddFlagCompleteEvent.gb');
    return await buildDotNetUtilityNetworkTraceAddFlagCompleteEventGenerated(jsObject);
}
