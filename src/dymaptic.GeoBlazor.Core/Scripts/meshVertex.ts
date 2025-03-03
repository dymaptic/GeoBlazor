
export async function buildJsMeshVertex(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeshVertexGenerated } = await import('./meshVertex.gb');
    return await buildJsMeshVertexGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeshVertex(jsObject: any): Promise<any> {
    let { buildDotNetMeshVertexGenerated } = await import('./meshVertex.gb');
    return await buildDotNetMeshVertexGenerated(jsObject);
}
