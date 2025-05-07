
export async function buildJsSublayerCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSublayerCapabilitiesGenerated } = await import('./sublayerCapabilities.gb');
    return await buildJsSublayerCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSublayerCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetSublayerCapabilitiesGenerated } = await import('./sublayerCapabilities.gb');
    return await buildDotNetSublayerCapabilitiesGenerated(jsObject);
}
