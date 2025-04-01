
export async function buildJsCapabilitiesMetadata(dotNetObject: any): Promise<any> {
    let { buildJsCapabilitiesMetadataGenerated } = await import('./capabilitiesMetadata.gb');
    return await buildJsCapabilitiesMetadataGenerated(dotNetObject);
}     

export async function buildDotNetCapabilitiesMetadata(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesMetadataGenerated } = await import('./capabilitiesMetadata.gb');
    return await buildDotNetCapabilitiesMetadataGenerated(jsObject);
}
