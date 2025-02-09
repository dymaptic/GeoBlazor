// override generated code in this file
import FeatureEffectGenerated from './featureEffect.gb';
import FeatureEffect from '@arcgis/core/layers/support/FeatureEffect';

export default class FeatureEffectWrapper extends FeatureEffectGenerated {

    constructor(component: FeatureEffect) {
        super(component);
    }
    
}              
export async function buildJsFeatureEffect(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureEffectGenerated } = await import('./featureEffect.gb');
    return await buildJsFeatureEffectGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetFeatureEffect(jsObject: any): Promise<any> {
    let { buildDotNetFeatureEffectGenerated } = await import('./featureEffect.gb');
    return await buildDotNetFeatureEffectGenerated(jsObject);
}
