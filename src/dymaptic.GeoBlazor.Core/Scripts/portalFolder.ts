
export async function buildJsPortalFolder(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsPortalFolderGenerated } = await import('./portalFolder.gb');
    return await buildJsPortalFolderGenerated(dotNetObject, viewId);
}     

export async function buildDotNetPortalFolder(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPortalFolderGenerated } = await import('./portalFolder.gb');
    return await buildDotNetPortalFolderGenerated(jsObject, viewId);
}
