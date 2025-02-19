export async function buildJsSizeAgeRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeAgeRendererResultGenerated } = await import('./sizeAgeRendererResult.gb');
    return await buildJsSizeAgeRendererResultGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSizeAgeRendererResult(jsObject: any): Promise<any> {
    let { buildDotNetSizeAgeRendererResultGenerated } = await import('./sizeAgeRendererResult.gb');
    return await buildDotNetSizeAgeRendererResultGenerated(jsObject);
}
