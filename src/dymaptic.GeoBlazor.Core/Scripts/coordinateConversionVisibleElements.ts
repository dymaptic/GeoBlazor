
export async function buildJsCoordinateConversionVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCoordinateConversionVisibleElementsGenerated } = await import('./coordinateConversionVisibleElements.gb');
    return await buildJsCoordinateConversionVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCoordinateConversionVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCoordinateConversionVisibleElementsGenerated } = await import('./coordinateConversionVisibleElements.gb');
    return await buildDotNetCoordinateConversionVisibleElementsGenerated(jsObject, layerId, viewId);
}
