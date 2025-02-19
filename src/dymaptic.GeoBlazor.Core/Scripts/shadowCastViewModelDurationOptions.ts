
export async function buildJsShadowCastViewModelDurationOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShadowCastViewModelDurationOptionsGenerated } = await import('./shadowCastViewModelDurationOptions.gb');
    return await buildJsShadowCastViewModelDurationOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetShadowCastViewModelDurationOptions(jsObject: any): Promise<any> {
    let { buildDotNetShadowCastViewModelDurationOptionsGenerated } = await import('./shadowCastViewModelDurationOptions.gb');
    return await buildDotNetShadowCastViewModelDurationOptionsGenerated(jsObject);
}
