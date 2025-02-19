
export async function buildJsRgbCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRgbCreateRendererParamsGenerated } = await import('./rgbCreateRendererParams.gb');
    return await buildJsRgbCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRgbCreateRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetRgbCreateRendererParamsGenerated } = await import('./rgbCreateRendererParams.gb');
    return await buildDotNetRgbCreateRendererParamsGenerated(jsObject);
}
