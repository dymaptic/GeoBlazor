
export async function buildJsMeshRotateParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeshRotateParametersGenerated } = await import('./meshRotateParameters.gb');
    return await buildJsMeshRotateParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeshRotateParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetMeshRotateParametersGenerated } = await import('./meshRotateParameters.gb');
    return await buildDotNetMeshRotateParametersGenerated(jsObject, layerId, viewId);
}
