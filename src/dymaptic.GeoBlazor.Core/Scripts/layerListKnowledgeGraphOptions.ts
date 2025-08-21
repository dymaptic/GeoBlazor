
export async function buildJsLayerListKnowledgeGraphOptions(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsLayerListKnowledgeGraphOptionsGenerated } = await import('./layerListKnowledgeGraphOptions.gb');
    return await buildJsLayerListKnowledgeGraphOptionsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetLayerListKnowledgeGraphOptions(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLayerListKnowledgeGraphOptionsGenerated } = await import('./layerListKnowledgeGraphOptions.gb');
    return await buildDotNetLayerListKnowledgeGraphOptionsGenerated(jsObject, viewId);
}
