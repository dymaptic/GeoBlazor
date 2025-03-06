
export async function buildJsFeatureLayerBaseElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureLayerBaseElevationInfoGenerated } = await import('./featureLayerBaseElevationInfo.gb');
    return await buildJsFeatureLayerBaseElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureLayerBaseElevationInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureLayerBaseElevationInfoGenerated } = await import('./featureLayerBaseElevationInfo.gb');
    return await buildDotNetFeatureLayerBaseElevationInfoGenerated(jsObject, layerId, viewId);
}
