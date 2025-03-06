
export async function buildJsUniqueValueRendererLegendOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueRendererLegendOptionsGenerated } = await import('./uniqueValueRendererLegendOptions.gb');
    return await buildJsUniqueValueRendererLegendOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUniqueValueRendererLegendOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUniqueValueRendererLegendOptionsGenerated } = await import('./uniqueValueRendererLegendOptions.gb');
    return await buildDotNetUniqueValueRendererLegendOptionsGenerated(jsObject, layerId, viewId);
}
