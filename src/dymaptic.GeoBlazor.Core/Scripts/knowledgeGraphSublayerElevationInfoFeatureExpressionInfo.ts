
export async function buildJsKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsKnowledgeGraphSublayerElevationInfoFeatureExpressionInfoGenerated } = await import('./knowledgeGraphSublayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsKnowledgeGraphSublayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetKnowledgeGraphSublayerElevationInfoFeatureExpressionInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetKnowledgeGraphSublayerElevationInfoFeatureExpressionInfoGenerated } = await import('./knowledgeGraphSublayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetKnowledgeGraphSublayerElevationInfoFeatureExpressionInfoGenerated(jsObject, viewId);
}
