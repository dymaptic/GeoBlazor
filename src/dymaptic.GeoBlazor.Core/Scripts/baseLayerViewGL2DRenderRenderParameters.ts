export async function buildJsBaseLayerViewGL2DRenderRenderParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBaseLayerViewGL2DRenderRenderParametersGenerated} = await import('./baseLayerViewGL2DRenderRenderParameters.gb');
    return await buildJsBaseLayerViewGL2DRenderRenderParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBaseLayerViewGL2DRenderRenderParameters(jsObject: any): Promise<any> {
    let {buildDotNetBaseLayerViewGL2DRenderRenderParametersGenerated} = await import('./baseLayerViewGL2DRenderRenderParameters.gb');
    return await buildDotNetBaseLayerViewGL2DRenderRenderParametersGenerated(jsObject);
}
