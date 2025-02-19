export async function buildJsStretchCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStretchCreateRendererParamsGenerated } = await import('./stretchCreateRendererParams.gb');
    return await buildJsStretchCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetStretchCreateRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetStretchCreateRendererParamsGenerated } = await import('./stretchCreateRendererParams.gb');
    return await buildDotNetStretchCreateRendererParamsGenerated(jsObject);
}
