
export async function buildJsPieChartCreateRendererParamsAttributes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPieChartCreateRendererParamsAttributesGenerated } = await import('./pieChartCreateRendererParamsAttributes.gb');
    return await buildJsPieChartCreateRendererParamsAttributesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPieChartCreateRendererParamsAttributes(jsObject: any): Promise<any> {
    let { buildDotNetPieChartCreateRendererParamsAttributesGenerated } = await import('./pieChartCreateRendererParamsAttributes.gb');
    return await buildDotNetPieChartCreateRendererParamsAttributesGenerated(jsObject);
}
