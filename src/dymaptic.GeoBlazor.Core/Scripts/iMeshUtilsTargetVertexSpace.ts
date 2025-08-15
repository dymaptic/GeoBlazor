
export async function buildJsIMeshUtilsTargetVertexSpace(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIMeshUtilsTargetVertexSpaceGenerated } = await import('./iMeshUtilsTargetVertexSpace.gb');
    return await buildJsIMeshUtilsTargetVertexSpaceGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIMeshUtilsTargetVertexSpace(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIMeshUtilsTargetVertexSpaceGenerated } = await import('./iMeshUtilsTargetVertexSpace.gb');
    return await buildDotNetIMeshUtilsTargetVertexSpaceGenerated(jsObject, viewId);
}
