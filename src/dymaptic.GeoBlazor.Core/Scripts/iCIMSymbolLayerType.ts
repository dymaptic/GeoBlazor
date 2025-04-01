
export async function buildJsICIMSymbolLayerType(dotNetObject: any): Promise<any> {
    let { buildJsICIMSymbolLayerTypeGenerated } = await import('./iCIMSymbolLayerType.gb');
    return await buildJsICIMSymbolLayerTypeGenerated(dotNetObject);
}     

export async function buildDotNetICIMSymbolLayerType(jsObject: any): Promise<any> {
    let { buildDotNetICIMSymbolLayerTypeGenerated } = await import('./iCIMSymbolLayerType.gb');
    return await buildDotNetICIMSymbolLayerTypeGenerated(jsObject);
}
