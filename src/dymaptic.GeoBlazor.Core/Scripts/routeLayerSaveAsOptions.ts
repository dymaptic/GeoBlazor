
export async function buildJsRouteLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRouteLayerSaveAsOptionsGenerated } = await import('./routeLayerSaveAsOptions.gb');
    return await buildJsRouteLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRouteLayerSaveAsOptions(jsObject: any): Promise<any> {
    let { buildDotNetRouteLayerSaveAsOptionsGenerated } = await import('./routeLayerSaveAsOptions.gb');
    return await buildDotNetRouteLayerSaveAsOptionsGenerated(jsObject);
}
