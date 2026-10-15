
export async function buildJsMeshCenterAtParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeshCenterAtParametersGenerated } = await import('./meshCenterAtParameters.gb');
    return await buildJsMeshCenterAtParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeshCenterAtParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetMeshCenterAtParametersGenerated } = await import('./meshCenterAtParameters.gb');
    return await buildDotNetMeshCenterAtParametersGenerated(jsObject, layerId, viewId);
}
