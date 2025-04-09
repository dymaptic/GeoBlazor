
export async function buildJsFixedIntervalBinParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFixedIntervalBinParametersGenerated } = await import('./fixedIntervalBinParameters.gb');
    return await buildJsFixedIntervalBinParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFixedIntervalBinParameters(jsObject: any): Promise<any> {
    let { buildDotNetFixedIntervalBinParametersGenerated } = await import('./fixedIntervalBinParameters.gb');
    return await buildDotNetFixedIntervalBinParametersGenerated(jsObject);
}
