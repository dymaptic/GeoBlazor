
export async function buildJsVideoViewParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVideoViewParamsGenerated } = await import('./videoViewParams.gb');
    return await buildJsVideoViewParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVideoViewParams(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVideoViewParamsGenerated } = await import('./videoViewParams.gb');
    return await buildDotNetVideoViewParamsGenerated(jsObject, layerId, viewId);
}
