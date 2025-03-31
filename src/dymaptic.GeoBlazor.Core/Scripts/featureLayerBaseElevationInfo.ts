
export async function buildJsFeatureLayerBaseElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsFeatureLayerBaseElevationInfoGenerated } = await import('./featureLayerBaseElevationInfo.gb');
    return await buildJsFeatureLayerBaseElevationInfoGenerated(dotNetObject);
}     

export async function buildDotNetFeatureLayerBaseElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetFeatureLayerBaseElevationInfoGenerated } = await import('./featureLayerBaseElevationInfo.gb');
    return await buildDotNetFeatureLayerBaseElevationInfoGenerated(jsObject);
}
