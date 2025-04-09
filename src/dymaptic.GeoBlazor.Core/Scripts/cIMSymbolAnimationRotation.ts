
export async function buildJsCIMSymbolAnimationRotation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMSymbolAnimationRotationGenerated } = await import('./cIMSymbolAnimationRotation.gb');
    return await buildJsCIMSymbolAnimationRotationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMSymbolAnimationRotation(jsObject: any): Promise<any> {
    let { buildDotNetCIMSymbolAnimationRotationGenerated } = await import('./cIMSymbolAnimationRotation.gb');
    return await buildDotNetCIMSymbolAnimationRotationGenerated(jsObject);
}
