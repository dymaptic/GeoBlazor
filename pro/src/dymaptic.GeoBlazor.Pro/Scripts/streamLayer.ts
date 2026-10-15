// override generated code in this file
import StreamLayerGenerated from './streamLayer.gb';
import StreamLayer from '@arcgis/core/layers/StreamLayer';

export default class StreamLayerWrapper extends StreamLayerGenerated {

    constructor(layer: StreamLayer) {
        super(layer);
    }
    
}

export async function buildJsStreamLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStreamLayerGenerated } = await import('./streamLayer.gb');
    return await buildJsStreamLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStreamLayer(jsObject: any): Promise<any> {
    let { buildDotNetStreamLayerGenerated } = await import('./streamLayer.gb');
    return await buildDotNetStreamLayerGenerated(jsObject);
}
