
export async function buildJsSymbolUtilsGetLegendLabelOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbolUtilsGetLegendLabelOptionsGenerated } = await import('./symbolUtilsGetLegendLabelOptions.gb');
    return await buildJsSymbolUtilsGetLegendLabelOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSymbolUtilsGetLegendLabelOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSymbolUtilsGetLegendLabelOptionsGenerated } = await import('./symbolUtilsGetLegendLabelOptions.gb');
    return await buildDotNetSymbolUtilsGetLegendLabelOptionsGenerated(jsObject, layerId, viewId);
}
