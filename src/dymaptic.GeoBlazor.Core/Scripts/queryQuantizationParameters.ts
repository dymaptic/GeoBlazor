export async function buildJsQueryQuantizationParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsQueryQuantizationParametersGenerated} = await import('./queryQuantizationParameters.gb');
    return await buildJsQueryQuantizationParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetQueryQuantizationParameters(jsObject: any): Promise<any> {
    let {buildDotNetQueryQuantizationParametersGenerated} = await import('./queryQuantizationParameters.gb');
    return await buildDotNetQueryQuantizationParametersGenerated(jsObject);
}
