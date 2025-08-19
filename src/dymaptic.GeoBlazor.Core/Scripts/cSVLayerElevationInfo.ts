
export async function buildJsCSVLayerElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsCSVLayerElevationInfoGenerated } = await import('./cSVLayerElevationInfo.gb');
    return await buildJsCSVLayerElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetCSVLayerElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetCSVLayerElevationInfoGenerated } = await import('./cSVLayerElevationInfo.gb');
    return await buildDotNetCSVLayerElevationInfoGenerated(jsObject, viewId);
}
