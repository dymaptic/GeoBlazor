
export async function buildJsCIMSymbolAnimationTransparency(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMSymbolAnimationTransparencyGenerated } = await import('./cIMSymbolAnimationTransparency.gb');
    return await buildJsCIMSymbolAnimationTransparencyGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMSymbolAnimationTransparency(jsObject: any): Promise<any> {
    let { buildDotNetCIMSymbolAnimationTransparencyGenerated } = await import('./cIMSymbolAnimationTransparency.gb');
    return await buildDotNetCIMSymbolAnimationTransparencyGenerated(jsObject);
}
