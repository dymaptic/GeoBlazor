// override generated code in this file
import WCSLayerGenerated from './wCSLayer.gb';
import WCSLayer from '@arcgis/core/layers/WCSLayer';

export default class WCSLayerWrapper extends WCSLayerGenerated {

    constructor(layer: WCSLayer) {
        super(layer);
    }

}

export async function buildJsWCSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWCSLayerGenerated} = await import('./wCSLayer.gb');
    return await buildJsWCSLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWCSLayer(jsObject: any): Promise<any> {
    let {buildDotNetWCSLayerGenerated} = await import('./wCSLayer.gb');
    return await buildDotNetWCSLayerGenerated(jsObject);
}
