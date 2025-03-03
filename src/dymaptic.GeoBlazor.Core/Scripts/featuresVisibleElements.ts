
export async function buildJsFeaturesVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeaturesVisibleElementsGenerated } = await import('./featuresVisibleElements.gb');
    return await buildJsFeaturesVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeaturesVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetFeaturesVisibleElementsGenerated } = await import('./featuresVisibleElements.gb');
    return await buildDotNetFeaturesVisibleElementsGenerated(jsObject);
}
