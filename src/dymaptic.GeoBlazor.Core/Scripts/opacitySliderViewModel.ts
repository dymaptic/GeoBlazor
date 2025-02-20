// override generated code in this file
import OpacitySliderViewModelGenerated from './opacitySliderViewModel.gb';
import OpacitySliderViewModel from '@arcgis/core/widgets/smartMapping/OpacitySlider/OpacitySliderViewModel';

export default class OpacitySliderViewModelWrapper extends OpacitySliderViewModelGenerated {

    constructor(component: OpacitySliderViewModel) {
        super(component);
    }

}

export async function buildJsOpacitySliderViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsOpacitySliderViewModelGenerated} = await import('./opacitySliderViewModel.gb');
    return await buildJsOpacitySliderViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetOpacitySliderViewModel(jsObject: any): Promise<any> {
    let {buildDotNetOpacitySliderViewModelGenerated} = await import('./opacitySliderViewModel.gb');
    return await buildDotNetOpacitySliderViewModelGenerated(jsObject);
}
