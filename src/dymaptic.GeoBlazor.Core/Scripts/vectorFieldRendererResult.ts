export async function buildJsVectorFieldRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVectorFieldRendererResultGenerated } = await import('./vectorFieldRendererResult.gb');
    return await buildJsVectorFieldRendererResultGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetVectorFieldRendererResult(jsObject: any): Promise<any> {
    let { buildDotNetVectorFieldRendererResultGenerated } = await import('./vectorFieldRendererResult.gb');
    return await buildDotNetVectorFieldRendererResultGenerated(jsObject);
}
