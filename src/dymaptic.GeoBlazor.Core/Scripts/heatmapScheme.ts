export async function buildJsHeatmapScheme(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsHeatmapSchemeGenerated} = await import('./heatmapScheme.gb');
    return await buildJsHeatmapSchemeGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetHeatmapScheme(jsObject: any): Promise<any> {
    let {buildDotNetHeatmapSchemeGenerated} = await import('./heatmapScheme.gb');
    return await buildDotNetHeatmapSchemeGenerated(jsObject);
}
