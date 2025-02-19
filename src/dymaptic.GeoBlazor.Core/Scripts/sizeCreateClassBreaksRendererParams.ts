
export async function buildJsSizeCreateClassBreaksRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeCreateClassBreaksRendererParamsGenerated } = await import('./sizeCreateClassBreaksRendererParams.gb');
    return await buildJsSizeCreateClassBreaksRendererParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeCreateClassBreaksRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetSizeCreateClassBreaksRendererParamsGenerated } = await import('./sizeCreateClassBreaksRendererParams.gb');
    return await buildDotNetSizeCreateClassBreaksRendererParamsGenerated(jsObject);
}
