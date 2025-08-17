
export async function buildJsIArcGISImageService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIArcGISImageServiceGenerated } = await import('./iArcGISImageService.gb');
    return await buildJsIArcGISImageServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIArcGISImageService(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIArcGISImageServiceGenerated } = await import('./iArcGISImageService.gb');
    return await buildDotNetIArcGISImageServiceGenerated(jsObject, viewId);
}
