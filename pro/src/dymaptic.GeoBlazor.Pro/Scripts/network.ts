// override generated code in this file
import NetworkGenerated from './network.gb';
import Network from '@arcgis/core/networks/Network';

export default class NetworkWrapper extends NetworkGenerated {

    constructor(component: Network) {
        super(component);
    }
    
}

export async function buildJsNetwork(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsNetworkGenerated } = await import('./network.gb');
    return await buildJsNetworkGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetNetwork(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetNetworkGenerated } = await import('./network.gb');
    return await buildDotNetNetworkGenerated(jsObject, layerId, viewId);
}
