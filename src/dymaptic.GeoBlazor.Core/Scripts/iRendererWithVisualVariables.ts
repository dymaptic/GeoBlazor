
export async function buildJsIRendererWithVisualVariables(dotNetObject: any): Promise<any> {
    let { buildJsIRendererWithVisualVariablesGenerated } = await import('./iRendererWithVisualVariables.gb');
    return await buildJsIRendererWithVisualVariablesGenerated(dotNetObject);
}     

export async function buildDotNetIRendererWithVisualVariables(jsObject: any): Promise<any> {
    let { buildDotNetIRendererWithVisualVariablesGenerated } = await import('./iRendererWithVisualVariables.gb');
    return await buildDotNetIRendererWithVisualVariablesGenerated(jsObject);
}
