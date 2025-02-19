// override generated code in this file
import ColorSizeSliderViewModelGenerated from './colorSizeSliderViewModel.gb';
import ColorSizeSliderViewModel from '@arcgis/core/widgets/smartMapping/ColorSizeSlider/ColorSizeSliderViewModel';

export default class ColorSizeSliderViewModelWrapper extends ColorSizeSliderViewModelGenerated {

    constructor(component: ColorSizeSliderViewModel) {
        super(component);
    }
    
}

export async function buildJsColorSizeSliderViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorSizeSliderViewModelGenerated } = await import('./colorSizeSliderViewModel.gb');
    return await buildJsColorSizeSliderViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorSizeSliderViewModel(jsObject: any): Promise<any> {
    let { buildDotNetColorSizeSliderViewModelGenerated } = await import('./colorSizeSliderViewModel.gb');
    return await buildDotNetColorSizeSliderViewModelGenerated(jsObject);
}
