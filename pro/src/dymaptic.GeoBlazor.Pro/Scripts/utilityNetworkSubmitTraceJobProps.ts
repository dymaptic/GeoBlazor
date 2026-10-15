
export async function buildJsUtilityNetworkSubmitTraceJobProps(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUtilityNetworkSubmitTraceJobPropsGenerated } = await import('./utilityNetworkSubmitTraceJobProps.gb');
    return await buildJsUtilityNetworkSubmitTraceJobPropsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUtilityNetworkSubmitTraceJobProps(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUtilityNetworkSubmitTraceJobPropsGenerated } = await import('./utilityNetworkSubmitTraceJobProps.gb');
    return await buildDotNetUtilityNetworkSubmitTraceJobPropsGenerated(jsObject, layerId, viewId);
}
