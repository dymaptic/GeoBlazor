
export async function buildJsIOrientedImageryLayerElevationSource(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIOrientedImageryLayerElevationSourceGenerated } = await import('./iOrientedImageryLayerElevationSource.gb');
    return await buildJsIOrientedImageryLayerElevationSourceGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIOrientedImageryLayerElevationSource(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIOrientedImageryLayerElevationSourceGenerated } = await import('./iOrientedImageryLayerElevationSource.gb');
    return await buildDotNetIOrientedImageryLayerElevationSourceGenerated(jsObject, viewId);
}
