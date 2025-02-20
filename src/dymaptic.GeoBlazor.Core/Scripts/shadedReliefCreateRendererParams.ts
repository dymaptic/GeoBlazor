export async function buildJsShadedReliefCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsShadedReliefCreateRendererParamsGenerated} = await import('./shadedReliefCreateRendererParams.gb');
    return await buildJsShadedReliefCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetShadedReliefCreateRendererParams(jsObject: any): Promise<any> {
    let {buildDotNetShadedReliefCreateRendererParamsGenerated} = await import('./shadedReliefCreateRendererParams.gb');
    return await buildDotNetShadedReliefCreateRendererParamsGenerated(jsObject);
}
