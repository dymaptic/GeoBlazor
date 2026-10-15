
export async function buildJsShadowCastViewModelDiscreteOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShadowCastViewModelDiscreteOptionsGenerated } = await import('./shadowCastViewModelDiscreteOptions.gb');
    return await buildJsShadowCastViewModelDiscreteOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetShadowCastViewModelDiscreteOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetShadowCastViewModelDiscreteOptionsGenerated } = await import('./shadowCastViewModelDiscreteOptions.gb');
    return await buildDotNetShadowCastViewModelDiscreteOptionsGenerated(jsObject, layerId, viewId);
}
