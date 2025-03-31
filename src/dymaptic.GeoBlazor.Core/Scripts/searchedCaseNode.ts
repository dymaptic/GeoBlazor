
export async function buildJsSearchedCaseNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchedCaseNodeGenerated } = await import('./searchedCaseNode.gb');
    return await buildJsSearchedCaseNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchedCaseNode(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSearchedCaseNodeGenerated } = await import('./searchedCaseNode.gb');
    return await buildDotNetSearchedCaseNodeGenerated(jsObject, layerId, viewId);
}
