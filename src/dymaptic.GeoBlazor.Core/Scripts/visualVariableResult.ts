
export async function buildJsVisualVariableResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVisualVariableResultGenerated } = await import('./visualVariableResult.gb');
    return await buildJsVisualVariableResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVisualVariableResult(jsObject: any): Promise<any> {
    let { buildDotNetVisualVariableResultGenerated } = await import('./visualVariableResult.gb');
    return await buildDotNetVisualVariableResultGenerated(jsObject);
}
