export async function buildJsDirectionsFeature(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDirectionsFeatureGenerated} = await import('./directionsFeature.gb');
    return await buildJsDirectionsFeatureGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDirectionsFeature(jsObject: any): Promise<any> {
    let {buildDotNetDirectionsFeatureGenerated} = await import('./directionsFeature.gb');
    return await buildDotNetDirectionsFeatureGenerated(jsObject);
}
