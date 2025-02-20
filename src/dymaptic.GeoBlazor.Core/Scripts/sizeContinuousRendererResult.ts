export async function buildJsSizeContinuousRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSizeContinuousRendererResultGenerated} = await import('./sizeContinuousRendererResult.gb');
    return await buildJsSizeContinuousRendererResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSizeContinuousRendererResult(jsObject: any): Promise<any> {
    let {buildDotNetSizeContinuousRendererResultGenerated} = await import('./sizeContinuousRendererResult.gb');
    return await buildDotNetSizeContinuousRendererResultGenerated(jsObject);
}
