export async function buildJsUtilityNetworkTraceAddResultAreaEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUtilityNetworkTraceAddResultAreaEventGenerated } = await import('./utilityNetworkTraceAddResultAreaEvent.gb');
    return await buildJsUtilityNetworkTraceAddResultAreaEventGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetUtilityNetworkTraceAddResultAreaEvent(jsObject: any): Promise<any> {
    let { buildDotNetUtilityNetworkTraceAddResultAreaEventGenerated } = await import('./utilityNetworkTraceAddResultAreaEvent.gb');
    return await buildDotNetUtilityNetworkTraceAddResultAreaEventGenerated(jsObject);
}
