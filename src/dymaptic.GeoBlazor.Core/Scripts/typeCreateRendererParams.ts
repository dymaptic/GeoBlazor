
export async function buildJsTypeCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTypeCreateRendererParamsGenerated } = await import('./typeCreateRendererParams.gb');
    return await buildJsTypeCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTypeCreateRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetTypeCreateRendererParamsGenerated } = await import('./typeCreateRendererParams.gb');
    return await buildDotNetTypeCreateRendererParamsGenerated(jsObject);
}
