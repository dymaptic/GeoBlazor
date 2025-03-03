
export async function buildJsElevationProfileVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElevationProfileVisibleElementsGenerated } = await import('./elevationProfileVisibleElements.gb');
    return await buildJsElevationProfileVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetElevationProfileVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetElevationProfileVisibleElementsGenerated } = await import('./elevationProfileVisibleElements.gb');
    return await buildDotNetElevationProfileVisibleElementsGenerated(jsObject);
}
