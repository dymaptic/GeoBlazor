
export async function buildJsKnowledgeGraphSublayerElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsKnowledgeGraphSublayerElevationInfoGenerated } = await import('./knowledgeGraphSublayerElevationInfo.gb');
    return await buildJsKnowledgeGraphSublayerElevationInfoGenerated(dotNetObject);
}     

export async function buildDotNetKnowledgeGraphSublayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetKnowledgeGraphSublayerElevationInfoGenerated } = await import('./knowledgeGraphSublayerElevationInfo.gb');
    return await buildDotNetKnowledgeGraphSublayerElevationInfoGenerated(jsObject);
}
