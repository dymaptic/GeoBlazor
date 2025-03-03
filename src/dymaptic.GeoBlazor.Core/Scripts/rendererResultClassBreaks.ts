
export async function buildJsRendererResultClassBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRendererResultClassBreaksGenerated } = await import('./rendererResultClassBreaks.gb');
    return await buildJsRendererResultClassBreaksGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRendererResultClassBreaks(jsObject: any): Promise<any> {
    let { buildDotNetRendererResultClassBreaksGenerated } = await import('./rendererResultClassBreaks.gb');
    return await buildDotNetRendererResultClassBreaksGenerated(jsObject);
}
