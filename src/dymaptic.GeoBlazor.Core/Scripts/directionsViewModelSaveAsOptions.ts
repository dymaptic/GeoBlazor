export async function buildJsDirectionsViewModelSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectionsViewModelSaveAsOptionsGenerated } = await import('./directionsViewModelSaveAsOptions.gb');
    return await buildJsDirectionsViewModelSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetDirectionsViewModelSaveAsOptions(jsObject: any): Promise<any> {
    let { buildDotNetDirectionsViewModelSaveAsOptionsGenerated } = await import('./directionsViewModelSaveAsOptions.gb');
    return await buildDotNetDirectionsViewModelSaveAsOptionsGenerated(jsObject);
}
