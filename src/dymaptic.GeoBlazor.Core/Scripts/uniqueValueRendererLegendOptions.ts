
export async function buildJsUniqueValueRendererLegendOptions(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsUniqueValueRendererLegendOptionsGenerated } = await import('./uniqueValueRendererLegendOptions.gb');
    return await buildJsUniqueValueRendererLegendOptionsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetUniqueValueRendererLegendOptions(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetUniqueValueRendererLegendOptionsGenerated } = await import('./uniqueValueRendererLegendOptions.gb');
    return await buildDotNetUniqueValueRendererLegendOptionsGenerated(jsObject, viewId);
}
