import {
    buildDotNetPortalFeaturedGroupsGenerated,
    buildJsPortalFeaturedGroupsGenerated
} from "./portalFeaturedGroups.gb";

export function buildJsPortalFeaturedGroups(dotNetObject: any): Promise<any> {
    return buildJsPortalFeaturedGroupsGenerated(dotNetObject);
}     

export async function buildDotNetPortalFeaturedGroups(jsObject: any, viewId: string | null): Promise<any> {
    return await buildDotNetPortalFeaturedGroupsGenerated(jsObject, viewId);
}
