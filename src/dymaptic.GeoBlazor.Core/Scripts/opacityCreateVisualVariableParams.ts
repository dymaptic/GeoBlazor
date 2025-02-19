
export async function buildJsOpacityCreateVisualVariableParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOpacityCreateVisualVariableParamsGenerated } = await import('./opacityCreateVisualVariableParams.gb');
    return await buildJsOpacityCreateVisualVariableParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOpacityCreateVisualVariableParams(jsObject: any): Promise<any> {
    let { buildDotNetOpacityCreateVisualVariableParamsGenerated } = await import('./opacityCreateVisualVariableParams.gb');
    return await buildDotNetOpacityCreateVisualVariableParamsGenerated(jsObject);
}
