
export async function buildJsIOrientedImageryLayerElevationSource(dotNetObject: any): Promise<any> {
    let { buildJsIOrientedImageryLayerElevationSourceGenerated } = await import('./iOrientedImageryLayerElevationSource.gb');
    return await buildJsIOrientedImageryLayerElevationSourceGenerated(dotNetObject);
}     

export async function buildDotNetIOrientedImageryLayerElevationSource(jsObject: any): Promise<any> {
    let { buildDotNetIOrientedImageryLayerElevationSourceGenerated } = await import('./iOrientedImageryLayerElevationSource.gb');
    return await buildDotNetIOrientedImageryLayerElevationSourceGenerated(jsObject);
}
