
export async function buildJsTrimExtendParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTrimExtendParametersGenerated } = await import('./trimExtendParameters.gb');
    return await buildJsTrimExtendParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTrimExtendParameters(jsObject: any): Promise<any> {
    let { buildDotNetTrimExtendParametersGenerated } = await import('./trimExtendParameters.gb');
    return await buildDotNetTrimExtendParametersGenerated(jsObject);
}
