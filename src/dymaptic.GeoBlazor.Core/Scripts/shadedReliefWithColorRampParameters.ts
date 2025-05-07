
export async function buildJsShadedReliefWithColorRampParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShadedReliefWithColorRampParametersGenerated } = await import('./shadedReliefWithColorRampParameters.gb');
    return await buildJsShadedReliefWithColorRampParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetShadedReliefWithColorRampParameters(jsObject: any): Promise<any> {
    let { buildDotNetShadedReliefWithColorRampParametersGenerated } = await import('./shadedReliefWithColorRampParameters.gb');
    return await buildDotNetShadedReliefWithColorRampParametersGenerated(jsObject);
}
