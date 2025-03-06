
export async function buildJsAuthoringInfoField(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAuthoringInfoFieldGenerated } = await import('./authoringInfoField.gb');
    return await buildJsAuthoringInfoFieldGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAuthoringInfoField(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetAuthoringInfoFieldGenerated } = await import('./authoringInfoField.gb');
    return await buildDotNetAuthoringInfoFieldGenerated(jsObject, layerId, viewId);
}
