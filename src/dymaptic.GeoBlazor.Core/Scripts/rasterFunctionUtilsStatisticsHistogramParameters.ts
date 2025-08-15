
export async function buildJsRasterFunctionUtilsStatisticsHistogramParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterFunctionUtilsStatisticsHistogramParametersGenerated } = await import('./rasterFunctionUtilsStatisticsHistogramParameters.gb');
    return await buildJsRasterFunctionUtilsStatisticsHistogramParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterFunctionUtilsStatisticsHistogramParameters(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRasterFunctionUtilsStatisticsHistogramParametersGenerated } = await import('./rasterFunctionUtilsStatisticsHistogramParameters.gb');
    return await buildDotNetRasterFunctionUtilsStatisticsHistogramParametersGenerated(jsObject, viewId);
}
