
export async function buildJsLayerListKnowledgeGraphOptionsVisibleElements(dotNetObject: any): Promise<any> {
    let { buildJsLayerListKnowledgeGraphOptionsVisibleElementsGenerated } = await import('./layerListKnowledgeGraphOptionsVisibleElements.gb');
    return await buildJsLayerListKnowledgeGraphOptionsVisibleElementsGenerated(dotNetObject);
}     

export async function buildDotNetLayerListKnowledgeGraphOptionsVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetLayerListKnowledgeGraphOptionsVisibleElementsGenerated } = await import('./layerListKnowledgeGraphOptionsVisibleElements.gb');
    return await buildDotNetLayerListKnowledgeGraphOptionsVisibleElementsGenerated(jsObject);
}
