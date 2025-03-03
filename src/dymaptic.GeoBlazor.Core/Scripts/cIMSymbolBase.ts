
export async function buildJsCIMSymbolBase(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMSymbolBaseGenerated } = await import('./cIMSymbolBase.gb');
    return await buildJsCIMSymbolBaseGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMSymbolBase(jsObject: any): Promise<any> {
    let { buildDotNetCIMSymbolBaseGenerated } = await import('./cIMSymbolBase.gb');
    return await buildDotNetCIMSymbolBaseGenerated(jsObject);
}
