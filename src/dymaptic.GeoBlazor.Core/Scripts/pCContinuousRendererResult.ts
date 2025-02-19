export async function buildJsPCContinuousRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPCContinuousRendererResultGenerated } = await import('./pCContinuousRendererResult.gb');
    return await buildJsPCContinuousRendererResultGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPCContinuousRendererResult(jsObject: any): Promise<any> {
    let { buildDotNetPCContinuousRendererResultGenerated } = await import('./pCContinuousRendererResult.gb');
    return await buildDotNetPCContinuousRendererResultGenerated(jsObject);
}
