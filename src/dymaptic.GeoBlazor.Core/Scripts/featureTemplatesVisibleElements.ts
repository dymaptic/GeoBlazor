
export async function buildJsFeatureTemplatesVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureTemplatesVisibleElementsGenerated } = await import('./featureTemplatesVisibleElements.gb');
    return await buildJsFeatureTemplatesVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureTemplatesVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetFeatureTemplatesVisibleElementsGenerated } = await import('./featureTemplatesVisibleElements.gb');
    return await buildDotNetFeatureTemplatesVisibleElementsGenerated(jsObject);
}
