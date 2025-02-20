// override generated code in this file
import ColorSliderViewModelGenerated from './colorSliderViewModel.gb';
import ColorSliderViewModel from '@arcgis/core/widgets/smartMapping/ColorSlider/ColorSliderViewModel';

export default class ColorSliderViewModelWrapper extends ColorSliderViewModelGenerated {

    constructor(component: ColorSliderViewModel) {
        super(component);
    }

}

export async function buildJsColorSliderViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorSliderViewModelGenerated} = await import('./colorSliderViewModel.gb');
    return await buildJsColorSliderViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorSliderViewModel(jsObject: any): Promise<any> {
    let {buildDotNetColorSliderViewModelGenerated} = await import('./colorSliderViewModel.gb');
    return await buildDotNetColorSliderViewModelGenerated(jsObject);
}
