// override generated code in this file
import VectorTileLayerGenerated from './vectorTileLayer.gb';
import VectorTileLayer from '@arcgis/core/layers/VectorTileLayer';

export default class VectorTileLayerWrapper extends VectorTileLayerGenerated {

    constructor(layer: VectorTileLayer) {
        super(layer);
    }
    
}              
export async function buildJsVectorTileLayer(dotNetObject: any): Promise<any> {
    let { buildJsVectorTileLayerGenerated } = await import('./vectorTileLayer.gb');
    return await buildJsVectorTileLayerGenerated(dotNetObject);
}
export async function buildDotNetVectorTileLayer(jsObject: any): Promise<any> {
    let { buildDotNetVectorTileLayerGenerated } = await import('./vectorTileLayer.gb');
    return await buildDotNetVectorTileLayerGenerated(jsObject);
}
