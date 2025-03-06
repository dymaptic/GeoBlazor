// override generated code in this file
import PortalUserGenerated from './portalUser.gb';
import PortalUser from '@arcgis/core/portal/PortalUser';

export default class PortalUserWrapper extends PortalUserGenerated {

    constructor(component: PortalUser) {
        super(component);
    }

}

export async function buildJsPortalUser(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPortalUserGenerated} = await import('./portalUser.gb');
    return await buildJsPortalUserGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPortalUser(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetPortalUserGenerated} = await import('./portalUser.gb');
    return await buildDotNetPortalUserGenerated(jsObject, layerId, viewId);
}
