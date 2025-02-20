export async function buildJsUtilityNetworkTraceCreateResultAreaEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUtilityNetworkTraceCreateResultAreaEventGenerated} = await import('./utilityNetworkTraceCreateResultAreaEvent.gb');
    return await buildJsUtilityNetworkTraceCreateResultAreaEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUtilityNetworkTraceCreateResultAreaEvent(jsObject: any): Promise<any> {
    let {buildDotNetUtilityNetworkTraceCreateResultAreaEventGenerated} = await import('./utilityNetworkTraceCreateResultAreaEvent.gb');
    return await buildDotNetUtilityNetworkTraceCreateResultAreaEventGenerated(jsObject);
}
