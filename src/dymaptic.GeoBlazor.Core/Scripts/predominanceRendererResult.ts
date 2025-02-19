
export async function buildJsPredominanceRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPredominanceRendererResultGenerated } = await import('./predominanceRendererResult.gb');
    return await buildJsPredominanceRendererResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPredominanceRendererResult(jsObject: any): Promise<any> {
    let { buildDotNetPredominanceRendererResultGenerated } = await import('./predominanceRendererResult.gb');
    return await buildDotNetPredominanceRendererResultGenerated(jsObject);
}
