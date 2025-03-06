
export async function buildJsKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsKnowledgeGraphSublayerElevationInfoFeatureExpressionInfoGenerated } = await import('./knowledgeGraphSublayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsKnowledgeGraphSublayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetKnowledgeGraphSublayerElevationInfoFeatureExpressionInfoGenerated } = await import('./knowledgeGraphSublayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetKnowledgeGraphSublayerElevationInfoFeatureExpressionInfoGenerated(jsObject, layerId, viewId);
}
