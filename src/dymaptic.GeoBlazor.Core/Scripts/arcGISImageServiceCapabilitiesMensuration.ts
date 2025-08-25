
export async function buildJsArcGISImageServiceCapabilitiesMensuration(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsArcGISImageServiceCapabilitiesMensurationGenerated } = await import('./arcGISImageServiceCapabilitiesMensuration.gb');
    return await buildJsArcGISImageServiceCapabilitiesMensurationGenerated(dotNetObject, viewId);
}     

export async function buildDotNetArcGISImageServiceCapabilitiesMensuration(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetArcGISImageServiceCapabilitiesMensurationGenerated } = await import('./arcGISImageServiceCapabilitiesMensuration.gb');
    return await buildDotNetArcGISImageServiceCapabilitiesMensurationGenerated(jsObject, viewId);
}
