
export async function buildJsRelatedRecordsInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelatedRecordsInfoGenerated } = await import('./relatedRecordsInfo.gb');
    return await buildJsRelatedRecordsInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelatedRecordsInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRelatedRecordsInfoGenerated } = await import('./relatedRecordsInfo.gb');
    return await buildDotNetRelatedRecordsInfoGenerated(jsObject, layerId, viewId);
}
