export async function buildJsWFSCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWFSCapabilitiesGenerated} = await import('./wFSCapabilities.gb');
    return await buildJsWFSCapabilitiesGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWFSCapabilities(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetWFSCapabilitiesGenerated} = await import('./wFSCapabilities.gb');
    return await buildDotNetWFSCapabilitiesGenerated(jsObject, layerId, viewId);
}
