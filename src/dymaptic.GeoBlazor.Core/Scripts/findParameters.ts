
export async function buildJsFindParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFindParametersGenerated } = await import('./findParameters.gb');
    return await buildJsFindParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFindParameters(jsObject: any): Promise<any> {
    let { buildDotNetFindParametersGenerated } = await import('./findParameters.gb');
    return await buildDotNetFindParametersGenerated(jsObject);
}
