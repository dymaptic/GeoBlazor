
export async function buildJsInitializationLinkChartConfig(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsInitializationLinkChartConfigGenerated } = await import('./initializationLinkChartConfig.gb');
    return await buildJsInitializationLinkChartConfigGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetInitializationLinkChartConfig(jsObject: any): Promise<any> {
    let { buildDotNetInitializationLinkChartConfigGenerated } = await import('./initializationLinkChartConfig.gb');
    return await buildDotNetInitializationLinkChartConfigGenerated(jsObject);
}
