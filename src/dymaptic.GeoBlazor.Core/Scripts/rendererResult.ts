export async function buildJsRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRendererResultGenerated} = await import('./rendererResult.gb');
    return await buildJsRendererResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRendererResult(jsObject: any): Promise<any> {
    let {buildDotNetRendererResultGenerated} = await import('./rendererResult.gb');
    return await buildDotNetRendererResultGenerated(jsObject);
}
