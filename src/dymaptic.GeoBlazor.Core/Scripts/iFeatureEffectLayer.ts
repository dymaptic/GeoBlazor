// override generated code in this file
import IFeatureEffectLayerGenerated from './iFeatureEffectLayer.gb';
import FeatureEffectLayer = __esri.FeatureEffectLayer;

export default class IFeatureEffectLayerWrapper extends IFeatureEffectLayerGenerated {

    constructor(layer: FeatureEffectLayer) {
        super(layer);
    }

}

export async function buildJsIFeatureEffectLayer(dotNetObject: any): Promise<any> {
    let {buildJsIFeatureEffectLayerGenerated} = await import('./iFeatureEffectLayer.gb');
    return buildJsIFeatureEffectLayerGenerated(dotNetObject);
}

export async function buildDotNetIFeatureEffectLayer(jsObject: any): Promise<any> {
    let {buildDotNetIFeatureEffectLayerGenerated} = await import('./iFeatureEffectLayer.gb');
    return await buildDotNetIFeatureEffectLayerGenerated(jsObject);
}
