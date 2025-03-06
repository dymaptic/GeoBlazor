
export async function buildJsCSVLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCSVLayerElevationInfoGenerated } = await import('./cSVLayerElevationInfo.gb');
    return await buildJsCSVLayerElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCSVLayerElevationInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCSVLayerElevationInfoGenerated } = await import('./cSVLayerElevationInfo.gb');
    return await buildDotNetCSVLayerElevationInfoGenerated(jsObject, layerId, viewId);
}
