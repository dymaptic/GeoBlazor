// override generated code in this file
import FeatureTemplateGenerated from './featureTemplate.gb';
import FeatureTemplate from '@arcgis/core/layers/support/FeatureTemplate';

export default class FeatureTemplateWrapper extends FeatureTemplateGenerated {

    constructor(component: FeatureTemplate) {
        super(component);
    }
    
}              
export async function buildJsFeatureTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureTemplateGenerated } = await import('./featureTemplate.gb');
    return await buildJsFeatureTemplateGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetFeatureTemplate(jsObject: any): Promise<any> {
    let { buildDotNetFeatureTemplateGenerated } = await import('./featureTemplate.gb');
    
    // layerId and viewId not needed to build the prototype graphic in the template
    return await buildDotNetFeatureTemplateGenerated(jsObject, null, null);
}
