
export async function buildJsWCSCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWCSCapabilitiesGenerated } = await import('./wCSCapabilities.gb');
    return await buildJsWCSCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWCSCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetWCSCapabilitiesGenerated } = await import('./wCSCapabilities.gb');
    return await buildDotNetWCSCapabilitiesGenerated(jsObject);
}
