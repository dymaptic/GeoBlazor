// override generated code in this file
import FeatureTemplatesViewModelGenerated from './featureTemplatesViewModel.gb';
import FeatureTemplatesViewModel from '@arcgis/core/widgets/FeatureTemplates/FeatureTemplatesViewModel';

export default class FeatureTemplatesViewModelWrapper extends FeatureTemplatesViewModelGenerated {

    constructor(component: FeatureTemplatesViewModel) {
        super(component);
    }
    
}

export async function buildJsFeatureTemplatesViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureTemplatesViewModelGenerated } = await import('./featureTemplatesViewModel.gb');
    return await buildJsFeatureTemplatesViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureTemplatesViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureTemplatesViewModelGenerated } = await import('./featureTemplatesViewModel.gb');
    return await buildDotNetFeatureTemplatesViewModelGenerated(jsObject, layerId, viewId);
}
