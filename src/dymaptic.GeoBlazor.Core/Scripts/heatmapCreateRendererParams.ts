export async function buildJsHeatmapCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsHeatmapCreateRendererParamsGenerated} = await import('./heatmapCreateRendererParams.gb');
    return await buildJsHeatmapCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetHeatmapCreateRendererParams(jsObject: any): Promise<any> {
    let {buildDotNetHeatmapCreateRendererParamsGenerated} = await import('./heatmapCreateRendererParams.gb');
    return await buildDotNetHeatmapCreateRendererParamsGenerated(jsObject);
}
