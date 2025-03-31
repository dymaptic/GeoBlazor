
export async function buildJsIRouteSymbolsPointBarriers(dotNetObject: any): Promise<any> {
    let { buildJsIRouteSymbolsPointBarriersGenerated } = await import('./iRouteSymbolsPointBarriers.gb');
    return await buildJsIRouteSymbolsPointBarriersGenerated(dotNetObject);
}     

export async function buildDotNetIRouteSymbolsPointBarriers(jsObject: any): Promise<any> {
    let { buildDotNetIRouteSymbolsPointBarriersGenerated } = await import('./iRouteSymbolsPointBarriers.gb');
    return await buildDotNetIRouteSymbolsPointBarriersGenerated(jsObject);
}
