
export async function buildJsArcGISImageServiceCapabilitiesMensuration(dotNetObject: any): Promise<any> {
    let { buildJsArcGISImageServiceCapabilitiesMensurationGenerated } = await import('./arcGISImageServiceCapabilitiesMensuration.gb');
    return await buildJsArcGISImageServiceCapabilitiesMensurationGenerated(dotNetObject);
}     

export async function buildDotNetArcGISImageServiceCapabilitiesMensuration(jsObject: any): Promise<any> {
    let { buildDotNetArcGISImageServiceCapabilitiesMensurationGenerated } = await import('./arcGISImageServiceCapabilitiesMensuration.gb');
    return await buildDotNetArcGISImageServiceCapabilitiesMensurationGenerated(jsObject);
}
