// override generated code in this file
import WebMapGenerated from './webMap.gb';
import WebMap from '@arcgis/core/WebMap';
import {esriConfig, hasValue} from './geoBlazorCore';

export default class WebMapWrapper extends WebMapGenerated {

    constructor(component: WebMap) {
        super(component);
    }
    
}

export async function buildJsWebMap(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebMapGenerated } = await import('./webMap.gb');
    let webmap;
    if (hasValue(dotNetObject.portalItem.excludeApiKey) && dotNetObject.portalItem.excludeApiKey) {
        esriConfig.apiKey = null;
        // this will be re-added in GeoBlazor's `AuthenticationManager` on the next MapView.
    }
    try {
        webmap = await buildJsWebMapGenerated(dotNetObject, layerId, viewId);
    } catch (e) {
        if (!hasValue(dotNetObject.portalItem.excludeApiKey) || dotNetObject.portalItem.excludeApiKey === false) {
            console.error(e);
            console.warn('WebMap: Failed to load WebMap with API key. Trying again without API key. To avoid this issue, set the property ExcludeApiKey="true" on the WebMap PortalItem in GeoBlazor. https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.PortalItem.html#portalitemexcludeapikey-property');
            esriConfig.apiKey = null;
            // this will be re-added in GeoBlazor's `AuthenticationManager` on the next MapView.
            webmap = await buildJsWebMapGenerated(dotNetObject, layerId, viewId);
        } else {
            throw e;
        }
    }
    
    return webmap;
}     

export async function buildDotNetWebMap(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetWebMapGenerated } = await import('./webMap.gb');
    return await buildDotNetWebMapGenerated(jsObject, layerId, viewId);
}
