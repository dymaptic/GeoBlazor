import PortalBasemapsSource from '@arcgis/core/widgets/BasemapGallery/support/PortalBasemapsSource';
import PortalBasemapsSourceGenerated from './portalBasemapsSource.gb';
import {hasValue} from './geoBlazorCore';

export default class PortalBasemapsSourceWrapper extends PortalBasemapsSourceGenerated {

    constructor(component: PortalBasemapsSource) {
        super(component);
    }

}

export async function buildJsPortalBasemapsSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPortalBasemapsSourceGenerated} = await import('./portalBasemapsSource.gb');
    let jsObject = await buildJsPortalBasemapsSourceGenerated(dotNetObject, layerId, viewId);
    
    if (hasValue(dotNetObject.queryString)) {
        jsObject.query = dotNetObject.queryString;
    } else if (hasValue(dotNetObject.queryParams)) {
        jsObject.query = dotNetObject.queryParams;
    }
    
    return jsObject;
}

export async function buildDotNetPortalBasemapsSource(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetPortalBasemapsSourceGenerated} = await import('./portalBasemapsSource.gb');
    return await buildDotNetPortalBasemapsSourceGenerated(jsObject, viewId);
}
