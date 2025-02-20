export async function buildJsUtilityNetworkTraceAddFlagErrorEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUtilityNetworkTraceAddFlagErrorEventGenerated} = await import('./utilityNetworkTraceAddFlagErrorEvent.gb');
    return await buildJsUtilityNetworkTraceAddFlagErrorEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUtilityNetworkTraceAddFlagErrorEvent(jsObject: any): Promise<any> {
    let {buildDotNetUtilityNetworkTraceAddFlagErrorEventGenerated} = await import('./utilityNetworkTraceAddFlagErrorEvent.gb');
    return await buildDotNetUtilityNetworkTraceAddFlagErrorEventGenerated(jsObject);
}
