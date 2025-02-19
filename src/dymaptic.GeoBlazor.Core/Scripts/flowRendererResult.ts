export async function buildJsFlowRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFlowRendererResultGenerated } = await import('./flowRendererResult.gb');
    return await buildJsFlowRendererResultGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetFlowRendererResult(jsObject: any): Promise<any> {
    let { buildDotNetFlowRendererResultGenerated } = await import('./flowRendererResult.gb');
    return await buildDotNetFlowRendererResultGenerated(jsObject);
}
