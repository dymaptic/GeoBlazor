// override generated code in this file
import FeaturesViewModelGenerated from './featuresViewModel.gb';
import FeaturesViewModel from '@arcgis/core/widgets/Features/FeaturesViewModel';

export default class FeaturesViewModelWrapper extends FeaturesViewModelGenerated {

    constructor(component: FeaturesViewModel) {
        super(component);
    }
    
}

export async function buildJsFeaturesViewModel(dotNetObject: any): Promise<any> {
    let { buildJsFeaturesViewModelGenerated } = await import('./featuresViewModel.gb');
    return buildJsFeaturesViewModelGenerated(dotNetObject);
}     

export async function buildDotNetFeaturesViewModel(jsObject: any): Promise<any> {
    let { buildDotNetFeaturesViewModelGenerated } = await import('./featuresViewModel.gb');
    return await buildDotNetFeaturesViewModelGenerated(jsObject);
}
