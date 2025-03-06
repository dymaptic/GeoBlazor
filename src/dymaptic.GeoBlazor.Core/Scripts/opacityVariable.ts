
export async function buildJsOpacityVariable(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOpacityVariableGenerated } = await import('./opacityVariable.gb');
    return await buildJsOpacityVariableGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOpacityVariable(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetOpacityVariableGenerated } = await import('./opacityVariable.gb');
    return await buildDotNetOpacityVariableGenerated(jsObject, layerId, viewId);
}
