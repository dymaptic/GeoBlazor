// override generated code in this file
import ITrackableLayerGenerated from './iTrackableLayer.gb';
import TrackableLayer = __esri.TrackableLayer;

export default class ITrackableLayerWrapper extends ITrackableLayerGenerated {

    constructor(layer: TrackableLayer) {
        super(layer);
    }
    
}

export async function buildJsITrackableLayer(dotNetObject: any): Promise<any> {
    let { buildJsITrackableLayerGenerated } = await import('./iTrackableLayer.gb');
    return await buildJsITrackableLayerGenerated(dotNetObject);
}     

export async function buildDotNetITrackableLayer(jsObject: any): Promise<any> {
    let { buildDotNetITrackableLayerGenerated } = await import('./iTrackableLayer.gb');
    return await buildDotNetITrackableLayerGenerated(jsObject);
}
