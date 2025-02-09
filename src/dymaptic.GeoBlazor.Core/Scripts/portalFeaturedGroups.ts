// override generated code in this file
import PortalFeaturedGroupsGenerated from './portalFeaturedGroups.gb';
import PortalFeaturedGroups = __esri.PortalFeaturedGroups;

export default class PortalFeaturedGroupsWrapper extends PortalFeaturedGroupsGenerated {

    constructor(component: PortalFeaturedGroups) {
        super(component);
    }
    
}              
export async function buildJsPortalFeaturedGroups(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPortalFeaturedGroupsGenerated } = await import('./portalFeaturedGroups.gb');
    return await buildJsPortalFeaturedGroupsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPortalFeaturedGroups(jsObject: any): Promise<any> {
    let { buildDotNetPortalFeaturedGroupsGenerated } = await import('./portalFeaturedGroups.gb');
    return await buildDotNetPortalFeaturedGroupsGenerated(jsObject);
}
