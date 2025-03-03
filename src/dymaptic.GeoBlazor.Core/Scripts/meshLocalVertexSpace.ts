
export async function buildJsMeshLocalVertexSpace(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeshLocalVertexSpaceGenerated } = await import('./meshLocalVertexSpace.gb');
    return await buildJsMeshLocalVertexSpaceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeshLocalVertexSpace(jsObject: any): Promise<any> {
    let { buildDotNetMeshLocalVertexSpaceGenerated } = await import('./meshLocalVertexSpace.gb');
    return await buildDotNetMeshLocalVertexSpaceGenerated(jsObject);
}
