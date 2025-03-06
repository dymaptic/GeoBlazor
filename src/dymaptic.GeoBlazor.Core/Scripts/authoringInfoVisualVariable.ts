
export async function buildJsAuthoringInfoVisualVariable(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAuthoringInfoVisualVariableGenerated } = await import('./authoringInfoVisualVariable.gb');
    return await buildJsAuthoringInfoVisualVariableGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAuthoringInfoVisualVariable(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetAuthoringInfoVisualVariableGenerated } = await import('./authoringInfoVisualVariable.gb');
    return await buildDotNetAuthoringInfoVisualVariableGenerated(jsObject, layerId, viewId);
}
