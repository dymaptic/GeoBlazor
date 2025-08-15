
export async function buildJsAuthoringInfoField(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsAuthoringInfoFieldGenerated } = await import('./authoringInfoField.gb');
    return await buildJsAuthoringInfoFieldGenerated(dotNetObject, viewId);
}     

export async function buildDotNetAuthoringInfoField(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetAuthoringInfoFieldGenerated } = await import('./authoringInfoField.gb');
    return await buildDotNetAuthoringInfoFieldGenerated(jsObject, viewId);
}
