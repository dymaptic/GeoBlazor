// override generated code in this file
import FeatureTableViewModelGenerated from './featureTableViewModel.gb';
import FeatureTableViewModel from '@arcgis/core/widgets/FeatureTable/FeatureTableViewModel';

export default class FeatureTableViewModelWrapper extends FeatureTableViewModelGenerated {

    constructor(component: FeatureTableViewModel) {
        super(component);
    }
    
}

export async function buildJsFeatureTableViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureTableViewModelGenerated } = await import('./featureTableViewModel.gb');
    return await buildJsFeatureTableViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureTableViewModel(jsObject: any): Promise<any> {
    let { buildDotNetFeatureTableViewModelGenerated } = await import('./featureTableViewModel.gb');
    return await buildDotNetFeatureTableViewModelGenerated(jsObject);
}
