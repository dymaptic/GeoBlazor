
export async function buildJsLegendViewModelLayerInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLegendViewModelLayerInfoGenerated } = await import('./legendViewModelLayerInfo.gb');
    return await buildJsLegendViewModelLayerInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLegendViewModelLayerInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLegendViewModelLayerInfoGenerated } = await import('./legendViewModelLayerInfo.gb');
    return await buildDotNetLegendViewModelLayerInfoGenerated(jsObject);
}
