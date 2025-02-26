
export async function buildJsCIMSymbolLayerBase(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMSymbolLayerBaseGenerated } = await import('./cIMSymbolLayerBase.gb');
    return await buildJsCIMSymbolLayerBaseGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMSymbolLayerBase(jsObject: any): Promise<any> {
    let { buildDotNetCIMSymbolLayerBaseGenerated } = await import('./cIMSymbolLayerBase.gb');
    return await buildDotNetCIMSymbolLayerBaseGenerated(jsObject);
}
