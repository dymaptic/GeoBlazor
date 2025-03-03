
export async function buildJsGraphicsLayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGraphicsLayerElevationInfoGenerated } = await import('./graphicsLayerElevationInfo.gb');
    return await buildJsGraphicsLayerElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGraphicsLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetGraphicsLayerElevationInfoGenerated } = await import('./graphicsLayerElevationInfo.gb');
    return await buildDotNetGraphicsLayerElevationInfoGenerated(jsObject);
}
