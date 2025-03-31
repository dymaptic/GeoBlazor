
export async function buildJsDirectionsVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectionsVisibleElementsGenerated } = await import('./directionsVisibleElements.gb');
    return await buildJsDirectionsVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectionsVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDirectionsVisibleElementsGenerated } = await import('./directionsVisibleElements.gb');
    return await buildDotNetDirectionsVisibleElementsGenerated(jsObject, layerId, viewId);
}
