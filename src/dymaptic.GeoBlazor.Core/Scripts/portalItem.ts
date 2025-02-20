// override generated code in this file
import PortalItemGenerated from './portalItem.gb';
import PortalItem from '@arcgis/core/portal/PortalItem';

export default class PortalItemWrapper extends PortalItemGenerated {

    constructor(component: PortalItem) {
        super(component);
    }

}

export async function buildJsPortalItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPortalItemGenerated} = await import('./portalItem.gb');
    return await buildJsPortalItemGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPortalItem(jsObject: any): Promise<any> {
    let {buildDotNetPortalItemGenerated} = await import('./portalItem.gb');
    return await buildDotNetPortalItemGenerated(jsObject);
}

// test
