
export async function buildJsColorSchemeForMesh(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorSchemeForMeshGenerated } = await import('./colorSchemeForMesh.gb');
    return await buildJsColorSchemeForMeshGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorSchemeForMesh(jsObject: any): Promise<any> {
    let { buildDotNetColorSchemeForMeshGenerated } = await import('./colorSchemeForMesh.gb');
    return await buildDotNetColorSchemeForMeshGenerated(jsObject);
}
