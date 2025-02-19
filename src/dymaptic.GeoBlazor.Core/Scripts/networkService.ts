// override generated code in this file
import NetworkServiceGenerated from './networkService.gb';
import networkService = __esri.networkService;

export default class NetworkServiceWrapper extends NetworkServiceGenerated {

    constructor(component: networkService) {
        super(component);
    }
    
}

export async function buildJsNetworkService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsNetworkServiceGenerated } = await import('./networkService.gb');
    return await buildJsNetworkServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetNetworkService(jsObject: any): Promise<any> {
    let { buildDotNetNetworkServiceGenerated } = await import('./networkService.gb');
    return await buildDotNetNetworkServiceGenerated(jsObject);
}
