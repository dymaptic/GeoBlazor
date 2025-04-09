
export async function buildJsCIMSymbolAnimationColor(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMSymbolAnimationColorGenerated } = await import('./cIMSymbolAnimationColor.gb');
    return await buildJsCIMSymbolAnimationColorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMSymbolAnimationColor(jsObject: any): Promise<any> {
    let { buildDotNetCIMSymbolAnimationColorGenerated } = await import('./cIMSymbolAnimationColor.gb');
    return await buildDotNetCIMSymbolAnimationColorGenerated(jsObject);
}
