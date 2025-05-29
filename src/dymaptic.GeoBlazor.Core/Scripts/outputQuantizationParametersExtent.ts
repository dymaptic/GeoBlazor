
export async function buildJsOutputQuantizationParametersExtent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOutputQuantizationParametersExtentGenerated } = await import('./outputQuantizationParametersExtent.gb');
    return await buildJsOutputQuantizationParametersExtentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOutputQuantizationParametersExtent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetOutputQuantizationParametersExtentGenerated } = await import('./outputQuantizationParametersExtent.gb');
    return await buildDotNetOutputQuantizationParametersExtentGenerated(jsObject, layerId, viewId);
}
