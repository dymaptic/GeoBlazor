
export async function buildJsSizeCreateContinuousRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeCreateContinuousRendererParamsGenerated } = await import('./sizeCreateContinuousRendererParams.gb');
    return await buildJsSizeCreateContinuousRendererParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeCreateContinuousRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetSizeCreateContinuousRendererParamsGenerated } = await import('./sizeCreateContinuousRendererParams.gb');
    return await buildDotNetSizeCreateContinuousRendererParamsGenerated(jsObject);
}
