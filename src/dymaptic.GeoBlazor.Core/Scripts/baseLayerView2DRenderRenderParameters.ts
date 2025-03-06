
export async function buildJsBaseLayerView2DRenderRenderParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBaseLayerView2DRenderRenderParametersGenerated } = await import('./baseLayerView2DRenderRenderParameters.gb');
    return await buildJsBaseLayerView2DRenderRenderParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBaseLayerView2DRenderRenderParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBaseLayerView2DRenderRenderParametersGenerated } = await import('./baseLayerView2DRenderRenderParameters.gb');
    return await buildDotNetBaseLayerView2DRenderRenderParametersGenerated(jsObject, layerId, viewId);
}
