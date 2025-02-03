// override generated code in this file
import MapImageLayerGenerated from './mapImageLayer.gb';
import MapImageLayer from '@arcgis/core/layers/MapImageLayer';

export default class MapImageLayerWrapper extends MapImageLayerGenerated {

    constructor(layer: MapImageLayer) {
        super(layer);
    }
    
}              
export async function buildJsMapImageLayer(dotNetObject: any): Promise<any> {
    let { buildJsMapImageLayerGenerated } = await import('./mapImageLayer.gb');
    return await buildJsMapImageLayerGenerated(dotNetObject);
}
export async function buildDotNetMapImageLayer(jsObject: any): Promise<any> {
    let { buildDotNetMapImageLayerGenerated } = await import('./mapImageLayer.gb');
    return await buildDotNetMapImageLayerGenerated(jsObject);
}
