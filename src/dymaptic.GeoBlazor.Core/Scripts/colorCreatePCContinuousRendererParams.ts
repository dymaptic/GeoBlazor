export async function buildJsColorCreatePCContinuousRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorCreatePCContinuousRendererParamsGenerated} = await import('./colorCreatePCContinuousRendererParams.gb');
    return await buildJsColorCreatePCContinuousRendererParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorCreatePCContinuousRendererParams(jsObject: any): Promise<any> {
    let {buildDotNetColorCreatePCContinuousRendererParamsGenerated} = await import('./colorCreatePCContinuousRendererParams.gb');
    return await buildDotNetColorCreatePCContinuousRendererParamsGenerated(jsObject);
}
