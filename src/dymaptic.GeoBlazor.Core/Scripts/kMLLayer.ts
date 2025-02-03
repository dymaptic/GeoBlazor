// override generated code in this file
import KMLLayerGenerated from './kMLLayer.gb';
import KMLLayer from '@arcgis/core/layers/KMLLayer';

export default class KMLLayerWrapper extends KMLLayerGenerated {

    constructor(layer: KMLLayer) {
        super(layer);
    }
    
}              
export async function buildJsKMLLayer(dotNetObject: any): Promise<any> {
    let { buildJsKMLLayerGenerated } = await import('./kMLLayer.gb');
    return await buildJsKMLLayerGenerated(dotNetObject);
}
export async function buildDotNetKMLLayer(jsObject: any): Promise<any> {
    let { buildDotNetKMLLayerGenerated } = await import('./kMLLayer.gb');
    return await buildDotNetKMLLayerGenerated(jsObject);
}
