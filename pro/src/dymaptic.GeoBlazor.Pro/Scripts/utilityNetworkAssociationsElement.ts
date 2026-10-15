
export async function buildJsUtilityNetworkAssociationsElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUtilityNetworkAssociationsElementGenerated } = await import('./utilityNetworkAssociationsElement.gb');
    return await buildJsUtilityNetworkAssociationsElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUtilityNetworkAssociationsElement(jsObject: any): Promise<any> {
    let { buildDotNetUtilityNetworkAssociationsElementGenerated } = await import('./utilityNetworkAssociationsElement.gb');
    return await buildDotNetUtilityNetworkAssociationsElementGenerated(jsObject);
}
