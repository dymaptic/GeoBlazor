
export async function buildJsSharedTemplateMetadata(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSharedTemplateMetadataGenerated } = await import('./sharedTemplateMetadata.gb');
    return await buildJsSharedTemplateMetadataGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSharedTemplateMetadata(jsObject: any): Promise<any> {
    let { buildDotNetSharedTemplateMetadataGenerated } = await import('./sharedTemplateMetadata.gb');
    return await buildDotNetSharedTemplateMetadataGenerated(jsObject);
}
