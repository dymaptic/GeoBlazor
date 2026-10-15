// override generated code in this file
import SizeSliderViewModelGenerated from './sizeSliderViewModel.gb';
import SizeSliderViewModel from '@arcgis/core/widgets/smartMapping/SizeSlider/SizeSliderViewModel';

export default class SizeSliderViewModelWrapper extends SizeSliderViewModelGenerated {

    constructor(component: SizeSliderViewModel) {
        super(component);
    }
    
}

export async function buildJsSizeSliderViewModel(dotNetObject: any): Promise<any> {
    let { buildJsSizeSliderViewModelGenerated } = await import('./sizeSliderViewModel.gb');
    return await buildJsSizeSliderViewModelGenerated(dotNetObject);
}     

export async function buildDotNetSizeSliderViewModel(jsObject: any): Promise<any> {
    let { buildDotNetSizeSliderViewModelGenerated } = await import('./sizeSliderViewModel.gb');
    return await buildDotNetSizeSliderViewModelGenerated(jsObject);
}
