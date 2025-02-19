
export async function buildJsSizeClassBreaksRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeClassBreaksRendererResultGenerated } = await import('./sizeClassBreaksRendererResult.gb');
    return await buildJsSizeClassBreaksRendererResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeClassBreaksRendererResult(jsObject: any): Promise<any> {
    let { buildDotNetSizeClassBreaksRendererResultGenerated } = await import('./sizeClassBreaksRendererResult.gb');
    return await buildDotNetSizeClassBreaksRendererResultGenerated(jsObject);
}
