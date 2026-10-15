
export async function buildJsDirectionsFeatureSet(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectionsFeatureSetGenerated } = await import('./directionsFeatureSet.gb');
    return await buildJsDirectionsFeatureSetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectionsFeatureSet(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDirectionsFeatureSetGenerated } = await import('./directionsFeatureSet.gb');
    return await buildDotNetDirectionsFeatureSetGenerated(jsObject, layerId, viewId);
}
