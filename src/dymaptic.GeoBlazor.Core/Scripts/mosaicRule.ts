// override generated code in this file
import MosaicRuleGenerated from './mosaicRule.gb';
import MosaicRule from '@arcgis/core/layers/support/MosaicRule';

export default class MosaicRuleWrapper extends MosaicRuleGenerated {

    constructor(component: MosaicRule) {
        super(component);
    }
    
}              
export async function buildJsMosaicRule(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMosaicRuleGenerated } = await import('./mosaicRule.gb');
    return await buildJsMosaicRuleGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetMosaicRule(jsObject: any): Promise<any> {
    let { buildDotNetMosaicRuleGenerated } = await import('./mosaicRule.gb');
    return await buildDotNetMosaicRuleGenerated(jsObject);
}
