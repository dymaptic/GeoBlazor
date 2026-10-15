
export async function buildJsNetworkFromPortalItemParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsNetworkFromPortalItemParamsGenerated } = await import('./networkFromPortalItemParams.gb');
    return await buildJsNetworkFromPortalItemParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetNetworkFromPortalItemParams(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetNetworkFromPortalItemParamsGenerated } = await import('./networkFromPortalItemParams.gb');
    return await buildDotNetNetworkFromPortalItemParamsGenerated(jsObject, layerId, viewId);
}
