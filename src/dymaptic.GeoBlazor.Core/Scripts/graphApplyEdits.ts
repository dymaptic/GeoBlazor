
export async function buildJsGraphApplyEdits(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGraphApplyEditsGenerated } = await import('./graphApplyEdits.gb');
    return await buildJsGraphApplyEditsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGraphApplyEdits(jsObject: any): Promise<any> {
    let { buildDotNetGraphApplyEditsGenerated } = await import('./graphApplyEdits.gb');
    return await buildDotNetGraphApplyEditsGenerated(jsObject);
}
