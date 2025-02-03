// override generated code in this file
import FeatureFilterGenerated from './featureFilter.gb';
import FeatureFilter from '@arcgis/core/layers/support/FeatureFilter';

export default class FeatureFilterWrapper extends FeatureFilterGenerated {

    constructor(component: FeatureFilter) {
        super(component);
    }
    
}              
export async function buildJsFeatureFilter(dotNetObject: any): Promise<any> {
    let { buildJsFeatureFilterGenerated } = await import('./featureFilter.gb');
    return await buildJsFeatureFilterGenerated(dotNetObject);
}
export async function buildDotNetFeatureFilter(jsObject: any): Promise<any> {
    let { buildDotNetFeatureFilterGenerated } = await import('./featureFilter.gb');
    return await buildDotNetFeatureFilterGenerated(jsObject);
}
