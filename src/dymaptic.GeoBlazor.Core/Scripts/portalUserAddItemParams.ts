// override generated code in this file
import PortalUserAddItemParamsGenerated from './portalUserAddItemParams.gb';
import PortalUserAddItemParams = __esri.PortalUserAddItemParams;

export default class PortalUserAddItemParamsWrapper extends PortalUserAddItemParamsGenerated {

    constructor(component: PortalUserAddItemParams) {
        super(component);
    }
    
}              
export async function buildJsPortalUserAddItemParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPortalUserAddItemParamsGenerated } = await import('./portalUserAddItemParams.gb');
    return await buildJsPortalUserAddItemParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPortalUserAddItemParams(jsObject: any): Promise<any> {
    let { buildDotNetPortalUserAddItemParamsGenerated } = await import('./portalUserAddItemParams.gb');
    return await buildDotNetPortalUserAddItemParamsGenerated(jsObject);
}
