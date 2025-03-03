
export async function buildJsPredominanceCreateRendererParamsFields(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPredominanceCreateRendererParamsFieldsGenerated } = await import('./predominanceCreateRendererParamsFields.gb');
    return await buildJsPredominanceCreateRendererParamsFieldsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPredominanceCreateRendererParamsFields(jsObject: any): Promise<any> {
    let { buildDotNetPredominanceCreateRendererParamsFieldsGenerated } = await import('./predominanceCreateRendererParamsFields.gb');
    return await buildDotNetPredominanceCreateRendererParamsFieldsGenerated(jsObject);
}
