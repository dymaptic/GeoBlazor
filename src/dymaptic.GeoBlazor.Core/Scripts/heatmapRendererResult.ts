export async function buildJsHeatmapRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsHeatmapRendererResultGenerated} = await import('./heatmapRendererResult.gb');
    return await buildJsHeatmapRendererResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetHeatmapRendererResult(jsObject: any): Promise<any> {
    let {buildDotNetHeatmapRendererResultGenerated} = await import('./heatmapRendererResult.gb');
    return await buildDotNetHeatmapRendererResultGenerated(jsObject);
}
