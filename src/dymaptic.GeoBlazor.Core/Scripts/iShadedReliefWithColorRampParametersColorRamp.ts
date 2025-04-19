
export async function buildJsIShadedReliefWithColorRampParametersColorRamp(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIShadedReliefWithColorRampParametersColorRampGenerated } = await import('./iShadedReliefWithColorRampParametersColorRamp.gb');
    return await buildJsIShadedReliefWithColorRampParametersColorRampGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIShadedReliefWithColorRampParametersColorRamp(jsObject: any): Promise<any> {
    let { buildDotNetIShadedReliefWithColorRampParametersColorRampGenerated } = await import('./iShadedReliefWithColorRampParametersColorRamp.gb');
    return await buildDotNetIShadedReliefWithColorRampParametersColorRampGenerated(jsObject);
}
