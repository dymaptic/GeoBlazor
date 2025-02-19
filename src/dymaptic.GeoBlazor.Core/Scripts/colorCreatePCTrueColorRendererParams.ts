
export async function buildJsColorCreatePCTrueColorRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorCreatePCTrueColorRendererParamsGenerated } = await import('./colorCreatePCTrueColorRendererParams.gb');
    return await buildJsColorCreatePCTrueColorRendererParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorCreatePCTrueColorRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetColorCreatePCTrueColorRendererParamsGenerated } = await import('./colorCreatePCTrueColorRendererParams.gb');
    return await buildDotNetColorCreatePCTrueColorRendererParamsGenerated(jsObject);
}
