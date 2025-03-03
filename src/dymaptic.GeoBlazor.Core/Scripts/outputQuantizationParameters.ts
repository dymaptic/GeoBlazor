
export async function buildJsOutputQuantizationParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOutputQuantizationParametersGenerated } = await import('./outputQuantizationParameters.gb');
    return await buildJsOutputQuantizationParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOutputQuantizationParameters(jsObject: any): Promise<any> {
    let { buildDotNetOutputQuantizationParametersGenerated } = await import('./outputQuantizationParameters.gb');
    return await buildDotNetOutputQuantizationParametersGenerated(jsObject);
}
