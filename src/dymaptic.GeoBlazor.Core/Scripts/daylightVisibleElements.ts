
export async function buildJsDaylightVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDaylightVisibleElementsGenerated } = await import('./daylightVisibleElements.gb');
    return await buildJsDaylightVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDaylightVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDaylightVisibleElementsGenerated } = await import('./daylightVisibleElements.gb');
    return await buildDotNetDaylightVisibleElementsGenerated(jsObject, layerId, viewId);
}
