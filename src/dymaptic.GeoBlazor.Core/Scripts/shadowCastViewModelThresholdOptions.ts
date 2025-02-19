export async function buildJsShadowCastViewModelThresholdOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShadowCastViewModelThresholdOptionsGenerated } = await import('./shadowCastViewModelThresholdOptions.gb');
    return await buildJsShadowCastViewModelThresholdOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetShadowCastViewModelThresholdOptions(jsObject: any): Promise<any> {
    let { buildDotNetShadowCastViewModelThresholdOptionsGenerated } = await import('./shadowCastViewModelThresholdOptions.gb');
    return await buildDotNetShadowCastViewModelThresholdOptionsGenerated(jsObject);
}
