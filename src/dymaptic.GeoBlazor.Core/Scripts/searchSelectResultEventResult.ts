
export async function buildJsSearchSelectResultEventResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchSelectResultEventResultGenerated } = await import('./searchSelectResultEventResult.gb');
    return await buildJsSearchSelectResultEventResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchSelectResultEventResult(jsObject: any): Promise<any> {
    let { buildDotNetSearchSelectResultEventResultGenerated } = await import('./searchSelectResultEventResult.gb');
    return await buildDotNetSearchSelectResultEventResultGenerated(jsObject);
}
