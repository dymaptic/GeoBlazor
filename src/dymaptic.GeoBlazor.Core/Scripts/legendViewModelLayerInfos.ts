
export async function buildJsLegendViewModelLayerInfos(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLegendViewModelLayerInfosGenerated } = await import('./legendViewModelLayerInfos.gb');
    return await buildJsLegendViewModelLayerInfosGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLegendViewModelLayerInfos(jsObject: any): Promise<any> {
    let { buildDotNetLegendViewModelLayerInfosGenerated } = await import('./legendViewModelLayerInfos.gb');
    return await buildDotNetLegendViewModelLayerInfosGenerated(jsObject);
}
