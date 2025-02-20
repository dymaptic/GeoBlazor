// override generated code in this file
import SizeSliderViewModelGenerated from './sizeSliderViewModel.gb';
import SizeSliderViewModel from '@arcgis/core/widgets/smartMapping/SizeSlider/SizeSliderViewModel';

export default class SizeSliderViewModelWrapper extends SizeSliderViewModelGenerated {

    constructor(component: SizeSliderViewModel) {
        super(component);
    }

}

export async function buildJsSizeSliderViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSizeSliderViewModelGenerated} = await import('./sizeSliderViewModel.gb');
    return await buildJsSizeSliderViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSizeSliderViewModel(jsObject: any): Promise<any> {
    let {buildDotNetSizeSliderViewModelGenerated} = await import('./sizeSliderViewModel.gb');
    return await buildDotNetSizeSliderViewModelGenerated(jsObject);
}
