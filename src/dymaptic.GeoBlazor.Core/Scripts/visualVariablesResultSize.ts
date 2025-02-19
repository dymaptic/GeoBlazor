
export async function buildJsVisualVariablesResultSize(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVisualVariablesResultSizeGenerated } = await import('./visualVariablesResultSize.gb');
    return await buildJsVisualVariablesResultSizeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVisualVariablesResultSize(jsObject: any): Promise<any> {
    let { buildDotNetVisualVariablesResultSizeGenerated } = await import('./visualVariablesResultSize.gb');
    return await buildDotNetVisualVariablesResultSizeGenerated(jsObject);
}
