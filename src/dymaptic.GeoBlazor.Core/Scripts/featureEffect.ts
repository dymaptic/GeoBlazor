// override generated code in this file
import FeatureEffectGenerated from './featureEffect.gb';
import FeatureEffect from '@arcgis/core/layers/support/FeatureEffect';

export default class FeatureEffectWrapper extends FeatureEffectGenerated {

    constructor(component: FeatureEffect) {
        super(component);
    }
    
}              
export async function buildJsFeatureEffect(dotNetObject: any): Promise<any> {
    let { buildJsFeatureEffectGenerated } = await import('./featureEffect.gb');
    return await buildJsFeatureEffectGenerated(dotNetObject);
}
export async function buildDotNetFeatureEffect(jsObject: any): Promise<any> {
    let { buildDotNetFeatureEffectGenerated } = await import('./featureEffect.gb');
    return await buildDotNetFeatureEffectGenerated(jsObject);
}
