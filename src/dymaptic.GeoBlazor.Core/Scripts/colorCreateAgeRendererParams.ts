export async function buildJsColorCreateAgeRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorCreateAgeRendererParamsGenerated } = await import('./colorCreateAgeRendererParams.gb');
    return await buildJsColorCreateAgeRendererParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetColorCreateAgeRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetColorCreateAgeRendererParamsGenerated } = await import('./colorCreateAgeRendererParams.gb');
    return await buildDotNetColorCreateAgeRendererParamsGenerated(jsObject);
}
