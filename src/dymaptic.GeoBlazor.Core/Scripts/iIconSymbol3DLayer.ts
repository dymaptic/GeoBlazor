// override generated code in this file
import IIconSymbol3DLayerGenerated from './iIconSymbol3DLayer.gb';
import IconSymbol3DLayer from '@arcgis/core/symbols/IconSymbol3DLayer';

export default class IIconSymbol3DLayerWrapper extends IIconSymbol3DLayerGenerated {

    constructor(layer: IconSymbol3DLayer) {
        super(layer);
    }
    
}

export async function buildJsIIconSymbol3DLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIIconSymbol3DLayerGenerated } = await import('./iIconSymbol3DLayer.gb');
    return await buildJsIIconSymbol3DLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIIconSymbol3DLayer(jsObject: any): Promise<any> {
    let { buildDotNetIIconSymbol3DLayerGenerated } = await import('./iIconSymbol3DLayer.gb');
    return await buildDotNetIIconSymbol3DLayerGenerated(jsObject);
}
