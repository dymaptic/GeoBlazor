
export async function buildJsMeshGeoreferencedVertexSpace(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeshGeoreferencedVertexSpaceGenerated } = await import('./meshGeoreferencedVertexSpace.gb');
    return await buildJsMeshGeoreferencedVertexSpaceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeshGeoreferencedVertexSpace(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetMeshGeoreferencedVertexSpaceGenerated } = await import('./meshGeoreferencedVertexSpace.gb');
    return await buildDotNetMeshGeoreferencedVertexSpaceGenerated(jsObject, layerId, viewId);
}
