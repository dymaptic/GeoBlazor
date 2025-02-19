
export async function buildJsSizeVisualVariableResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeVisualVariableResultGenerated } = await import('./sizeVisualVariableResult.gb');
    return await buildJsSizeVisualVariableResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeVisualVariableResult(jsObject: any): Promise<any> {
    let { buildDotNetSizeVisualVariableResultGenerated } = await import('./sizeVisualVariableResult.gb');
    return await buildDotNetSizeVisualVariableResultGenerated(jsObject);
}
