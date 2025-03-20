
export async function buildJsLayerListKnowledgeGraphOptions(dotNetObject: any): Promise<any> {
    let { buildJsLayerListKnowledgeGraphOptionsGenerated } = await import('./layerListKnowledgeGraphOptions.gb');
    return await buildJsLayerListKnowledgeGraphOptionsGenerated(dotNetObject);
}     

export async function buildDotNetLayerListKnowledgeGraphOptions(jsObject: any): Promise<any> {
    let { buildDotNetLayerListKnowledgeGraphOptionsGenerated } = await import('./layerListKnowledgeGraphOptions.gb');
    return await buildDotNetLayerListKnowledgeGraphOptionsGenerated(jsObject);
}
