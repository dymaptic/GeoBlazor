
export async function buildJsKnowledgeGraphSublayerElevationInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsKnowledgeGraphSublayerElevationInfoGenerated } = await import('./knowledgeGraphSublayerElevationInfo.gb');
    return await buildJsKnowledgeGraphSublayerElevationInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetKnowledgeGraphSublayerElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetKnowledgeGraphSublayerElevationInfoGenerated } = await import('./knowledgeGraphSublayerElevationInfo.gb');
    return await buildDotNetKnowledgeGraphSublayerElevationInfoGenerated(jsObject, viewId);
}
