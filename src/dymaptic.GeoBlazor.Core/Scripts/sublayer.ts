// override generated code in this file
import SublayerGenerated from './sublayer.gb';
import Sublayer from '@arcgis/core/layers/support/Sublayer';

export default class SublayerWrapper extends SublayerGenerated {

    constructor(component: Sublayer) {
        super(component);
    }
    
}              
export async function buildJsSublayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSublayerGenerated } = await import('./sublayer.gb');
    return await buildJsSublayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSublayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSublayerGenerated } = await import('./sublayer.gb');
    return await buildDotNetSublayerGenerated(jsObject, layerId, viewId);
}
