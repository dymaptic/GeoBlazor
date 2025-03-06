
export async function buildJsDirectionsViewModelTimeAttribute(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectionsViewModelTimeAttributeGenerated } = await import('./directionsViewModelTimeAttribute.gb');
    return await buildJsDirectionsViewModelTimeAttributeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectionsViewModelTimeAttribute(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDirectionsViewModelTimeAttributeGenerated } = await import('./directionsViewModelTimeAttribute.gb');
    return await buildDotNetDirectionsViewModelTimeAttributeGenerated(jsObject, layerId, viewId);
}
