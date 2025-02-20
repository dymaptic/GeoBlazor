export async function buildJsLayerPerformanceInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLayerPerformanceInfoGenerated} = await import('./layerPerformanceInfo.gb');
    return await buildJsLayerPerformanceInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLayerPerformanceInfo(jsObject: any): Promise<any> {
    let {buildDotNetLayerPerformanceInfoGenerated} = await import('./layerPerformanceInfo.gb');
    return await buildDotNetLayerPerformanceInfoGenerated(jsObject);
}
