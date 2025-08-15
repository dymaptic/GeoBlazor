
export async function buildJsIntervalQualifierNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIntervalQualifierNodeGenerated } = await import('./intervalQualifierNode.gb');
    return await buildJsIntervalQualifierNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIntervalQualifierNode(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIntervalQualifierNodeGenerated } = await import('./intervalQualifierNode.gb');
    return await buildDotNetIntervalQualifierNodeGenerated(jsObject, viewId);
}
