
export async function buildJsDirectionsViewModelImpedanceAttribute(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectionsViewModelImpedanceAttributeGenerated } = await import('./directionsViewModelImpedanceAttribute.gb');
    return await buildJsDirectionsViewModelImpedanceAttributeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectionsViewModelImpedanceAttribute(jsObject: any): Promise<any> {
    let { buildDotNetDirectionsViewModelImpedanceAttributeGenerated } = await import('./directionsViewModelImpedanceAttribute.gb');
    return await buildDotNetDirectionsViewModelImpedanceAttributeGenerated(jsObject);
}
