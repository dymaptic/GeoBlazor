// override generated code in this file
import SliderViewModelGenerated from './sliderViewModel.gb';
import SliderViewModel from '@arcgis/core/widgets/Slider/SliderViewModel';

export default class SliderViewModelWrapper extends SliderViewModelGenerated {

    constructor(component: SliderViewModel) {
        super(component);
    }

}

export async function buildJsSliderViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSliderViewModelGenerated} = await import('./sliderViewModel.gb');
    return await buildJsSliderViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSliderViewModel(jsObject: any): Promise<any> {
    let {buildDotNetSliderViewModelGenerated} = await import('./sliderViewModel.gb');
    return await buildDotNetSliderViewModelGenerated(jsObject);
}
