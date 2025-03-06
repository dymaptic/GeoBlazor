// override generated code in this file
import WMTSLayerGenerated from './wMTSLayer.gb';
import WMTSLayer from '@arcgis/core/layers/WMTSLayer';

export default class WMTSLayerWrapper extends WMTSLayerGenerated {

    constructor(layer: WMTSLayer) {
        super(layer);
    }

}

export async function buildJsWMTSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWMTSLayerGenerated} = await import('./wMTSLayer.gb');
    return await buildJsWMTSLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWMTSLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetWMTSLayerGenerated} = await import('./wMTSLayer.gb');
    return await buildDotNetWMTSLayerGenerated(jsObject, layerId, viewId);
}
