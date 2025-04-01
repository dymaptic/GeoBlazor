
export async function buildJsPortalFolder(dotNetObject: any): Promise<any> {
    let { buildJsPortalFolderGenerated } = await import('./portalFolder.gb');
    return await buildJsPortalFolderGenerated(dotNetObject);
}     

export async function buildDotNetPortalFolder(jsObject: any): Promise<any> {
    let { buildDotNetPortalFolderGenerated } = await import('./portalFolder.gb');
    return await buildDotNetPortalFolderGenerated(jsObject);
}
