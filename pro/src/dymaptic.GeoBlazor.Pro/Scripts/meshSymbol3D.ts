
export async function buildJsMeshSymbol3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeshSymbol3DGenerated } = await import('./meshSymbol3D.gb');
    return await buildJsMeshSymbol3DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeshSymbol3D(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetMeshSymbol3DGenerated } = await import('./meshSymbol3D.gb');
    return await buildDotNetMeshSymbol3DGenerated(jsObject, layerId, viewId);
}
