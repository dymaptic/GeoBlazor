
export async function buildJsCreateSphereParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCreateSphereParametersGenerated } = await import('./createSphereParameters.gb');
    return await buildJsCreateSphereParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCreateSphereParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCreateSphereParametersGenerated } = await import('./createSphereParameters.gb');
    return await buildDotNetCreateSphereParametersGenerated(jsObject, layerId, viewId);
}
