
export async function buildJsArrayVariable(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsArrayVariableGenerated } = await import('./arrayVariable.gb');
    return await buildJsArrayVariableGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetArrayVariable(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetArrayVariableGenerated } = await import('./arrayVariable.gb');
    return await buildDotNetArrayVariableGenerated(jsObject, layerId, viewId);
}
