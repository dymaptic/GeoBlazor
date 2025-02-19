export async function buildJsKnowledgeGraph(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsKnowledgeGraphGenerated } = await import('./knowledgeGraph.gb');
    return await buildJsKnowledgeGraphGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetKnowledgeGraph(jsObject: any): Promise<any> {
    let { buildDotNetKnowledgeGraphGenerated } = await import('./knowledgeGraph.gb');
    return await buildDotNetKnowledgeGraphGenerated(jsObject);
}
