export async function buildJsHeatmapSchemes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsHeatmapSchemesGenerated} = await import('./heatmapSchemes.gb');
    return await buildJsHeatmapSchemesGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetHeatmapSchemes(jsObject: any): Promise<any> {
    let {buildDotNetHeatmapSchemesGenerated} = await import('./heatmapSchemes.gb');
    return await buildDotNetHeatmapSchemesGenerated(jsObject);
}
