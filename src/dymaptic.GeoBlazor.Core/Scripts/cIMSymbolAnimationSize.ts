
export async function buildJsCIMSymbolAnimationSize(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMSymbolAnimationSizeGenerated } = await import('./cIMSymbolAnimationSize.gb');
    return await buildJsCIMSymbolAnimationSizeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMSymbolAnimationSize(jsObject: any): Promise<any> {
    let { buildDotNetCIMSymbolAnimationSizeGenerated } = await import('./cIMSymbolAnimationSize.gb');
    return await buildDotNetCIMSymbolAnimationSizeGenerated(jsObject);
}
