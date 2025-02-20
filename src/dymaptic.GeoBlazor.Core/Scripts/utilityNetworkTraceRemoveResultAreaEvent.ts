export async function buildJsUtilityNetworkTraceRemoveResultAreaEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUtilityNetworkTraceRemoveResultAreaEventGenerated} = await import('./utilityNetworkTraceRemoveResultAreaEvent.gb');
    return await buildJsUtilityNetworkTraceRemoveResultAreaEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUtilityNetworkTraceRemoveResultAreaEvent(jsObject: any): Promise<any> {
    let {buildDotNetUtilityNetworkTraceRemoveResultAreaEventGenerated} = await import('./utilityNetworkTraceRemoveResultAreaEvent.gb');
    return await buildDotNetUtilityNetworkTraceRemoveResultAreaEventGenerated(jsObject);
}
