
export async function buildJsFeatureLayerBaseElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsFeatureLayerBaseElevationInfoGenerated } = await import('./featureLayerBaseElevationInfo.gb');
    return await buildJsFeatureLayerBaseElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetFeatureLayerBaseElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureLayerBaseElevationInfoGenerated } = await import('./featureLayerBaseElevationInfo.gb');
    return await buildDotNetFeatureLayerBaseElevationInfoGenerated(jsObject, viewId);
}
