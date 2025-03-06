
export async function buildJsLayerListKnowledgeGraphOptionsVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerListKnowledgeGraphOptionsVisibleElementsGenerated } = await import('./layerListKnowledgeGraphOptionsVisibleElements.gb');
    return await buildJsLayerListKnowledgeGraphOptionsVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerListKnowledgeGraphOptionsVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLayerListKnowledgeGraphOptionsVisibleElementsGenerated } = await import('./layerListKnowledgeGraphOptionsVisibleElements.gb');
    return await buildDotNetLayerListKnowledgeGraphOptionsVisibleElementsGenerated(jsObject, layerId, viewId);
}
