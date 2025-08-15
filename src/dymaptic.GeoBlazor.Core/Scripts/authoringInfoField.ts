
export async function buildJsAuthoringInfoField(dotNetObject: any): Promise<any> {
    let { buildJsAuthoringInfoFieldGenerated } = await import('./authoringInfoField.gb');
    return await buildJsAuthoringInfoFieldGenerated(dotNetObject);
}     

export async function buildDotNetAuthoringInfoField(jsObject: any): Promise<any> {
    let { buildDotNetAuthoringInfoFieldGenerated } = await import('./authoringInfoField.gb');
    return await buildDotNetAuthoringInfoFieldGenerated(jsObject);
}
