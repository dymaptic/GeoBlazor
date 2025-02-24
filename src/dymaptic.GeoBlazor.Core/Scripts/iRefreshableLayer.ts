// override generated code in this file
import IRefreshableLayerGenerated from './iRefreshableLayer.gb';
import RefreshableLayer = __esri.RefreshableLayer;

export default class IRefreshableLayerWrapper extends IRefreshableLayerGenerated {

    constructor(layer: RefreshableLayer) {
        super(layer);
    }

}

export async function buildJsIRefreshableLayer(dotNetObject: any): Promise<any> {
    let {buildJsIRefreshableLayerGenerated} = await import('./iRefreshableLayer.gb');
    return buildJsIRefreshableLayerGenerated(dotNetObject);
}

export async function buildDotNetIRefreshableLayer(jsObject: any): Promise<any> {
    let {buildDotNetIRefreshableLayerGenerated} = await import('./iRefreshableLayer.gb');
    return await buildDotNetIRefreshableLayerGenerated(jsObject);
}
