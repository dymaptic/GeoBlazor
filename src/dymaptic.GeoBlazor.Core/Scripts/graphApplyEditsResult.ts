
export async function buildJsGraphApplyEditsResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGraphApplyEditsResultGenerated } = await import('./graphApplyEditsResult.gb');
    return await buildJsGraphApplyEditsResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGraphApplyEditsResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetGraphApplyEditsResultGenerated } = await import('./graphApplyEditsResult.gb');
    return await buildDotNetGraphApplyEditsResultGenerated(jsObject, layerId, viewId);
}
