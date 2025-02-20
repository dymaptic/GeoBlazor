export async function buildJsTypeSchemeForMesh(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTypeSchemeForMeshGenerated} = await import('./typeSchemeForMesh.gb');
    return await buildJsTypeSchemeForMeshGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTypeSchemeForMesh(jsObject: any): Promise<any> {
    let {buildDotNetTypeSchemeForMeshGenerated} = await import('./typeSchemeForMesh.gb');
    return await buildDotNetTypeSchemeForMeshGenerated(jsObject);
}
