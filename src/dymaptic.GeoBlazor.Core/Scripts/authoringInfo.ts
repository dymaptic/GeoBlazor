export async function buildJsAuthoringInfo(dotNetObject: any): Promise<any> {
    let {buildJsAuthoringInfoGenerated} = await import('./authoringInfo.gb');
    return await buildJsAuthoringInfoGenerated(dotNetObject);
}

export async function buildDotNetAuthoringInfo(jsObject: any): Promise<any> {
    let {buildDotNetAuthoringInfoGenerated} = await import('./authoringInfo.gb');
    return await buildDotNetAuthoringInfoGenerated(jsObject);
}
