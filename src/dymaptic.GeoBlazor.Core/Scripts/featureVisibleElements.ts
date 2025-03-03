
export async function buildJsFeatureVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureVisibleElementsGenerated } = await import('./featureVisibleElements.gb');
    return await buildJsFeatureVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetFeatureVisibleElementsGenerated } = await import('./featureVisibleElements.gb');
    return await buildDotNetFeatureVisibleElementsGenerated(jsObject);
}
