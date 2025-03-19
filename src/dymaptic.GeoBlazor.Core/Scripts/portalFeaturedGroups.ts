
export async function buildJsPortalFeaturedGroups(dotNetObject: any): Promise<any> {
    let { buildJsPortalFeaturedGroupsGenerated } = await import('./portalFeaturedGroups.gb');
    return await buildJsPortalFeaturedGroupsGenerated(dotNetObject);
}     

export async function buildDotNetPortalFeaturedGroups(jsObject: any): Promise<any> {
    let { buildDotNetPortalFeaturedGroupsGenerated } = await import('./portalFeaturedGroups.gb');
    return await buildDotNetPortalFeaturedGroupsGenerated(jsObject);
}
