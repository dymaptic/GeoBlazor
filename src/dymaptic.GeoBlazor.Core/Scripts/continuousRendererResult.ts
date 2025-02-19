
export async function buildJsContinuousRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsContinuousRendererResultGenerated } = await import('./continuousRendererResult.gb');
    return await buildJsContinuousRendererResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetContinuousRendererResult(jsObject: any): Promise<any> {
    let { buildDotNetContinuousRendererResultGenerated } = await import('./continuousRendererResult.gb');
    return await buildDotNetContinuousRendererResultGenerated(jsObject);
}
