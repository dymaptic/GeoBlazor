export async function buildJsDirectionsEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDirectionsEventGenerated} = await import('./directionsEvent.gb');
    return await buildJsDirectionsEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDirectionsEvent(jsObject: any): Promise<any> {
    let {buildDotNetDirectionsEventGenerated} = await import('./directionsEvent.gb');
    return await buildDotNetDirectionsEventGenerated(jsObject);
}
