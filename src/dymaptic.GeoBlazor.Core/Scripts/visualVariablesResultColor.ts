export async function buildJsVisualVariablesResultColor(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVisualVariablesResultColorGenerated } = await import('./visualVariablesResultColor.gb');
    return await buildJsVisualVariablesResultColorGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetVisualVariablesResultColor(jsObject: any): Promise<any> {
    let { buildDotNetVisualVariablesResultColorGenerated } = await import('./visualVariablesResultColor.gb');
    return await buildDotNetVisualVariablesResultColorGenerated(jsObject);
}
