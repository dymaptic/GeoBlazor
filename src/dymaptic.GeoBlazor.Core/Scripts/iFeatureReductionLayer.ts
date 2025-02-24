// override generated code in this file
import IFeatureReductionLayerGenerated from './iFeatureReductionLayer.gb';
import FeatureReductionLayer = __esri.FeatureReductionLayer;

export default class IFeatureReductionLayerWrapper extends IFeatureReductionLayerGenerated {

    constructor(layer: FeatureReductionLayer) {
        super(layer);
    }

}

export async function buildJsIFeatureReductionLayer(dotNetObject: any): Promise<any> {
    let {buildJsIFeatureReductionLayerGenerated} = await import('./iFeatureReductionLayer.gb');
    return buildJsIFeatureReductionLayerGenerated(dotNetObject);
}

export async function buildDotNetIFeatureReductionLayer(jsObject: any): Promise<any> {
    let {buildDotNetIFeatureReductionLayerGenerated} = await import('./iFeatureReductionLayer.gb');
    return await buildDotNetIFeatureReductionLayerGenerated(jsObject);
}
