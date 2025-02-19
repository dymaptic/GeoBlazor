// override generated code in this file
import WMSSublayerGenerated from './wMSSublayer.gb';
import WMSSublayer from '@arcgis/core/layers/support/WMSSublayer';

export default class WMSSublayerWrapper extends WMSSublayerGenerated {

    constructor(component: WMSSublayer) {
        super(component);
    }
    
}

export async function buildJsWMSSublayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWMSSublayerGenerated } = await import('./wMSSublayer.gb');
    return await buildJsWMSSublayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWMSSublayer(jsObject: any): Promise<any> {
    let { buildDotNetWMSSublayerGenerated } = await import('./wMSSublayer.gb');
    return await buildDotNetWMSSublayerGenerated(jsObject);
}
