export async function buildJsClassBreaksRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsClassBreaksRendererResultGenerated} = await import('./classBreaksRendererResult.gb');
    return await buildJsClassBreaksRendererResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetClassBreaksRendererResult(jsObject: any): Promise<any> {
    let {buildDotNetClassBreaksRendererResultGenerated} = await import('./classBreaksRendererResult.gb');
    return await buildDotNetClassBreaksRendererResultGenerated(jsObject);
}
