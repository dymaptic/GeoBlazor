
export async function buildJsICIMSymbolAnimation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsICIMSymbolAnimationGenerated } = await import('./iCIMSymbolAnimation.gb');
    return await buildJsICIMSymbolAnimationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetICIMSymbolAnimation(jsObject: any): Promise<any> {
    let { buildDotNetICIMSymbolAnimationGenerated } = await import('./iCIMSymbolAnimation.gb');
    return await buildDotNetICIMSymbolAnimationGenerated(jsObject);
}
