
export async function buildJsStreamLayerElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsStreamLayerElevationInfoGenerated } = await import('./streamLayerElevationInfo.gb');
    return await buildJsStreamLayerElevationInfoGenerated(dotNetObject);
}     

export async function buildDotNetStreamLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetStreamLayerElevationInfoGenerated } = await import('./streamLayerElevationInfo.gb');
    return await buildDotNetStreamLayerElevationInfoGenerated(jsObject);
}
