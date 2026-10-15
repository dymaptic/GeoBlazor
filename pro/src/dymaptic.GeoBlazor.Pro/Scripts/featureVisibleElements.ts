
export async function buildJsFeatureVisibleElements(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsFeatureVisibleElementsGenerated } = await import('./featureVisibleElements.gb');
    return await buildJsFeatureVisibleElementsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetFeatureVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureVisibleElementsGenerated } = await import('./featureVisibleElements.gb');
    return await buildDotNetFeatureVisibleElementsGenerated(jsObject, viewId);
}
