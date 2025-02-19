
export async function buildJsColorCreateClassBreaksRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorCreateClassBreaksRendererParamsGenerated } = await import('./colorCreateClassBreaksRendererParams.gb');
    return await buildJsColorCreateClassBreaksRendererParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorCreateClassBreaksRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetColorCreateClassBreaksRendererParamsGenerated } = await import('./colorCreateClassBreaksRendererParams.gb');
    return await buildDotNetColorCreateClassBreaksRendererParamsGenerated(jsObject);
}
