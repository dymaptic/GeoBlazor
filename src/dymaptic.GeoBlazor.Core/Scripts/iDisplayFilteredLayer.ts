// override generated code in this file
import IDisplayFilteredLayerGenerated from './iDisplayFilteredLayer.gb';
import DisplayFilteredLayer = __esri.DisplayFilteredLayer;

export default class IDisplayFilteredLayerWrapper extends IDisplayFilteredLayerGenerated {

    constructor(layer: DisplayFilteredLayer) {
        super(layer);
    }
    
}

export async function buildJsIDisplayFilteredLayer(dotNetObject: any): Promise<any> {
    let { buildJsIDisplayFilteredLayerGenerated } = await import('./iDisplayFilteredLayer.gb');
    return await buildJsIDisplayFilteredLayerGenerated(dotNetObject);
}     

export async function buildDotNetIDisplayFilteredLayer(jsObject: any): Promise<any> {
    let { buildDotNetIDisplayFilteredLayerGenerated } = await import('./iDisplayFilteredLayer.gb');
    return await buildDotNetIDisplayFilteredLayerGenerated(jsObject);
}
