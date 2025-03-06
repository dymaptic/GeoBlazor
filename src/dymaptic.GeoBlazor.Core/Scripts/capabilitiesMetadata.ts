
export async function buildJsCapabilitiesMetadata(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesMetadataGenerated } = await import('./capabilitiesMetadata.gb');
    return await buildJsCapabilitiesMetadataGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCapabilitiesMetadata(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCapabilitiesMetadataGenerated } = await import('./capabilitiesMetadata.gb');
    return await buildDotNetCapabilitiesMetadataGenerated(jsObject, layerId, viewId);
}
