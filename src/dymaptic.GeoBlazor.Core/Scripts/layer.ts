// override generated code in this file
import LayerGenerated from './layer.gb';
import Layer from '@arcgis/core/layers/Layer';

export default class LayerWrapper extends LayerGenerated {

    constructor(layer: Layer) {
        super(layer);
    }
    
}

export async function buildJsLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerGenerated } = await import('./layer.gb');
    return await buildJsLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLayerGenerated } = await import('./layer.gb');
    return await buildDotNetLayerGenerated(jsObject, layerId, viewId);
}
