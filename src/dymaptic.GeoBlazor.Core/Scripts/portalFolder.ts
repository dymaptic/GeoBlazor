
export async function buildJsPortalFolder(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPortalFolderGenerated } = await import('./portalFolder.gb');
    return await buildJsPortalFolderGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPortalFolder(jsObject: any): Promise<any> {
    let { buildDotNetPortalFolderGenerated } = await import('./portalFolder.gb');
    return await buildDotNetPortalFolderGenerated(jsObject);
}
