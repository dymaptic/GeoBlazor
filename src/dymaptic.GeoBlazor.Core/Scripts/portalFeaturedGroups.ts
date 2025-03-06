
export async function buildJsPortalFeaturedGroups(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPortalFeaturedGroupsGenerated } = await import('./portalFeaturedGroups.gb');
    return await buildJsPortalFeaturedGroupsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPortalFeaturedGroups(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPortalFeaturedGroupsGenerated } = await import('./portalFeaturedGroups.gb');
    return await buildDotNetPortalFeaturedGroupsGenerated(jsObject, layerId, viewId);
}
