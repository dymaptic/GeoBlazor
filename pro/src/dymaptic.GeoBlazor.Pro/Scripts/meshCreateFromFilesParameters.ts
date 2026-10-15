
export async function buildJsMeshCreateFromFilesParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeshCreateFromFilesParametersGenerated } = await import('./meshCreateFromFilesParameters.gb');
    return await buildJsMeshCreateFromFilesParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeshCreateFromFilesParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetMeshCreateFromFilesParametersGenerated } = await import('./meshCreateFromFilesParameters.gb');
    return await buildDotNetMeshCreateFromFilesParametersGenerated(jsObject, layerId, viewId);
}
