
export async function buildJsLegendStyle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLegendStyleGenerated } = await import('./legendStyle.gb');
    return await buildJsLegendStyleGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLegendStyle(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLegendStyleGenerated } = await import('./legendStyle.gb');
    return await buildDotNetLegendStyleGenerated(jsObject, layerId, viewId);
}
