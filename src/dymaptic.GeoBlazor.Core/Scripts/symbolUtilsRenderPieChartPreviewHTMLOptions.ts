
export async function buildJsSymbolUtilsRenderPieChartPreviewHTMLOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbolUtilsRenderPieChartPreviewHTMLOptionsGenerated } = await import('./symbolUtilsRenderPieChartPreviewHTMLOptions.gb');
    return await buildJsSymbolUtilsRenderPieChartPreviewHTMLOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSymbolUtilsRenderPieChartPreviewHTMLOptions(jsObject: any): Promise<any> {
    let { buildDotNetSymbolUtilsRenderPieChartPreviewHTMLOptionsGenerated } = await import('./symbolUtilsRenderPieChartPreviewHTMLOptions.gb');
    return await buildDotNetSymbolUtilsRenderPieChartPreviewHTMLOptionsGenerated(jsObject);
}
