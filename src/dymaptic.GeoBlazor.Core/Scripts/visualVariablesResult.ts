export async function buildJsVisualVariablesResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVisualVariablesResultGenerated } = await import('./visualVariablesResult.gb');
    return await buildJsVisualVariablesResultGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetVisualVariablesResult(jsObject: any): Promise<any> {
    let { buildDotNetVisualVariablesResultGenerated } = await import('./visualVariablesResult.gb');
    return await buildDotNetVisualVariablesResultGenerated(jsObject);
}
