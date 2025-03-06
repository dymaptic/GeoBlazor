
export async function buildJsKnowledgeGraphSublayerElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsKnowledgeGraphSublayerElevationInfoGenerated } = await import('./knowledgeGraphSublayerElevationInfo.gb');
    return await buildJsKnowledgeGraphSublayerElevationInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetKnowledgeGraphSublayerElevationInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetKnowledgeGraphSublayerElevationInfoGenerated } = await import('./knowledgeGraphSublayerElevationInfo.gb');
    return await buildDotNetKnowledgeGraphSublayerElevationInfoGenerated(jsObject, layerId, viewId);
}
