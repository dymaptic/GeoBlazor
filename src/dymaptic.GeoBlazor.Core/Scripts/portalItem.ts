// override generated code in this file
import PortalItemGenerated from './portalItem.gb';
import PortalItem from '@arcgis/core/portal/PortalItem';
import { hasValue, esriConfig } from './geoBlazorCore';

export default class PortalItemWrapper extends PortalItemGenerated {

    constructor(component: PortalItem) {
        super(component);
    }

    async updateThumbnail(thumbnail: any, filename: string | null): Promise<any> {
        let parameters: any = {};
        if (thumbnail instanceof ArrayBuffer) {
            parameters = {
                thumbnail: new Blob([thumbnail]),
                filename: filename
            };
        } else {
            parameters = {
                thumbnail: thumbnail,
                filename: filename
            };
        }
        
        let result = await this.component.updateThumbnail(parameters);
        let { buildDotNetPortalItem } = await import('./portalItem');
        return await buildDotNetPortalItem(result, this.layerId, this.viewId);
    }
}

export async function buildJsPortalItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (hasValue(dotNetObject.apiKey) || (hasValue(dotNetObject.excludeApiKey) && dotNetObject.excludeApiKey)) {
        esriConfig.apiKey = null;
        // this will be re-added in GeoBlazor's `AuthenticationManager` on the next MapView.
    }

    let {buildJsPortalItemGenerated} = await import('./portalItem.gb');
    return await buildJsPortalItemGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPortalItem(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetPortalItemGenerated} = await import('./portalItem.gb');
    return await buildDotNetPortalItemGenerated(jsObject, layerId, viewId);
}
