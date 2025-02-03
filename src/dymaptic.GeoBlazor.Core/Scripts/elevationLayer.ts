// override generated code in this file
import ElevationLayerGenerated from './elevationLayer.gb';
import ElevationLayer from '@arcgis/core/layers/ElevationLayer';

export default class ElevationLayerWrapper extends ElevationLayerGenerated {

    constructor(layer: ElevationLayer) {
        super(layer);
    }
    
}              
export async function buildJsElevationLayer(dotNetObject: any): Promise<any> {
    let { buildJsElevationLayerGenerated } = await import('./elevationLayer.gb');
    return await buildJsElevationLayerGenerated(dotNetObject);
}
export async function buildDotNetElevationLayer(jsObject: any): Promise<any> {
    let { buildDotNetElevationLayerGenerated } = await import('./elevationLayer.gb');
    return await buildDotNetElevationLayerGenerated(jsObject);
}
