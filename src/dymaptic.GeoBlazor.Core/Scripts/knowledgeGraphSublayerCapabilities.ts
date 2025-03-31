
export async function buildJsKnowledgeGraphSublayerCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsKnowledgeGraphSublayerCapabilitiesGenerated } = await import('./knowledgeGraphSublayerCapabilities.gb');
    return await buildJsKnowledgeGraphSublayerCapabilitiesGenerated(dotNetObject);
}     

export async function buildDotNetKnowledgeGraphSublayerCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetKnowledgeGraphSublayerCapabilitiesGenerated } = await import('./knowledgeGraphSublayerCapabilities.gb');
    return await buildDotNetKnowledgeGraphSublayerCapabilitiesGenerated(jsObject);
}
