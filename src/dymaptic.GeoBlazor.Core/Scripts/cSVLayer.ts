// override generated code in this file
import CSVLayerGenerated from './cSVLayer.gb';
import CSVLayer from '@arcgis/core/layers/CSVLayer';

export default class CSVLayerWrapper extends CSVLayerGenerated {

    constructor(layer: CSVLayer) {
        super(layer);
    }
    
}              
export async function buildJsCSVLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCSVLayerGenerated } = await import('./cSVLayer.gb');
    return await buildJsCSVLayerGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCSVLayer(jsObject: any): Promise<any> {
    let { buildDotNetCSVLayerGenerated } = await import('./cSVLayer.gb');
    return await buildDotNetCSVLayerGenerated(jsObject);
}
