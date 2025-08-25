
export async function buildJsHeatmapRampElement(dotNetObject: any): Promise<any> {
    let { buildJsHeatmapRampElementGenerated } = await import('./heatmapRampElement.gb');
    return await buildJsHeatmapRampElementGenerated(dotNetObject);
}     

export async function buildDotNetHeatmapRampElement(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetHeatmapRampElementGenerated } = await import('./heatmapRampElement.gb');
    return await buildDotNetHeatmapRampElementGenerated(jsObject, viewId);
}
