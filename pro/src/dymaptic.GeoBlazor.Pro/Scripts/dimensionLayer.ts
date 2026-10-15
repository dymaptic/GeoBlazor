// override generated code in this file
import DimensionLayerGenerated from './dimensionLayer.gb';
import DimensionLayer from '@arcgis/core/layers/DimensionLayer';

export default class DimensionLayerWrapper extends DimensionLayerGenerated {

    constructor(layer: DimensionLayer) {
        super(layer);
    }
    
}

export async function buildJsDimensionLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDimensionLayerGenerated } = await import('./dimensionLayer.gb');
    return await buildJsDimensionLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDimensionLayer(jsObject: any): Promise<any> {
    let { buildDotNetDimensionLayerGenerated } = await import('./dimensionLayer.gb');
    return await buildDotNetDimensionLayerGenerated(jsObject);
}
