
export async function buildJsDefaultEditingCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDefaultEditingCapabilitiesGenerated } = await import('./defaultEditingCapabilities.gb');
    return await buildJsDefaultEditingCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDefaultEditingCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetDefaultEditingCapabilitiesGenerated } = await import('./defaultEditingCapabilities.gb');
    return await buildDotNetDefaultEditingCapabilitiesGenerated(jsObject);
}
