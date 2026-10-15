
export async function buildJsTravelModeAttributeParameterValues(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTravelModeAttributeParameterValuesGenerated } = await import('./travelModeAttributeParameterValues.gb');
    return await buildJsTravelModeAttributeParameterValuesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTravelModeAttributeParameterValues(jsObject: any): Promise<any> {
    let { buildDotNetTravelModeAttributeParameterValuesGenerated } = await import('./travelModeAttributeParameterValues.gb');
    return await buildDotNetTravelModeAttributeParameterValuesGenerated(jsObject);
}
