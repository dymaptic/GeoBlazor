
export async function buildJsPortalFeaturedGroups(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsPortalFeaturedGroupsGenerated } = await import('./portalFeaturedGroups.gb');
    return await buildJsPortalFeaturedGroupsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetPortalFeaturedGroups(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPortalFeaturedGroupsGenerated } = await import('./portalFeaturedGroups.gb');
    return await buildDotNetPortalFeaturedGroupsGenerated(jsObject, viewId);
}
