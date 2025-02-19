
export async function buildJsColorCreateContinuousRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorCreateContinuousRendererParamsGenerated } = await import('./colorCreateContinuousRendererParams.gb');
    return await buildJsColorCreateContinuousRendererParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorCreateContinuousRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetColorCreateContinuousRendererParamsGenerated } = await import('./colorCreateContinuousRendererParams.gb');
    return await buildDotNetColorCreateContinuousRendererParamsGenerated(jsObject);
}
