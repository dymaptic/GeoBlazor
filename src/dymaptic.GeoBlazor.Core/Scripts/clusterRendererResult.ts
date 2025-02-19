export async function buildJsClusterRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClusterRendererResultGenerated } = await import('./clusterRendererResult.gb');
    return await buildJsClusterRendererResultGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetClusterRendererResult(jsObject: any): Promise<any> {
    let { buildDotNetClusterRendererResultGenerated } = await import('./clusterRendererResult.gb');
    return await buildDotNetClusterRendererResultGenerated(jsObject);
}
