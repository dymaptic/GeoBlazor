export async function buildJsCreationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCreationInfoGenerated} = await import('./creationInfo.gb');
    return await buildJsCreationInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCreationInfo(jsObject: any): Promise<any> {
    let {buildDotNetCreationInfoGenerated} = await import('./creationInfo.gb');
    return await buildDotNetCreationInfoGenerated(jsObject);
}
