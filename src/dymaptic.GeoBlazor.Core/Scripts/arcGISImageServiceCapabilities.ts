
export async function buildJsArcGISImageServiceCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsArcGISImageServiceCapabilitiesGenerated } = await import('./arcGISImageServiceCapabilities.gb');
    return await buildJsArcGISImageServiceCapabilitiesGenerated(dotNetObject);
}     

export async function buildDotNetArcGISImageServiceCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetArcGISImageServiceCapabilitiesGenerated } = await import('./arcGISImageServiceCapabilities.gb');
    return await buildDotNetArcGISImageServiceCapabilitiesGenerated(jsObject);
}
