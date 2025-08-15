
export async function buildJsIRendererWithVisualVariables(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIRendererWithVisualVariablesGenerated } = await import('./iRendererWithVisualVariables.gb');
    return await buildJsIRendererWithVisualVariablesGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIRendererWithVisualVariables(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIRendererWithVisualVariablesGenerated } = await import('./iRendererWithVisualVariables.gb');
    return await buildDotNetIRendererWithVisualVariablesGenerated(jsObject, viewId);
}
