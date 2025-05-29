
export async function buildJsShadowCastVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShadowCastVisibleElementsGenerated } = await import('./shadowCastVisibleElements.gb');
    return await buildJsShadowCastVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetShadowCastVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetShadowCastVisibleElementsGenerated } = await import('./shadowCastVisibleElements.gb');
    return await buildDotNetShadowCastVisibleElementsGenerated(jsObject, layerId, viewId);
}
