
export async function buildJsUtilityNetworkTraceProps(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUtilityNetworkTracePropsGenerated } = await import('./utilityNetworkTraceProps.gb');
    return await buildJsUtilityNetworkTracePropsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUtilityNetworkTraceProps(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUtilityNetworkTracePropsGenerated } = await import('./utilityNetworkTraceProps.gb');
    return await buildDotNetUtilityNetworkTracePropsGenerated(jsObject, layerId, viewId);
}
