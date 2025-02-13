// override generated code in this file
import KMLLayerGenerated from './kMLLayer.gb';
import KMLLayer from '@arcgis/core/layers/KMLLayer';

export default class KMLLayerWrapper extends KMLLayerGenerated {

    constructor(layer: KMLLayer) {
        super(layer);
    }
    
}              
export async function buildJsKMLLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsKMLLayerGenerated } = await import('./kMLLayer.gb');
    return await buildJsKMLLayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetKMLLayer(jsObject: any): Promise<any> {
    let { buildDotNetKMLLayerGenerated } = await import('./kMLLayer.gb');
    return await buildDotNetKMLLayerGenerated(jsObject);
}
