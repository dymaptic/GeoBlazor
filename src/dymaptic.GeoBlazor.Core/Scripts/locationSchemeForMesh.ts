export async function buildJsLocationSchemeForMesh(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocationSchemeForMeshGenerated} = await import('./locationSchemeForMesh.gb');
    return await buildJsLocationSchemeForMeshGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocationSchemeForMesh(jsObject: any): Promise<any> {
    let {buildDotNetLocationSchemeForMeshGenerated} = await import('./locationSchemeForMesh.gb');
    return await buildDotNetLocationSchemeForMeshGenerated(jsObject);
}
