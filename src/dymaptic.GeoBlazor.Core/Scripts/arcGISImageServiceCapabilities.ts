
export async function buildJsArcGISImageServiceCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsArcGISImageServiceCapabilitiesGenerated } = await import('./arcGISImageServiceCapabilities.gb');
    return await buildJsArcGISImageServiceCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetArcGISImageServiceCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetArcGISImageServiceCapabilitiesGenerated } = await import('./arcGISImageServiceCapabilities.gb');
    return await buildDotNetArcGISImageServiceCapabilitiesGenerated(jsObject);
}
