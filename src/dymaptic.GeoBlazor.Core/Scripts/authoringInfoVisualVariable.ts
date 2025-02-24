
export async function buildJsAuthoringInfoVisualVariable(dotNetObject: any): Promise<any> {
    let { buildJsAuthoringInfoVisualVariableGenerated } = await import('./authoringInfoVisualVariable.gb');
    return await buildJsAuthoringInfoVisualVariableGenerated(dotNetObject);
}     

export async function buildDotNetAuthoringInfoVisualVariable(jsObject: any): Promise<any> {
    let { buildDotNetAuthoringInfoVisualVariableGenerated } = await import('./authoringInfoVisualVariable.gb');
    return await buildDotNetAuthoringInfoVisualVariableGenerated(jsObject);
}
