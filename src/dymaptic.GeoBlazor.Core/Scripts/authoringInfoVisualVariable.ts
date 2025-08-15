
export async function buildJsAuthoringInfoVisualVariable(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsAuthoringInfoVisualVariableGenerated } = await import('./authoringInfoVisualVariable.gb');
    return await buildJsAuthoringInfoVisualVariableGenerated(dotNetObject, viewId);
}     

export async function buildDotNetAuthoringInfoVisualVariable(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetAuthoringInfoVisualVariableGenerated } = await import('./authoringInfoVisualVariable.gb');
    return await buildDotNetAuthoringInfoVisualVariableGenerated(jsObject, viewId);
}
