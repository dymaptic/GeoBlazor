
export async function buildJsArcGISImageServiceCapabilities(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsArcGISImageServiceCapabilitiesGenerated } = await import('./arcGISImageServiceCapabilities.gb');
    return await buildJsArcGISImageServiceCapabilitiesGenerated(dotNetObject, viewId);
}     

export async function buildDotNetArcGISImageServiceCapabilities(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetArcGISImageServiceCapabilitiesGenerated } = await import('./arcGISImageServiceCapabilities.gb');
    return await buildDotNetArcGISImageServiceCapabilitiesGenerated(jsObject, viewId);
}
