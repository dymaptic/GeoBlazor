import FeatureViewModel from '@arcgis/core/widgets/Feature/FeatureViewModel';
import FeatureViewModelGenerated from './featureViewModel.gb';

export default class FeatureViewModelWrapper extends FeatureViewModelGenerated {

    constructor(component: FeatureViewModel) {
        super(component);
    }
    
}

export async function buildJsFeatureViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureViewModelGenerated } = await import('./featureViewModel.gb');
    return await buildJsFeatureViewModelGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetFeatureViewModel(jsObject: any): Promise<any> {
    let { buildDotNetFeatureViewModelGenerated } = await import('./featureViewModel.gb');
    return await buildDotNetFeatureViewModelGenerated(jsObject);
}
