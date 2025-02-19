
export async function buildJsLocationRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLocationRendererResultGenerated } = await import('./locationRendererResult.gb');
    return await buildJsLocationRendererResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLocationRendererResult(jsObject: any): Promise<any> {
    let { buildDotNetLocationRendererResultGenerated } = await import('./locationRendererResult.gb');
    return await buildDotNetLocationRendererResultGenerated(jsObject);
}
