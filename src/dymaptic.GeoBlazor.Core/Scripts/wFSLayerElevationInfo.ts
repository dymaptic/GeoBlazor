
export async function buildJsWFSLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSLayerElevationInfoGenerated } = await import('./wFSLayerElevationInfo.gb');
    return await buildJsWFSLayerElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWFSLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetWFSLayerElevationInfoGenerated } = await import('./wFSLayerElevationInfo.gb');
    return await buildDotNetWFSLayerElevationInfoGenerated(jsObject);
}
