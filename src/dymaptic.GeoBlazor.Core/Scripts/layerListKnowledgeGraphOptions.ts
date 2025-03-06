
export async function buildJsLayerListKnowledgeGraphOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerListKnowledgeGraphOptionsGenerated } = await import('./layerListKnowledgeGraphOptions.gb');
    return await buildJsLayerListKnowledgeGraphOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerListKnowledgeGraphOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLayerListKnowledgeGraphOptionsGenerated } = await import('./layerListKnowledgeGraphOptions.gb');
    return await buildDotNetLayerListKnowledgeGraphOptionsGenerated(jsObject, layerId, viewId);
}
