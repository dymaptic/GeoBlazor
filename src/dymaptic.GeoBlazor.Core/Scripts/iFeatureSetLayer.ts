// override generated code in this file
import IFeatureSetLayerGenerated from './iFeatureSetLayer.gb';
import FeatureSetLayer = __esri.FeatureSetLayer;

export default class IFeatureSetLayerWrapper extends IFeatureSetLayerGenerated {

    constructor(layer: FeatureSetLayer) {
        super(layer);
    }

}

export async function buildJsIFeatureSetLayer(dotNetObject: any): Promise<any> {
    let {buildJsIFeatureSetLayerGenerated} = await import('./iFeatureSetLayer.gb');
    return buildJsIFeatureSetLayerGenerated(dotNetObject);
}

export async function buildDotNetIFeatureSetLayer(jsObject: any): Promise<any> {
    let {buildDotNetIFeatureSetLayerGenerated} = await import('./iFeatureSetLayer.gb');
    return await buildDotNetIFeatureSetLayerGenerated(jsObject);
}
