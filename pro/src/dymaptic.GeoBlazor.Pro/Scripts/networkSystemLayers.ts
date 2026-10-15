// override generated code in this file
import NetworkSystemLayersGenerated from './networkSystemLayers.gb';
import NetworkSystemLayers from '@arcgis/core/networks/support/NetworkSystemLayers';

export default class NetworkSystemLayersWrapper extends NetworkSystemLayersGenerated {

    constructor(component: NetworkSystemLayers) {
        super(component);
    }
    
}

export async function buildJsNetworkSystemLayers(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsNetworkSystemLayersGenerated } = await import('./networkSystemLayers.gb');
    return await buildJsNetworkSystemLayersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetNetworkSystemLayers(jsObject: any): Promise<any> {
    let { buildDotNetNetworkSystemLayersGenerated } = await import('./networkSystemLayers.gb');
    return await buildDotNetNetworkSystemLayersGenerated(jsObject);
}
