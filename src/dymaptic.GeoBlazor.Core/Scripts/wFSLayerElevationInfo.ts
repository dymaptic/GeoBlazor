
export async function buildJsWFSLayerElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsWFSLayerElevationInfoGenerated } = await import('./wFSLayerElevationInfo.gb');
    return await buildJsWFSLayerElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetWFSLayerElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetWFSLayerElevationInfoGenerated } = await import('./wFSLayerElevationInfo.gb');
    return await buildDotNetWFSLayerElevationInfoGenerated(jsObject, viewId);
}
