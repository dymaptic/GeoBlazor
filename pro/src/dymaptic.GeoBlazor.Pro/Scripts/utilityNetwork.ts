import UtilityNetwork from '@arcgis/core/networks/UtilityNetwork';
// override generated code in this file
import UtilityNetworkGenerated from './utilityNetwork.gb';

export default class UtilityNetworkWrapper extends UtilityNetworkGenerated {

    constructor(component: UtilityNetwork) {
        super(component);
    }
    
}

export async function buildJsUtilityNetwork(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUtilityNetworkGenerated } = await import('./utilityNetwork.gb');
    return await buildJsUtilityNetworkGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUtilityNetwork(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUtilityNetworkGenerated } = await import('./utilityNetwork.gb');
    return await buildDotNetUtilityNetworkGenerated(jsObject, layerId, viewId);
}
