// override generated code in this file
import FeatureLayerBaseGetFieldDomainOptionsGenerated from './featureLayerBaseGetFieldDomainOptions.gb';
import FeatureLayerBaseGetFieldDomainOptions = __esri.FeatureLayerBaseGetFieldDomainOptions;

export default class FeatureLayerBaseGetFieldDomainOptionsWrapper extends FeatureLayerBaseGetFieldDomainOptionsGenerated {

    constructor(component: FeatureLayerBaseGetFieldDomainOptions) {
        super(component);
    }
    
}              
export async function buildJsFeatureLayerBaseGetFieldDomainOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureLayerBaseGetFieldDomainOptionsGenerated } = await import('./featureLayerBaseGetFieldDomainOptions.gb');
    return await buildJsFeatureLayerBaseGetFieldDomainOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetFeatureLayerBaseGetFieldDomainOptions(jsObject: any): Promise<any> {
    let { buildDotNetFeatureLayerBaseGetFieldDomainOptionsGenerated } = await import('./featureLayerBaseGetFieldDomainOptions.gb');
    return await buildDotNetFeatureLayerBaseGetFieldDomainOptionsGenerated(jsObject);
}
