import PortalBasemapsSource from '@arcgis/core/widgets/BasemapGallery/support/PortalBasemapsSource';
import PortalBasemapsSourceGenerated from './portalBasemapsSource.gb';

export default class PortalBasemapsSourceWrapper extends PortalBasemapsSourceGenerated {

    constructor(component: PortalBasemapsSource) {
        super(component);
    }

}

export async function buildJsPortalBasemapsSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPortalBasemapsSourceGenerated} = await import('./portalBasemapsSource.gb');
    return await buildJsPortalBasemapsSourceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPortalBasemapsSource(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetPortalBasemapsSourceGenerated} = await import('./portalBasemapsSource.gb');
    return await buildDotNetPortalBasemapsSourceGenerated(jsObject, layerId, viewId);
}
