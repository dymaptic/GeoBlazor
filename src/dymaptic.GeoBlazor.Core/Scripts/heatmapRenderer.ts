export async function buildJsHeatmapRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsHeatmapRendererGenerated} = await import('./heatmapRenderer.gb');
    return await buildJsHeatmapRendererGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetHeatmapRenderer(jsObject: any): Promise<any> {
    let {buildDotNetHeatmapRendererGenerated} = await import('./heatmapRenderer.gb');
    return await buildDotNetHeatmapRendererGenerated(jsObject);
}
