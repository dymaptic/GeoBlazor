export async function buildJsUniqueValueCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUniqueValueCreateRendererParamsGenerated} = await import('./uniqueValueCreateRendererParams.gb');
    return await buildJsUniqueValueCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUniqueValueCreateRendererParams(jsObject: any): Promise<any> {
    let {buildDotNetUniqueValueCreateRendererParamsGenerated} = await import('./uniqueValueCreateRendererParams.gb');
    return await buildDotNetUniqueValueCreateRendererParamsGenerated(jsObject);
}
