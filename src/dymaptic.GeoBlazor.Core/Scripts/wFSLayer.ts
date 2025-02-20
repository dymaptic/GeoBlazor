// override generated code in this file
import WFSLayerGenerated from './wFSLayer.gb';
import WFSLayer from '@arcgis/core/layers/WFSLayer';

export default class WFSLayerWrapper extends WFSLayerGenerated {

    constructor(layer: WFSLayer) {
        super(layer);
    }

}

export async function buildJsWFSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWFSLayerGenerated} = await import('./wFSLayer.gb');
    return await buildJsWFSLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWFSLayer(jsObject: any): Promise<any> {
    let {buildDotNetWFSLayerGenerated} = await import('./wFSLayer.gb');
    return await buildDotNetWFSLayerGenerated(jsObject);
}
