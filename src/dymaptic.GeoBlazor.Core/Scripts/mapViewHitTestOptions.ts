export async function buildJsMapViewHitTestOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMapViewHitTestOptionsGenerated} = await import('./mapViewHitTestOptions.gb');
    return await buildJsMapViewHitTestOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMapViewHitTestOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetMapViewHitTestOptionsGenerated} = await import('./mapViewHitTestOptions.gb');
    return await buildDotNetMapViewHitTestOptionsGenerated(jsObject, layerId, viewId);
}
