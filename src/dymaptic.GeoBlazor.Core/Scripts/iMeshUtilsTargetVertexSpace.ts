
export async function buildJsIMeshUtilsTargetVertexSpace(dotNetObject: any): Promise<any> {
    let { buildJsIMeshUtilsTargetVertexSpaceGenerated } = await import('./iMeshUtilsTargetVertexSpace.gb');
    return await buildJsIMeshUtilsTargetVertexSpaceGenerated(dotNetObject);
}     

export async function buildDotNetIMeshUtilsTargetVertexSpace(jsObject: any): Promise<any> {
    let { buildDotNetIMeshUtilsTargetVertexSpaceGenerated } = await import('./iMeshUtilsTargetVertexSpace.gb');
    return await buildDotNetIMeshUtilsTargetVertexSpaceGenerated(jsObject);
}
