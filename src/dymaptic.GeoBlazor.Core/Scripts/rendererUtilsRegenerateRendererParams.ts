
export async function buildJsRendererUtilsRegenerateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRendererUtilsRegenerateRendererParamsGenerated } = await import('./rendererUtilsRegenerateRendererParams.gb');
    return await buildJsRendererUtilsRegenerateRendererParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRendererUtilsRegenerateRendererParams(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRendererUtilsRegenerateRendererParamsGenerated } = await import('./rendererUtilsRegenerateRendererParams.gb');
    return await buildDotNetRendererUtilsRegenerateRendererParamsGenerated(jsObject, viewId);
}
