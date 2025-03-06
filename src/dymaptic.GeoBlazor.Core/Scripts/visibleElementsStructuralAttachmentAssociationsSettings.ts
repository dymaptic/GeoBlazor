
export async function buildJsVisibleElementsStructuralAttachmentAssociationsSettings(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVisibleElementsStructuralAttachmentAssociationsSettingsGenerated } = await import('./visibleElementsStructuralAttachmentAssociationsSettings.gb');
    return await buildJsVisibleElementsStructuralAttachmentAssociationsSettingsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVisibleElementsStructuralAttachmentAssociationsSettings(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVisibleElementsStructuralAttachmentAssociationsSettingsGenerated } = await import('./visibleElementsStructuralAttachmentAssociationsSettings.gb');
    return await buildDotNetVisibleElementsStructuralAttachmentAssociationsSettingsGenerated(jsObject, layerId, viewId);
}
