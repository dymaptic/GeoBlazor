// override generated code in this file
import WMTSSublayerGenerated from './wMTSSublayer.gb';
import WMTSSublayer from '@arcgis/core/layers/support/WMTSSublayer';

export default class WMTSSublayerWrapper extends WMTSSublayerGenerated {

    constructor(component: WMTSSublayer) {
        super(component);
    }
    
}

export async function buildJsWMTSSublayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWMTSSublayerGenerated } = await import('./wMTSSublayer.gb');
    return await buildJsWMTSSublayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWMTSSublayer(jsObject: any): Promise<any> {
    let { buildDotNetWMTSSublayerGenerated } = await import('./wMTSSublayer.gb');
    return await buildDotNetWMTSSublayerGenerated(jsObject);
}
