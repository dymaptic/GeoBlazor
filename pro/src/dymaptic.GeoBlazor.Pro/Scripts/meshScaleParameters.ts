
export async function buildJsMeshScaleParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeshScaleParametersGenerated } = await import('./meshScaleParameters.gb');
    return await buildJsMeshScaleParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeshScaleParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetMeshScaleParametersGenerated } = await import('./meshScaleParameters.gb');
    return await buildDotNetMeshScaleParametersGenerated(jsObject, layerId, viewId);
}
