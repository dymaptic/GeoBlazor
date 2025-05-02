
export async function buildJsCapabilitiesQueryAttributeBinsSupportedNormalizationTypes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesQueryAttributeBinsSupportedNormalizationTypesGenerated } = await import('./capabilitiesQueryAttributeBinsSupportedNormalizationTypes.gb');
    return await buildJsCapabilitiesQueryAttributeBinsSupportedNormalizationTypesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCapabilitiesQueryAttributeBinsSupportedNormalizationTypes(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesQueryAttributeBinsSupportedNormalizationTypesGenerated } = await import('./capabilitiesQueryAttributeBinsSupportedNormalizationTypes.gb');
    return await buildDotNetCapabilitiesQueryAttributeBinsSupportedNormalizationTypesGenerated(jsObject);
}
