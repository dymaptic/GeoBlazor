
export async function buildJsCIMSymbolAnimationScale(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMSymbolAnimationScaleGenerated } = await import('./cIMSymbolAnimationScale.gb');
    return await buildJsCIMSymbolAnimationScaleGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMSymbolAnimationScale(jsObject: any): Promise<any> {
    let { buildDotNetCIMSymbolAnimationScaleGenerated } = await import('./cIMSymbolAnimationScale.gb');
    return await buildDotNetCIMSymbolAnimationScaleGenerated(jsObject);
}
