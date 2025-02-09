// override generated code in this file
import KMLSublayerGenerated from './kMLSublayer.gb';
import KMLSublayer from '@arcgis/core/layers/support/KMLSublayer';

export default class KMLSublayerWrapper extends KMLSublayerGenerated {

    constructor(component: KMLSublayer) {
        super(component);
    }
    
}              
export async function buildJsKMLSublayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsKMLSublayerGenerated } = await import('./kMLSublayer.gb');
    return await buildJsKMLSublayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetKMLSublayer(jsObject: any): Promise<any> {
    let { buildDotNetKMLSublayerGenerated } = await import('./kMLSublayer.gb');
    return await buildDotNetKMLSublayerGenerated(jsObject);
}
