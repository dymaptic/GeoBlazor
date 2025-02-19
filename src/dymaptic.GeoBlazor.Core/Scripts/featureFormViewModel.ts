// override generated code in this file
import FeatureFormViewModelGenerated from './featureFormViewModel.gb';
import FeatureFormViewModel from '@arcgis/core/widgets/FeatureForm/FeatureFormViewModel';

export default class FeatureFormViewModelWrapper extends FeatureFormViewModelGenerated {

    constructor(component: FeatureFormViewModel) {
        super(component);
    }
    
}

export async function buildJsFeatureFormViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureFormViewModelGenerated } = await import('./featureFormViewModel.gb');
    return await buildJsFeatureFormViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureFormViewModel(jsObject: any): Promise<any> {
    let { buildDotNetFeatureFormViewModelGenerated } = await import('./featureFormViewModel.gb');
    return await buildDotNetFeatureFormViewModelGenerated(jsObject);
}
