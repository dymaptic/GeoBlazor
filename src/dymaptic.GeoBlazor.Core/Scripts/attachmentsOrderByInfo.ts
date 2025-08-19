
export async function buildJsAttachmentsOrderByInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttachmentsOrderByInfoGenerated } = await import('./attachmentsOrderByInfo.gb');
    return await buildJsAttachmentsOrderByInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttachmentsOrderByInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetAttachmentsOrderByInfoGenerated } = await import('./attachmentsOrderByInfo.gb');
    return await buildDotNetAttachmentsOrderByInfoGenerated(jsObject, viewId);
}
