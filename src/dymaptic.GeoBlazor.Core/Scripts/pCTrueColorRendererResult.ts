
export async function buildJsPCTrueColorRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPCTrueColorRendererResultGenerated } = await import('./pCTrueColorRendererResult.gb');
    return await buildJsPCTrueColorRendererResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPCTrueColorRendererResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPCTrueColorRendererResultGenerated } = await import('./pCTrueColorRendererResult.gb');
    return await buildDotNetPCTrueColorRendererResultGenerated(jsObject, layerId, viewId);
}
