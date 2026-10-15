
export async function buildJsMeshCreateFromPolygonParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeshCreateFromPolygonParametersGenerated } = await import('./meshCreateFromPolygonParameters.gb');
    return await buildJsMeshCreateFromPolygonParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeshCreateFromPolygonParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetMeshCreateFromPolygonParametersGenerated } = await import('./meshCreateFromPolygonParameters.gb');
    return await buildDotNetMeshCreateFromPolygonParametersGenerated(jsObject, layerId, viewId);
}
