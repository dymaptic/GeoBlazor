
export async function buildJsStreamLayerElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsStreamLayerElevationInfoGenerated } = await import('./streamLayerElevationInfo.gb');
    return await buildJsStreamLayerElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetStreamLayerElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetStreamLayerElevationInfoGenerated } = await import('./streamLayerElevationInfo.gb');
    return await buildDotNetStreamLayerElevationInfoGenerated(jsObject, viewId);
}
