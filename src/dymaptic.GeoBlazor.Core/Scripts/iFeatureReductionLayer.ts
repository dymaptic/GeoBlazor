// override generated code in this file
import IFeatureReductionLayerGenerated from './iFeatureReductionLayer.gb';
import FeatureReductionLayer = __esri.FeatureReductionLayer;

export default class IFeatureReductionLayerWrapper extends IFeatureReductionLayerGenerated {

    constructor(layer: FeatureReductionLayer) {
        super(layer);
    }
    
}

export async function buildJsIFeatureReductionLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIFeatureReductionLayerGenerated } = await import('./iFeatureReductionLayer.gb');
    return await buildJsIFeatureReductionLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIFeatureReductionLayer(jsObject: any): Promise<any> {
    let { buildDotNetIFeatureReductionLayerGenerated } = await import('./iFeatureReductionLayer.gb');
    return await buildDotNetIFeatureReductionLayerGenerated(jsObject);
}
