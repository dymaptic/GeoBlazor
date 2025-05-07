
export async function buildJsIUrbanMeshUtilsTargetVertexSpace(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIUrbanMeshUtilsTargetVertexSpaceGenerated } = await import('./iUrbanMeshUtilsTargetVertexSpace.gb');
    return await buildJsIUrbanMeshUtilsTargetVertexSpaceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIUrbanMeshUtilsTargetVertexSpace(jsObject: any): Promise<any> {
    let { buildDotNetIUrbanMeshUtilsTargetVertexSpaceGenerated } = await import('./iUrbanMeshUtilsTargetVertexSpace.gb');
    return await buildDotNetIUrbanMeshUtilsTargetVertexSpaceGenerated(jsObject);
}
