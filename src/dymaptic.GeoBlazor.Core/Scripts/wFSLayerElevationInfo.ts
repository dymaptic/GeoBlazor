
export async function buildJsWFSLayerElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsWFSLayerElevationInfoGenerated } = await import('./wFSLayerElevationInfo.gb');
    return await buildJsWFSLayerElevationInfoGenerated(dotNetObject);
}     

export async function buildDotNetWFSLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetWFSLayerElevationInfoGenerated } = await import('./wFSLayerElevationInfo.gb');
    return await buildDotNetWFSLayerElevationInfoGenerated(jsObject);
}
