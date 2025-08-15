
export async function buildJsShadedReliefWithColorRampNameParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShadedReliefWithColorRampNameParametersGenerated } = await import('./shadedReliefWithColorRampNameParameters.gb');
    return await buildJsShadedReliefWithColorRampNameParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetShadedReliefWithColorRampNameParameters(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetShadedReliefWithColorRampNameParametersGenerated } = await import('./shadedReliefWithColorRampNameParameters.gb');
    return await buildDotNetShadedReliefWithColorRampNameParametersGenerated(jsObject, viewId);
}
