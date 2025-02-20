export async function buildJsPredominanceCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPredominanceCreateRendererParamsGenerated} = await import('./predominanceCreateRendererParams.gb');
    return await buildJsPredominanceCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPredominanceCreateRendererParams(jsObject: any): Promise<any> {
    let {buildDotNetPredominanceCreateRendererParamsGenerated} = await import('./predominanceCreateRendererParams.gb');
    return await buildDotNetPredominanceCreateRendererParamsGenerated(jsObject);
}
