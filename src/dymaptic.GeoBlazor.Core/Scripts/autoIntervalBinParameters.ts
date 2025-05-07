
export async function buildJsAutoIntervalBinParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAutoIntervalBinParametersGenerated } = await import('./autoIntervalBinParameters.gb');
    return await buildJsAutoIntervalBinParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAutoIntervalBinParameters(jsObject: any): Promise<any> {
    let { buildDotNetAutoIntervalBinParametersGenerated } = await import('./autoIntervalBinParameters.gb');
    return await buildDotNetAutoIntervalBinParametersGenerated(jsObject);
}
