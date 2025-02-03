// override generated code in this file
import PortalUserGenerated from './portalUser.gb';
import PortalUser from '@arcgis/core/portal/PortalUser';

export default class PortalUserWrapper extends PortalUserGenerated {

    constructor(component: PortalUser) {
        super(component);
    }
    
}              
export async function buildJsPortalUser(dotNetObject: any): Promise<any> {
    let { buildJsPortalUserGenerated } = await import('./portalUser.gb');
    return await buildJsPortalUserGenerated(dotNetObject);
}
export async function buildDotNetPortalUser(jsObject: any): Promise<any> {
    let { buildDotNetPortalUserGenerated } = await import('./portalUser.gb');
    return await buildDotNetPortalUserGenerated(jsObject);
}
