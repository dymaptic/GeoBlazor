
export async function buildJsStreamLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStreamLayerElevationInfoGenerated } = await import('./streamLayerElevationInfo.gb');
    return await buildJsStreamLayerElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStreamLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetStreamLayerElevationInfoGenerated } = await import('./streamLayerElevationInfo.gb');
    return await buildDotNetStreamLayerElevationInfoGenerated(jsObject);
}
