
export async function buildJsKnowledgeGraphSublayerCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsKnowledgeGraphSublayerCapabilitiesGenerated } = await import('./knowledgeGraphSublayerCapabilities.gb');
    return await buildJsKnowledgeGraphSublayerCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetKnowledgeGraphSublayerCapabilities(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetKnowledgeGraphSublayerCapabilitiesGenerated } = await import('./knowledgeGraphSublayerCapabilities.gb');
    return await buildDotNetKnowledgeGraphSublayerCapabilitiesGenerated(jsObject, layerId, viewId);
}
