
export async function buildJsGraphicsLayerElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsGraphicsLayerElevationInfoGenerated } = await import('./graphicsLayerElevationInfo.gb');
    return await buildJsGraphicsLayerElevationInfoGenerated(dotNetObject);
}     

export async function buildDotNetGraphicsLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetGraphicsLayerElevationInfoGenerated } = await import('./graphicsLayerElevationInfo.gb');
    return await buildDotNetGraphicsLayerElevationInfoGenerated(jsObject);
}
