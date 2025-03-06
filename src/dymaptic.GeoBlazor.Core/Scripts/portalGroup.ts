// override generated code in this file
import PortalGroupGenerated from './portalGroup.gb';
import PortalGroup from '@arcgis/core/portal/PortalGroup';

export default class PortalGroupWrapper extends PortalGroupGenerated {

    constructor(component: PortalGroup) {
        super(component);
    }

}

export async function buildJsPortalGroup(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPortalGroupGenerated} = await import('./portalGroup.gb');
    return await buildJsPortalGroupGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPortalGroup(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetPortalGroupGenerated} = await import('./portalGroup.gb');
    return await buildDotNetPortalGroupGenerated(jsObject, layerId, viewId);
}
