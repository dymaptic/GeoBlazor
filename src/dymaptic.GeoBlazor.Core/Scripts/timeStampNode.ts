
export async function buildJsTimeStampNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTimeStampNodeGenerated } = await import('./timeStampNode.gb');
    return await buildJsTimeStampNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTimeStampNode(jsObject: any): Promise<any> {
    let { buildDotNetTimeStampNodeGenerated } = await import('./timeStampNode.gb');
    return await buildDotNetTimeStampNodeGenerated(jsObject);
}
