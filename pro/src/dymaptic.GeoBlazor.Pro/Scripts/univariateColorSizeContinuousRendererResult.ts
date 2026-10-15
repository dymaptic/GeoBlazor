
export async function buildJsUnivariateColorSizeContinuousRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUnivariateColorSizeContinuousRendererResultGenerated } = await import('./univariateColorSizeContinuousRendererResult.gb');
    return await buildJsUnivariateColorSizeContinuousRendererResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUnivariateColorSizeContinuousRendererResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUnivariateColorSizeContinuousRendererResultGenerated } = await import('./univariateColorSizeContinuousRendererResult.gb');
    return await buildDotNetUnivariateColorSizeContinuousRendererResultGenerated(jsObject, layerId, viewId);
}
