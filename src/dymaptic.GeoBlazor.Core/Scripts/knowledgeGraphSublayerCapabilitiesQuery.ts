
export async function buildJsKnowledgeGraphSublayerCapabilitiesQuery(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsKnowledgeGraphSublayerCapabilitiesQueryGenerated } = await import('./knowledgeGraphSublayerCapabilitiesQuery.gb');
    return await buildJsKnowledgeGraphSublayerCapabilitiesQueryGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetKnowledgeGraphSublayerCapabilitiesQuery(jsObject: any): Promise<any> {
    let { buildDotNetKnowledgeGraphSublayerCapabilitiesQueryGenerated } = await import('./knowledgeGraphSublayerCapabilitiesQuery.gb');
    return await buildDotNetKnowledgeGraphSublayerCapabilitiesQueryGenerated(jsObject);
}
