// override generated code in this file
import WMSLayerGenerated from './wMSLayer.gb';
import WMSLayer from '@arcgis/core/layers/WMSLayer';

export default class WMSLayerWrapper extends WMSLayerGenerated {

    constructor(layer: WMSLayer) {
        super(layer);
    }

}

export async function buildJsWMSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWMSLayerGenerated} = await import('./wMSLayer.gb');
    return await buildJsWMSLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWMSLayer(jsObject: any): Promise<any> {
    let {buildDotNetWMSLayerGenerated} = await import('./wMSLayer.gb');
    return await buildDotNetWMSLayerGenerated(jsObject);
}
