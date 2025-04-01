
export async function buildJsUniqueValueRendererLegendOptions(dotNetObject: any): Promise<any> {
    let { buildJsUniqueValueRendererLegendOptionsGenerated } = await import('./uniqueValueRendererLegendOptions.gb');
    return await buildJsUniqueValueRendererLegendOptionsGenerated(dotNetObject);
}     

export async function buildDotNetUniqueValueRendererLegendOptions(jsObject: any): Promise<any> {
    let { buildDotNetUniqueValueRendererLegendOptionsGenerated } = await import('./uniqueValueRendererLegendOptions.gb');
    return await buildDotNetUniqueValueRendererLegendOptionsGenerated(jsObject);
}
