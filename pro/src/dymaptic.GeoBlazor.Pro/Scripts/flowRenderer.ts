
export async function buildJsFlowRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFlowRendererGenerated } = await import('./flowRenderer.gb');
    return await buildJsFlowRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFlowRenderer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFlowRendererGenerated } = await import('./flowRenderer.gb');
    return await buildDotNetFlowRendererGenerated(jsObject, layerId, viewId);
}
