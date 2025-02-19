// override generated code in this file
import IFeatureLayerViewMixinGenerated from './iFeatureLayerViewMixin.gb';
import FeatureLayerViewMixin from '@arcgis/core/views/layers/FeatureLayerViewMixin';

export default class IFeatureLayerViewMixinWrapper extends IFeatureLayerViewMixinGenerated {

    constructor(component: FeatureLayerViewMixin) {
        super(component);
    }
    
}

export async function buildJsIFeatureLayerViewMixin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIFeatureLayerViewMixinGenerated } = await import('./iFeatureLayerViewMixin.gb');
    return await buildJsIFeatureLayerViewMixinGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIFeatureLayerViewMixin(jsObject: any): Promise<any> {
    let { buildDotNetIFeatureLayerViewMixinGenerated } = await import('./iFeatureLayerViewMixin.gb');
    return await buildDotNetIFeatureLayerViewMixinGenerated(jsObject);
}
