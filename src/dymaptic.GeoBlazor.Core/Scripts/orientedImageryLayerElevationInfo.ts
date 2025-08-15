
export async function buildJsOrientedImageryLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOrientedImageryLayerElevationInfoGenerated } = await import('./orientedImageryLayerElevationInfo.gb');
    return await buildJsOrientedImageryLayerElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOrientedImageryLayerElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetOrientedImageryLayerElevationInfoGenerated } = await import('./orientedImageryLayerElevationInfo.gb');
    return await buildDotNetOrientedImageryLayerElevationInfoGenerated(jsObject, viewId);
}
