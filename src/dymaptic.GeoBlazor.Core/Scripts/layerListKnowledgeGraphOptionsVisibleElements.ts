
export async function buildJsLayerListKnowledgeGraphOptionsVisibleElements(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsLayerListKnowledgeGraphOptionsVisibleElementsGenerated } = await import('./layerListKnowledgeGraphOptionsVisibleElements.gb');
    return await buildJsLayerListKnowledgeGraphOptionsVisibleElementsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetLayerListKnowledgeGraphOptionsVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLayerListKnowledgeGraphOptionsVisibleElementsGenerated } = await import('./layerListKnowledgeGraphOptionsVisibleElements.gb');
    return await buildDotNetLayerListKnowledgeGraphOptionsVisibleElementsGenerated(jsObject, viewId);
}
