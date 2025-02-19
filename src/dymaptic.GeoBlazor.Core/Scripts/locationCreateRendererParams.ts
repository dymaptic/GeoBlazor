export async function buildJsLocationCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLocationCreateRendererParamsGenerated } = await import('./locationCreateRendererParams.gb');
    return await buildJsLocationCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetLocationCreateRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetLocationCreateRendererParamsGenerated } = await import('./locationCreateRendererParams.gb');
    return await buildDotNetLocationCreateRendererParamsGenerated(jsObject);
}
