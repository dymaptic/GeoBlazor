
export async function buildJsAuthoringInfoField2(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAuthoringInfoField2Generated } = await import('./authoringInfoField2.gb');
    return await buildJsAuthoringInfoField2Generated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAuthoringInfoField2(jsObject: any): Promise<any> {
    let { buildDotNetAuthoringInfoField2Generated } = await import('./authoringInfoField2.gb');
    return await buildDotNetAuthoringInfoField2Generated(jsObject);
}
