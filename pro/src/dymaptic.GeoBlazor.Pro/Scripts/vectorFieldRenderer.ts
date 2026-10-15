
export async function buildJsVectorFieldRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVectorFieldRendererGenerated } = await import('./vectorFieldRenderer.gb');
    return await buildJsVectorFieldRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVectorFieldRenderer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVectorFieldRendererGenerated } = await import('./vectorFieldRenderer.gb');
    return await buildDotNetVectorFieldRendererGenerated(jsObject, layerId, viewId);
}
