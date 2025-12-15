export async function buildJsRelatedRecordsInfoFieldOrder(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelatedRecordsInfoFieldOrderGenerated } = await import('./relatedRecordsInfoFieldOrder.gb');
    return await buildJsRelatedRecordsInfoFieldOrderGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetRelatedRecordsInfoFieldOrder(jsObject: any): Promise<any> {
    let { buildDotNetRelatedRecordsInfoFieldOrderGenerated } = await import('./relatedRecordsInfoFieldOrder.gb');
    return await buildDotNetRelatedRecordsInfoFieldOrderGenerated(jsObject);
}
