export async function buildJsHeatmapUpdateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsHeatmapUpdateRendererParamsGenerated} = await import('./heatmapUpdateRendererParams.gb');
    return await buildJsHeatmapUpdateRendererParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetHeatmapUpdateRendererParams(jsObject: any): Promise<any> {
    let {buildDotNetHeatmapUpdateRendererParamsGenerated} = await import('./heatmapUpdateRendererParams.gb');
    return await buildDotNetHeatmapUpdateRendererParamsGenerated(jsObject);
}
