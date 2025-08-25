
export async function buildJsGraphicsLayerElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsGraphicsLayerElevationInfoGenerated } = await import('./graphicsLayerElevationInfo.gb');
    return await buildJsGraphicsLayerElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetGraphicsLayerElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetGraphicsLayerElevationInfoGenerated } = await import('./graphicsLayerElevationInfo.gb');
    return await buildDotNetGraphicsLayerElevationInfoGenerated(jsObject, viewId);
}
