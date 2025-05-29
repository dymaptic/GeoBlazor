
export async function buildJsKnowledgeGraphSublayerCapabilitiesQuery(dotNetObject: any): Promise<any> {
    let { buildJsKnowledgeGraphSublayerCapabilitiesQueryGenerated } = await import('./knowledgeGraphSublayerCapabilitiesQuery.gb');
    return await buildJsKnowledgeGraphSublayerCapabilitiesQueryGenerated(dotNetObject);
}     

export async function buildDotNetKnowledgeGraphSublayerCapabilitiesQuery(jsObject: any): Promise<any> {
    let { buildDotNetKnowledgeGraphSublayerCapabilitiesQueryGenerated } = await import('./knowledgeGraphSublayerCapabilitiesQuery.gb');
    return await buildDotNetKnowledgeGraphSublayerCapabilitiesQueryGenerated(jsObject);
}
