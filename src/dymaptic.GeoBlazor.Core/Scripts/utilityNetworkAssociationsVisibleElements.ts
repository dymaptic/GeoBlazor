
export async function buildJsUtilityNetworkAssociationsVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUtilityNetworkAssociationsVisibleElementsGenerated } = await import('./utilityNetworkAssociationsVisibleElements.gb');
    return await buildJsUtilityNetworkAssociationsVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUtilityNetworkAssociationsVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUtilityNetworkAssociationsVisibleElementsGenerated } = await import('./utilityNetworkAssociationsVisibleElements.gb');
    return await buildDotNetUtilityNetworkAssociationsVisibleElementsGenerated(jsObject, layerId, viewId);
}
