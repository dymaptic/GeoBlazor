
export async function buildJsFeatureTableVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureTableVisibleElementsGenerated } = await import('./featureTableVisibleElements.gb');
    return await buildJsFeatureTableVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureTableVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetFeatureTableVisibleElementsGenerated } = await import('./featureTableVisibleElements.gb');
    return await buildDotNetFeatureTableVisibleElementsGenerated(jsObject);
}
