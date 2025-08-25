export async function buildJsAuthoringInfo(dotNetObject: any): Promise<any> {
    let {buildJsAuthoringInfoGenerated} = await import('./authoringInfo.gb');
    return await buildJsAuthoringInfoGenerated(dotNetObject);
}

export async function buildDotNetAuthoringInfo(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetAuthoringInfoGenerated} = await import('./authoringInfo.gb');
    return await buildDotNetAuthoringInfoGenerated(jsObject, viewId);
}
