
export async function buildJsPointCloudLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudLayerElevationInfoGenerated } = await import('./pointCloudLayerElevationInfo.gb');
    return await buildJsPointCloudLayerElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointCloudLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetPointCloudLayerElevationInfoGenerated } = await import('./pointCloudLayerElevationInfo.gb');
    return await buildDotNetPointCloudLayerElevationInfoGenerated(jsObject);
}
