
export async function buildJsFeatureTemplatesVisibleElements(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsFeatureTemplatesVisibleElementsGenerated } = await import('./featureTemplatesVisibleElements.gb');
    return await buildJsFeatureTemplatesVisibleElementsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetFeatureTemplatesVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureTemplatesVisibleElementsGenerated } = await import('./featureTemplatesVisibleElements.gb');
    return await buildDotNetFeatureTemplatesVisibleElementsGenerated(jsObject, viewId);
}
