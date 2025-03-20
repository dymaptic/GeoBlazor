
export async function buildJsPointCloudLayerElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsPointCloudLayerElevationInfoGenerated } = await import('./pointCloudLayerElevationInfo.gb');
    return await buildJsPointCloudLayerElevationInfoGenerated(dotNetObject);
}     

export async function buildDotNetPointCloudLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetPointCloudLayerElevationInfoGenerated } = await import('./pointCloudLayerElevationInfo.gb');
    return await buildDotNetPointCloudLayerElevationInfoGenerated(jsObject);
}
