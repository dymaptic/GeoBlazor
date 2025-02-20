export async function buildJsValidateNetworkTopologyParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsValidateNetworkTopologyParametersGenerated} = await import('./validateNetworkTopologyParameters.gb');
    return await buildJsValidateNetworkTopologyParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetValidateNetworkTopologyParameters(jsObject: any): Promise<any> {
    let {buildDotNetValidateNetworkTopologyParametersGenerated} = await import('./validateNetworkTopologyParameters.gb');
    return await buildDotNetValidateNetworkTopologyParametersGenerated(jsObject);
}
