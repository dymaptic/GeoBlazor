export async function buildJsPieChartCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPieChartCreateRendererParamsGenerated} = await import('./pieChartCreateRendererParams.gb');
    return await buildJsPieChartCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPieChartCreateRendererParams(jsObject: any): Promise<any> {
    let {buildDotNetPieChartCreateRendererParamsGenerated} = await import('./pieChartCreateRendererParams.gb');
    return await buildDotNetPieChartCreateRendererParamsGenerated(jsObject);
}
