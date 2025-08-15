
export async function buildJsPointCloudLayerElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsPointCloudLayerElevationInfoGenerated } = await import('./pointCloudLayerElevationInfo.gb');
    return await buildJsPointCloudLayerElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetPointCloudLayerElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPointCloudLayerElevationInfoGenerated } = await import('./pointCloudLayerElevationInfo.gb');
    return await buildDotNetPointCloudLayerElevationInfoGenerated(jsObject, viewId);
}
