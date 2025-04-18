
export async function buildJsIPieChartRendererVisualVariables(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIPieChartRendererVisualVariablesGenerated } = await import('./iPieChartRendererVisualVariables.gb');
    return await buildJsIPieChartRendererVisualVariablesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIPieChartRendererVisualVariables(jsObject: any): Promise<any> {
    let { buildDotNetIPieChartRendererVisualVariablesGenerated } = await import('./iPieChartRendererVisualVariables.gb');
    return await buildDotNetIPieChartRendererVisualVariablesGenerated(jsObject);
}
