// override generated code in this file
import ITemporalLayerGenerated from './iTemporalLayer.gb';
import TemporalLayer = __esri.TemporalLayer;

export default class ITemporalLayerWrapper extends ITemporalLayerGenerated {

    constructor(layer: TemporalLayer) {
        super(layer);
    }

}

export async function buildJsITemporalLayer(dotNetObject: any): Promise<any> {
    let {buildJsITemporalLayerGenerated} = await import('./iTemporalLayer.gb');
    return buildJsITemporalLayerGenerated(dotNetObject);
}

export async function buildDotNetITemporalLayer(jsObject: any): Promise<any> {
    let {buildDotNetITemporalLayerGenerated} = await import('./iTemporalLayer.gb');
    return await buildDotNetITemporalLayerGenerated(jsObject);
}
