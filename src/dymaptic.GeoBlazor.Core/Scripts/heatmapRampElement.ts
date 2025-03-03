
export async function buildJsHeatmapRampElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHeatmapRampElementGenerated } = await import('./heatmapRampElement.gb');
    return await buildJsHeatmapRampElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHeatmapRampElement(jsObject: any): Promise<any> {
    let { buildDotNetHeatmapRampElementGenerated } = await import('./heatmapRampElement.gb');
    return await buildDotNetHeatmapRampElementGenerated(jsObject);
}
