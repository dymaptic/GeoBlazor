// override generated code in this file
import PortalItemResourceGenerated from './portalItemResource.gb';
import PortalItemResource from '@arcgis/core/portal/PortalItemResource';

export default class PortalItemResourceWrapper extends PortalItemResourceGenerated {

    constructor(component: PortalItemResource) {
        super(component);
    }

}

export async function buildJsPortalItemResource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPortalItemResourceGenerated} = await import('./portalItemResource.gb');
    return await buildJsPortalItemResourceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPortalItemResource(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetPortalItemResourceGenerated} = await import('./portalItemResource.gb');
    return await buildDotNetPortalItemResourceGenerated(jsObject, layerId, viewId);
}
