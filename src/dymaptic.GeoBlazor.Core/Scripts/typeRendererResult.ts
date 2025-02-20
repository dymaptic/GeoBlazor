export async function buildJsTypeRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTypeRendererResultGenerated} = await import('./typeRendererResult.gb');
    return await buildJsTypeRendererResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTypeRendererResult(jsObject: any): Promise<any> {
    let {buildDotNetTypeRendererResultGenerated} = await import('./typeRendererResult.gb');
    return await buildDotNetTypeRendererResultGenerated(jsObject);
}
