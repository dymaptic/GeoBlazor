
export async function buildJsServiceAreaParametersAttributeParameterValue(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsServiceAreaParametersAttributeParameterValueGenerated } = await import('./serviceAreaParametersAttributeParameterValue.gb');
    return await buildJsServiceAreaParametersAttributeParameterValueGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetServiceAreaParametersAttributeParameterValue(jsObject: any): Promise<any> {
    let { buildDotNetServiceAreaParametersAttributeParameterValueGenerated } = await import('./serviceAreaParametersAttributeParameterValue.gb');
    return await buildDotNetServiceAreaParametersAttributeParameterValueGenerated(jsObject);
}
