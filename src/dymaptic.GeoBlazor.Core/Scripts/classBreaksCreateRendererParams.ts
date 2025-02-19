
export async function buildJsClassBreaksCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassBreaksCreateRendererParamsGenerated } = await import('./classBreaksCreateRendererParams.gb');
    return await buildJsClassBreaksCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClassBreaksCreateRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetClassBreaksCreateRendererParamsGenerated } = await import('./classBreaksCreateRendererParams.gb');
    return await buildDotNetClassBreaksCreateRendererParamsGenerated(jsObject);
}
