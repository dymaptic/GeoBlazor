export async function buildJsColormapCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColormapCreateRendererParamsGenerated } = await import('./colormapCreateRendererParams.gb');
    return await buildJsColormapCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetColormapCreateRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetColormapCreateRendererParamsGenerated } = await import('./colormapCreateRendererParams.gb');
    return await buildDotNetColormapCreateRendererParamsGenerated(jsObject);
}
