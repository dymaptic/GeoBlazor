
export async function buildJsSupportingWidgetDefaultsAttachments(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSupportingWidgetDefaultsAttachmentsGenerated } = await import('./supportingWidgetDefaultsAttachments.gb');
    return await buildJsSupportingWidgetDefaultsAttachmentsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSupportingWidgetDefaultsAttachments(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSupportingWidgetDefaultsAttachmentsGenerated } = await import('./supportingWidgetDefaultsAttachments.gb');
    return await buildDotNetSupportingWidgetDefaultsAttachmentsGenerated(jsObject, layerId, viewId);
}
