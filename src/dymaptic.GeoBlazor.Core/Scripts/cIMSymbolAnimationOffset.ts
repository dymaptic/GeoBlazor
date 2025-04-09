
export async function buildJsCIMSymbolAnimationOffset(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMSymbolAnimationOffsetGenerated } = await import('./cIMSymbolAnimationOffset.gb');
    return await buildJsCIMSymbolAnimationOffsetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMSymbolAnimationOffset(jsObject: any): Promise<any> {
    let { buildDotNetCIMSymbolAnimationOffsetGenerated } = await import('./cIMSymbolAnimationOffset.gb');
    return await buildDotNetCIMSymbolAnimationOffsetGenerated(jsObject);
}
