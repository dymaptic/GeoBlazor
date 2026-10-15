
export async function buildJsFeatureFormVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureFormVisibleElementsGenerated } = await import('./featureFormVisibleElements.gb');
    return await buildJsFeatureFormVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureFormVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureFormVisibleElementsGenerated } = await import('./featureFormVisibleElements.gb');
    return await buildDotNetFeatureFormVisibleElementsGenerated(jsObject, viewId);
}
